using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_proj2
{
    static class ConvexHull
    {
        static public Polygon GetConvexHull(Polygon a)
        {
            Polygon output = new Polygon() { Completed = true };
            List<Point> l = ConvexHullf(a.points);
            output.points = l;
            output.FarRight = new Point(a.FarRight.X, a.FarRight.Y);
            return output;
        }

        //https://rosettacode.org/wiki/Convex_hull#C.23
        private static List<Point> ConvexHullf(List<Point> p)
        { 
            if (p.Count == 0) return new List<Point>();
            p.Sort((x, y) => x.Y - y.Y);
            List<Point> h = new List<Point>();

            // lower hull
            foreach (var pt in p)
            {
                while (h.Count >= 2 && !Ccw(h[h.Count - 2], h[h.Count - 1], pt))
                {
                    h.RemoveAt(h.Count - 1);
                }
                h.Add(pt);
            }

            // upper hull
            int t = h.Count + 1;
            for (int i = p.Count - 1; i >= 0; i--)
            {
                Point pt = p[i];
                while (h.Count >= t && !Ccw(h[h.Count - 2], h[h.Count - 1], pt))
                {
                    h.RemoveAt(h.Count - 1);
                }
                h.Add(pt);
            }

            h.RemoveAt(h.Count - 1);
            return h;
        }

        private static bool Ccw(Point a, Point b, Point c)
        {
            return ((b.X - a.X) * (c.Y - a.Y)) > ((b.Y - a.Y) * (c.X - a.X));
        }
    }
}
