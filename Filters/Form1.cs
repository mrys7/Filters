using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filters
{
    public partial class Form1 : Form
    {
        private int szer = 0, wys = 0;
        public Form1()
        {
            InitializeComponent();
        }

        //filtr
        private void filter(int [,] F)
        {
            Cursor = Cursors.WaitCursor;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1, k2;

            for (int i = 1; i < szer - 1; i++)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    int r_nowy = 0;
                    int g_nowy = 0;
                    int b_nowy = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int o = -1; o <= 1; o++)
                        {
                            k1 = b1.GetPixel(i + k, j + o);
                            r_nowy += k1.R * F[k + 1, o + 1];
                            g_nowy += k1.G * F[k + 1, o + 1];
                            b_nowy += k1.B * F[k + 1, o + 1];
                        }
                    }

                    int norm = 0;
                    for (int o = 0; o < 3; o++)
                    {
                        for (int p = 0; p < 3; p++)
                        {
                            norm += F[o, p];
                        }
                    }

                    if(norm != 0)
                    {
                        r_nowy /= norm;
                        g_nowy /= norm;
                        b_nowy /= norm;
                    }

                    if (r_nowy > 255) r_nowy = 255;
                    if (r_nowy < 0) r_nowy = 0;
                    if (g_nowy > 255) g_nowy = 255;
                    if (g_nowy < 0) g_nowy = 0;
                    if (b_nowy > 255) b_nowy = 255;
                    if (b_nowy < 0) b_nowy = 0;

                    k2 = Color.FromArgb((int)r_nowy, (int)g_nowy, (int)b_nowy);
                    b2.SetPixel(i, j, k2);
                }
            }
            pictureBox2.Invalidate();
            Cursor = Cursors.Default;

        }

        //zaladuj
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox2.Image = new Bitmap(szer, wys);
            }
        }

        //roberts
        private void button3_Click(object sender, EventArgs e)
        {
            int[,] F_table = new int[3, 3];
            F_table[0, 0] = 0;
            F_table[0, 1] = 0;
            F_table[0, 2] = 0;
            F_table[1, 0] = 0;
            F_table[1, 1] = 1;
            F_table[1, 2] = -1;
            F_table[2, 0] = 0;
            F_table[2, 1] = 0;
            F_table[2, 2] = 0;
            filter(F_table);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[,] F_table = new int[3, 3];
            F_table[0, 0] = 0;
            F_table[0, 1] = 0;
            F_table[0, 2] = 0;
            F_table[1, 0] = 0;
            F_table[1, 1] = 1;
            F_table[1, 2] = 0;
            F_table[2, 0] = 0;
            F_table[2, 1] = -1;
            F_table[2, 2] = 0;
            filter(F_table);
        }


        //sobel
        private void button5_Click(object sender, EventArgs e)
        {
            int[,] F_table = new int[3, 3];
            F_table[0, 0] = 1;
            F_table[0, 1] = 2;
            F_table[0, 2] = 1;
            F_table[1, 0] = 0;
            F_table[1, 1] = 0;
            F_table[1, 2] = 0;
            F_table[2, 0] = -1;
            F_table[2, 1] = -2;
            F_table[2, 2] = -1;
            filter(F_table);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[,] F_table = new int[3, 3];
            F_table[0, 0] = 1;
            F_table[0, 1] = 0;
            F_table[0, 2] = -1;
            F_table[1, 0] = 2;
            F_table[1, 1] = 0;
            F_table[1, 2] = -2;
            F_table[2, 0] = 1;
            F_table[2, 1] = 0;
            F_table[2, 2] = -1;
            filter(F_table);
        }

        //prewitt
        private void button7_Click(object sender, EventArgs e)
        {
            int[,] F_table = new int[3, 3];
            F_table[0, 0] = 1;
            F_table[0, 1] = 1;
            F_table[0, 2] = 1;
            F_table[1, 0] = 0;
            F_table[1, 1] = 0;
            F_table[1, 2] = 0;
            F_table[2, 0] = -1;
            F_table[2, 1] = -1;
            F_table[2, 2] = -1;
            filter(F_table);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int[,] F_table = new int[3, 3];
            F_table[0, 0] = 1;
            F_table[0, 1] = 0;
            F_table[0, 2] = -1;
            F_table[1, 0] = 1;
            F_table[1, 1] = 0;
            F_table[1, 2] = -1;
            F_table[2, 0] = 1;
            F_table[2, 1] = 0;
            F_table[2, 2] = -1;
            filter(F_table);
        }

        //laplace
        private void button9_Click(object sender, EventArgs e)
        {
            int[,] F_table = new int[3, 3];
            F_table[0, 0] = -1;
            F_table[0, 1] = -1;
            F_table[0, 2] = -1;
            F_table[1, 0] = -1;
            F_table[1, 1] = 8;
            F_table[1, 2] = -1;
            F_table[2, 0] = -1;
            F_table[2, 1] = -1;
            F_table[2, 2] = -1;
            filter(F_table);
        }

        //minimum
        private void button10_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1, k2;

            for (int i = 1; i < szer - 1; i++)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    int r_nowy = 255;
                    int g_nowy = 255;
                    int b_nowy = 255;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int o = -1; o <= 1; o++)
                        {
                            k1 = b1.GetPixel(i + k, j + o);
                            if (r_nowy > k1.R) r_nowy = k1.R;
                            if (g_nowy > k1.G) g_nowy = k1.G;
                            if (b_nowy > k1.B) b_nowy = k1.B;
                        }
                    }

                    if (r_nowy > 255) r_nowy = 255;
                    if (r_nowy < 0) r_nowy = 0;
                    if (g_nowy > 255) g_nowy = 255;
                    if (g_nowy < 0) g_nowy = 0;
                    if (b_nowy > 255) b_nowy = 255;
                    if (b_nowy < 0) b_nowy = 0;

                    k2 = Color.FromArgb((int)r_nowy, (int)g_nowy, (int)b_nowy);
                    b2.SetPixel(i, j, k2);
                }
            }
            pictureBox2.Invalidate();
            Cursor = Cursors.Default;
        }

        //maximum
        private void button11_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1, k2;

            for (int i = 1; i < szer - 1; i++)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    int r_nowy = 0;
                    int g_nowy = 0;
                    int b_nowy = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int o = -1; o <= 1; o++)
                        {
                            k1 = b1.GetPixel(i + k, j + o);
                            if (r_nowy < k1.R) r_nowy = k1.R;
                            if (g_nowy < k1.G) g_nowy = k1.G;
                            if (b_nowy < k1.B) b_nowy = k1.B;
                        }
                    }

                    if (r_nowy > 255) r_nowy = 255;
                    if (r_nowy < 0) r_nowy = 0;
                    if (g_nowy > 255) g_nowy = 255;
                    if (g_nowy < 0) g_nowy = 0;
                    if (b_nowy > 255) b_nowy = 255;
                    if (b_nowy < 0) b_nowy = 0;

                    k2 = Color.FromArgb((int)r_nowy, (int)g_nowy, (int)b_nowy);
                    b2.SetPixel(i, j, k2);
                }
            }
            pictureBox2.Invalidate();
            Cursor = Cursors.Default;
        }

        //zapisz
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        pictureBox2.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        pictureBox2.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        pictureBox2.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }
    }
}
  