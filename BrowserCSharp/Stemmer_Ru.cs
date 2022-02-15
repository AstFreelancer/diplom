using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;

namespace Athelas
{
    class Stemmer_Ru
    {
        public static string VOWEL = "���������";
        public static string PERFECTIVEGROUND = "((��|����|������|��|����|������)|((?<=[��])(�|���|�����)))$";
        public static string REFLEXIVE = "(�[��])$";
        public static string ADJECTIVE = "(��|��|��|��|���|���|��|��|��|��|��|��|��|��|���|���|���|���|��|��|��|��|��|��|��|��)$";
        public static string PARTICIPLE = "((���|���|���)|((?<=[��])(��|��|��|��|�)))$";
        public static string VERB = "((���|���|���|����|����|���|���|���|��|��|��|��|��|��|��|���|���|���|��|���|���|��|��|���|���|���|���|��|�)|((?<=[��])(��|��|���|���|��|�|�|��|�|��|��|��|��|��|��|���|���)))$";
        public static string NOUN = "(�|��|��|��|��|�|����|���|���|��|��|�|���|��|��|��|�|���|��|���|��|��|��|�|�|��|���|��|�|�|��|��|�|��|��|�)$";
        public static string RVRE = "^(.*?[���������])(.*)$";
        public static string DERIVATIONAL = "[^���������][���������]+[^���������]+[���������].*(?<=�)���?$";

        public static string PPARTICLE = "(-��|-��|-����|-������|-�|-����|-��)$";
        public static string PPREFIX = "^(���-)";

        public static string RV;

        public static bool isReplaced(string pattern, string towhat)
        {
            String temp = RV;
            Regex reg = new Regex(pattern,RegexOptions.Multiline);
            RV=reg.Replace(RV,towhat);
            if (temp == RV)
                return false;
            return true;
        }
        public static bool isCanReplace(string pattern, string towhat)
        {
            String temp = RV;
            Regex reg = new Regex(pattern);
            if (reg.IsMatch(RV))
                return true;
            return false;
        }
        public static string GetStem(string word)
        {
//            word = word.ToLower();
            word = word.Replace('�', '�');

            Regex reg1 = new Regex(PPARTICLE, RegexOptions.Multiline);
            word = reg1.Replace(word, "");

            Regex reg2 = new Regex(PPREFIX, RegexOptions.Multiline);
            word = reg2.Replace(word, "");

            string stem = word;
            do
            {
                Regex reScript = new Regex(RVRE, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                MatchCollection mc = reScript.Matches(word);
                if (mc.Count < 1)
                    break;

                Match m = mc[0];
                string start = m.Groups[1].ToString();
                RV = m.Groups[2].ToString();
              
                if (RV == "")
                    break;

                //Step 1
                if (!isReplaced(PERFECTIVEGROUND,""))
                {
                  isReplaced(REFLEXIVE,"");
                
                    if (isReplaced(ADJECTIVE,""))
                  {
                     isReplaced(PARTICIPLE,"");
                  }
                  else
                  {
                if (!isReplaced(VERB,""))
                    {
                  isReplaced(NOUN,"");
                    }
                  }
              }

              //Step 2
                  isReplaced("�$", "");

              //Step 3
                reScript = new Regex(DERIVATIONAL, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    if (isCanReplace(DERIVATIONAL,""))
                    {
                        isReplaced("����?$","");
                    }

              //Step 4
              if (!isReplaced("�$",""))
              {
                  isReplaced("����?","");
                  isReplaced("��$", "�");
              }

              stem = start+RV;
            }
            while(false);
            return stem;
    }
}
}
