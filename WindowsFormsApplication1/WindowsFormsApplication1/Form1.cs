using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int zo = 230, xo = 400, yo = 230;
        Matrix matrix = new Matrix();

        private int rPent;
        private int hPent;
        Pentagon pentagon;
        //Pentagon petagon;
        private Pentagon pentCopy;

        private int rCyl;
        private int hCyl;
        private int _N;
        Cylinder cylinder;
        //Cylinder cyinder;
        private Cylinder cylCopy;

        Pen pen = new Pen(Color.Black, 1);
        Graphics formGraphics;
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            formGraphics = Graphics.FromImage(bitmap);
            formGraphics.Clear(BackColor);
            formGraphics.DrawEllipse(pen, xo, zo, 1, 2);
            DrawCoordinates();
            rPent = Convert.ToInt32(textBox1.Text.ToString(), 10);
            hPent = Convert.ToInt32(textBox2.Text.ToString(), 10);
            hCyl = Convert.ToInt32(textBox5.Text.ToString());
            rCyl = Convert.ToInt32(textBox4.Text.ToString());
            _N = Convert.ToInt32(textBox6.Text.ToString());
         
            pentagon = new Pentagon(rPent, hPent, xo, yo, zo);
            cylinder = new Cylinder(rCyl, hCyl, _N, xo, yo, zo);

            pentagon.Coordinates();
            cylinder.Coordinates();

            if (checkBox4.Checked)
                DrawWithoutLines(pentagon, cylinder);
            else
            {
                DrawCylinderXY(cylinder);
                DrawPentagonXY(pentagon);
            }

            pictureBox1.Image = bitmap;

        }

        private void DrawCylinderXY(Cylinder cylinderD)
        {
            for (int i = 0; i < _N; i++)
            {
                if (i == _N - 1)
                    formGraphics.DrawLine(pen, (float)cylinderD[i].X, (float)cylinderD[i].Y, (float)cylinderD[0].X, (float)cylinderD[0].Y);
                else
                    formGraphics.DrawLine(pen, (float)cylinderD[i].X, (float)cylinderD[i].Y, (float)cylinderD[i + 1].X,
                        (float)cylinderD[i + 1].Y);
            }
            for (int i = 0; i < _N; i++)
            {
                formGraphics.DrawLine(pen, (float)cylinderD[i].X, (float)cylinderD[i].Y, (float)cylinderD[_N + i].X,
                    (float)(cylinderD[_N + i].Y));
            }
            for (int i = _N; i < 2 * _N; i++)
            {
                if (i == 2 * _N - 1)
                    formGraphics.DrawLine(pen, (float)cylinderD[i].X, (float)cylinderD[i].Y, (float)cylinderD[_N].X, (float)cylinderD[_N].Y);
                else
                    formGraphics.DrawLine(pen, (float)cylinderD[i].X, (float)cylinderD[i].Y, (float)cylinderD[i + 1].X,
                        (float)cylinderD[i + 1].Y);
            }
        }

        private void DrawPentagonXY(Pentagon pentagonD)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 2)
                {
                    formGraphics.DrawLine(pen, (float)pentagonD[i].X, (float)pentagonD[i].Y, (float)pentagonD[i - 2].X,
                          (float)pentagonD[i - 2].Y);

                    formGraphics.DrawLine(pen, (float)pentagonD[i + 3].X, (float)pentagonD[i + 3].Y, (float)pentagonD[i + 1].X,
                        (float)pentagonD[i + 1].Y);
                }
                else
                {
                    formGraphics.DrawLine(pen, (float)pentagonD[i].X, (float)pentagonD[i].Y, (float)pentagonD[i + 1].X,
                        (float)pentagonD[i + 1].Y);

                    formGraphics.DrawLine(pen, (float)pentagonD[i + 3].X, (float)pentagonD[i + 3].Y, (float)pentagonD[i + 4].X,
                        (float)pentagonD[i + 4].Y);
                }
            }
            for (int i = 0; i < 3; i++)
                formGraphics.DrawLine(pen, (float)pentagonD[i].X, (float)pentagonD[i].Y, (float)pentagonD[i + 3].X,
                    (float)pentagonD[i + 3].Y);
        }

        private void DrawWithoutLines(Pentagon pentagonС, Cylinder cylinderС)
        {
            Side.isFill = checkBox6.Checked;
            Side.isLight = checkBox5.Checked;

            if (Side.isFill)
                Side.curColor = Color.FromArgb((int)Double.Parse(textBox21.Text),
                    (int)Double.Parse(textBox22.Text),
                    (int)Double.Parse(textBox23.Text));
            else
                Side.curColor = Color.White;

            GetCoordLight();

            pen = new Pen(Color.Black, 1);
            List<Line> lines1 = Line.GetLinesPentagon(pentagonС);
            List<Line> lines2 = Line.GetLinesCylinder(cylinderС);

            List<Line> lineCyl = Line.GetLinesCylinder(cylinder);
            List<Line> linePent = Line.GetLinesPentagon(pentagon);

            List<Side> edges = Side.SetEdgesAll(lines2, lines1);

            List<Side> edgesPC = Side.SetEdgesAll(lineCyl, linePent);

            //Отрисовка
            for (int i = edges.Count - 1; i >= 0; i--)
            {
                if (edges[i].GetVisiable())
                {
                    PointF[] pointsF = Side.GetPointsFAll(edges[i]);

                    formGraphics.FillPolygon(new SolidBrush(edgesPC[i].GetCurColor()), pointsF);
                    if (!checkBox6.Checked)
                    {
                        Side.DrawDeleteAll(edges[i], formGraphics, pen);
                    }
                }
            }
            pen = new Pen(Color.Black, 1);
        }

        private void DrawCoordinates()
        {
            float x = 0, y = 0, z = 0;
            Pen pen1 = new Pen(Color.OrangeRed, 1);
            formGraphics.DrawLine(pen1, xo, zo, xo, zo - 200);
            formGraphics.DrawLine(pen1, xo, zo, xo - 100, (float)(zo + 86.6));
            formGraphics.DrawLine(pen1, xo, zo, xo + 200, zo);
        }

        public void GetCoordLight()
        {
            Side.lightPoint.X = Double.Parse(textBox24.Text);
            Side.lightPoint.Y = Double.Parse(textBox25.Text);
            Side.lightPoint.Z = Double.Parse(textBox26.Text);
        }


        //TR
        private void button3_Click(object sender, EventArgs e)
        {
            int dx = Int32.Parse(textBox7.Text.ToString());
            int dy = Int32.Parse(textBox8.Text.ToString());
            int dz = Int32.Parse(textBox9.Text.ToString());
            new Translate().TranslateFigure(pentagon, cylinder, _N, dx, dy, dz);        
            formGraphics.Clear(BackColor);
            // DrawCoordinates();
            if (checkBox2.Checked)
                UseProjection("perspective", pentagon, cylinder);
            else if (checkBox3.Checked)
                UseProjection("cos", pentagon, cylinder);
            else
            {
                if (checkBox4.Checked)
                    DrawWithoutLines(pentagon, cylinder);
                else
                {
                    DrawCylinderXY(cylinder);
                    DrawPentagonXY(pentagon);
                }
            }
            pictureBox1.Image = bitmap;

        }

        //SC
        private void button4_Click(object sender, EventArgs e)
        {
            double dx = Double.Parse(textBox10.Text);
            double dy = Double.Parse(textBox11.Text);
            double dz = Double.Parse(textBox12.Text);
            new Scale(xo, yo, zo).ScaleFigure(pentagon, cylinder, _N, dx, dy, dz);
            formGraphics.Clear(BackColor);
            if (checkBox2.Checked)
                UseProjection("perspective", pentagon, cylinder);
            else if (checkBox3.Checked)
                UseProjection("cos", pentagon, cylinder);
            else
            {
                if (checkBox4.Checked)
                    DrawWithoutLines(pentagon, cylinder);
                else
                {
                    DrawCylinderXY(cylinder);
                    DrawPentagonXY(pentagon);
                }
            }
            pictureBox1.Image = bitmap;

        }

        //Rot
        private void button5_Click(object sender, EventArgs e)
        {
            Rotate rotate = new Rotate(xo, yo, zo);
            double an = Double.Parse(textBox13.Text);
            an = an * Math.PI / 180;
                if (radioButton1.Checked)
                    rotate.RotateX(an, pentagon, cylinder, _N);
                else if (radioButton2.Checked)
                    rotate.RotateY(an, pentagon, cylinder, _N);
                else if (radioButton3.Checked)
                    rotate.RotateZ(an, pentagon, cylinder, _N);
                // }
                formGraphics.Clear(BackColor);
            if (checkBox2.Checked)
                UseProjection("perspective", pentagon, cylinder);
            else if (checkBox3.Checked)
                UseProjection("cos", pentagon, cylinder);
            else
            {
                if (checkBox4.Checked)
                    DrawWithoutLines(pentagon, cylinder);
                else
                {
                    DrawCylinderXY(cylinder);
                    DrawPentagonXY(pentagon);
                }
            }
            pictureBox1.Image = bitmap;

        }

        //Front
        private void button6_Click(object sender, EventArgs e)
        {
            formGraphics.Clear(BackColor);
            new Rotate(xo, yo, zo).Front(pentagon, cylinder, _N);
            if (checkBox4.Checked)
                DrawWithoutLines(pentagon, cylinder);
            else
            {
                DrawCylinderXY(cylinder);
                DrawPentagonXY(pentagon);
            }
            pictureBox1.Image = bitmap;
        }



        private void button7_Click_1(object sender, EventArgs e)
        {
            formGraphics.Clear(BackColor);
            new Rotate(xo, yo, zo).Prof(pentagon, cylinder, _N);
            if (checkBox4.Checked)
                DrawWithoutLines(pentagon, cylinder);
            else
            {
                DrawCylinderXY(cylinder);
                DrawPentagonXY(pentagon);
            }
            pictureBox1.Image = bitmap;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Rotate(xo, yo, zo).Goriz(pentagon, cylinder, _N);
            formGraphics.Clear(BackColor);
            if (checkBox4.Checked)
                DrawWithoutLines(pentagon,cylinder);
            else
            {
                DrawCylinderXY(cylinder);
                DrawPentagonXY(pentagon);
            }
            pictureBox1.Image = bitmap;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            formGraphics.Clear(BackColor);
            UseProjection("cos", pentagon, cylinder);
            pictureBox1.Image = bitmap;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //double d = Double.Parse(textBox17.Text);
            //double ro = Double.Parse(textBox18.Text);
            //double tetta = Double.Parse(textBox19.Text) * Math.PI / 180;
            //double fi = Double.Parse(textBox20.Text) * Math.PI / 180;
            //formGraphics.Clear(BackColor);
            //pentCopy = pentagon.DeepCopy();
            //cylCopy = cylinder.DeepCopy();
            //new Projections(xo, yo, zo).PersProjection(d, ro, tetta, fi, pentagon, cylinder, N);
            //DrawCoordinates();
            //DrawPentagonXY();
            //DrawCylinderXY();
            UseProjection("perspective", pentagon,cylinder);
            pictureBox1.Image = bitmap;


        }

        private void UseProjection(string projection, Pentagon pentagon, Cylinder cylinder)
        {
            switch (projection)
            {
                case "perspective":
                    double d = Double.Parse(textBox17.Text);
                    double ro = Double.Parse(textBox18.Text);
                    double tetta = Double.Parse(textBox19.Text) * Math.PI / 180;
                    double fi = Double.Parse(textBox20.Text) * Math.PI / 180;
                    formGraphics.Clear(BackColor);
                    pentCopy = pentagon.DeepCopy();
                    cylCopy = cylinder.DeepCopy();
                    new Projections(xo, yo, zo).PersProjection(d, ro, tetta, fi, pentCopy, cylCopy, _N);
                    if (checkBox4.Checked)
                        DrawWithoutLines(pentCopy, cylCopy);
                    else
                    {
                        DrawCylinderXY(cylCopy);
                        DrawPentagonXY(pentCopy);
                    }
                    break;

                case "aks":
                    double psi = Double.Parse(textBox3.Text) * Math.PI / 180;
                    double fii = Double.Parse(textBox14.Text) * Math.PI / 180;
                    formGraphics.Clear(BackColor);
                    pentCopy = pentagon.DeepCopy();
                    cylCopy = cylinder.DeepCopy();
                    new Projections(xo, yo, zo).AksProjection(psi, fii, pentCopy, cylCopy, _N);
                    if (checkBox4.Checked)
                        DrawWithoutLines(pentCopy, cylCopy);
                    else
                    {
                        DrawCylinderXY(cylCopy);
                        DrawPentagonXY(pentCopy);
                    }
                    break;

                case "cos":
                    double alpha = Double.Parse(textBox15.Text) * Math.PI / 180;
                    double l = Double.Parse(textBox16.Text);
                    formGraphics.Clear(BackColor);
                    pentCopy = pentagon.DeepCopy();
                    cylCopy = cylinder.DeepCopy();
                    new Projections(xo, yo, zo).CosProjection(alpha, l, pentCopy, cylCopy, _N);
                    if (checkBox4.Checked)
                        DrawWithoutLines(pentCopy, cylCopy);
                    else
                    {
                        DrawCylinderXY(cylCopy);
                        DrawPentagonXY(pentCopy);
                    }
                    break;

                default:
                    if (checkBox1.Checked)
                        DrawWithoutLines(pentCopy, cylCopy);
                    else
                    {
                        DrawCylinderXY(cylCopy);
                        DrawPentagonXY(pentCopy);
                    }
                    break;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            formGraphics.Clear(BackColor);
            UseProjection("aks", pentagon, cylinder);
            pictureBox1.Image = bitmap;

        }


        //private void OrtProjection(double[,] T) 
        //{
        //    try {
        //        double[,] result = new double[1, 4] { { 0, 0, 0, 0 } };

        //        for (int i = 0; i < 6; i++)
        //        {
        //            double[,] s = new double[1, 4] { { petagon[i].X - xo, petagon[i].Y - yo, petagon[i].Z - zo, 1 } };
        //            result = matrix.multiplyMatrixs(s, T);
        //            petagon[i].X = result[0, 0] + xo;
        //            petagon[i].Y = result[0, 1] + yo;
        //            petagon[i].Z = result[0, 2] + zo;
        //        }
        //        result = new double[1, 4] { { 0, 0, 0, 0 } };
        //        for (int i = 0; i < 2 * _N; i++)
        //        {
        //            double[,] s = new double[1, 4] { { cyinder[i].X - xo, cyinder[i].Y - yo, cyinder[i].Z - zo, 1 } };
        //            result = matrix.multiplyMatrixs(s, T);
        //            cyinder[i].X = result[0, 0] + xo;
        //            cyinder[i].Y = result[0, 1] + yo;
        //            cyinder[i].Z = result[0, 2] + zo;
        //        }
        //    } catch(NullReferenceException e){}
            
        //}
   

        
        
        
    }
}
