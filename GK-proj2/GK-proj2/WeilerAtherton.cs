using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GK_proj2
{
    enum Operation
    {
        Union,
        Intersect,
        Difference
    }

    struct Pair<T> : IEquatable<Pair<T>>
    {
        readonly T first;
        readonly T second;

        public Pair(T first, T second)
        {
            this.first = first;
            this.second = second;
        }

        public T First { get { return first; } }
        public T Second { get { return second; } }

        public override int GetHashCode()
        {
            return first.GetHashCode() ^ second.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals((Pair<T>)obj);
        }

        public bool Equals(Pair<T> other)
        {
            return other.first.Equals(first) && other.second.Equals(second) ||
                    other.first.Equals(second) && other.second.Equals(first);
        }
    }

    //https://github.com/Skybladev2/Weiler-Atherton

    class WeilerAtherton
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject">Первый контур.</param>
        /// <param name="clip">Второй контур.</param>
        /// <param name="operation">Операция, проводимая над контурами.</param>
        /// <returns></returns>
        public static ICollection<CircularLinkedList<Vector2>> Process(CircularLinkedList<Vector2> subject,
                                                                        CircularLinkedList<Vector2> clip,
                                                                        Operation operation,
                                                                        Polygon ClipP,
                                                                        Polygon SubjectP)
        {
            LinkedListNode<Vector2> curSubject = subject.First;
            Dictionary<Vector2, Pair<Vector2>> intersections = new Dictionary<Vector2, Pair<Vector2>>();
            List<CircularLinkedList<Vector2>> polygons = new List<CircularLinkedList<Vector2>>();

            if (AreEqual<Vector2>(subject, clip))
            {
                switch (operation)
                {
                    case Operation.Union:
                        polygons.Add(subject);
                        return polygons;
                    case Operation.Intersect:
                        polygons.Add(subject);
                        return polygons;
                    case Operation.Difference:
                        // нужно как-то разграничивать внешние и внутренние полигоны
                        return polygons;
                    default:
                        break;
                }
            }

            do
            {
                LinkedListNode<Vector2> curClip = clip.First;
                do
                {
                    Vector2 intersectionPoint;
                    if (IntersectSegment(curSubject.Value,
                                        subject.NextOrFirst(curSubject).Value,
                                        curClip.Value,
                                        clip.NextOrFirst(curClip).Value,
                                        out intersectionPoint))
                    {
                        if (!intersections.ContainsKey(intersectionPoint))
                        {
                            subject.AddAfter(curSubject, intersectionPoint);
                            clip.AddAfter(curClip, intersectionPoint);
                            intersections.Add(intersectionPoint, new Pair<Vector2>(curClip.Value, clip.NextOrFirst(curClip).Value));
                        }
                    }
                    curClip = clip.NextOrFirst(curClip);
                }
                while (curClip != clip.First);

                curSubject = subject.NextOrFirst(curSubject);
            }
            while (curSubject != subject.First);


            CircularLinkedList<Vector2> entering = new CircularLinkedList<Vector2>();
            CircularLinkedList<Vector2> exiting = new CircularLinkedList<Vector2>();
            
            MakeEnterExitList(subject, clip, intersections, entering, exiting, ClipP, SubjectP);

            Traverse(subject, clip, entering, exiting, polygons, operation);

            return polygons;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static bool AreEqual<T>(LinkedList<T> a, LinkedList<T> b) where T : IEquatable<T>
        {
            if (a.Count != b.Count)
            {
                return false;
            }

            LinkedListNode<T> currA = a.First;
            LinkedListNode<T> currB = b.First;

            while (currA != null)
            {
                if (!currA.Value.Equals(currB.Value))
                    return false;

                currA = currA.Next;
                currB = currB.Next;
            }

            return true;
        }

        public static void Swap<T>(ref T left, ref T right) where T : class
        {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }

        private static void Traverse(CircularLinkedList<Vector2> subject,
                                        CircularLinkedList<Vector2> clip,
                                        CircularLinkedList<Vector2> entering,
                                        CircularLinkedList<Vector2> exiting,
                                        List<CircularLinkedList<Vector2>> polygons,
                                        Operation operation)
        {
            while (entering.Count > 0)
            {
                CircularLinkedList<Vector2> polygon = new CircularLinkedList<Vector2>();
                Vector2 start = entering.First.Value;
                LinkedListNode<Vector2> curNode = subject.Find(start);
                polygon.AddLast(curNode.Value);
                curNode = subject.NextOrFirst(curNode);
                bool IsSubjectNode = true;
                while (curNode.Value != start)
                {
                    polygon.AddLast(curNode.Value);
                    if (entering.Contains(curNode.Value))
                    {
                        entering.Remove(curNode.Value);
                        IsSubjectNode = true;
                        curNode = subject.Find(curNode.Value);
                    }
                    if (exiting.Contains(curNode.Value))
                    {
                        exiting.Remove(curNode.Value);

                        IsSubjectNode = false;
                        curNode = clip.Find(curNode.Value);
                    }
                    if (IsSubjectNode) 
                    {
                        curNode = subject.NextOrFirst(curNode);
                    }
                    else
                    {
                        curNode = clip.NextOrFirst(curNode);
                    }
                }
                entering.Remove(curNode.Value);
                polygons.Add(polygon);
            }
        }

        private static LinkedListNode<Vector2> TraverseList(CircularLinkedList<Vector2> contour,
                                                            CircularLinkedList<Vector2> entering,
                                                            CircularLinkedList<Vector2> exiting,
                                                            CircularLinkedList<Vector2> polygon,
                                                            LinkedListNode<Vector2> currentNode,
                                                            Vector2 startNode,
                                                            CircularLinkedList<Vector2> contour2)
        {
            LinkedListNode<Vector2> contourNode = contour.Find(currentNode.Value);
            if (contourNode == null)
                return null;

            entering.Remove(currentNode.Value);

            while (contourNode != null
                    &&
                        !entering.Contains(contourNode.Value)
                        &&
                        !exiting.Contains(contourNode.Value)
                    )
            {
                polygon.AddLast(contourNode.Value);
                contourNode = contour.NextOrFirst(contourNode);

                if (contourNode.Value == startNode)
                    return null;
            }

            entering.Remove(contourNode.Value);
            polygon.AddLast(contourNode.Value);

            return contour2.NextOrFirst(contour2.Find(contourNode.Value));
        }

        private static void MakeEnterExitList(CircularLinkedList<Vector2> subject,
                                                CircularLinkedList<Vector2> clip,
                                                Dictionary<Vector2, Pair<Vector2>> intersections,
                                                CircularLinkedList<Vector2> entering,
                                                CircularLinkedList<Vector2> exiting,
                                                Polygon ClipP,
                                                Polygon SbujectP)
        {
            LinkedListNode<Vector2> curr = subject.First;
            do
            {
                if (intersections.ContainsKey(curr.Value))
                {
                    bool isEntering = Vector2Cross(subject.NextOrFirst(curr).Value.X - subject.PreviousOrLast(curr).Value.X,
                                              subject.NextOrFirst(curr).Value.Y - subject.PreviousOrLast(curr).Value.Y,
                                              intersections[curr.Value].Second.X - intersections[curr.Value].First.X,
                                              intersections[curr.Value].Second.Y - intersections[curr.Value].First.Y) < 0;
                    if (isEntering)
                        entering.AddLast(curr.Value);
                    else
                        exiting.AddLast(curr.Value);
                }

                curr = subject.NextOrFirst(curr);
            } while (curr != subject.First);
        }

        private static float Vector2Cross(float x1, float y1, float x2, float y2)
        {
            return x1 * y2 - x2 * y1;
        }

        public static bool IntersectSegment(Vector2 start1, Vector2 end1, Vector2 start2, Vector2 end2, out Vector2 intersection)
        {
            
            //addIntersection = true;
            Vector2 dir1 = end1 - start1;
            Vector2 dir2 = end2 - start2;

            //считаем уравнения прямых проходящих через отрезки
            float a1 = -dir1.Y;
            float b1 = +dir1.X;
            float d1 = -(a1 * start1.X + b1 * start1.Y);

            float a2 = -dir2.Y;
            float b2 = +dir2.X;
            float d2 = -(a2 * start2.X + b2 * start2.Y);

            //подставляем концы отрезков, для выяснения в каких полуплоскотях они
            float seg1_line2_start = a2 * start1.X + b2 * start1.Y + d2;
            float seg1_line2_end = a2 * end1.X + b2 * end1.Y + d2;

            float seg2_line1_start = a1 * start2.X + b1 * start2.Y + d1;
            float seg2_line1_end = a1 * end2.X + b1 * end2.Y + d1;

            //если концы одного отрезка имеют один знак, значит он в одной полуплоскости и пересечения нет.
            if (seg1_line2_start * seg1_line2_end >= 0 || seg2_line1_start * seg2_line1_end >= 0)
            {
                intersection = Vector2.Zero;
                return false;
            }

            float u = seg1_line2_start / (seg1_line2_start - seg1_line2_end);
            intersection = start1 + u * dir1;

            return true;
            
        }
    }
}
