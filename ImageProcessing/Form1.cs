using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        Bitmap load, result;
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            load = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = load;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = new Bitmap(load.Width, load.Height);
            for(int x = 0; x < load.Width; x++)
            {
                for(int y = 0; y < load.Height; y++)
                {
                    Color pixel = load.GetPixel(x, y);
                    result.SetPixel(x, y, pixel);
                }
            }
            pictureBox2.Image = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result = new Bitmap(load.Width, load.Height);
            for (int x = 0; x < load.Width; x++)
            {
                for (int y = 0; y < load.Height; y++)
                {
                    Color pixel = load.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    Color color = Color.FromArgb(grey,grey,grey);
                    result.SetPixel(x, y, color);
                }
            }
            pictureBox2.Image = result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            result = new Bitmap(load.Width, load.Height);
            for (int x = 0; x < load.Width; x++)
            {
                for (int y = 0; y < load.Height; y++)
                {
                    Color pixel = load.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    Color color = Color.FromArgb(255-pixel.R, 255 - pixel.G, 255 - pixel.B);
                    result.SetPixel(x, y, color);
                }
            }
            pictureBox2.Image = result;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            result = new Bitmap(load.Width, load.Height);
            for (int x = 0; x < load.Width; x++)
            {
                for (int y = 0; y < load.Height; y++)
                {
                    Color pixel = load.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    //Color color = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    result.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }
            }
            Color example;
            int[] histdata = new int[256];
            for (int x = 0; x < load.Width; x++)
            {
                for (int y = 0; y < load.Height; y++)
                {
                    example = result.GetPixel(x, y);
                    histdata[example.R] ++;
                }
            }
            Bitmap bmp = new Bitmap(256,800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    bmp.SetPixel(x, y, Color.White);
                }
            }
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histdata[x]/5,800); y++)
                {
                    bmp.SetPixel(x, 799-y, Color.Black);
                }
            }
            pictureBox2.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            result.Save(saveFileDialog1.FileName);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            result = new Bitmap(load.Width, load.Height);
            for (int x = 0; x < load.Width; x++)
            {
                for (int y = 0; y < load.Height; y++)
                {
                    Color pixel = load.GetPixel(x, y);
                    int red = (int)(pixel.R * 0.393 + pixel.G * 0.769 + pixel.B * 0.189);
                    int green = (int)(pixel.R * 0.349 + pixel.G * 0.686 + pixel.B * 0.168);
                    int blue = (int)(pixel.R * 0.272 + pixel.G * 0.534 + pixel.B * 0.131);
                    Color color = Color.FromArgb(Math.Min(red,255), Math.Min(green, 255), Math.Min(blue, 255));
                    result.SetPixel(x, y, color);
                }
            }
            pictureBox2.Image = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
        }
    }
}
