using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SideScreen2
{
    public partial class frmFull : Form
    {
        int i;
        string[] saChemins;
        bool slideStarted = false;

        public frmFull()
        {
            InitializeComponent();

            pctNext.Parent = pictureBox1;
            pctPrev.Parent = pictureBox1;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFull_Load(object sender, EventArgs e)
        {
            //frmResize();
        }

        private void frmResize()
        {
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
            pictureBox1.Height = this.Height;
            pictureBox1.Width = this.Width;

            pctNext.Top = 0;
            pctNext.Left = 9 * pictureBox1.Width / 10;
            pctNext.Width = pictureBox1.Width / 10;
            pctNext.Height = pictureBox1.Height;

            pctPrev.Top = 0;
            pctPrev.Left = 0;
            pctPrev.Width = pictureBox1.Width / 10;
            pctPrev.Height = pictureBox1.Height;

            if (saChemins != null)
                pictureBox1.Image = ImageHelper.getImage(saChemins[this.i], pictureBox1.Width, pictureBox1.Height);

        }

        public void giveInfos(int current, string[] psachemins, bool slideshow = false)
        {
            this.i = current;
            this.saChemins = psachemins;
            this.slideStarted = slideshow;

        }

        private void frmFull_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void pctNext_Click(object sender, EventArgs e)
        {
            //(frmSideScreen)(Parent).pctClick(sender, e, 0);
            if (i < 6) i++;
            try
            {
                pictureBox1.Image = ImageHelper.getImage(saChemins[this.i], pictureBox1.Width, pictureBox1.Height);
            }
            catch
            {
                i = 0;
                pictureBox1.Image = ImageHelper.getImage(saChemins[this.i], pictureBox1.Width, pictureBox1.Height);
            }
        }

        private void pctPrev_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0) i=5;
            try
            {
                pictureBox1.Image = ImageHelper.getImage(saChemins[this.i], pictureBox1.Width, pictureBox1.Height);
            }
            catch
            {
                i = 0;
                pictureBox1.Image = ImageHelper.getImage(saChemins[this.i], pictureBox1.Width, pictureBox1.Height);
            }

        }

        private void frmFull_Resize(object sender, EventArgs e)
        {
            frmResize();
        }

        private void frmFull_Shown(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(saChemins[this.i]);
            timer1.Enabled = slideStarted;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            //if (i < 6) i++;
            try
            {
                pictureBox1.Image = ImageHelper.getImage(saChemins[this.i], pictureBox1.Width, pictureBox1.Height);
            }
            catch
            {
                i = 0;
                pictureBox1.Image = ImageHelper.getImage(saChemins[this.i], pictureBox1.Width, pictureBox1.Height);
            }
        }
    }
}
