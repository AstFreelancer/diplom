using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;


namespace Athelas
{
    class VSM
    {
//        public static ArrayList index = new ArrayList();
////        public static Hashtable hash = new Hashtable();
//        public static Hashtable QueryVector;
//        public static string query;
//        static SqlConnection connection;

//        public VSM(string q, SqlConnection sc)
//        {
//            query = q;
//            connection = sc;
//        }

//        public static void MakeSpace()
//        {
//            if (query == "")
//                return;

//            QueryVector = Indexer.GetIdTerms(query,connection);
//            ArrayList id_texts = Indexer.SearchById(QueryVector, connection);
//            foreach (int id_text in id_texts)
//            {
//                Hashtable textVector = GetTextVector(id_text);
//                index.Add(textVector);
//            }
//        }
//        public static float Cosinus(Hashtable x,Hashtable y)
//        {
//            float chisl = 0;
//            int len1 = 0;
//            int len2 = 0;

//            foreach (DictionaryEntry de in x)
//            {
//                if (!y.Contains(de.Key))
//                    continue;
//                int x1 = int.Parse(de.Value.ToString());
//                int x2 = int.Parse(y[de.Key].ToString());
//                chisl += x1 * x2;
//                len1 += x1 * x1;
//                len2 += x2 * x2;
                
//            }
//            float znam = (float)Math.Sqrt(len1 * len2);
//            if (znam == 0)
//                return 0;
//            return chisl / znam;
//        }

//        public  Hashtable Search()
//        {
////берет вектор запроса и сравнивает его со всеми векторами документов, возвраща€ ранжированный список совпадений.
////ќна возвращает хэш, в котором идентификаторы документа будут ключами, а косинусы будут значени€ми.
////¬се, что осталось, это отсортировать результаты по косинусу (в пор€дке убывани€), отформатировать их, и вывести
//            Hashtable output = new Hashtable();
//            MakeSpace();
//            foreach (Hashtable Text in index)
//            {
//                output[Text[0]]=Cosinus(QueryVector, Text);
//            }
//            return output;
//        }

//        public static Hashtable GetTextVector(int id_text)
//        {
//            Hashtable vector = new Hashtable();
//            //дл€ каждого терма из QueryVector 
//            //если он присутствует в данном тексте
//            //то добавить пару - номер_терма - количество_вхождений
//            foreach (DictionaryEntry de in QueryVector)
//            {
//                string sqlQuery = "select entriesnumber from termentries where id_text=" + id_text.ToString() +
//                    " and id_term=" + de.Key;
//                SqlCommand command = new SqlCommand(sqlQuery, connection);
//                SqlDataReader reader = command.ExecuteReader();
//                if (!reader.Read())
//                {
//                    reader.Close();
//                    continue;
//                }
//                vector[de.Key] = reader.GetInt32(0);
//            }
//            vector[0] = id_text;
//            return vector;
//        }
    }
}
