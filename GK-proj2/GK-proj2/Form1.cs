using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_proj2
{
    public partial class Form1 : Form
    {
        bool IsMouseDown = false;
        List<Polygon> polygons = new List<Polygon>();
        List<Polygon> MovingPolygons = new List<Polygon>();
        public enum Mode { AddPolygon, Move, Delete, Light }
        Mode CurrentMode;
        Polygon WhichPoly;
        int? WhichPoint;
        Point LightP = new Point(0,0);
        int LightZ = 1;

        public Form1()
        {
            InitializeComponent();

            CurrentMode = Mode.AddPolygon;
            int x = DrawArea.ClientSize.Width;
            MovingPolygons.Add(new Polygon(new Point(200, 200)));
            MovingPolygons[MovingPolygons.Count - 1].points.Add(new Point(250, 250));
            MovingPolygons[MovingPolygons.Count - 1].points.Add(new Point(200, 250));
            MovingPolygons[MovingPolygons.Count - 1].Completed = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void line(int x, int y, int x2, int y2, SolidBrush sb, Graphics g) //https://stackoverflow.com/questions/11678693/all-cases-covered-bresenhams-line-algorithm
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                g.FillRectangle(sb, x, y, 1, 1);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        void drawVertice(Point p, SolidBrush sb, Graphics g)
        {
            for (int i = -3; i <= 3; i++)
                g.FillRectangle(sb, p.X - i, p.Y - 3, 1, 1);
            for (int i = -3; i <= 3; i++)
                g.FillRectangle(sb, p.X - i, p.Y + 3, 1, 1);
            for (int i = -2; i <= 2; i++)
                g.FillRectangle(sb, p.X - 3, p.Y - i, 1, 1);
            for (int i = -3; i <= 3; i++)
                g.FillRectangle(sb, p.X + 3, p.Y - i, 1, 1);
        }

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            foreach (Polygon p in MovingPolygons)
            {

                if (p.Completed)
                {
                    for (int i = 0; i < p.points.Count; i++)
                    {
                        line(p.points[i].X, p.points[i].Y, p.points[(i + 1) % p.points.Count].X, p.points[(i + 1) % p.points.Count].Y, new SolidBrush(Color.Black), e.Graphics);
                    }
                }
                else
                {
                    for (int i = 0; i < p.points.Count - 1; i++)
                    {
                        line(p.points[i].X, p.points[i].Y, p.points[(i + 1) % p.points.Count].X, p.points[(i + 1) % p.points.Count].Y, new SolidBrush(Color.Black), e.Graphics);
                    }
                }
            }



            drawVertice(LightP, new SolidBrush(Color.Red), e.Graphics);
            foreach (Polygon p in polygons)
            {
                //draw poly
                for (int i = 0; i < p.points.Count; i++)
                    drawVertice(p.points[i], new SolidBrush(Color.Black), e.Graphics);

                if (p.Completed)
                {
                    for (int i = 0; i < p.points.Count; i++)
                    {
                        line(p.points[i].X, p.points[i].Y, p.points[(i + 1) % p.points.Count].X, p.points[(i + 1) % p.points.Count].Y, new SolidBrush(Color.Black), e.Graphics);
                    }
                }
                else
                {
                    for (int i = 0; i < p.points.Count - 1; i++)
                    {
                        line(p.points[i].X, p.points[i].Y, p.points[(i + 1) % p.points.Count].X, p.points[(i + 1) % p.points.Count].Y, new SolidBrush(Color.Black), e.Graphics);
                    }
                }
            }
        }

        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            switch (CurrentMode)
            {
                case Mode.AddPolygon:
                    if (polygons.Count != 0)
                    {
                        Polygon p = polygons[polygons.Count - 1];
                        if (p.Completed)
                        {
                            polygons.Add(new Polygon(e.Location));
                        }
                        else
                        {
                            bool Found = false;
                            for (int i = 0; i < polygons[polygons.Count - 1].points.Count && !Found; i++)
                            {
                                if ((Math.Abs(e.X - p.points[i].X) < 10 && Math.Abs(e.Y - p.points[i].Y) < 10))
                                {
                                    Found = true;
                                }
                            }
                            if(p.points.Count >= 3 && Math.Abs(e.X - p.points[0].X) < 10 && Math.Abs(e.Y - p.points[0].Y) < 10)
                            {
                                p.Completed = true;
                            }
                            else
                            {
                                polygons[polygons.Count - 1].points.Add(e.Location);
                            }
                        }
                    }
                    else
                    {
                        polygons.Add(new Polygon(e.Location));
                    }
                    break;
                case Mode.Delete:
                    for (int i = 0; i < polygons.Count; i++)
                    {
                        if(polygons[i].IsInside(e.Location))
                        {
                            polygons.RemoveAt(i);
                            break;
                        }
                    }
                    break;
                case Mode.Move:
                    bool Found1 = false;
                    for (int i = 0; i < polygons.Count && !Found1; i++)
                    {
                        for (int j = 0; j < polygons[i].points.Count && !Found1; j++)
                        {
                            if (Math.Abs(e.X - polygons[i].points[j].X) < 10 && Math.Abs(e.Y - polygons[i].points[j].Y) < 10)
                            {
                                Found1 = true;
                                WhichPoly = polygons[i];
                                WhichPoint = j;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < polygons.Count && !Found1; i++)
                    {
                        if (polygons[i].IsInside(e.Location))
                        {
                            WhichPoly = polygons[i];
                            break;
                        }
                    }
                    break;
                case Mode.Light:
                    LightP = e.Location;
                    break;
            }
            DrawArea.Refresh();
        }

        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            switch(CurrentMode)
            {
                case Mode.Move:
                    if (WhichPoly != null)
                    {
                        if (WhichPoint != null)
                        {
                            WhichPoly.points[(int)WhichPoint] = e.Location;
                            WhichPoly = null;
                            WhichPoint = null;
                        }
                        else
                        {
                            Point middle1 = WhichPoly.Middle();
                            for (int i = 0; i < WhichPoly.points.Count; i++)
                            {
                                WhichPoly.points[i] = new Point(WhichPoly.points[i].X + (e.X - middle1.X), WhichPoly.points[i].Y + (e.Y - middle1.Y));
                            }
                            WhichPoly = null;
                        }
                    }
                    break;
            }
            DrawArea.Refresh();
        }

        private void AddPoly_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.AddPolygon;
        }

        private void DeletePoly_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Delete;
        }

        private void EditPoly_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Move;
        }

        private void LightXY_Click(object sender, EventArgs e)
        {
            CurrentMode = Mode.Light;
        }

        private void StartB_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                StartB.Text = "Start";
                timer1.Stop();
            }
            else
            {
                StartB.Text = "Stop";
                timer1.Start();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (var p in MovingPolygons)
            {
                for (int i = 0; i < p.points.Count; i++)
                {
                    p.points[i] = new Point(p.points[i].X - 1, p.points[i].Y); 
                }
            }
            DrawArea.Refresh();
        }

        private void SpeedC_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)SpeedC.Value;
        }

        private void LightZC_ValueChanged(object sender, EventArgs e)
        {
            LightZ = (int)LightZC.Value;
        }
    }
}
