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
    public partial class frmWeb : Form
    {
        int i;
        string[] saChemins;
        bool slideStarted = false;

        public frmWeb()
        {
            InitializeComponent();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFull_Load(object sender, EventArgs e)
        {
        }

        private void frmResize()
        {
            panel1.Left = this.Width / 10;
            panel1.Top = 0;
            panel1.Height = this.Height;
            panel1.Width = this.Width / 10 * 9;

            int iLeftMargin = this.Width / 10;
            int iToolbarHeight = this.Height / 5;

            btnRefresh.Left = 0;
            btnRefresh.Top = 0;
            btnRefresh.Width = iLeftMargin - 1;
            btnRefresh.Height = iToolbarHeight;

            btnExit.Left = 0;
            btnExit.Top = iToolbarHeight;
            btnExit.Width = iLeftMargin - 1;
            btnExit.Height = iToolbarHeight;
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

        
        private void frmFull_Resize(object sender, EventArgs e)
        {
            frmResize();
        }

        private void frmFull_Shown(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(saChemins[this.i]);
            //timer1.Enabled = slideStarted;
            //frmResize();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
    }
}
