using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Athelas
{
    class Point
    {
        public int id_text = 0;
        public ArrayList coord = new ArrayList();
        public void Set(Point p)
        {
            coord = new ArrayList(p.coord);
            id_text = p.id_text;
        }
        public Point(ArrayList coords, int id)
        {
            coord = new ArrayList(coords);
            id_text = id;
        }
        public Point()
        {
            coord = new ArrayList();
            id_text = 0;
        }
        public double GetDistance(Point p)
        {
            double chisl = 0;
            double len1 = 0;
            double len2 = 0;
            for (int i = 0; i < p.coord.Count; i++)
            {
                double x1 = (double)coord[i];
                double x2 = (double)p.coord[i];
                if (x1 == 0 && x2 == 0)
                    continue;
                chisl += x1 * x2;
                len1 += x1 * x1;
                len2 += x2 * x2;
            }
            double znam = (double)Math.Sqrt(len1 * len2);
            if (znam == 0)
                return 0;
            return chisl / znam;            
        }
    }
}
