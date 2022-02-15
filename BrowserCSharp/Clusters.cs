using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Athelas
{
    class Clusters
    {
        public ArrayList clusters = new ArrayList();
        public Point maxCoord = new Point();
        public ArrayList id_texts = new ArrayList();
        public ArrayList id_terms = new ArrayList();
        public SqlConnection connection;
        public int K = 5;
        public ArrayList points = new ArrayList();
        int ntexts = 0;
        int nterms = 0;
        Random rand = new Random(DateTime.Now.Millisecond);

        public Clusters(ArrayList id_texts1,ArrayList id_terms1,SqlConnection connection1,int K1,ArrayList points1)
        {
            id_texts=new ArrayList(id_texts1);
            id_terms=new ArrayList(id_terms1);
            connection = connection1;
            K=K1;
            points = new ArrayList(points1);
            ntexts = id_texts.Count;
            nterms = id_terms.Count;
        }
        public Clusters(int k1)
        {
            K = k1;
            clusters = new ArrayList();
        }

        public void Clear()
        {
            clusters = new ArrayList();
        }

        public void SetActive(int pos,bool isActive)
        {
            ((Cluster)clusters[pos]).isActive = isActive;
        }

        public void Add(Cluster cl)
        {
            clusters.Add(cl);
        }
        public void AddPoint(Point p, int id)
        {
            ((Cluster)clusters[id]).points.Add(p);
        }
        public void ReInit()
        {
            for (int i = 0; i < clusters.Count; i++)
                ((Cluster)clusters[i]).points.Clear();
        }
        public bool isEqual(Clusters oldcls)
        {
            if (oldcls.clusters.Count != clusters.Count)
                return false;
            for (int i = 0; i < clusters.Count; i++)
            {
                Cluster cl1 = (Cluster)clusters[i];
                Cluster cl2 = (Cluster)oldcls.clusters[i];
                if (!cl1.isEqual(cl2))
                    return false;
            }
            return true;
        }

        public void Recalculate(Point maxCoord)
        {
            for (int i = 0; i < clusters.Count; i++)
                ((Cluster)clusters[i]).CalculateAverage(maxCoord);
        }
        public Cluster GetCluster(int i)
        {
            return (Cluster)clusters[i];
        }
        public void SetCluster(Cluster cl, int i)
        {
            clusters[i] = cl;
        }

        public int numNotEmptyClusters()
        {
            int n = 0;
            foreach (Cluster cl in clusters)
                if (!cl.isEmpty()) n++;
            return n;
        }

        public void delEmptyClusters()
        {
            ArrayList not_empty = new ArrayList();
            foreach (Cluster cl in clusters)
                if (!cl.isEmpty())
                    not_empty.Add(cl);
            clusters.Clear();
            clusters = new ArrayList(not_empty);
        }

        public ArrayList GetAllTermsId(SqlConnection connection)
        {
            ArrayList id_terms = new ArrayList();
            string query = "select id from terms";
            SqlCommand myCommand = new SqlCommand(query, connection);
            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                id_terms.Add(reader.GetInt32(0));
            }
            reader.Close();
            return id_terms;

        }
        public void DoKMeans()
        {
            int i, j;

            //найдем макс. знач. каждой из координат
            maxCoord = new Point();

            for (i = 0; i < nterms; i++)
            {
                double max = 0;
                for (j = 0; j < ntexts; j++)
                {
                    double tf_idf = (double)((Point)points[j]).coord[i];
                    if (tf_idf > max)
                        max = tf_idf;
                }
                maxCoord.coord.Add(max);
            }

            //случайным образом генерируем k центроидов кластеров
            for (i = 0; i < K; i++)
            {
                Cluster cl = new Cluster();
                Point tmpP = new Point();
                for (j = 0; j < nterms; j++)
                {
                    double coord = rand.NextDouble() * ((double)maxCoord.coord[j]);
                    tmpP.coord.Add(coord);
                }
                cl.SetAvgPoint(tmpP);
                Add(cl);
            }

            //Clusters oldcls = new Clusters();
            //int notChanged = 0;
            //соотнести точки с ближайшим центром
            //перевычислить центры
            for (int a = 0; a < 20; a++)
            {
                ReInit();

                foreach (Point pnt in points)
                {
                    int id_best_cl = 0;
                    Cluster bestcluster = GetCluster(id_best_cl);
                    double bestdist = bestcluster.avgPoint.GetDistance(pnt);

                    for (i = 1; i < clusters.Count; i++)
                    {
                        Cluster cluster = GetCluster(i);
                        double newdist = cluster.avgPoint.GetDistance(pnt);
                        if (newdist < bestdist)
                        {
                            id_best_cl = i;
                            bestdist = newdist;
                        }
                    }
                    AddPoint(pnt, id_best_cl);//добавить точку к ближайшему кластеру
                }
                //перевычислить центры
                Recalculate(maxCoord);
                //if (oldcls.clusters.Count == 0)
                //    oldcls = this;
                //else
                //{
                //    if (oldcls.isEqual(this))
                //        notChanged++;
                //    else
                //        notChanged = 0;
                //    if (notChanged > 2)
                //    {
                //        MessageBox.Show(i.ToString() + " - достаточно");
                //        break;
                //    }
                //}
            }
            //MessageBox.Show("отработан");
        }
    }
 
}
