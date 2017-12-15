using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Line
    {
        public Point _point1, _point2;

        public Line(Point point1, Point point2)
        {
            _point1 = point1;
            _point2 = point2;
        }

        public Line()
        {

        }

        public static List<Line> GetLinesPentagon(Pentagon pentagon)
        {
            List<Line> lines = new List<Line>();
            Line buf;
            //int n = cylinder.Count / 2;

            for (int i = 0; i < pentagon.Count/2 - 1; i++)
            {
                buf = new Line(pentagon[i], pentagon[i + 1]);
                lines.Add(buf);
            }

            buf = new Line(pentagon[pentagon.Count/2 - 1], pentagon[0]);
            lines.Add(buf);

            for (int i = pentagon.Count / 2; i < pentagon.Count -1; i++)
            {
                buf = new Line(pentagon[i], pentagon[i + 1]);
                lines.Add(buf);
            }

            buf = new Line(pentagon[pentagon.Count -1], pentagon[pentagon.Count / 2]);
            lines.Add(buf);

            for (int i = 0; i < pentagon.Count / 2; i++)
            {
                buf = new Line(pentagon[i], pentagon[pentagon.Count / 2 + i]);
                lines.Add(buf);
            }
            return lines;
        }

        public static List<Line> GetLinesCylinder(Cylinder cylinder)
        {
            List<Line> lines = new List<Line>();
            Line buf;
            //int n = cylinder.Count / 2;

            for (int i = 0; i < cylinder.Appr - 1; i++)
            {
                buf = new Line(cylinder[i], cylinder[i + 1]);
                lines.Add(buf);
            }

            buf = new Line(cylinder[cylinder.Appr - 1], cylinder[0]);
            lines.Add(buf);

            for (int i = cylinder.Appr; i < 2 * cylinder.Appr - 1; i++)
            {
                buf = new Line(cylinder[i], cylinder[i + 1]);
                lines.Add(buf);
            }

            buf = new Line(cylinder[2 * cylinder.Appr - 1], cylinder[cylinder.Appr]);
            lines.Add(buf);

            for (int i = 0; i < cylinder.Appr; i++)
            {
                buf = new Line(cylinder[i], cylinder[cylinder.Appr + i]);
                lines.Add(buf);
            }
            return lines;
        }
    }
}
