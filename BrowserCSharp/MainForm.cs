using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

using System.Text.RegularExpressions;

using Shell32;

using System.Xml;

namespace Athelas
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            StemIndexer = new Indexer("stop_ru.dat", "stop_ru_stem.dat", "stop_en.dat");

            CurrentFileName = "";
            isFileChanged = false;
            isStop = false;

            string check = CheckFiles();

            if (check != "")
            {
                MessageBox.Show("Не найдены следующие файлы: " + check,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            AppSettings = new Settings();

            создатьКоллекциюToolStripMenuItem_Click(this, null);
            try
            {
                sc = new SqlConnection(AppSettings.connectionstring);
                myCommand = new SqlCommand();
                myCommand.Connection = sc;
                myCommand.Connection.Open();         
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                MessageBox.Show(e.Message, "Ошибка соединения с базой", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (System.InvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Ошибка соединения с базой", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DownloadFromDBUnindexed();
        }

        private string GetEndingZap(int count_zap)
        {
            if (count_zap.ToString().EndsWith("1"))
                return "и";
            return "ей";
        }

        private void UpdateGooglePR()
        {
            if (InternetChecker.Check() == "Не обнаружено подключения к интернету")
            {
                MessageBox.Show("Невозможно обновить данные, так как компьютер не подключен к интернету","Диплом",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            SetQuery("select url,id from docs");

            Hashtable hash = new Hashtable();
            SqlDataReader r = myCommand.ExecuteReader();
            while (r.Read())
                hash[r.GetInt32(1)] = r.GetString(0);
            r.Close();

            int count = 0;
            foreach (DictionaryEntry de in hash)
            {
                int gpr = 0;
                if (de.Value.ToString().StartsWith("http://"))
                {
                    gpr = PageRank.GetGooglePageRank(de.Value.ToString());
                    count++;
                }
                SetAndExecuteQuery("update docs set gpr=" + gpr.ToString() + " where id=" + de.Key.ToString());
            }
            MessageBox.Show("Google PR обновлен для "+count.ToString()+" запис"+GetEndingZap(count),"Обновление",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void UpdateYandexTCY()
        {
            if (InternetChecker.Check() == "Не обнаружено подключения к интернету")
            {
                MessageBox.Show("Невозможно обновить данные, так как компьютер не подключен к интернету", "Диплом",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            SetQuery("select url,id from docs");

            Hashtable hash = new Hashtable();
            SqlDataReader r = myCommand.ExecuteReader();
            while (r.Read())
                hash[r.GetInt32(1)] = r.GetString(0);
            r.Close();

            int count = 0;
            foreach (DictionaryEntry de in hash)
            {
                int tcy = 0;
                if (de.Value.ToString().StartsWith("http://"))
                {
                    tcy = PageRank.GetYandexTCY(de.Value.ToString());
                    count++;
                }
                SetAndExecuteQuery("update docs set tcy=" + tcy.ToString() + " where id=" + de.Key.ToString());
            }
            MessageBox.Show("Yandex ТИЦ обновлен для " + count.ToString() + " запис" + GetEndingZap(count), "Обновление",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string check = InternetChecker.Check();
            if (check.Contains("("))
                check=check.Substring(0,check.IndexOf("("));
            toolStripStatusLabel1.Text = check;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFileChanged)
            {
                if (MessageBox.Show("Файл " + CurrentFileName + " был изменен. Сохранить?", "Сохранение", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    сохранитьToolStripMenuItem_Click(sender, e);
            }
            else
                if (CurrentFileName=="" && !isFileChanged && lbClt.Items.Count>0)
                    if (MessageBox.Show("Сохранить найденные гиперссылки в файл?", "Сохранение", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                        сохранитьToolStripMenuItem_Click(sender, e);

            myCommand.Connection.Close();
        }

        private void опцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm of = new OptionsForm();
            of.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите стереть все данные из базы?", "Подтверждение", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                myCommand.CommandText = "delete from terms";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "delete from termentries";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "delete from docs";
                myCommand.ExecuteNonQuery();

                MessageBox.Show("Вcе данные стерты","Сообщение",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private string CheckFiles()
        {
            string nofiles = "";
            string path = Application.StartupPath + "\\";
            if (!File.Exists(path+"config.ini"))
                nofiles += "config.ini\n";
            if (!File.Exists(path+"stop_ru.dat"))
                nofiles += "stop_ru.dat\n";
            if (!File.Exists(path+"stop_en.dat"))
                nofiles += "stop_en.dat\n";
            if (!File.Exists(path+"stop_ru_stem.dat"))
                nofiles += "stop_ru_stem.dat";
            return nofiles;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }



        private void опцииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OptionsForm of = new OptionsForm();
            of.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show();
        }


        private void обходToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void создатьКоллекциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFileChanged)
            {
                if (MessageBox.Show("Файл " + CurrentFileName + " был изменен. Сохранить?", "Сохранение", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    сохранитьToolStripMenuItem_Click(sender, e);
            }
            CreateCollection();
        }

        private void CreateCollection()
        {
            lbClt.Visible = true;
            toolStripStatusLabel1.Text = "Новая коллекция";
            lbClt.Items.Clear();
            doListCLTCount();
            isFileChanged = false;
        }

        private void открытьКоллекциюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFileChanged)
            {
                if (MessageBox.Show("Файл " + CurrentFileName + " был изменен. Сохранить?", "Сохранение", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    сохранитьToolStripMenuItem_Click(sender, e);
            }
            OpenCollection();
        }

        private void OpenCollection()
        {
            if (openCltDialog.ShowDialog() == DialogResult.OK)
            {
                lbClt.Visible = true;
                CurrentFileName = openCltDialog.FileName;
                toolStripStatusLabel1.Text = CurrentFileName;
                
                lbClt.Items.Clear();
                StreamReader FS = new StreamReader(CurrentFileName);
                while (!FS.EndOfStream)
                    lbClt.Items.Add(FS.ReadLine());
                FS.Close();
                lbClt.Update();
                doListCLTCount();
                isFileChanged = false;
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCollectionAs();
        }

        private void SaveCollectionAs()
        {
            if (saveCltDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentFileName = saveCltDialog.FileName;
                SaveCollection();
                toolStripStatusLabel1.Text = CurrentFileName;
            }
        }

        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            AppSettings.Read();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFileName == "")
                SaveCollectionAs();
            else
                SaveCollection();
        }

        private void SaveCollection()
        {
            if (CurrentFileName == "")
                SaveCollectionAs();
            else
            {
                StreamWriter FS = new StreamWriter(CurrentFileName, false);
                foreach (string url in lbClt.Items)
                    FS.WriteLine(url);
                FS.Close();
                isFileChanged = false;
            }
        }
        private void btAddManyAddr_Click(object sender, EventArgs e)
        {

        }

        private void AddUrlToCltList(string url)
        {
            if (lbClt.Items.Contains(url))
            {
                MessageBox.Show(url + ": такой адрес уже есть в коллекции", "Повтор",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (url.Contains("'"))
            {
                url = url.Replace('\'', '*');
            }

            lbClt.Items.Add(url);
            tbAddress_Sp.Text = "";
            doListCLTCount();
            lbClt.Update();
            isFileChanged = true;
        }

        private void AddUrlToDBList(string url,bool isRobot)
        {
            if (lbDB.Items.Contains(url))
            {
                if (isRobot)
                {
                    lbReport.Items.Add(url + ": такой адрес уже есть в коллекции");
                    return;
                }
                MessageBox.Show(url + ": такой адрес уже есть в коллекции", "Повтор",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (url.Contains("'"))
            {
                url=url.Replace('\'','*');
            }

            //и в базу
            SetQuery("select id from docs where url='" + url + "'");
            SqlDataReader r = myCommand.ExecuteReader();
            bool t = false;
            if (r.HasRows)
                t=true;
            r.Close();
            if (t)
                MessageBox.Show(url + ": уже есть в базе", "Ошибка добавления",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                AddToDB(url);
                lbDB.Items.Add(url);
            }
            doListDBCount();
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void doListCLTCount()
        {
            int ct = lbClt.Items.Count;
            lbCltCount.Text = ct.ToString() + " адрес" + getEnding(ct);
        }
        private void doListDBCount()
        {
            int ct = lbDB.Items.Count;
            lbDBCount.Text = ct.ToString() + " адрес" + getEnding(ct);
        }
        private string getEnding(int count)
        {
            int c = count % 100;
            if (c > 10 && c < 15)
                return "ов";
            switch (c % 10)
            {
                case 1: return "";
                case 2:
                case 3:
                case 4: return "а";
                default: return "ов";
            }
        }
        private void DeleteUrl()
        {
            ArrayList urls_to_delete = new ArrayList();
            foreach (string url in lbClt.SelectedItems)
            {
                urls_to_delete.Add(url);
            }
            foreach (string url1 in urls_to_delete)
                lbClt.Items.Remove(url1);
            lbClt.Update();
            doListCLTCount();
            isFileChanged = true;
        }

        private void btDel_Click(object sender, EventArgs e)
        {
        }

        void SortFile(string old, string nnew)
        {
            StreamReader r = new StreamReader(old);
            StreamWriter w = new StreamWriter(nnew, false);
            ArrayList list = new ArrayList();
            while (!r.EndOfStream)
                list.Add(r.ReadLine());
            r.Close();
            list.Sort();
            foreach (string str in list)
                w.WriteLine(str);
            w.Close();
        }
        
        void SetQuery(string q)
        {
            myCommand.CommandText = q;
        }

        void SetAndExecuteQuery(string q)
        {
            myCommand.CommandText = q;
            myCommand.ExecuteNonQuery();
        }

        private void AddToDB(String url)
        {
            if (url.Length > 255)
                url = url.Substring(0, 255);
            SetAndExecuteQuery("INSERT INTO docs(url) values('" + url + "');");
        }

        private void DelFromDB(String url)
        {
            SetAndExecuteQuery("DELETE FROM docs where url='" + url + "';");
        }

        private void DownloadFromDBUnindexed()
        {
            lbDB.Items.Clear();
            //загрузить из БД неиндексированное
            SetQuery("SELECT url FROM docs WHERE indexed=0;");
            SqlDataReader r = myCommand.ExecuteReader();
            while (r.Read())
                lbDB.Items.Add(r.GetValue(0).ToString());
            doListDBCount();
            r.Close();
        }

        private void ListToDB()
        {
            foreach (String s in lbClt.Items)
                AddToDB(s);
            lbClt.Items.Clear();
        }
        private void DelNotUnique()
        {
            SetQuery("select url,id from docs");
            SqlDataReader r = myCommand.ExecuteReader();
            Hashtable docs = new Hashtable();
            ArrayList toDelete = new ArrayList();
            while (r.Read())
            {
                string url = r.GetValue(0).ToString();//url
                int id = int.Parse(r.GetValue(1).ToString());
                if (!docs.ContainsKey(url))
                {
                    docs.Add(url, id);
                }
                else
                    toDelete.Add(id);

            }
            r.Close();

            foreach (int i in toDelete)
                SetAndExecuteQuery("delete from docs where id=" + i.ToString() + ";");

            MessageBox.Show(toDelete.Count.ToString(),"Удалено",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(sc,AppSettings);
            sf.Show();
        }


        private void btFolder_Click(object sender, EventArgs e)
        {
        }
        private void SearchInFolder(Folder folder, Regex filePathPattern, bool searchSubFolders)
        {
            foreach (FolderItem item in folder.Items())
            {
                if (item.IsLink)
                    continue;

                if (item.IsFolder && searchSubFolders && !item.Name.EndsWith(".zip"))
                {
                    SearchInFolder((Folder)item.GetFolder,filePathPattern, searchSubFolders);
                    continue;
                }

                if (filePathPattern.IsMatch(item.Path))
                {
                    AddUrlToCltList(item.Path);
                }
            }
        }

        private void стопсловаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopForm sf = new StopForm();
            sf.Show();
        }

        private void btToStart_Sp_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void базаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void обновитьЯндексТИЦToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateYandexTCY();
        }

        private void обновитьGooglePRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateGooglePR();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OptionsForm of = new OptionsForm();
            of.Show();
        }

        private void CheckConnection()
        {
            MessageBox.Show(InternetChecker.Check(), "Проверка подключения",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CheckConnection();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(sc, AppSettings);
            sf.Show();
        }

        private void проверитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckConnection();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            AddSmthToCollection();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            DeleteUrl();
        }

        private void добавитьФайлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            AddFiles();
        }

        private void добавитьПапкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            int count = lbClt.Items.Count;
            AddFolder();
            //if (lbClt.Items.Count == count)
            //    MessageBox.Show("В указанной папке не найдено\nни одного документа индексируемого типа", "Файлы не найдены",MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteUrl();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddSmthToCollection();
        }

        private void AddSmthToCollection()
        {
            if (tbAddress_Sp.Text.Length == 0)
                return;
            if (!tbAddress_Sp.Text.StartsWith("http://"))
                tbAddress_Sp.Text = "http://" + tbAddress_Sp.Text;
            AddUrlToCltList(tbAddress_Sp.Text);
        }

        private void добавитьФайлыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddFiles();
        }

        private void AddFiles()
        {
            //      (\.doc)|(\.txt)|(\.htm)|(\.ppt)|(\.xls)$

            char[] Delimeters = new char[] { '(', ')', '\\', '.', '|', '$' };
            string[] exts = AppSettings.files.Split(Delimeters);
            string filt = "Документы (";
            foreach (string ext in exts)
                if (ext.Length > 2)
                    filt += "*." + ext + ",";
            filt = filt.Substring(0, filt.Length - 1);
            filt += ")|";
            foreach (string ext in exts)
                if (ext.Length > 2)
                    filt += "*." + ext + ";";
            filt = filt.Substring(0, filt.Length - 1);

            openManyDocDialog.Filter = filt;
            if (openManyDocDialog.ShowDialog() == DialogResult.OK)
            {
                tbAddress_Sp.Text = "";
                foreach (string name in openManyDocDialog.FileNames)
                {
                    AddUrlToCltList(name);
                }
            }
        }

        private void добавитьПапкуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void AddFolder()
        {
            Shell shell = new Shell();
            Folder folder = shell.BrowseForFolder(
                0,
                "Выберите папку (добавлены в коллекцию будут все файлы, расположенные в этой папке).",
                0,
                ShellSpecialFolderConstants.ssfDESKTOP
            );

            Regex fileext = new Regex(AppSettings.files, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (folder != null)
                SearchInFolder(folder, fileext, AppSettings.isSearchSubFolders);

        }


        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            создатьКоллекциюToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            открытьКоллекциюToolStripMenuItem_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList urls_to_delete = new ArrayList();
            foreach (string url in lbClt.SelectedItems)
            {
                AddUrlToDBList(url,false);
                urls_to_delete.Add(url);
            }
            foreach (string url1 in urls_to_delete)
                lbClt.Items.Remove(url1);
            if (urls_to_delete.Count > 0)
                isFileChanged = true;
            doListCLTCount();
            doListDBCount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList urls_to_delete = new ArrayList();
            foreach (string url in lbClt.Items)
            {
                AddUrlToDBList(url,false);
                urls_to_delete.Add(url);
            }
            foreach (string url1 in urls_to_delete)
                lbClt.Items.Remove(url1);
            if (urls_to_delete.Count > 0)
                isFileChanged = true;
            doListCLTCount();
            doListDBCount();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ArrayList urls_to_delete = new ArrayList();
            foreach (string url in lbDB.SelectedItems)
            {
                if (lbClt.Items.Contains(url))
                    MessageBox.Show(url + ": уже есть в списке", "Ошибка добавления",MessageBoxButtons.OK,MessageBoxIcon.Error);
                else
                {
                    lbClt.Items.Add(url);
                    urls_to_delete.Add(url);
                    DelFromDB(url);
                }
            }
            foreach (string url1 in urls_to_delete)
                lbDB.Items.Remove(url1);

            if (urls_to_delete.Count > 0)
                isFileChanged = true;
            doListCLTCount();
            doListDBCount();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayList urls_to_delete = new ArrayList();
            foreach (string url in lbDB.Items)
            {
                if (!lbClt.Items.Contains(url))
                {
                    lbClt.Items.Add(url);
                    urls_to_delete.Add(url);
                    DelFromDB(url);
                }
            }
            foreach (string url1 in urls_to_delete)
                lbDB.Items.Remove(url1);
            if (urls_to_delete.Count > 0)
                isFileChanged = true;
            doListCLTCount();
            doListDBCount();
        }

        private void lstAddress_Sp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbClt.SelectedItems.Count > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDB.SelectedItems.Count > 0)
                button3.Enabled = true;
            else
                button3.Enabled = false;
        }

        private void экспортИзбранногоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFavoritesPath = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strFavoritesPath);
            SearchInFavoriteFolder(di);
            LoadFavoritesFromPath(strFavoritesPath);
        }

        private void SearchInFavoriteFolder(System.IO.DirectoryInfo dirInfo)
        {
            foreach (System.IO.DirectoryInfo objDir in dirInfo.GetDirectories())
            {
                if (objDir.GetDirectories().Length == 0)
                    LoadFavoritesFromPath(objDir.FullName);
                else
                {
                    SearchInFavoriteFolder(objDir);
                    LoadFavoritesFromPath(objDir.FullName);
                }
            }
        }

        private void LoadFavoritesFromPath(string astrPath)
        {
            System.IO.DirectoryInfo objDir = new System.IO.DirectoryInfo(astrPath);
            foreach (System.IO.FileInfo objFile in objDir.GetFiles("*.url"))
            {
                string url = GetFavoriteUrlFromUrl(objFile.FullName);
                if (url.StartsWith("file://"))
                    url = url.Substring(7, url.Length - 7);
                AddUrlToCltList(url);
            }
        }
        private string GetFavoriteUrlFromUrl(string path)
        {
            StreamReader r = new StreamReader(path,Encoding.Default);
            string s = r.ReadToEnd();
            r.Close();
            int pos = s.IndexOf("URL=");
            s=s.Substring(pos+4,s.Length-(pos+4));
            pos=s.IndexOf("\r\n");
            s=s.Substring(0,pos);
            return s;
        }

        private void начатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbClt.Items.Count>0)
                сохранитьToolStripMenuItem_Click(sender, e);
            isFileChanged = false;
            CurrentFileName = "";
            lbClt.Items.Clear();
            toolStripStatusLabel1.Text = "Обход";

            //lbReport.Items.Clear();
            step = 0;
            trafic = 0;
            AppSettings.Read();
            begintime = System.DateTime.Now;
            DoStep();
            if (AppSettings.isSearchHyperLinks)
            {
                while (!isStop)
                {
                    DownloadFromDBUnindexed();
                    MoveLinksToDB();
                    if (!DoStep())
                        break;
                }
            }
            lbReport.SelectedIndex = lbReport.Items.Count - 1;
            lbDB.Items.Clear();
        }
        private void MoveLinksToDB()
        {
            foreach (string link in lbClt.Items)
            {
                if (lbDB.Items.Contains(link))
                    continue;
                AddUrlToDBList(link,true);
            }
            lbClt.Items.Clear();
            lbDB.Update();
        }

        private bool DoStep()
        {
            processed = 0;
            btStop.Enabled = true;
            isStop = false;
            if (lbDB.Items.Count == 0)
            {
                MessageBox.Show("В списке базе нет элементов","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            step++;
            lbReport.Items.Add("НОВЫЙ ЭТАП");
            lbReport.Items.Add(System.DateTime.Now.ToString() + " Шаг №" + step.ToString() + ": обход коллекции...");
            lbReport.Update();

            System.TimeSpan delta = new TimeSpan();

            toolStripProgressBar1.Maximum = lbDB.Items.Count;
            toolStripProgressBar1.Value = 0;
            int i = 0;
            for (i = 0; i < lbDB.Items.Count; i++)
            {
                lbDB.SelectedIndex = -1;
                lbDB.SelectedIndex = i;
                lbDB.Update();
                String url = lbDB.Items[i].ToString();

                myCommand.CommandText = "SELECT id FROM docs WHERE url='" + @url + "' and indexed=0";
                SqlDataReader reader1 = myCommand.ExecuteReader();
                if (!reader1.Read())
                {
                    reader1.Close();
                    continue;
                }
                int id = reader1.GetInt32(0);
                reader1.Close();

                ProcessUrl(id,url);

                if (trafic > AppSettings.maxTrafic * 1000)
                    isStop = true;

                System.DateTime nowtime = System.DateTime.Now;
                delta = nowtime - begintime;
                int diff = (int)delta.TotalMinutes;
                if (diff > AppSettings.maxTime)
                    isStop = true;
                numTime.Text = delta.ToString().Substring(0, 8);
                toolStripProgressBar1.Value++;
                processed++;

                lbTrafic.Text = trafic.ToString();
                lbProcessed.Text = processed.ToString();
                if (isStop)
                {
                    MessageBox.Show("Процесс остановлен", "Остановка",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    break;
                }
            }

            if (isStop)
            {
                lbReport.Items.Add(System.DateTime.Now.ToString() + " Обход коллекции остановлен");
            }
            else
                lbReport.Items.Add(System.DateTime.Now.ToString() + " Обход коллекции выполнен");
            return true;
        }

        void ProcessUrl(int id,string docname)
        {
            docname = docname.Replace('*', '\'');

            string filetext = "";

            string name = "";
            long docsize = 0;
            string ext = "";

            if (isFileName(docname))
            {
                if (!(File.Exists(docname)))
                {
                    lbReport.Items.Add(docname + ": файл не существует");
                    return;
                }
                System.IO.FileInfo file = new System.IO.FileInfo(docname);
                if (file.Length > AppSettings.maxDocSize * 1000)
                {
                    lbReport.Items.Add(docname + ": слишком большой файл");
                    return;
                }

                name = Path.GetFileNameWithoutExtension(docname).Replace("'", " ");
                docsize = file.Length;
                ext = Path.GetExtension(docname).Replace("'", " ");

                if (file.Extension == ".doc" || file.Extension == ".ppt" || file.Extension == ".xls")
                    filetext = OfficeFileReader.GetText(docname);
                else
                {
                    StreamReader r = new StreamReader(docname, System.Text.Encoding.Default);
                    filetext = r.ReadToEnd();
                }
            }
            else
            {
                //this is URL
                try
                {
                    System.Net.WebRequest req = System.Net.WebRequest.Create(docname);
                    System.Net.WebResponse resp = req.GetResponse();

                    if (resp.ContentLength > AppSettings.maxDocSize * 1000)
                    {
                        lbReport.Items.Add(docname + ": слишком большой файл");
                        return;
                    }


                    System.IO.Stream stream = resp.GetResponseStream();
                    System.IO.StreamReader sr = new System.IO.StreamReader(stream, System.Text.Encoding.GetEncoding(1251));
                    filetext = sr.ReadToEnd();
                    String TitlePattern = "<title>(.*?)</title>";
                    Regex title = new Regex(TitlePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    MatchCollection mc = title.Matches(filetext);
                    if (mc.Count != 0)
                        name = mc[0].Groups[1].ToString().Replace("'", " ");
                    docsize = filetext.Length;
                    ext = docname.Substring(docname.IndexOf("/")).Replace("'", " ");
                    int ind = ext.IndexOf(".");
                    if (ind != -1)
                        ext = ext.Substring(ind);
                    else
                        ext = "";
                    ext = ext.Replace("'", " ");
                    ext = ext.Substring(0, 5);
                }

                catch (System.ArgumentNullException e)
                {
                    lbReport.Items.Add(docname + ": " + e.Message);
                    return;
                }
                catch (System.Security.SecurityException e)
                {
                    lbReport.Items.Add(docname + ": " + e.Message);
                    return;
                }
                catch (System.NotImplementedException e)
                {
                    lbReport.Items.Add(docname + ": " + e.Message);
                    return;
                }

                catch (System.NotSupportedException e)
                {
                    lbReport.Items.Add(docname + ": " + e.Message);
                    return;
                }
                catch (System.UriFormatException e)
                {
                    lbReport.Items.Add(docname + ": " + e.Message);
                    return;
                }
                catch (System.Net.WebException e)
                {
                    lbReport.Items.Add(docname + ": " + e.Message);
                    return;
                }
            }
            System.DateTime dt = System.DateTime.Now;
            dt.ToString("mm.dd.yyyy hh:mm:ss");
            //здесь часы вставляются от 0 до 12 p/a m

            if (name.Length > 255)
                name = name.Substring(0, 255);
            if (ext.Length > 255)
                ext = ext.Substring(0, 255);

            int tcy = PageRank.GetYandexTCY(docname);

            int gpr = 0;
            if (docname.StartsWith("http://"))
                gpr = PageRank.GetGooglePageRank(docname);

            if (docname.StartsWith("http://"))
            {
                trafic += (int)docsize;
            }
            FindHyperlinks(filetext);
            filetext = Tags.DeleteAll(filetext);
            filetext = filetext.Replace("'"," ");
            SetAndExecuteQuery("UPDATE docs SET name='" + name + "',docdate='" + dt.ToString("MM.dd.yyyy hh:mm:ss") +
                "',docsize='" + docsize + "',ext='" + ext + "',tcy=" + tcy.ToString() + ",gpr=" + gpr.ToString() + 
                ",indexed=1,doctext='" + filetext + "' where id=" + id + ";");
            }
            private bool isFileName(string s)
            {
                if (s.StartsWith("http://", true, null))
                    return false;
                return true;
            }
            private void AddHyperlink(string url)
            {
                if (!lbClt.Items.Contains(url))
                {
                    lbClt.Items.Add(url);
                    doListCLTCount();
                }
            }
            private void FindHyperlinks(String filetext)
            {
                if (filetext == "") return;

                //Regex regex = new Regex(@"(\b\w+:\/\/\w+((\.\w)*\w+)*\.\w{2,3}(\/\w*|\.\w*|\?\w*\=\w*)*)"); 

                String HttpPattern = "<(a|link).*?href=\"(http:.+?\\.(ru|su|net|org|com).+?)\".*?>";
//                String HttpPattern = "<(a|link).*?href=\"(http:.+?\\..{2,4}\\.?.*?)\".*?>";
                Regex reHTTP = new Regex(HttpPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                MatchCollection mc = reHTTP.Matches(filetext);
                Regex fileext = new Regex(AppSettings.files, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in mc)
                {
                    String newurl = m.Groups[2].ToString();
                    if (!lbClt.Items.Contains(newurl))
                    {
                        newurl = newurl.Replace('\'', '*');
                        String s = newurl.Substring(7);//http://
                        int si = s.LastIndexOf("/");
                        int di = s.LastIndexOf(".");
                        if (di == -1 || di <= si || //вообще нет расширения
                            s.EndsWith(".htm") || s.EndsWith(".html") || fileext.IsMatch(s))
                        {
                            newurl = newurl.Replace("&amp;", "&");
                            if (newurl.Contains("\""))
                                newurl = newurl.Substring(0, newurl.IndexOf("\""));
                            AddHyperlink(newurl);
                        }
                    }
                }
            }

        private void btStop_Click(object sender, EventArgs e)
        {
            остановитьToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            начатьToolStripMenuItem_Click(sender, e);
        }

        private void остановитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStop = true;
        }
        
        private void DoIndex()
        {
            lbReport.Items.Add(System.DateTime.Now.ToString() + " Индексация...");
            lbReport.SelectedIndex = lbReport.Items.Count - 1;
            lbReport.Update();
            //myCommand.CommandText = "select count(id) from docs;";
            //int count = (int)myCommand.ExecuteScalar();

            toolStripStatusLabel1.Text = "Индексация";
            toolStripProgressBar1.Maximum = lbDB.Items.Count;
            toolStripProgressBar1.Value = 0;
            processed = 0;
            lbProcessed.Text = "0";
            lbTrafic.Text = "0";
            numTime.Text = "00:00:00";

            begintime = System.DateTime.Now;
            System.TimeSpan delta = new TimeSpan();
            System.DateTime now = new DateTime();

            for (int i = 0; i < lbDB.Items.Count; i++)
            {
                lbDB.SelectedIndex = -1;
                lbDB.SelectedIndex = i;
                lbDB.Update();
                String url = lbDB.Items[i].ToString();
                toolStripProgressBar1.Value++;
                myCommand.CommandText = "select id from docs where url='" + url+"'";
                int id = 0;
                id = (int)myCommand.ExecuteScalar();
                if (id == 0) continue;
                StemIndexer.CreateIndex(id, sc);
                processed++;
                lbProcessed.Text = processed.ToString();
                now = System.DateTime.Now;
                delta = now - begintime;
                numTime.Text = delta.ToString().Substring(0, 8);
            }

            myCommand.CommandText = "UPDATE Terms SET Terms.TextsNumber=" +
                "(SELECT Count(TermEntries.Id) FROM TermEntries" +
                " WHERE TermEntries.Id_Term=Terms.Id)";
            myCommand.ExecuteNonQuery();
            lbReport.Items.Add(System.DateTime.Now.ToString() + " Перерасчет TF-IDF");
            lbReport.SelectedIndex = lbReport.Items.Count - 1;
            lbReport.Update();
            tfidf.DoTF(sc);
            tfidf.DoIDF(sc);
            lbReport.Items.Add(System.DateTime.Now.ToString() + " Коллекция проиндексирована");
            lbReport.SelectedIndex = lbReport.Items.Count - 1;
            lbReport.Update();
            now = System.DateTime.Now;
            delta = now - begintime;
            numTime.Text = delta.ToString().Substring(0, 8);
        }

        private void индексироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbDB.Items.Clear();
            //что индексируем?
            myCommand.CommandText = "select url from docs where indexed=1 and termsnumber=0;";
            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                lbDB.Items.Add(reader.GetString(0));
            }
            reader.Close();
            doListDBCount();
            DoIndex();
        }

        private void экспортИзЯндексToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InternetChecker.Check() == "Не обнаружено подключения к интернету")
            {
                MessageBox.Show("Невозможно экспортировать данные, так как компьютер не подключен к интернету", "Диплом",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ExportForm ef = new ExportForm();
            ef.ShowDialog();
            if (ef.Query=="")
                return;

            try
            {
                System.Net.WebRequest req =
                    System.Net.WebRequest.Create("http://xmlsearch.yandex.ru/xmlsearch?query=" + ef.Query);
                System.Net.WebResponse resp = req.GetResponse();

                System.IO.Stream stream = resp.GetResponseStream();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(stream);
                stream.Close();
                resp.Close();
                
                XmlNodeList urls = xDoc.GetElementsByTagName("url");
                XmlNodeList founds = xDoc.GetElementsByTagName("found");
                int N = 0;
                foreach (XmlElement found in founds)
                    if (found.GetAttribute("priority") == "all")
                    {
                        N = int.Parse(found.InnerText);
                        break;
                    }
                if (N > ef.N)
                    N = ef.N;
                foreach (XmlElement url in urls)
                {
                    AddUrlToCltList(url.InnerText);
                    N--;
                }

                int page = 1;
                while (N > 0)
                {
                    page++;
                    req =
                        System.Net.WebRequest.Create("http://xmlsearch.yandex.ru/xmlsearch?query=" +
                                                                    ef.Query + "&page=" + page.ToString());
                    resp = req.GetResponse();
                    stream = resp.GetResponseStream();
                    xDoc = new XmlDocument();
                    xDoc.Load(stream);
                    stream.Close();
                    resp.Close();
            
                    urls = xDoc.GetElementsByTagName("url");
                    foreach (XmlElement url in urls)
                    {
                        AddUrlToCltList(url.InnerText);
                        N--;
                        if (N < 1)
                            break;
                    }
                    if (urls.Count < 10)
                        break;
                }
            }
            catch (System.ArgumentNullException) { return; }
            catch (System.NotImplementedException) { return; }
            catch (System.Security.SecurityException) { return; }
            catch (System.Net.WebException)
            {
                MessageBox.Show("Нет доступа к Яндексу", "Диплом",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void задатьОбластьИндексированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSystemForm fs = new FileSystemForm();
            fs.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            UpdateYandexTCY();
            UpdateGooglePR();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            индексироватьToolStripMenuItem_Click(sender, e);
        }
    }
}