using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_proj2
{
    static class WeilerAthertonClip
    {
        public static List<Polygon> GetClippedPolygons(Polygon Clip, Polygon Subject)
        {
            List<Polygon> output = new List<Polygon>();
            CircularLinkedList<Vector2> SubjectL = new CircularLinkedList<Vector2>();
            CircularLinkedList<Vector2> ClipL = new CircularLinkedList<Vector2>();
            //todo check if subject inside clip
            bool AllPointsInside = true;
            for (int i = 0; i < Subject.points.Count; i++)
            {
                if (!Clip.IsInside(Subject.points[i]))
                {
                    AllPointsInside = false;
                    break;
                }
            }
            if (AllPointsInside)
            {
                output.Add(Subject);
                return output;
            }
            for (int i = 0; i < Clip.points.Count; i++)
            {
                ClipL.AddLast(new Vector2(Clip.points[i].X, Clip.points[i].Y));
            }
            for (int i = 0; i < Subject.points.Count; i++)
            {
                SubjectL.AddLast(new Vector2(Subject.points[i].X, Subject.points[i].Y));
            }
            List<CircularLinkedList<Vector2>> result = (List<CircularLinkedList<Vector2>>)WeilerAtherton.Process(SubjectL, ClipL, Operation.Intersect, Clip, Subject);
            for (int i = 0; i < result.Count; i++)
            {
                output.Add(new Polygon() { Completed = true });
                List<Vector2> temp = result[i].ToList<Vector2>();
                for (int j = 0; j < temp.Count; j++)
                {
                    output[output.Count - 1].Add(new Point((int)temp[j].X, (int)temp[j].Y));
                }
            }
            return output;
        }
    }
}
