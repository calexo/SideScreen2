namespace SideScreen2
{
    partial class frmFull
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pctPrev = new System.Windows.Forms.PictureBox();
            this.pctNext = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pctPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pctPrev
            // 
            this.pctPrev.BackColor = System.Drawing.Color.Transparent;
            this.pctPrev.Location = new System.Drawing.Point(12, 156);
            this.pctPrev.Name = "pctPrev";
            this.pctPrev.Size = new System.Drawing.Size(185, 298);
            this.pctPrev.TabIndex = 2;
            this.pctPrev.TabStop = false;
            this.pctPrev.Click += new System.EventHandler(this.pctPrev_Click);
            // 
            // pctNext
            // 
            this.pctNext.BackColor = System.Drawing.Color.Transparent;
            this.pctNext.Location = new System.Drawing.Point(608, 112);
            this.pctNext.Name = "pctNext";
            this.pctNext.Size = new System.Drawing.Size(185, 298);
            this.pctNext.TabIndex = 1;
            this.pctNext.TabStop = false;
            this.pctNext.Click += new System.EventHandler(this.pctNext_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(75, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(610, 269);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmFull
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1264, 646);
            this.Controls.Add(this.pctPrev);
            this.Controls.Add(this.pctNext);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFull";
            this.Text = "Calexo SideScreen Full";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFull_Load);
            this.Shown += new System.EventHandler(this.frmFull_Shown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmFull_MouseClick);
            this.Resize += new System.EventHandler(this.frmFull_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pctPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pctNext;
        private System.Windows.Forms.PictureBox pctPrev;
        private System.Windows.Forms.Timer timer1;
    }
}