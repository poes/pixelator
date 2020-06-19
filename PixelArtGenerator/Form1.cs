using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelArtGenerator
{
    public partial class Pixelator : Form
    {
        string selectedFileName = "none";
        public Pixelator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(selectedFileName == "none") { return; }
            int offset = (int)numericUpDown1.Value;
            var lm = new Bitmap(@"" + selectedFileName);

            Form show = generateForm(lm.Width,lm.Height);
            Graphics g = show.CreateGraphics();
            var bitmap = new Bitmap(lm.Width, lm.Height);

            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, lm.GetPixel(x / offset * offset, y / offset * offset));
                }
            }
            g.DrawImage(bitmap, 0, 0);
            lm.Dispose();
            bitmap.Dispose();
        }

        private Form generateForm(int w, int h)
        {
            Form x = new Form();
            x.Text = "image preview";
            x.Width = w;
            x.Height = h;
            x.ShowIcon = false;
            x.Show();
            return x;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files|*.bmp;*.jpg;*.png;*.tif|All files|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFileName = openFileDialog1.FileName;
            }
        }
    }
}
