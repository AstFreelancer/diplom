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
        public static string VOWEL = "аеиоуыэю€";
        public static string PERFECTIVEGROUND = "((ив|ивши|ившись|ыв|ывши|ывшись)|((?<=[а€])(в|вши|вшись)))$";
        public static string REFLEXIVE = "(с[€ь])$";
        public static string ADJECTIVE = "(ее|ие|ые|ое|ими|ыми|ей|ий|ый|ой|ем|им|ым|ом|его|ого|ему|ому|их|ых|ую|юю|а€|€€|ою|ею)$";
        public static string PARTICIPLE = "((ивш|ывш|ующ)|((?<=[а€])(ем|нн|вш|ющ|щ)))$";
        public static string VERB = "((ила|ыла|ена|ейте|уйте|ите|или|ыли|ей|уй|ил|ыл|им|ым|ен|ило|ыло|ено|€т|ует|уют|ит|ыт|ены|ить|ыть|ишь|ую|ю)|((?<=[а€])(ла|на|ете|йте|ли|й|л|ем|н|ло|но|ет|ют|ны|ть|ешь|нно)))$";
        public static string NOUN = "(а|ев|ов|ие|ье|е|и€ми|€ми|ами|еи|ии|и|ией|ей|ой|ий|й|и€м|€м|ием|ем|ам|ом|о|у|ах|и€х|€х|ы|ь|ию|ью|ю|и€|ь€|€)$";
        public static string RVRE = "^(.*?[аеиоуыэю€])(.*)$";
        public static string DERIVATIONAL = "[^аеиоуыэю€][аеиоуыэю€]+[^аеиоуыэю€]+[аеиоуыэю€].*(?<=о)сть?$";

        public static string PPARTICLE = "(-де|-ка|-либо|-нибудь|-с|-таки|-то)$";
        public static string PPREFIX = "^(кое-)";

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
            word = word.Replace('Є', 'е');

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
                  isReplaced("и$", "");

              //Step 3
                reScript = new Regex(DERIVATIONAL, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    if (isCanReplace(DERIVATIONAL,""))
                    {
                        isReplaced("ость?$","");
                    }

              //Step 4
              if (!isReplaced("ь$",""))
              {
                  isReplaced("ейше?","");
                  isReplaced("нн$", "н");
              }

              stem = start+RV;
            }
            while(false);
            return stem;
    }
}
}
