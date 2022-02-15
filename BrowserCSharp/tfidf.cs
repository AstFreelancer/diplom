using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace Athelas
{
    class tfidf
    {
        public static void DoTF(SqlConnection connection)
        {
            SqlCommand myCommand = new SqlCommand("UPDATE TermEntries SET tf=CAST(EntriesNumber as float)/" +
                "(select TermsNumber from docs where id=termentries.id_text)", connection);
            myCommand.ExecuteNonQuery();
        }
        public static void DoIDF(SqlConnection connection)
        {
            int D = 0;
            SqlCommand myCommand = new SqlCommand("select count(*) from docs", connection);
            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.Read())
                D = reader.GetInt32(0);
            reader.Close();
            if (D == 0)
                return;

            myCommand.CommandText = "UPDATE TermEntries SET idf=CAST(" + D.ToString() + " as float)/" +
                "(select TextsNumber from terms where id=termentries.id_term)";
            myCommand.ExecuteNonQuery();
        }

        ////число вхождений слова в документ
        //public static int GetNi(int id_term, int id_text, SqlConnection connection)
        //{
        //    SqlCommand myCommand = new SqlCommand("select EntriesNumber from TermEntries " +
        //        "where id_text=" + id_text.ToString() + " and id_term=" + id_term.ToString(), connection);
        //    SqlDataReader reader = myCommand.ExecuteReader();
        //    int result = 0;
        //    if (reader.Read())
        //        result = reader.GetInt32(0);
        //    reader.Close();
        //    return result;
        //}

        ////число слов в документе
        //public static int GetSumN(int id_text, SqlConnection connection)
        //{
        //    SqlCommand myCommand = new SqlCommand("select TermsNumber from Texts " +
        //        "where id=" + id_text.ToString(), connection);
        //    SqlDataReader reader = myCommand.ExecuteReader();
        //    int result = 0;
        //    if (reader.Read())
        //        result = reader.GetInt32(0);
        //    reader.Close();
        //    return result;
        //}

        //public static double TF(int id_term, int id_text, SqlConnection connection)
        //{
        //    int Ni = GetNi(id_term, id_text, connection);
        //    int SumN = GetSumN(id_text, connection);
        //    if (SumN == 0)
        //        return 0;
        //    return (double)Ni / (double)SumN;
        //}

        //public static double GetDiTi(int id_term, SqlConnection connection)
        //{
        //    double result = 0;
        //    SqlCommand myCommand = new SqlCommand("select count(*) from TermEntries " +
        //        "where id_term=" + id_term.ToString(), connection);
        //    SqlDataReader reader = myCommand.ExecuteReader();
        //    if (reader.Read())
        //        result = (double)reader.GetInt32(0);
        //    reader.Close();
        //    return result;
        //}
        //public static double IDF(double D, int id_term, SqlConnection connection)
        //{
        //    double DiTi = GetDiTi(id_term, connection);
        //    if (DiTi == 0)
        //        return 0;
        //    return (double)Math.Log(D / DiTi);
        //}
        //public static int GetD(SqlConnection connection)
        //{
        //    int result = 0;
        //    SqlCommand myCommand = new SqlCommand("select count(*) from texts", connection);
        //    SqlDataReader reader = myCommand.ExecuteReader();
        //    if (reader.Read())
        //        result = reader.GetInt32(0);
        //    reader.Close();
        //    return result;
        //}
        
        public static ArrayList GetTFIDFMatrix(ArrayList id_texts, ArrayList id_terms, SqlConnection connection)
        {
//            double[,] tfidf = new double[10, 10];

            int ntexts = id_texts.Count;
            int nterms = id_terms.Count;

            ArrayList points = new ArrayList();

            for (int i = 0; i < ntexts; i++)
            {
                ArrayList coord = new ArrayList();
                for (int j = 0; j < nterms; j++)
                {
                    coord.Add(0.0);
                }
                Point p = new Point(coord,(int)id_texts[i]);
                points.Add(p);
            }
            SqlCommand myCommand = new SqlCommand("select id_text,id_term,tf,idf from TermEntries",
                connection);
            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                int id_txt = reader.GetInt32(0);
                int id_trm = reader.GetInt32(1);
                int ii = id_texts.IndexOf(id_txt);
                int jj = id_terms.IndexOf(id_trm);
                if (ii == -1 || jj == -1)
                    continue;
                double tf = reader.GetDouble(2);
                double idf = Math.Log(reader.GetDouble(3),2);
                ((Point)points[ii]).coord[jj] = tf*idf;
            }
            reader.Close();
            
            return points;
            //return tfidf;
        }
    }
}
