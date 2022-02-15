using System;
using System.Collections.Generic;
using System.Text;

namespace Athelas
{
    class TermEntry
    {
        public int id_text;
        public int id_term;
        public int EntriesNumber = 0;
        public double TF = 0.0;
        public double IDF = 0.0;
        public TermEntry(int idt, int idtm,int n)
        {
            id_text = idt;
            id_term = idtm;
            EntriesNumber = n;
        }
    }
}
