using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Athelas
{
    class Results
    {
        public ArrayList res = new ArrayList();
        public Results()
        {
            res = new ArrayList();
        }

        public void Add(Snippet r)
        {
            res.Add(r);
        }
        public Snippet Get(int i)
        {
            return (Snippet)res[i];
        }
        public string GetNameById(int i)
        {
            foreach (Snippet r in res)
                if (r.id == i)
                    return r.docname;
            return "";
        }
        public ArrayList GetIdListFound()
        {
            ArrayList list = new ArrayList();
            foreach (Snippet r in res)
                list.Add(r.id);
            return list;
        }
        public void SetIdCl(int id_text, int id_cl)//сниппету id_text присвоить номер кластера i
        {
            foreach (Snippet r in res)
                if (r.id == id_text)
                    r.idcl = id_cl;
        }
        public ArrayList GetPage(int page, ArrayList idActiveClusters)
        {
            ArrayList activeres = new ArrayList();
            if (idActiveClusters.Count < 1)
            //еще ничего не поделили на кластеры, значит выводим все
                activeres = new ArrayList(res);
            else
            //выбрать только сниппеты активных кластеров
            {
                foreach (Snippet snip in res)
                {
                    if (idActiveClusters.Contains(snip.idcl))
                        activeres.Add(snip);
                }
            }
            int b = (page - 1) * 10;
            int e = 10;
            if (b < activeres.Count && b >= 0)
            {
                if ((b + e) <= activeres.Count)
                    return activeres.GetRange(b, 10);
                else
                    return activeres.GetRange(b, activeres.Count - b);
            }
            ArrayList smth = new ArrayList(); smth.Clear();
            return smth;
        }
        
    }
}
