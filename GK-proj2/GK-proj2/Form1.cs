using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        Point LightP = new Point(10,10);
        double LightZ = 100D;
        Color LightColor = Color.White;
        Bitmap map;
        Bitmap Texture;
        Bitmap NormalMap;

        public Form1()
        {
            InitializeComponent();

            ColorPicker.BackColor = Color.White;
            Texture = new Bitmap(GK_proj2.Properties.Resources.Texture);
            NormalMap = new Bitmap(GK_proj2.Properties.Resources.bumpMap);
            this.DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, DrawArea, new object[] { true });
            map = new Bitmap(DrawArea.Width, DrawArea.Height);
            CurrentMode = Mode.AddPolygon;
            openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            //MovingPolygons.Add(new Polygon(new Point(100, 100)));
            //MovingPolygons[MovingPolygons.Count - 1].Add(new Point(500, 500));
            //MovingPolygons[MovingPolygons.Count - 1].Add(new Point(100, 500));
            //MovingPolygons[MovingPolygons.Count - 1].Completed = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void line(int x, int y, int x2, int y2, Color c) //https://stackoverflow.com/questions/11678693/all-cases-covered-bresenhams-line-algorithm
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
                DrawPixel(x, y, c);
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

        void DrawPixel(int x, int y, Color c)
        {
            if (x >= map.Width || y >= map.Height || x < 0 || y < 0) return;
            map.SetPixel(x, y, c);
        }

        void drawVertice(Point p, Color c)
        {
            for (int i = -3; i <= 3; i++)
                DrawPixel(p.X - i, p.Y - 3, c);
            for (int i = -3; i <= 3; i++)
                DrawPixel(p.X - i, p.Y + 3, c);
            for (int i = -2; i <= 2; i++)
                DrawPixel(p.X - 3, p.Y - i, c);
            for (int i = -3; i <= 3; i++)
                DrawPixel(p.X + 3, p.Y - i, c);
        }

        class EdgePointer
        {
            public int ymax;
            public double x;
            public double m;
            public EdgePointer next;

            public EdgePointer(int ymax, double x, double m, EdgePointer next)
            {
                this.ymax = ymax;
                this.x = x;
                this.m = m;
                this.next = next;
            }
        }

        void FillPoly(Polygon p)
        {
            EdgePointer[] ET = new EdgePointer[2000];
            int ymin, ymax, x, ystart = p.points[0].Y;
            double m;
            int count = p.points.Count;
            for (int i = 0; i < p.points.Count; i++)
            {
                ymin = p.points[i].Y;
                ymax = p.points[(i + 1) % p.points.Count].Y;
                x = p.points[i].X;
                m = (double)(ymin - ymax) / (double)(x - p.points[(i + 1) % p.points.Count].X);
                m = 1 / m;
                if (ymax < ymin)
                {
                    int t = ymin;
                    ymin = ymax;
                    ymax = t;
                    x = p.points[(i + 1) % p.points.Count].X;
                }
                else if (ymax == ymin)
                {
                    count--;
                    continue;
                }
                if (ET[ymin] == null) ET[ymin] = new EdgePointer(ymax, x, m, null);
                else
                {
                    EdgePointer pt = ET[ymin];
                    while (pt.next != null)
                        pt = pt.next;
                    pt.next = new EdgePointer(ymax, x, m, null);
                }
                if (ystart > ymin) ystart = ymin;
            }

            List<EdgePointer> AET = new List<EdgePointer>();
            while ((count != 0 || AET.Count != 0) && ystart < DrawArea.Height)
            {
                EdgePointer pty = ET[ystart];
                while (pty != null)
                {
                    AET.Add(pty);
                    pty = pty.next;
                    count--;
                }
                AET.Sort((x1, x2) => (int)(x1.x - x2.x));
                for (int i = 0; i < AET.Count; i += 2)
                {
                    int xa1 = (int)AET[i].x + 1;
                    int xa2 = (int)AET[i + 1].x;
                    if (InterpolationCheckBox.Checked)
                    {
                        Color Left = GetColor(xa1, ystart);
                        Color Right = GetColor(xa2, ystart);
                        DrawPixel(xa1, ystart, Left);
                        DrawPixel(xa2, ystart, Right);
                        for (int j = xa1 + 1; j < xa2; j++)
                        {
                            DrawPixel(j, ystart, InterpolateColor(xa1, xa2, j, Left, Right));
                        }
                    }
                    else
                    {
                        for (int j = xa1; j <= xa2; j++)
                        {
                            DrawPixel(j, ystart, GetColor(j, ystart));
                        }
                    }
                }
                ystart++;
                AET.RemoveAll(x1 => x1.ymax == ystart);
                foreach (var e in AET)
                {
                    e.x += e.m;
                }
            }
        }

        Color InterpolateColor(int x1, int x2, int x, Color Left, Color Right)
        {
            double ratio = (double)Math.Abs(x - x1) / Math.Abs(x1 - x2);
            double ratio2 = 1D - ratio;
            return Color.FromArgb((int)(Left.R * ratio2 + Right.R * ratio) % 255, (int)(Left.G * ratio2 + Right.G * ratio) % 255, (int)(Left.B * ratio2 + Right.B * ratio) % 255);
        }

        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            map = new Bitmap(DrawArea.Width, DrawArea.Height);

            foreach (Polygon p in MovingPolygons)
            {
                if (FillMoving.Checked) 
                    FillPoly(p);
                if (p.Completed)
                {
                    for (int i = 0; i < p.points.Count; i++)
                    {
                        line(p.points[i].X, p.points[i].Y, p.points[(i + 1) % p.points.Count].X, p.points[(i + 1) % p.points.Count].Y, Color.Black);
                    }
                }
                else
                {
                    for (int i = 0; i < p.points.Count - 1; i++)
                    {
                        line(p.points[i].X, p.points[i].Y, p.points[(i + 1) % p.points.Count].X, p.points[(i + 1) % p.points.Count].Y, Color.Black);
                    }
                }
            }

            foreach (Polygon p in polygons)
            {
                if (FillStatic.Checked)
                    FillPoly(p);
                for (int i = 0; i < p.points.Count; i++)
                    drawVertice(p.points[i], Color.Black);

                if (p.Completed)
                {
                    for (int i = 0; i < p.points.Count; i++)
                    {
                        line(p.points[i].X, p.points[i].Y, p.points[(i + 1) % p.points.Count].X, p.points[(i + 1) % p.points.Count].Y, Color.Black);
                    }
                }
                else
                {
                    for (int i = 0; i < p.points.Count - 1; i++)
                    {
                        line(p.points[i].X, p.points[i].Y, p.points[(i + 1) % p.points.Count].X, p.points[(i + 1) % p.points.Count].Y, Color.Black);
                    }
                }
            }
            if (ClipCheckbox.Checked)
                foreach (Polygon p1 in polygons)
                {
                    foreach (Polygon p2 in MovingPolygons)
                    {
                        foreach (Polygon p3 in WeilerAthertonClip.GetClippedPolygons(p1, p2))
                        {
                            FillPoly(p3);
                        }
                    }
                }
            drawVertice(LightP, Color.Red);



            e.Graphics.DrawImage(map, 0, 0);
        }

        Color GetColor(int x, int y)
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            Color TC = Texture.GetPixel(x % Texture.Width, y % Texture.Height);
            double r = TC.R / 255D;
            double g = TC.G / 255D;
            double b = TC.B / 255D;
            Color N = NormalMap.GetPixel(x % NormalMap.Width, y % NormalMap.Height);
            Color NX = NormalMap.GetPixel((x + 1) % NormalMap.Width, y % NormalMap.Height);
            Color NY = NormalMap.GetPixel(x % NormalMap.Width, (y + 1) % NormalMap.Height);
            double DX = (NX.R - N.R) / 255D;
            double DY = (NY.R - N.R) / 255D;
            double DZ = 1D;
            double DLength = Math.Sqrt(DX * DX + DY * DY + 1);
            DX /= DLength;
            DY /= DLength;
            DZ /= DLength;
            double ToLightX = LightP.X - x;
            double ToLightY = LightP.Y - y;
            double ToLightZ = LightZ;
            double ToLightLength = Math.Sqrt(ToLightX * ToLightX + ToLightY * ToLightY + ToLightZ * ToLightZ);
            ToLightX /= ToLightLength;
            ToLightY /= ToLightLength;
            ToLightZ /= ToLightLength;
            double cos = DX * ToLightX + DY * ToLightY + DZ * ToLightZ;

            r = r * (LightColor.R / 255D) * cos;
            g = g * (LightColor.G / 255D) * cos;
            b = b * (LightColor.B / 255D) * cos;
            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;
            return Color.FromArgb((int)(r * 255D) % 255, (int)(g * 255D) % 255, (int)(b * 255D) % 255);
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
            List<Polygon> ToDelete = new List<Polygon>();
            for (int j = 0; j < MovingPolygons.Count; j++)
            {
                for (int i = 0; i < MovingPolygons[j].points.Count; i++)
                {
                    MovingPolygons[j].points[i] = new Point(MovingPolygons[j].points[i].X - 1, MovingPolygons[j].points[i].Y);
                }
                MovingPolygons[j].FarRight = new Point(MovingPolygons[j].FarRight.X - 1, MovingPolygons[j].FarRight.Y);
                if (MovingPolygons[j].FarRight.X < 0)
                    ToDelete.Add(MovingPolygons[j]);
            }
            foreach (var p in ToDelete)
            {
                MovingPolygons.Remove(p);
            }
            DrawArea.Refresh();
        }

        private void SpeedC_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)SpeedC.Value;
        }

        private void LightZC_ValueChanged(object sender, EventArgs e)
        {
            LightZ = (double)LightZC.Value;
            DrawArea.Refresh();
        }

        private void SpawnPolyB_Click(object sender, EventArgs e)
        {
            int w = DrawArea.ClientSize.Width;
            int h = DrawArea.ClientSize.Height;
            Polygon mp = new Polygon();
            mp.Completed = true;
            Random r = new Random();
            int y = r.Next(0, h - 100);
            mp.Add(new Point(r.Next(w, w + 200), r.Next(y, y + 200)));
            for (; mp.points.Count < 15;)
                mp.Add(new Point(r.Next(w, w + 200), r.Next(y, y + 200)));
            MovingPolygons.Add(ConvexHull.GetConvexHull(mp));
        }

        private void ColorPicker_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                ColorPicker.BackColor = colorDialog1.Color;
                LightColor = colorDialog1.Color;
            }
            DrawArea.Refresh();
        }

        private void PickTexture_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Texture = new Bitmap(openFileDialog1.FileName);
            }
            DrawArea.Refresh();
        }

        private void PickBumpMap_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                NormalMap = new Bitmap(openFileDialog1.FileName);
            }
            DrawArea.Refresh();
        }
    }
}
