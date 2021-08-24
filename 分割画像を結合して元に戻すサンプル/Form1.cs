// https://imagingsolution.net/program/csharp/image_combine/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 分割画像を結合して元に戻すサンプル
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Bitmap> ketugous = new List<Bitmap>();
            ketugous.Add(new Bitmap("0.tif"));
            ketugous.Add(new Bitmap("1.tif"));
            ketugous.Add(new Bitmap("2.tif"));
            //ketugous.Add(new Bitmap("3.tif"));
            ketugou(ketugous);
        }

        private void ketugou(List<Bitmap> ketugous)
        {
            if (ketugous.Count <= 0)
            {
                MessageBox.Show("結合画像なし");
                return;
            }

            int width = 0;
            int height = ketugous[0].Height; // 全て同じ高さのはず
            for (int i = 0; i < ketugous.Count - 1; i++)
            {
                if (ketugous[i].Height != ketugous[i + 1].Height)
                {
                    MessageBox.Show("結合画像高さ違い");
                    return;
                }
            }

            for (int i = 0; i < ketugous.Count; i++)
            {
                width += ketugous[i].Width;
            }

            Bitmap dest = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(dest);

            Rectangle srcRect;
            Rectangle destRect;
            int x = 0;
            for (int i = 0; i < ketugous.Count; i++)
            {
                srcRect = new Rectangle(0, 0, ketugous[i].Width, height);
                destRect = new Rectangle(x, 0, ketugous[i].Width, height);
                g.DrawImage(ketugous[i], destRect, srcRect, GraphicsUnit.Pixel);
                x += ketugous[i].Width;
            }

            dest.Save("ketugou.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            pictureBox1.ImageLocation = "ketugou.bmp";
            //dest.Save("ketugou.tif", System.Drawing.Imaging.ImageFormat.Tiff);
            //pictureBox1.ImageLocation = "ketugou.tif";

            g.Dispose();

        }
    }
}
