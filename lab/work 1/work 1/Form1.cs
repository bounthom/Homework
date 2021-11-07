using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap setimage = new Bitmap(pictureBox1.Image);
            for (int x = 10; x < 300; x++)
            {
                setimage.SetPixel(x, 20, Color.Red);
            }
            pictureBox1.Image = setimage;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap srcB = new Bitmap(pictureBox2.Image);
            Bitmap dsB = new Bitmap(500, 500);
            for (int x = 200; x < 320; x++)
            {
                for (int y = 100; y < 230; y++)
                {
                    dsB.SetPixel(x - 120, y - 80, srcB.GetPixel(x, y));
                }
            }
            pictureBox3.Image = dsB;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Color Clr = bmp.GetPixel(e.X, e.Y);
            label1.Text = "R :" + Clr.R.ToString();
            label2.Text = "G :" + Clr.G.ToString();
            label3.Text = "B :" + Clr.B.ToString();
        }
        Bitmap image_c;
        public Bitmap Gray1(Bitmap source)
        {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    int avg = (int)((c.R + c.G + c.B) / 3);
                    bmp.SetPixel(i, j, Color.FromArgb(avg, avg, avg));
                }
            }
            return bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            image_c = new Bitmap(pictureBox2.Image);
            pictureBox2.Image = Gray1(image_c);
        }
    }
}
