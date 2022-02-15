using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Athelas
{
    class Indexer
    {
        public static ArrayList StopWords_Ru;
        public static ArrayList StopStems_Ru;

        public static ArrayList StopWords_En;

        public Indexer(string path_swr, string path_ssr, string path_swe)
        {
            StopStems_Ru = new ArrayList();
            StopWords_En = new ArrayList();
            StopWords_Ru = new ArrayList();

            string path = Application.StartupPath + "\\";
            StreamReader reader = new StreamReader(path + path_swr);
            while (!reader.EndOfStream)
            {
                string stopword = reader.ReadLine();
                StopWords_Ru.Add(stopword);
            }
            reader.Close();

            reader = new StreamReader(path + path_swe);
            while (!reader.EndOfStream)
            {
                string stopword = reader.ReadLine();
                StopWords_En.Add(stopword);
            }
            reader.Close();


            reader = new StreamReader(path + path_ssr);
            while (!reader.EndOfStream)
            {
                string stopword = reader.ReadLine();
                StopStems_Ru.Add(stopword);
            }
            reader.Close();

        }

        public static void CreateVoc(SqlConnection connection)
        {
            if (!File.Exists("c:/voc.txt"))
                return;
            StreamReader r = new StreamReader("c:/voc.txt",Encoding.GetEncoding(1251));
            while (!r.EndOfStream)
            {
                string word = r.ReadLine();
                string stem = Stemmer_Ru.GetStem(word);
                string ending = "";
                if (word!=stem)
                    ending=word.Substring(stem.Length, word.Length - stem.Length);
                string query = "INSERT INTO voc VALUES('" + stem + "','" + ending + "')";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            r.Close();
        }

        public static string GetNF(string stem,SqlConnection connection)
        {
            string query = "SELECT ending FROM voc WHERE stem='" + stem+"'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                return stem;
            }
            string result = stem + reader.GetString(0);
            reader.Close();
            return result;
          }

        private static bool IsStopWord_Ru(string word)
        {
            if (StopWords_Ru.Contains(word))
                return true;
            return false;
        }

        private static bool IsStopWord_En(string word)
        {
            if (StopWords_En.Contains(word))
                return true;
            return false;
        }

        private static bool IsStopStem_Ru(string stem)
        {
            if (StopStems_Ru.Contains(stem))
                return true;
            return false;
        }

        public static string DelNotLetters(string word)
        {
            string result = "";
            for (int i = 0; i < word.Length; i++)
                if (Char.IsLetter(word, i))
                    result += word.Substring(i, 1);
            return result;
        }

        private static string GetTerm(string word)
        {
            word = word.Trim();

            word = DelNotLetters(word);

            if (isContainsDigits(word))
                return "";

            string term = word.ToLower();
            string oldw = term;

            if (term.Length <= 1)
                return "";

            if (term.Length > 49)
                term = term.Remove(49);

            bool isRus = isRusWord(term);

            if (isRus && IsStopWord_Ru(term))
                return "";

            if (!isRus && IsStopWord_En(term))
                return "";

            if (term != oldw && isRus && IsStopStem_Ru(term))
                return "";

            string stem = "";
            if (isRus)
                stem = Stemmer_Ru.GetStem(term);
            else
            {
                Stemmer_En enstemmer = new Stemmer_En();
                stem = enstemmer.GetStem(term);
            }
            if (stem.Length <= 1)
                return "";
            return stem;
        }
        public static bool isRusWord(string word)
        {
            if (word == "")
                return true;
            string ending = word.Substring(word.Length - 1,1);
            string RusLetters = "àáâãäå¸æçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
            if (RusLetters.Contains(ending))
                return true;
            return false;
        }

        private static bool isContainsDigits(string word)
        {
            for (int i = 0; i < word.Length; i++)
                if (Char.IsDigit(word[i]))
                    return true;
            return false;
        }

        public static Hashtable GetTerms(string text)
        {
            int termsCount = 0;
            Hashtable terms = new Hashtable();
            char[] Delimeters = new char[] { '.', ',', ';', '"', '!', '?', ' ', '\n', '\r', '-', '=', '\\', '/' ,
                '(',')','@','#','$','%','^','&','*','+','`','~','¹',':','_','=','[',']','{','}','<','>' };
            string[] words = text.Split(Delimeters, StringSplitOptions.RemoveEmptyEntries);
            foreach (string w in words)
            {
                string term = "";
                if (w.ToLower().Contains("âàñíåöîâ"))
                    term = "âàñíåö";
                else
                    term = GetTerm(w);

                if (term == "")
                    continue;

                if (terms.ContainsKey(term))
                    terms[term] = (int)terms[term] + 1;
                else
                    terms[term] = 1;
                termsCount++;
            }

            terms[0] = termsCount;
            return terms;
        }
        public static int GetIdTerm(string term, SqlConnection connection)
        {
            SqlCommand command;
            string sqlQuery = "select id from terms where term='" + term + "'";
            command = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                return -1;
            }
            int result = reader.GetInt32(0);
            reader.Close();
            return result;
        }
        public static string GetTermById(int id, SqlConnection connection)
        {
            SqlCommand command;
            string sqlQuery = "select term from terms where id=" + id.ToString();
            command = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                return "";
            }
            string result = reader.GetString(0);
            reader.Close();
            return result;
        }

        public static Hashtable GetIdTerms(string text,SqlConnection connection)
        {
//            int termsCount = 0;
            Hashtable terms = new Hashtable();
            char[] Delimeters = new char[] { '.', ',', ';', '"', '!', '?', ' ', '\n', '\r', '-', '=', '\\', '/' ,
                '(',')','@','#','$','%','^','&','*','+','`','~','¹',':','_','=','[',']','{','}','<','>' };
            string[] words = text.Split(Delimeters, StringSplitOptions.RemoveEmptyEntries);
            foreach (string w in words)
            {
                string term = GetTerm(w);

                if (term == "")
                    continue;

                int id_term = GetIdTerm(term,connection);
                if (id_term == -1)
                    continue;

                if (terms.ContainsKey(id_term))
                    terms[id_term] = (int)terms[id_term] + 1;
                else
                    terms[id_term] = 1;
//                termsCount++;
            }

//            terms[0] = termsCount;
            return terms;
        }
        public  int CreateIndex(int idText, SqlConnection connection)
        {
            SqlCommand command;
            command = new SqlCommand("SELECT DocText FROM docs WHERE Id=" +
                idText.ToString(), connection);

            string text = command.ExecuteScalar().ToString();
            Hashtable terms = GetTerms(text);
            int termsNumber = (int)terms[0];
            terms.Remove(0);
            ArrayList termlist = new ArrayList(terms.Keys);
            for (int i = 0; i < termlist.Count; i++)
            {
                string termName = (string)termlist[i];
                DBTerm term = DBTerm.FindByName(termName, connection);
                if (term == null)
                {
                    int isRus;
                    if (isRusWord(termName))
                        isRus = 1;
                    else
                        isRus = 0;
                    term = DBTerm.Create(termName, 1,isRus, connection);
                }
                else
                {
                    term.TextsNumber++;
//                    term.Update(connection);
                }
                command = new SqlCommand("INSERT INTO TermEntries Values(" +
                    idText.ToString() + "," + term.Id.ToString() + "," +
                    ((int)terms[termName]).ToString() + ",0,0)", connection);
                command.ExecuteNonQuery();
            }
            command = new SqlCommand("UPDATE docs SET TermsNumber=" +
                termsNumber.ToString() + " WHERE Id=" + idText.ToString(), connection);
            command.ExecuteNonQuery();
            return termsNumber;
        }

        //public void CreateIndexes(SqlConnection connection,ArrayList idtextslist)
        //{
        //    foreach (int id in idtextslist)
        //    {
        //        CreateIndex(id, connection);
        //    }
        //    SqlCommand command;
        //    command = new SqlCommand("UPDATE Terms SET Terms.TextsNumber=" +
        //        "(SELECT Count(TermEntries.Id) FROM TermEntries"+
        //        " WHERE TermEntries.Id_Term=Terms.Id)", connection);
        //    command.ExecuteNonQuery();
        //}

        public static ArrayList Search(string query, SqlConnection connection)
        {
            int i;
            Hashtable terms = GetTerms(query);
            string sqlQuery = "SELECT docs.Id, SUM(TermEntries.EntriesNumber) as entries FROM docs" +
                " Inner Join TermEntries ON docs.Id=TermEntries.Id_Text"+
                " INNER JOIN Terms ON TermEntries.Id_Term=Terms.Id WHERE ";
            ArrayList ts=new ArrayList(terms.Keys);
            for(i=0;i<ts.Count;i++)
            {
                if (i>0) sqlQuery+="OR ";
                sqlQuery+="Terms.Term='"+(ts[i] as string)+"' ";
            }
            sqlQuery += "GROUP BY docs.Id ORDER BY entries DESC";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = command.ExecuteReader();
            ArrayList idlist = new ArrayList();
            while (reader.Read())
                idlist.Add(reader.GetInt32(0));
            reader.Close();
            return idlist;
        }
//        public static ArrayList SearchById(Hashtable terms, SqlConnection connection)
//        {
//            int i;
////            Hashtable terms = GetIdTerms(query);
//            string sqlQuery = "SELECT Texts.Id, SUM(TermEntries.EntriesNumber) as entries FROM Texts" +
//                " Inner Join TermEntries ON Texts.Id=TermEntries.Id_Text" +
//                " INNER JOIN Terms ON TermEntries.Id_Term=Terms.Id WHERE ";
//            ArrayList ts = new ArrayList(terms.Values);
//            for (i = 0; i < ts.Count; i++)
//            {
//                if (i > 0) sqlQuery += " OR ";
//                sqlQuery += "Terms.Id=" + (ts[i] as string);
//            }
//            sqlQuery += "GROUP BY Texts.Id ORDER BY entries DESC";
//            SqlCommand command = new SqlCommand(sqlQuery, connection);
//            SqlDataReader reader = command.ExecuteReader();
//            ArrayList idlist = new ArrayList();
//            while (reader.Read())
//                idlist.Add(reader.GetInt32(0));
//            reader.Close();
//            return idlist;
//        }
public static string GetMostRelevantPart(string text, ArrayList queryTerms, int maximumSize)
        {
            int i, charCount=0;
            ArrayList beginPositions = new ArrayList();
            ArrayList endPositions = new ArrayList();
            ArrayList termsCount = new ArrayList();
            ArrayList notEndedIndexes=new ArrayList();
            int bestIndex=0;
            char[] Delimeters = new char[] { '.', ',', ';', '"', '!', '?', ' ', '\n', '\r', '-', '=', '\\', '/' ,
                '(',')','@','#','$','%','^','&','*','+','`','~','¹',':','_','=','[',']','{','}','<','>' };
            string[] words = text.Split(Delimeters, StringSplitOptions.None);
            for(i=0;i<words.Length;i++,charCount++)
            {
                string w = words[i];
                charCount += w.Length;
                foreach (int j in notEndedIndexes)
                    if (charCount - (int)beginPositions[j] > maximumSize)
                        notEndedIndexes.Remove(j);
                    else
                        endPositions[j] = charCount;
                charCount += w.Length;
                if ((w.Length <= 1) || (isContainsDigits(w)))
                    continue;
                w = (w.Trim()).ToLower();
                if (w.Length > 49)
                    w = w.Remove(49);
                string term = GetTerm(w);
                if (queryTerms.Contains(term))
                {
                    beginPositions.Add(charCount - w.Length);
                    endPositions.Add(charCount);
                    termsCount.Add(1);
                    foreach (int j in notEndedIndexes)
                    {
                        termsCount[j] = ((int)termsCount[j]) + 1;
                        if ((int)termsCount[j] > (int)termsCount[bestIndex])
                            bestIndex = j;
                    }
                }
            }
            return text.Substring((int)beginPositions[bestIndex],
                        (int)endPositions[bestIndex] - (int)beginPositions[bestIndex]);
        }
    }
}
