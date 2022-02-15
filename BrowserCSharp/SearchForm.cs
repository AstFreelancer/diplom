using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.XPath;

namespace Athelas
{
    public partial class SearchForm : Form
    {
        
        Indexer StemIndexer = new Indexer("stop_ru.dat", "stop_ru_stem.dat", "stop_en.dat");
        ArrayList dbterms = new ArrayList();
        ArrayList termentries = new ArrayList();
        // Constants that we need in the function call
        private const int SHGFI_ICON = 0x100;
        private const int SHGFI_SMALLICON = 0x1;
        private const int SHGFI_LARGEICON = 0x0;

        // This structure will contain information about the file
        public struct SHFILEINFO
        {
            // Handle to the icon representing the file
            public IntPtr hIcon;
            // Index of the icon within the image list
            public int iIcon;
            // Various attributes of the file
            public uint dwAttributes;
            // Path to the file
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;
            // File type
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        // The signature of SHGetFileInfo (located in Shell32.dll)
        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);
        public SearchForm(SqlConnection sc1, Settings appsettings1)
        {
            InitializeComponent();
            dataGridView1.Columns["date"].ValueType = typeof(System.DateTime);
            dataGridView1.Columns["dsize"].ValueType = typeof(System.Int32);
            dataGridView1.Columns["id"].ValueType = typeof(System.Int32);
            dataGridView1.Columns["tcy"].ValueType = typeof(System.Int32);
            dataGridView1.Columns["gpr"].ValueType = typeof(System.Int32);

            dataGridView1.Columns["dsize"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["id"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["tcy"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["gpr"].DefaultCellStyle.Format = "N0";
            
            this.Text = "Поиск";
            sc = sc1;
            myCommand = new SqlCommand();
            myCommand.Connection = sc;

//            StemIndexer = new Indexer("stop_ru.dat", "stop_ru_stem.dat", "stop_en.dat");
            AppSettings = appsettings1;
            cls = new Clusters(AppSettings.maxClusters);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked && InternetChecker.Check() == "Не обнаружено подключения к интернету")
            {
                MessageBox.Show("Невозможно начать поиск, так как компьютер не подключен к интернету", "Диплом",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            dataGridView1.Rows.Clear();
            NumSnippets = 0;
            lbSearchTime.Text = "Выполняется поиск по запросу...";
            lbSearchTime.ForeColor = Color.Red;
            lbSearchTime.Update();
            lbTimeProcessed.Text = "";
            chLBClusters.Items.Clear();

            if (radioButton1.Checked)
                Search();
            else
                YandexSearch();
            button3.Enabled = true;
        }
        
        private void btFilter_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SetClustersChecked();

            //изменить количество страниц, отображаемое внизу
            ArrayList idActiveClusters = new ArrayList();//порядковые номера активных кластеров
            NumSnippets = 0;
            int i = 0;
            foreach (Cluster cl in cls.clusters)
            {
                if (cl.isActive)
                {
                    NumSnippets += cl.points.Count;
                    idActiveClusters.Add(i);
                }
                i++;
            }
            lbFilterSelectedCount.Text = "(выбрано: " + NumSnippets.ToString() + ")";
            lbFilterSelectedCount.Update();

            if (NumSnippets!=0)
                PrintResultsInDataGrid(idActiveClusters);
            else
                dataGridView1.Rows.Clear();
        }
        private void DoClustering()
        {
            AppSettings.Read();
            System.DateTime begintime = System.DateTime.Now;
            int K = AppSettings.maxClusters;
            int k1 = 0;
            if (K < 4)
                k1 = 2;
            else
                k1 = 4;
            ArrayList id_terms = cls.GetAllTermsId(sc);
            ArrayList id_texts = results.GetIdListFound();

            ArrayList points = tfidf.GetTFIDFMatrix(id_texts, id_terms, sc);
            cls = new Clusters(id_texts, id_terms, sc, K, points);
            do
            {
                cls.Clear();
                cls.DoKMeans();
            }
            while (cls.numNotEmptyClusters() < k1);

            cls.delEmptyClusters();

            chLBClusters.Items.Clear();

            for (int i = 0; i < cls.clusters.Count; i++)
            {
                Cluster cl = (Cluster)cls.clusters[i];
                if (cl.isEmpty())
                    continue;

                ArrayList names = new ArrayList();
                string snames = "";
                foreach (Point p in cl.points)
                {
                    results.SetIdCl(p.id_text, i);//сниппету id_text присвоить номер кластера i
                    string name = results.GetNameById(p.id_text);
                    names.Add(name);
                    snames += name+" ";
                }

                Hashtable hash = Indexer.GetTerms(snames);
                hash.Remove(0);

                ArrayList values = new ArrayList(hash.Values);
                values.Sort(); values.Reverse();

                ArrayList maxvalues = new ArrayList();
                foreach (int v in values)
                    if (v > 1)
                        maxvalues.Add(v);

                if (maxvalues.Count < 1)
                {
                    maxvalues = new ArrayList(values);
                }

                if (maxvalues.Count > 3)
                    maxvalues.RemoveRange(3, maxvalues.Count - 3);

                string keyterm = "";
                int c = 0;
                foreach (DictionaryEntry de in hash)
                {
                    if (maxvalues.Contains((int)de.Value))
                    {
                        c++;
                        string word = (string)de.Key;
                        word = GetNF(word);
                        keyterm += word + " ";
                        if (c >= 4)
                            break;
                    }
                }

                chLBClusters.Items.Add(keyterm + " (" + cl.points.Count.ToString() + ")", true);
            }

            System.DateTime endtime = System.DateTime.Now;
            System.TimeSpan delta = endtime - begintime;
            lbTimeProcessed.Text = "Кластеризация выполнена за " + delta.TotalSeconds.ToString() + " с";
            lbTimeProcessed.Visible = true;
            lbTimeProcessed.ForeColor = Color.Black;
            lbFilterSelectedCount.Text = "(выбрано: " + results.res.Count.ToString() + ")";
            lbFilterSelectedCount.Update();
            btFilter.Enabled = true;
        }
        private void Search()
        {
            AppSettings.Read();
            dataGridView1.Rows.Clear();
            dataGridView1.Update();
            chLBClusters.Items.Clear();
            chLBClusters.Update();
            System.DateTime begintime = System.DateTime.Now;
            ArrayList list = Indexer.Search(tbSearch.Text, sc);
            System.DateTime endtime = System.DateTime.Now;

            TimeSpan delta = endtime - begintime;

            this.Text = "Поиск: " + tbSearch.Text;

            results = new Results();

            lbSearchTime.Text = "Запрос выполнен за " + delta.TotalSeconds.ToString() + " с";
            lbSearchTime.ForeColor = Color.Black;
            lbSearchTime.Update();

            foreach (int id in list)
            {
                myCommand.CommandText = "select docs.name,docs.url,docs.docsize,docs.tcy,docs.gpr,docs.docdate from docs" +
                    " where id=" + id.ToString();
                SqlDataReader reader = myCommand.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    continue;
                }
                Snippet r = new Snippet(id, reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3),
                    reader.GetInt32(4),reader.GetDateTime(5),-1);
                results.Add(r);
                reader.Close();
            }
            NumSnippets = results.res.Count;

            ArrayList idActiveClusters = new ArrayList();//порядковые номера активных кластеров
            lbSearchTime.Text += ", найдено документов " + results.res.Count.ToString();
            lbSearchTime.Update();
            
            PrintResultsInDataGrid(idActiveClusters);
        }

        private void PrintResultsInDataGrid(ArrayList idActiveClusters)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(NumSnippets);
            int k = 0;
            foreach (Snippet snip in results.res)
            {
                if (idActiveClusters.Count > 0)
                {
                    if (!idActiveClusters.Contains(snip.idcl))
                        continue;
                }

                DataGridViewTextBoxCell snipid = new DataGridViewTextBoxCell();
                snipid.Value = k + 1;
                dataGridView1.Rows[k].Cells["id"] = snipid;

                DataGridViewLinkCell snipname = new DataGridViewLinkCell();
                snipname.Value = snip.docname;
                dataGridView1.Rows[k].Cells["Docname"] = snipname;

                DataGridViewTextBoxCell snipsize = new DataGridViewTextBoxCell();
                snipsize.Value = snip.docsize;
                dataGridView1.Rows[k].Cells["Dsize"] = snipsize;

                DataGridViewTextBoxCell snipurl = new DataGridViewTextBoxCell();
                snipurl.Value = snip.url;
                dataGridView1.Rows[k].Cells["Url"] = snipurl;

                DataGridViewTextBoxCell sniptcy = new DataGridViewTextBoxCell();
                sniptcy.Value = snip.tcy;
                dataGridView1.Rows[k].Cells["TCY"] = sniptcy;

                DataGridViewTextBoxCell snipgpr = new DataGridViewTextBoxCell();
                snipgpr.Value = snip.gpr;
                dataGridView1.Rows[k].Cells["GPR"] = snipgpr;

                string ext = "";
                DataGridViewTextBoxCell snipext = new DataGridViewTextBoxCell();
                if (snip.url.StartsWith("http://"))
                    snipext.Value = "html";
                else
                {
                    ext=Path.GetExtension(snip.url);
                    snipext.Value = ext;
                }
                dataGridView1.Rows[k].Cells["ext"] = snipext;

                DataGridViewImageCell snipimg = new DataGridViewImageCell();

                if (snip.url.StartsWith("http://"))
                {
                    Image img = Bitmap.FromFile(Application.StartupPath + "\\htm.gif");
                    snipimg.Value = img;
                    dataGridView1.Rows[k].Cells["Img"] = snipimg;
                }
                
                else
                {
                    string filename = "doc.gif";
                    if (ext == ".ppt")
                        filename = "ppt.gif";
                    if (ext == ".xls")
                        filename = "xls.gif";
                    if (ext == ".txt")
                        filename = "txt.gif";
                    if (ext == ".htm")
                        filename = "htm.gif";

                    Image img = Bitmap.FromFile(Application.StartupPath + "\\"+filename);
                    snipimg.Value = img;
                    dataGridView1.Rows[k].Cells["Img"] = snipimg;

                    //System.Drawing.Icon fileicon;
                    //IntPtr hImgSmall;
                    ////IntPtr hImgLarge;
                    //SHFILEINFO shinfo = new SHFILEINFO();
                    //hImgSmall = SHGetFileInfo(snip.url, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
                    //fileicon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
                    ////picIconSmall.Image = fileicon.ToBitmap();
                    ////hImgLarge = SHGetFileInfo(snip.url, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
                    ////fileicon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
                    ////picIconLarge.Image = fileicon.ToBitmap();
                    //snipimg.Value = fileicon.ToBitmap();
                    //dataGridView1.Rows[k].Cells["Img"] = snipimg;
                }
                //snipimg.ValueIsIcon = true;

                DataGridViewTextBoxCell snipdate = new DataGridViewTextBoxCell();
                snipdate.Value = snip.date;
                dataGridView1.Rows[k].Cells["Date"] = snipdate;

                k++;
            }
            dataGridView1.Update();
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btSearch_Click(sender, e);
                //Search();
                //DoClustering();
            }
        }

        private void SearchForm_Activated(object sender, EventArgs e)
        {
            AppSettings.Read();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            string url = dataGridView1.Rows[e.RowIndex].Cells["url"].Value.ToString();
            if (url == "")
                return;
            System.Diagnostics.Process.Start(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName, false);
                writer.WriteLine(tbSearch.Text);//текст запроса
                writer.WriteLine(cls.clusters.Count.ToString());//число кластеров
                int i = 0;
                foreach (Cluster cl in cls.clusters)
                {
                    writer.WriteLine(cl.isActive.ToString());//активный ли
                    writer.WriteLine(chLBClusters.Items[i].ToString());//название
                    writer.WriteLine(cl.points.Count);//число точек
                    foreach (Point p in cl.points)
                        writer.WriteLine(p.id_text.ToString());//код документа
                    i++;
                }
                writer.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chLBClusters.Items.Clear();
                StreamReader reader = new StreamReader(openFileDialog1.FileName);
                tbSearch.Text=reader.ReadLine();//текст запроса
                Search();
                int cluster_count = int.Parse(reader.ReadLine());//число кластеров
                cls = new Clusters(cluster_count);
                for (int i = 0; i < cluster_count; i++)
                {
                    Cluster new_cluster = new Cluster();
                    new_cluster.isActive = bool.Parse(reader.ReadLine());//активный ли
                    chLBClusters.Items.Add(reader.ReadLine());//название
                    chLBClusters.SetItemChecked(i, new_cluster.isActive);
                    int point_count = int.Parse(reader.ReadLine());//число точек
                    new_cluster.points = new ArrayList();
                    for (int j = 0; j < point_count; j++)
                    {
                        Point p = new Point();
                        p.id_text=int.Parse(reader.ReadLine());//код документа
                        new_cluster.points.Add(p);
                        foreach (Snippet snip in results.res)
                        {
                            if (snip.id == p.id_text)
                                snip.idcl = i;
                        }
                    }
                    cls.Add(new_cluster);
                }
                reader.Close();
                btFilter.Enabled = true;
                btFilter_Click(sender, e);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                checkBox1.Enabled = true;
                numericUpDown1.Enabled = true;
                label2.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = false;
                numericUpDown1.Enabled = false;
                label2.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
        DateTime GetTime(string t)
        {
            string s = t.Substring(0, 4) + "-" + t.Substring(4, 2) + "-" + t.Substring(6, 2) + " " + t.Substring(8, 3) + ":" + t.Substring(11, 2) + ":" + t.Substring(13, 2);
            DateTime time = DateTime.Parse(s);
            return time;
        }

        private string GetOnlyLetters(string title)
        {
            string result = title;
            result = result.Replace("<hlword priority=\"strict\">", " ");
            result = result.Replace("</hlword>", " ");
            result = result.Replace('\r', ' ');
            result = result.Replace('\n', ' ');
            result = result.Replace('\t', ' ');
            result = result.Replace("   ", " ");
            result = result.Replace("  ", " ");
            return result.Trim();
        }

        private void YandexSearch()
        {
            AppSettings.Read();
            dataGridView1.Rows.Clear();
            chLBClusters.Items.Clear();
            System.DateTime begintime = System.DateTime.Now;
            results=new Results();
            
            if (InternetChecker.Check() == "Не обнаружено подключения к интернету")
            {
                MessageBox.Show("Невозможно найти данные, так как компьютер не подключен к интернету", "Диплом",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                lbSearchTime.Text = "Поиск не выполнен";
                lbSearchTime.ForeColor = Color.Black;
                return;
            }

            try
            {
                System.Net.WebRequest req =
                    System.Net.WebRequest.Create("http://xmlsearch.yandex.ru/xmlsearch?query=" + tbSearch.Text);
                System.Net.WebResponse resp = req.GetResponse();

                System.IO.Stream stream = resp.GetResponseStream();

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(stream);
                stream.Close();
                resp.Close();
                
                XmlNodeList list = xDoc.SelectNodes("//doc");

                XmlNodeList founds = xDoc.GetElementsByTagName("found");
                int N = 0;
                foreach (XmlElement found in founds)
                    if (found.GetAttribute("priority") == "all")
                    {
                        N = int.Parse(found.InnerText);
                        break;
                    }
                if (N > (int)numericUpDown1.Value)
                    N = (int)numericUpDown1.Value;

                int i = 0;
                foreach (XmlNode node in list)
                {
                    N--;
                    string text = "";
                    XmlNodeList passages = node.SelectNodes(".//passage");
                    foreach (XmlNode n in passages)
                        text += GetOnlyLetters(n.InnerXml) + " ";

                    string u = ""; XmlNode url = node.SelectSingleNode(".//url");
                    if (url != null)
                        u = url.InnerText;
                    else
                        continue;//без url смысла не имеет
                    string t = ""; XmlNode title = node.SelectSingleNode(".//title");
                    if (title != null)
                        t = GetOnlyLetters(title.InnerXml);
                    else
                        t = url.InnerText;
                    XmlNode size = node.SelectSingleNode(".//size");
                    int s = 0; if (size != null) s = int.Parse(size.InnerText);

                    DateTime time = DateTime.Now; XmlNode modtime = node.SelectSingleNode(".//modtime");
                    if (modtime != null)
                        time = GetTime(modtime.InnerText);

                    int tcy = PageRank.GetYandexTCY(url.InnerText);
                    int gpr = PageRank.GetGooglePageRank(url.InnerText);
                    Snippet r = new Snippet(i++, t, u, s, tcy, gpr, time, -1);
                    r.text = text;
                    results.Add(r);
                }

                int page = 1;
                while (N > 0)
                {
                    page++;
                    req =
                        System.Net.WebRequest.Create("http://xmlsearch.yandex.ru/xmlsearch?query=" +
                                                                    tbSearch.Text + "&page=" + page.ToString());
                    resp = req.GetResponse();
                    stream = resp.GetResponseStream();
                    xDoc = new XmlDocument();
                    xDoc.Load(stream);

                    stream.Close();
                    resp.Close();
                    list = xDoc.SelectNodes("//doc");
                    foreach (XmlNode node in list)
                    {
                        string text = "";
                        XmlNodeList passages = node.SelectNodes(".//passage");
                        foreach (XmlNode n in passages)
                            text += GetOnlyLetters(n.InnerXml)+" ";

                        string u = ""; XmlNode url = node.SelectSingleNode(".//url");
                        if (url != null)
                            u = url.InnerText;
                        else
                            continue;//без url смысла не имеет
                        string t = ""; XmlNode title = node.SelectSingleNode(".//title");
                        if (title != null)
                            t = GetOnlyLetters(title.InnerXml);
                        else
                            t = url.InnerText;
                        XmlNode size = node.SelectSingleNode(".//size");
                        int s = 0; if (size != null) s = int.Parse(size.InnerText);

                        DateTime time = DateTime.Now; XmlNode modtime = node.SelectSingleNode(".//modtime");
                        if (modtime != null)
                            time = GetTime(modtime.InnerText);
                        N--;

                        int tcy = PageRank.GetYandexTCY(url.InnerText);
                        int gpr = PageRank.GetGooglePageRank(url.InnerText);
                        Snippet r = new Snippet(i++, t, u, s, tcy, gpr, time, -1);
                        r.text = text;
                        results.Add(r);

                        if (N < 1)
                            break;
                    }
                }
            }

            catch (System.ArgumentNullException) { return; }
            catch (System.NotImplementedException) { return; }
            catch (System.Security.SecurityException) { return; }
            catch (System.Net.WebException) {
                MessageBox.Show("Невозможно найти данные, так как компьютер не подключен к интернету", "Диплом",
    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                            
           

            //ArrayList list = Indexer.Search(tbSearch.Text, sc);
            System.DateTime endtime = System.DateTime.Now;

            TimeSpan delta = endtime - begintime;

            this.Text = "Поиск: " + tbSearch.Text;

            lbSearchTime.Text = "Запрос выполнен за " + delta.TotalSeconds.ToString() + " с";
            lbSearchTime.ForeColor = Color.Black;
            lbSearchTime.Update();

            NumSnippets = results.res.Count;

            ArrayList idActiveClusters = new ArrayList();//порядковые номера активных кластеров
            lbSearchTime.Text += ", найдено документов " + results.res.Count.ToString();
            lbSearchTime.Update();

            PrintResultsInDataGrid(idActiveClusters);
        }

        public void DoKMeansInMemory(int K,ArrayList points)
        {
            int ntexts = results.res.Count;
            int nterms = dbterms.Count;

            int i, j;

            //найдем макс. знач. каждой из координат
            cls.maxCoord = new Point();

            for (i = 0; i < nterms; i++)
            {
                double max = 0;
                for (j = 0; j < ntexts; j++)
                {
                    double tf_idf = (double)((Point)points[j]).coord[i];
                    if (tf_idf > max)
                        max = tf_idf;
                }
                cls.maxCoord.coord.Add(max);
            }

            //случайным образом генерируем k центроидов кластеров
            Random rand = new Random(DateTime.Now.Millisecond);
            for (i = 0; i < K; i++)
            {
                Cluster cl = new Cluster();
                Point tmpP = new Point();
                for (j = 0; j < nterms; j++)
                {
                    double coord = rand.NextDouble() * ((double)cls.maxCoord.coord[j]);
                    tmpP.coord.Add(coord);
                }
                cl.SetAvgPoint(tmpP);
                cls.Add(cl);
            }

            //соотнести точки с ближайшим центром
            //перевычислить центры
            for (int a = 0; a < 20; a++)
            {
                cls.ReInit();

                foreach (Point pnt in points)
                {
                    int id_best_cl = 0;
                    Cluster bestcluster = cls.GetCluster(id_best_cl);
                    double bestdist = bestcluster.avgPoint.GetDistance(pnt);

                    for (i = 1; i < cls.clusters.Count; i++)
                    {
                        Cluster cluster = cls.GetCluster(i);
                        double newdist = cluster.avgPoint.GetDistance(pnt);
                        if (newdist < bestdist)
                        {
                            id_best_cl = i;
                            bestdist = newdist;
                        }
                    }
                    cls.AddPoint(pnt, id_best_cl);//добавить точку к ближайшему кластеру
                }
                //перевычислить центры
                cls.Recalculate(cls.maxCoord);
            }
        }    

        private void DoClusteringInMemory()
        {
            AppSettings.Read();
            System.DateTime begintime = System.DateTime.Now;
            int K = AppSettings.maxClusters;
            int k1 = 0;
            if (K < 4)
                k1 = 2;
            else
                k1 = 4;

            ArrayList points = GetTFIDFMatrix();
            do
            {
                cls = new Clusters(K);
                DoKMeansInMemory(K,points);
            }
            while (cls.numNotEmptyClusters() < k1);
            cls.delEmptyClusters();

            chLBClusters.Items.Clear();

            for (int i = 0; i < cls.clusters.Count; i++)
            {
                Cluster cl = (Cluster)cls.clusters[i];
                if (cl.isEmpty())
                    continue;

                ArrayList names = new ArrayList();
                string snames = "";
                foreach (Point p in cl.points)
                {
                    results.SetIdCl(p.id_text, i);//сниппету id_text присвоить номер кластера i
                    string name = results.GetNameById(p.id_text);
                    names.Add(name);
                    snames += name;
                }

                Hashtable hash = Indexer.GetTerms(snames);
                hash.Remove(0);

                ArrayList values = new ArrayList(hash.Values);
                values.Sort(); values.Reverse();

                ArrayList maxvalues = new ArrayList();
                foreach (int v in values)
                    if (v > 1)
                        maxvalues.Add(v);

                if (maxvalues.Count < 1)
                {
                    maxvalues = new ArrayList(values);
                }

                if (maxvalues.Count > 3)
                    maxvalues.RemoveRange(3, maxvalues.Count - 3);

                string keyterm = "";
                int c = 0;
                foreach (DictionaryEntry de in hash)
                {
                    if (maxvalues.Contains((int)de.Value))
                    {
                        c++;
                        string word = (string)de.Key;
                        if (sc.State == ConnectionState.Open)
                            word = GetNF(word);
                        keyterm += word + " ";
                        if (c >= 4)
                            break;
                    }
                }

                chLBClusters.Items.Add(keyterm + " (" + cl.points.Count.ToString() + ")", true);
            }

            System.DateTime endtime = System.DateTime.Now;
            System.TimeSpan delta = endtime - begintime;
            lbTimeProcessed.Text = "Кластеризация выполнена за " + delta.TotalSeconds.ToString() + " с";
            lbTimeProcessed.Visible = true;
            lbTimeProcessed.ForeColor = Color.Black;
            lbTimeProcessed.Update();
            lbFilterSelectedCount.Text = "(выбрано: " + results.res.Count.ToString() + ")";
            lbFilterSelectedCount.Update();
            btFilter.Enabled = true;
        }

        private string GetNF(string word)
        {
            if (word == "миха")
                return "михаил";
            if (word == "васнец" || word == "нестер")
                return word + "ов";
            if (word == "студ")
                return "студия";
            if (word == "виктор")
                return word;
            if (word == "кров")
                return "кровь";
            if (word == "ита")
                return "итал";
            return Indexer.GetNF(word, sc);
        }

        private void DoYandexIndex()
        {
            dbterms = new ArrayList();
            termentries = new ArrayList();
            foreach (Snippet snip in results.res)
            {
                Hashtable terms = Indexer.GetTerms(snip.text);
                int termsNumber = (int)terms[0];
                terms.Remove(0);
                ArrayList termlist = new ArrayList(terms.Keys);
                for (int i = 0; i < termlist.Count; i++)
                {
                    string termName = (string)termlist[i];
                    bool isFound = false;
                    int pos = -1;
                    foreach (DBTerm dbt in dbterms)
                    {
                        pos++;
                        if (dbt.Name == termName)
                        {
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        int isRus;
                        if (isRusWord(termName))
                            isRus = 1;
                        else
                            isRus = 0;
                        DBTerm dbt = new DBTerm(dbterms.Count, termName, 1, isRus);
                        pos = dbterms.Count;
                        dbterms.Add(dbt);
                    }
                    else
                    {
                        ((DBTerm)dbterms[pos]).TextsNumber++;
                    }
                    TermEntry te = new TermEntry(snip.id,pos,(int)terms[termName]);
                    termentries.Add(te);
                }
                snip.termsnumber= termsNumber;       
            }//foreach Snippet snip
        }
        //число вхождений слова в документ
        public int GetNi(int id_term, int id_text)
        {
            foreach (TermEntry te in termentries)
            {
                if (te.id_term == id_term && te.id_text == id_text)
                    return te.EntriesNumber;
            }
            return 0;
        }

        //число слов в документе
        public int GetSumN(int id_text)
        {
            foreach (Snippet snip in results.res)
                if (snip.id == id_text)
                    return snip.termsnumber;
            return 0;
        }

        public double TF(int id_term, int id_text)
        {
            int Ni = GetNi(id_term, id_text);
            int SumN = GetSumN(id_text);
            if (SumN == 0)
                return 0;
            return (double)Ni / (double)SumN;
        }

        public double GetDiTi(int id_term)
        {
            int result = 0;
            foreach (TermEntry te in termentries)
            {
                if (te.id_term == id_term)
                    result++;
            }
            return (double)result;
        }
        public double IDF(double D, int id_term)
        {
            double DiTi = GetDiTi(id_term);
            if (DiTi == 0)
                return 0;
            return (double)Math.Log(D / DiTi,2);
        }
        public int GetD()
        {
            return results.res.Count;
        }

        public ArrayList GetTFIDFMatrix()
        {
            int ntexts = results.res.Count;
            int nterms = dbterms.Count;

            ArrayList points = new ArrayList();

            for (int i = 0; i < ntexts; i++)
            {
                ArrayList coord = new ArrayList();
                for (int j = 0; j < nterms; j++)
                {
                    coord.Add(0.0);
                }
                Point p = new Point(coord, i);
                points.Add(p);
            }
            foreach (TermEntry te in termentries)
            {
                double tf = TF(te.id_term,te.id_text);
                double idf = IDF((double)GetD(),te.id_term);
                ((Point)points[te.id_text]).coord[te.id_term] = tf * idf;
            }

            return points;
        }
        public static bool isRusWord(string word)
        {
            if (word == "")
                return true;
            string ending = word.Substring(word.Length - 1, 1);
            string RusLetters = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            if (RusLetters.Contains(ending))
                return true;
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isReprint = false;
            if (NumSnippets != results.res.Count)
            {
                isReprint = true;
                NumSnippets = results.res.Count;
            }
            ArrayList idActiveClusters = new ArrayList();
            if (isReprint)
                PrintResultsInDataGrid(idActiveClusters);
            lbTimeProcessed.Text = "Выполняется кластеризация результатов...";
            lbTimeProcessed.ForeColor = Color.Red;
            lbTimeProcessed.Visible = true;
            lbTimeProcessed.Update();
            chLBClusters.Items.Clear();
            lbFilterSelectedCount.Text = "";
            if (radioButton1.Checked)
            {
                DoClustering();
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                try
                {
                    DoYandexIndex();
                    DoClusteringInMemory();
                    button1.Enabled = false;
                    button2.Enabled = false;
                }
                catch (System.Net.WebException exc)
                {
                    MessageBox.Show(exc.Message,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void SetClustersChecked()
        {
            int i;
            //изменить активные-неактивные кластеры  в соответствии с check
            for (i = 0; i < chLBClusters.Items.Count; i++)
            {
                if (chLBClusters.GetItemChecked(i))
                    cls.SetActive(i, true);
                else
                    cls.SetActive(i, false);
            }
        }
    }
}