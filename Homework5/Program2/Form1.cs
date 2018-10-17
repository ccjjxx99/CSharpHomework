using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            else graphics.Clear(BackColor);
            getData();
            drawCayleyTree(10, 240, 310, 100, -Math.PI / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            else graphics.Clear(BackColor);
            Random rd1 = new Random(int.Parse(DateTime.Now.ToString("HHmmssfff")));
            int a = rd1.Next(0, 90);
            th1 = a * Math.PI / 180;
            textBox1.Text = a.ToString();
            Random rd2 = new Random();
            int b = rd2.Next(0, 90);
            th2 = b * Math.PI / 180;
            textBox2.Text = b.ToString();
            per1 = rd1.NextDouble();
            textBox3.Text = per1.ToString();
            per2 = rd2.NextDouble();
            textBox4.Text = per2.ToString();
            Random rd3 = new Random(int.Parse(DateTime.Now.ToString("HHssmmfff")));
            k = rd3.NextDouble();
            textBox5.Text = k.ToString();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        double k = 1;
        Color color = Color.Blue;


        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + k * leng * Math.Cos(th);
            double y2 = y0 + k * leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawLine(x0, y0, x2, y2);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);//右支
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);//左支
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            setColor();
            Pen pen = new Pen(color);
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        void getData()
        {
            try
            {
                th1 = int.Parse(textBox1.Text) * Math.PI / 180;
                th2 = int.Parse(textBox2.Text) * Math.PI / 180;
                per1 = double.Parse(textBox3.Text);
                per2 = double.Parse(textBox4.Text);
                k = double.Parse(textBox5.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void setColor()
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    color = Color.Blue;
                    break;
                case 1:
                    color = Color.Red;
                    break;
                case 2:
                    color = Color.Green;
                    break;
                case 3:
                    color = RandomColor();
                    break;
                default:
                    color = Color.Blue;
                    break;
            }
        }

        private Color RandomColor()
        {
            Random c1 = new Random(int.Parse(DateTime.Now.ToString("HHmmssfff")));
            Random c2 = new Random(int.Parse(DateTime.Now.ToString("mmHHssfff")));
            Random c3 = new Random(int.Parse(DateTime.Now.ToString("ssHHmmfff")));
            int r = c1.Next(0, 255);
            int g = c2.Next(0, 255);
            int b = c3.Next(0, 255);
            return Color.FromArgb(r, g, b);
        }
    }
}
