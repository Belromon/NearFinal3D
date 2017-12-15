using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Side
    {
        List<Line> linesOfEdge;
        bool visiable = false;
        public Point pointCenter = new Point();

        public static Color curColor;
        public Color colorEdge;
        double angle;
        public static bool isFill;
        public static bool isLight;
        public static Point lightPoint = new Point(0, 0, 0);

        public Side() { }

        public Side(List<Line> lines)
        {
            linesOfEdge = lines;
        }

        public void SetVisiableFirstCyl()
        {
            Point vectorA = new Point();
            Point vectorB = new Point();
            Point normal = new Point();
            Point viewpoint = new Point();
            double normalLight, viewpointLight, angle;


            vectorA.X = linesOfEdge[0]._point2.X - linesOfEdge[0]._point1.X;
            vectorA.Y = linesOfEdge[0]._point2.Y - linesOfEdge[0]._point1.Y;
            vectorA.Z = linesOfEdge[0]._point2.Z - linesOfEdge[0]._point1.Z;

            vectorB.X = linesOfEdge[0]._point2.X - linesOfEdge[1]._point2.X;
            vectorB.Y = linesOfEdge[0]._point2.Y - linesOfEdge[1]._point2.Y;
            vectorB.Z = linesOfEdge[0]._point2.Z - linesOfEdge[1]._point2.Z;

            normal.X = vectorA.Y * vectorB.Z - vectorA.Z * vectorB.Y;
            normal.Y = vectorA.X * vectorB.Z - vectorA.Z * vectorB.X;
            normal.Z = vectorA.X * vectorB.Y - vectorA.Y * vectorB.X;

            viewpoint.X = 0; viewpoint.Y = 0; viewpoint.Z = -1000;

            normalLight = Math.Sqrt(Math.Pow(normal.X, 2) + Math.Pow(normal.Y, 2) + Math.Pow(normal.Z, 2));

            viewpointLight = Math.Sqrt(Math.Pow(viewpoint.X, 2) + Math.Pow(viewpoint.Y, 2) + Math.Pow(viewpoint.Z, 2));

            if (normalLight == 0 || viewpointLight == 0)
                angle = -1;
            else
                angle = (normal.X * viewpoint.X + normal.Y * viewpoint.Y + normal.Z * viewpoint.Z) / (normalLight * viewpointLight);

            visiable = (angle > 0);

            SetCurColor();

            if (isLight)
            {

                viewpointLight = Math.Sqrt(Math.Pow(lightPoint.X, 2) + Math.Pow(lightPoint.Y, 2) + Math.Pow(lightPoint.Z, 2));

                normalLight = normalLight == 0 ? 0.0001 : normalLight;
                viewpointLight = viewpointLight == 0 ? 0.0001 : viewpointLight;

                angle = (normal.X * lightPoint.X + normal.Y * lightPoint.Y + normal.Z * lightPoint.Z) / (normalLight * viewpointLight);

                //angle = angle <= 0 ? -1 : angle;

                colorEdge = Color.FromArgb((int)(curColor.R * (0.5 + 0.5 * angle)),
                    (int)(curColor.G * (0.5 + 0.5 * angle)),
                    (int)(curColor.B * (0.5 + 0.5 * angle)));
            }
            else
            {
                colorEdge = curColor;
            }
        }

        public void SetVisiableSecondCyl()
        {
            Point vectorA = new Point();
            Point vectorB = new Point();
            Point normal = new Point();
            Point viewpoint = new Point();
            double normalLight, viewpointLight, angle;

            vectorA.X = linesOfEdge[0]._point1.X - linesOfEdge[0]._point2.X;
            vectorA.Y = linesOfEdge[0]._point1.Y - linesOfEdge[0]._point2.Y;
            vectorA.Z = linesOfEdge[0]._point1.Z - linesOfEdge[0]._point2.Z;

            vectorB.X = linesOfEdge[0]._point2.X - linesOfEdge[1]._point2.X;
            vectorB.Y = linesOfEdge[0]._point2.Y - linesOfEdge[1]._point2.Y;
            vectorB.Z = linesOfEdge[0]._point2.Z - linesOfEdge[1]._point2.Z;

            normal.X = vectorA.Y * vectorB.Z - vectorA.Z * vectorB.Y;
            normal.Y = vectorA.X * vectorB.Z - vectorA.Z * vectorB.X;
            normal.Z = vectorA.X * vectorB.Y - vectorA.Y * vectorB.X;

            viewpoint.X = 0; viewpoint.Y = 0; viewpoint.Z = -1000;

            normalLight = Math.Sqrt(Math.Pow(normal.X, 2) + Math.Pow(normal.Y, 2) + Math.Pow(normal.Z, 2));

            viewpointLight = Math.Sqrt(Math.Pow(viewpoint.X, 2) + Math.Pow(viewpoint.Y, 2) + Math.Pow(viewpoint.Z, 2));

            if (normalLight == 0 || viewpointLight == 0)
                angle = -1;
            else
                angle = (normal.X * viewpoint.X + normal.Y * viewpoint.Y + normal.Z * viewpoint.Z) / (normalLight * viewpointLight);

            visiable = (angle > 0);

            SetCurColor();

            if (isLight)
            {

                viewpointLight = Math.Sqrt(Math.Pow(lightPoint.X, 2) + Math.Pow(lightPoint.Y, 2) + Math.Pow(lightPoint.Z, 2));

                normalLight = normalLight == 0 ? 1 : normalLight;
                viewpointLight = viewpointLight == 0 ? 1 : viewpointLight;

                angle = (normal.X * lightPoint.X + normal.Y * lightPoint.Y + normal.Z * lightPoint.Z) / (normalLight * viewpointLight);

                colorEdge = Color.FromArgb((int)(curColor.R * (0.5 + 0.5 * angle)),
                    (int)(curColor.G * (0.5 + 0.5 * angle)),
                    (int)(curColor.B * (0.5 + 0.5 * angle)));
            }
            else
            {
                colorEdge = curColor;
            }
        }

        public void SetCurColor()
        {
            if (!isFill)
                curColor = Color.White;
        }

        public Color GetCurColor()
        {
            return colorEdge;
        }

        public void EdgeCenter()
        {
            pointCenter = new Point();
            double xSum = 0, ySum = 0, zSum = 0;


            for (int i = 0; i < linesOfEdge.Count; i++)
            {
                xSum += linesOfEdge[i]._point1.X;
                ySum += linesOfEdge[i]._point1.Y;
                zSum += linesOfEdge[i]._point1.Z;
                xSum += linesOfEdge[i]._point2.X;
                ySum += linesOfEdge[i]._point2.Y;
                zSum += linesOfEdge[i]._point2.Z;
            }
            if (linesOfEdge.Count > 2)
            {
                pointCenter.X = xSum / linesOfEdge.Count / 2;
                pointCenter.Y = ySum / linesOfEdge.Count / 2;
                pointCenter.Z = zSum / linesOfEdge.Count / 2;
            }
            else
            {
                pointCenter.X = xSum / linesOfEdge.Count;
                pointCenter.Y = ySum / linesOfEdge.Count;
                pointCenter.Z = zSum / linesOfEdge.Count;
            }

        }

        public bool GetVisiable()
        {
            return visiable;
        }

        public static List<Side> SetEdgesAll(List<Line> linesOfCyl, List<Line> linesOfPr)
        {
            List<Side> edges = new List<Side>();
            int countCyl = linesOfCyl.Count;
            int countPr = linesOfPr.Count;
            List<Line> lines = new List<Line>();

            for (int i = 0; i < countPr / 3; i++)
            {
                lines.Add(linesOfPr[i]);
            }
            for (int i = 0; i < countCyl / 3; i++)
            {
                lines.Add(linesOfCyl[i]);
            }
            edges.Add(new Side() { linesOfEdge = lines });
            edges[0].SetVisiableFirstCyl();
            lines = new List<Line>();

            for (int i = countPr / 3; i < countPr / 3 * 2; i++)
            {
                lines.Add(linesOfPr[i]);
            }
            for (int i = countCyl / 3; i < countCyl / 3 * 2; i++)
            {
                lines.Add(linesOfCyl[i]);
            }
            edges.Add(new Side() { linesOfEdge = lines });
            edges[1].SetVisiableSecondCyl();
            lines = new List<Line>();

            for (int i = countPr / 3 * 2; i < countPr - 1; i++)
            {
                lines.Add(linesOfPr[i]);
                lines.Add(linesOfPr[i + 1]);
                edges.Add(new Side() { linesOfEdge = lines});
                lines = new List<Line>();
            }
            lines.Add(linesOfPr[countPr - 1]);
            lines.Add(linesOfPr[countPr / 3 * 2]);
            edges.Add(new Side() { linesOfEdge = lines});
            for (int i = 2; i < countPr / 3 + 2; i++)
            {
                edges[i].SetVisiableFirstCyl();
            }
            lines = new List<Line>();

            if (countCyl > 0)
            {
                for (int i = countCyl / 3 * 2; i < countCyl - 1; i++)
                {
                    lines.Add(linesOfCyl[i]);
                    lines.Add(linesOfCyl[i + 1]);
                    edges.Add(new Side() { linesOfEdge = lines});
                    lines = new List<Line>();
                }
                lines.Add(linesOfCyl[countCyl - 1]);
                lines.Add(linesOfCyl[countCyl / 3 * 2]);
                edges.Add(new Side() { linesOfEdge = lines});
                for (int i = countPr / 3 + 2; i < countCyl / 3 + countPr / 3 + 2; i++)
                {
                    edges[i].SetVisiableSecondCyl();
                }
                lines = new List<Line>();
            }

            return edges;
        }
        public static PointF[] GetPointsFAll(Side edge)
        {
            PointF[] points;
            // int x0 = 456, y0 = 324;

            if (edge.linesOfEdge.Count >=3 )
            {
                points = new PointF[edge.linesOfEdge.Count + 2];
                for (int i = 0; i < 3; i++)
                {
                    points[i].X = (float)edge.linesOfEdge[i]._point1.X;
                    points[i].Y = (float)edge.linesOfEdge[i]._point1.Y;
                }
                points[3].X = (float)edge.linesOfEdge[0]._point1.X;
                points[3].Y = (float)edge.linesOfEdge[0]._point1.Y;
                for (int i = 3; i < edge.linesOfEdge.Count; i++)
                {
                    points[i + 1].X = (float)edge.linesOfEdge[i]._point1.X;
                    points[i + 1].Y = (float)edge.linesOfEdge[i]._point1.Y;
                }
                if (edge.linesOfEdge.Count != 3)
                {
                    points[edge.linesOfEdge.Count + 1].X = (float)edge.linesOfEdge[3]._point1.X;
                    points[edge.linesOfEdge.Count + 1].Y = (float)edge.linesOfEdge[3]._point1.Y;
                }
            }
            else
            {
                points = new PointF[2 * edge.linesOfEdge.Count];

                /*for (int i = 0; i < edge.linesOfEdge.Count; i += 2)
                {
                    points[i].X = x0 + edge.linesOfEdge[i].point1.x - 1;
                    points[i].Y = y0 - edge.linesOfEdge[i].point1.y;
                    points[i + 1].X = x0 + edge.linesOfEdge[i].point2.x - 1;
                    points[i + 1].Y = y0 - edge.linesOfEdge[i].point2.y;
                }   */

                points[0].X = (float)edge.linesOfEdge[0]._point1.X;
                points[0].Y = (float)edge.linesOfEdge[0]._point1.Y;
                points[1].X = (float)edge.linesOfEdge[0]._point2.X;
                points[1].Y = (float)edge.linesOfEdge[0]._point2.Y;
                points[2].X = (float)edge.linesOfEdge[1]._point2.X;
                points[2].Y = (float)edge.linesOfEdge[1]._point2.Y;
                points[3].X = (float)edge.linesOfEdge[1]._point1.X;
                points[3].Y = (float)edge.linesOfEdge[1]._point1.Y;
            }

            return points;
        }

        public static void DrawDeleteAll(Side edge, Graphics gr, Pen pen)
        {
            if (edge.linesOfEdge.Count == 2)
            {
                gr.DrawLine(pen, (float)edge.linesOfEdge[0]._point1.X, (float)edge.linesOfEdge[0]._point1.Y,
                    (float)edge.linesOfEdge[0]._point2.X, (float)edge.linesOfEdge[0]._point2.Y);
                gr.DrawLine(pen, (float)edge.linesOfEdge[0]._point2.X, (float)edge.linesOfEdge[0]._point2.Y,
                    (float)edge.linesOfEdge[1]._point2.X, (float)edge.linesOfEdge[1]._point2.Y);
                gr.DrawLine(pen, (float)edge.linesOfEdge[1]._point2.X, (float)edge.linesOfEdge[1]._point2.Y,
                    (float)edge.linesOfEdge[1]._point1.X, (float)edge.linesOfEdge[1]._point1.Y);
                gr.DrawLine(pen, (float)edge.linesOfEdge[1]._point1.X, (float)edge.linesOfEdge[1]._point1.Y,
                    (float)edge.linesOfEdge[0]._point1.X, (float)edge.linesOfEdge[0]._point1.Y);
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    gr.DrawLine(pen, (float)edge.linesOfEdge[i]._point1.X, (float)edge.linesOfEdge[i]._point1.Y,
                        (float)edge.linesOfEdge[i]._point2.X, (float)edge.linesOfEdge[i]._point2.Y);
                }
                for (int i = 3; i < edge.linesOfEdge.Count; i++)
                {
                    gr.DrawLine(pen, (float)edge.linesOfEdge[i]._point1.X, (float)edge.linesOfEdge[i]._point1.Y,
                        (float)edge.linesOfEdge[i]._point2.X, (float)edge.linesOfEdge[i]._point2.Y);

                }

            }
        }

    }
}
