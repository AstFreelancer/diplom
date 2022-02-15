using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Athelas
{
    class Cluster
    {
        public bool isActive = true;
        public ArrayList points = new ArrayList();
        public Point avgPoint = new Point();
        public bool isEmpty()
        {
            if (points.Count > 0)
                return false;
            return true;
        }

        public bool isEqual(Cluster cl)
        {//одинаковы если один и тот же состав точек
            if (points.Count != cl.points.Count)
                return false;
            foreach (Point p in points)
                if (!cl.points.Contains((int)p.id_text))
                    return false;
            return true;
        }

        public ArrayList GetImpTerms(int n, ArrayList maxCoord)
        {
            //номера n слов с наибольшим весом
            ArrayList id_coords = new ArrayList();
            //double mnozh = 0.9;
            //while (mnozh > 0)
            //{
            //    int i;
            //    for (i = 0; i < avgPoint.coord.Count; i++)
            //    {
            //        if (id_coords.Contains(i))
            //            continue;
            //        if ((double)avgPoint.coord[i] > (mnozh * (double)maxCoord[i]))
            //            id_coords.Add(i);
            //        if (id_coords.Count >= n)
            //            return id_coords;
            //    }
            //    mnozh -= 0.1;
            //}
            double max = 0.0;
            int pos = -1;
            for (int i = 0; i < avgPoint.coord.Count; i ++)
                if ((double)avgPoint.coord[i] > max)
                {
                    max = (double)avgPoint.coord[i];
                    pos = i;
                }
            id_coords.Add(pos);
            return id_coords;
        }
        public void CalculateAverage(Point maxCoord)
        {
            int i, j;
            if (points.Count == 0)
            {
                for (i = 0; i < maxCoord.coord.Count; i++)
                {
                    Random rand = new Random(DateTime.Now.Millisecond);
                    avgPoint.coord[i] = rand.NextDouble() * (double)maxCoord.coord[i];
                }
                return;
            }
            Point sum = new Point();
            for (i = 0; i < maxCoord.coord.Count; i++)
                sum.coord.Add(0.0);

            foreach (Point p in points)
            {
                for (j = 0; j < p.coord.Count; j++)
                    sum.coord[j] = (double)sum.coord[j] + (double)p.coord[j];
            }
            int count = points.Count;
            for (i = 0; i < maxCoord.coord.Count; i++)
                avgPoint.coord[i] = (double)sum.coord[i] / (double)count;
        }
        public void SetAvgPoint(Point p)
        {
            avgPoint.Set(p);
        }
        public void AddPoint(Point p)
        {
            points.Add(p);
        }
    }
}
