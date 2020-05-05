using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SideScreen2
{
    public partial class frmSideScreen : Form
    {


        string baseFolder = Path.Combine(Application.StartupPath, "data");
        string currentFolder = "";
        string currentFullFolder, currentFullFile;
        int lastPctClicked;

        int iThumbSizeWidth, iThumbSizeHeight;

        private PictureBox[] pictureBoxes;
        private Label[] labels;
        
    

        public frmSideScreen()
        {
            InitializeComponent();

            pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6 };
            labels = new Label[] { label1, label2, label3, label4, label5, label6 };

            Console.WriteLine("events");
            pictureBox1.Click += (sender, EventArgs) => { pctClick(sender, EventArgs, 0); };
            pictureBox2.Click += (sender, EventArgs) => { pctClick(sender, EventArgs, 1); };
            pictureBox3.Click += (sender, EventArgs) => { pctClick(sender, EventArgs, 2); };
            pictureBox4.Click += (sender, EventArgs) => { pctClick(sender, EventArgs, 3); };
            pictureBox5.Click += (sender, EventArgs) => { pctClick(sender, EventArgs, 4); };
            pictureBox6.Click += (sender, EventArgs) => { pctClick(sender, EventArgs, 5); };

        }

        private void frmSideScreen_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Load");

            Console.WriteLine("Show");
            this.Show();

            Console.WriteLine("frmResize");
            frmResize();

            Console.WriteLine("loadMenu");
            loadMenu();


        }

        private void loadMenu()
        {
            currentFullFolder = Path.Combine(baseFolder, currentFolder);
            currentFullFile = Path.Combine(baseFolder, currentFolder + ".jpg");

            btnUp.Enabled = (currentFolder != "");

            try
            {

                if (Directory.Exists(currentFullFolder))
                {

                    string[] pFiles = Directory.GetFiles(currentFullFolder, "*.jpg", SearchOption.TopDirectoryOnly).Where(file => file.ToLower().EndsWith("jpg")).ToArray();
                    int nbFiles = pFiles.Count();
                    if (nbFiles > 6) nbFiles = 6;

                    foreach (PictureBox pctb in pictureBoxes)
                    {
                        pctb.Image = null;
                    }

                    foreach (Label lbl in labels)
                    {
                        //lbl.Text = "";
                        lbl.Visible = false;
                    }

                    for (int i = 0; i < nbFiles; i++)
                    {
                        this.pictureBoxes[i].Image = ImageHelper.getImage (pFiles[i], iThumbSizeWidth, iThumbSizeHeight);
                        this.pictureBoxes[i].Tag = Path.GetFileNameWithoutExtension(pFiles[i]);
                        labels[i].Text = this.pictureBoxes[i].Tag.ToString().ToUpper();
                        labels[i].Visible = true;

                        // Si correspond à dossier
                        if (Directory.Exists(pFiles[i].Replace (".jpg","")) )
                        {
                            labels[i].BackColor = Color.LightYellow;
                        }
                        else
                        {
                            labels[i].BackColor = Color.LightGray;
                        }
                        // this.pictureBoxes[i].Tag = Path.GetFileName(pFiles[i]);
                    }
                } else if (File.Exists(currentFullFile))
                {
                    frmFull frm = new frmFull();
                    //frm.pictureBox1.Image = Image.FromFile(currentFullFile);

                    currentFolder = Path.GetDirectoryName(currentFolder);

                    string[] psachemins = new string[6];
                    for (int i = 0; i < 6; i++)
                    {
                        if (this.pictureBoxes[i].Tag != null)
                            psachemins[i] = Path.Combine(baseFolder, currentFolder, this.pictureBoxes[i].Tag.ToString() + ".jpg"); ;
                        // this.pictureBoxes[i].Tag = Path.GetFileName(pFiles[i]);
                    }

                    frm.giveInfos(lastPctClicked, psachemins);

                    frm.Show();

                    
                } else
                {
                    currentFolder = "";
                    loadMenu();
                }
            }
            catch (IOException e)
            {
                lblStatus.Text = "!D";
            }


        }

        

        private void frmResize()
        {
            Console.WriteLine("frmResize");

            if (pictureBoxes != null)
            {

                int iLeftMargin = this.Width / 10;
                int iToolbarHeight = this.Height / 5;

                btnHome.Left = 0;
                btnHome.Top = 0;
                btnHome.Width = iLeftMargin - 1;
                btnHome.Height = iToolbarHeight;

                btnUp.Left = 0;
                btnUp.Top = iToolbarHeight;
                btnUp.Width = iLeftMargin - 1;
                btnUp.Height = iToolbarHeight;

                btnPlay.Left = 0;
                btnPlay.Top = iToolbarHeight * 2;
                btnPlay.Width = iLeftMargin - 1;
                btnPlay.Height = iToolbarHeight;

                btnExit.Left = 0;
                btnExit.Top = iToolbarHeight * 3;
                btnExit.Width = iLeftMargin - 1;
                btnExit.Height = iToolbarHeight;

                lblStatus.Left = 0;
                lblStatus.Top = 4 * iToolbarHeight;
                lblStatus.Width = iLeftMargin - 1;
                lblStatus.Height = iToolbarHeight;


                iThumbSizeWidth = (this.Width - iLeftMargin) / 3 - 3;
                iThumbSizeHeight = (this.Height / 2) - 2;

                Console.WriteLine("pctb");

                foreach (PictureBox pctb in pictureBoxes)
                {
                    pctb.Width = iThumbSizeWidth;
                    pctb.Height = iThumbSizeHeight;
                    pctb.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                Console.WriteLine("pctb pos");

                pictureBox1.Left = iLeftMargin;
                pictureBox2.Left = pictureBox1.Left + iThumbSizeWidth + 1;
                pictureBox3.Left = pictureBox2.Left + iThumbSizeWidth + 1;
                pictureBox4.Left = pictureBox1.Left;
                pictureBox5.Left = pictureBox4.Left + iThumbSizeWidth + 1;
                pictureBox6.Left = pictureBox5.Left + iThumbSizeWidth + 1;

                pictureBox1.Top = 0;
                pictureBox2.Top = 0;
                pictureBox3.Top = 0;
                pictureBox4.Top = iThumbSizeHeight + 1;
                pictureBox5.Top = iThumbSizeHeight + 1;
                pictureBox6.Top = iThumbSizeHeight + 1;

                label1.Left = pictureBox1.Left;
                label1.Width = pictureBox1.Width;
                label1.Height = pictureBox1.Height / 10;
                label1.Top = pictureBox1.Top + 9 * pictureBox1.Height / 10;

                label2.Left = pictureBox2.Left;
                label2.Width = pictureBox2.Width;
                label2.Height = pictureBox2.Height / 10;
                label2.Top = pictureBox2.Top + 9 * pictureBox2.Height / 10;

                label3.Left = pictureBox3.Left;
                label3.Width = pictureBox1.Width;
                label3.Height = pictureBox1.Height / 10;
                label3.Top = pictureBox3.Top + 9 * pictureBox1.Height / 10;

                label4.Left = pictureBox4.Left;
                label4.Width = pictureBox1.Width;
                label4.Height = pictureBox1.Height / 10;
                label4.Top = pictureBox4.Top + 9 * pictureBox1.Height / 10;

                label5.Left = pictureBox5.Left;
                label5.Width = pictureBox1.Width;
                label5.Height = pictureBox1.Height / 10;
                label5.Top = pictureBox5.Top + 9 * pictureBox1.Height / 10;

                label6.Left = pictureBox6.Left;
                label6.Width = pictureBox1.Width;
                label6.Height = pictureBox1.Height / 10;
                label6.Top = pictureBox6.Top + 9 * pictureBox1.Height / 10;


                Font lfont = new Font(label1.Font.FontFamily, 50, label1.Font.Style);
                label1.Font = lfont;
                while (label1.Height < System.Windows.Forms.TextRenderer.MeasureText(label1.Text,
                new Font(label1.Font.FontFamily, label1.Font.Size, label1.Font.Style)).Height)
                {
                    lfont = new Font(label1.Font.FontFamily, label1.Font.Size - 0.5f, label1.Font.Style);
                    label1.Font = lfont;
                }
                label2.Font = lfont;
                label3.Font = lfont;
                label4.Font = lfont;
                label5.Font = lfont;
                label6.Font = lfont;

            }
        }

        private void frmSideScreen_Resize(object sender, EventArgs e)
        {
            frmResize();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void pctClick(object sender, EventArgs e, int ipct)
        {
            lastPctClicked = ipct;

            lblStatus.Text = "C" + ipct + pictureBoxes[ipct].Tag;

            if (pictureBoxes[ipct].Tag !=null)
                currentFolder = Path.Combine(currentFolder, pictureBoxes[ipct].Tag.ToString());
            loadMenu();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            frmFull frm = new frmFull();

            //currentFolder = Path.GetDirectoryName(currentFolder);

            string[] psachemins = new string[6];
            for (int i = 0; i < 6; i++)
            {
                if (this.pictureBoxes[i].Tag != null)
                    psachemins[i] = Path.Combine(baseFolder, currentFolder, this.pictureBoxes[i].Tag.ToString() + ".jpg"); ;
                // this.pictureBoxes[i].Tag = Path.GetFileName(pFiles[i]);
            }

            frm.giveInfos(0, psachemins, true);

            frm.Show();
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            currentFolder = "";
            loadMenu();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            //currentFolder = Directory.GetParent(currentFullFolder).FullName.Replace(baseFolder + Path.PathSeparator, "") ;
            currentFolder = Path.GetDirectoryName(currentFolder);
            loadMenu();
        }
    }
}


