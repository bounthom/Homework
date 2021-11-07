using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work2
{
    public partial class Form1 : Form
    {
        Bitmap image_c, image_o;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Load Image";
            opf.Filter = ("Png (*.png)|*.png|Jpeg (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp");
            if (opf.ShowDialog() == DialogResult.OK) { image_o = new Bitmap(opf.FileName);
                image_c = image_o;
                pictureBox1.Image = image_c;
            }
        }
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
        public Bitmap Gray2(Bitmap source)
        {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color c = source.GetPixel(i, j);
                    //Luminance
                    int nP = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    bmp.SetPixel(i, j, Color.FromArgb(nP, nP, nP));
                }
            }
            return bmp;
        }
        public Bitmap Threshold (Bitmap source)
        {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            int t = int.Parse(textBox1.Text);
            for (int x = 0; x < source.Width ; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    Color c = source.GetPixel(x, y); 
                    int avg = (int)((c.R + c.G + c.B)/3);
                    if (avg < t)
                        avg = 255;
                    else avg = 0;
                    bmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            return bmp;
        }


private void button3_Click(object sender, EventArgs e)
        {
            image_c = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = Gray1(image_c);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            image_c = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = Gray2(image_c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            image_c = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = image_o;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            image_c = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = Threshold(image_c);
        }

        public Form1()
        {
            InitializeComponent();
        }

    }
}
