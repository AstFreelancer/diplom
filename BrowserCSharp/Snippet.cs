using System;
using System.Collections.Generic;
using System.Text;

namespace Athelas
{
    class Snippet
    {
        public int id;
        public string docname;
        public string url;
        public int docsize;
        public int tcy;
        public int gpr;
        public DateTime date;
        public int idcl;//id of cluster
        public string text = "";
        public int termsnumber = 0;

        public Snippet(int i, string d, string u, int ds, int t,int g, DateTime dt,int idcl1)
        {
            id = i;
            docname = d;
            tcy = t;
            gpr = g;
            date = dt;
            idcl = idcl1;
            text = "";
            if (docname.Length<3)
                docname = u;
            else
            {
                int ind = docname.LastIndexOf("\\");
                if (ind != -1)
                    docname = docname.Substring(ind + 1, docname.Length - (ind + 1));
            }
            url = u;
            docsize = ds;
            //if (docsize < 1000)
            //    docsize = 1;
            //else
            //    docsize /= 1000;
        }
    }
}
