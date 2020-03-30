namespace ETESP_Quiz
{
    partial class frmJogoPergunta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJogoPergunta));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTxt = new System.Windows.Forms.Label();
            this.lblAlt1 = new System.Windows.Forms.Label();
            this.altsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlt5 = new System.Windows.Forms.Label();
            this.lblAlt4 = new System.Windows.Forms.Label();
            this.lblAlt3 = new System.Windows.Forms.Label();
            this.lblAlt2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.questionPic = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDica = new System.Windows.Forms.Label();
            this.btnHide = new ETESP_Quiz.RoundedButton();
            this.button3 = new System.Windows.Forms.Button();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.altsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionPic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(29, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1290, 83);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Leia o seguinte e texto e responda:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTxt
            // 
            this.lblTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTxt.BackColor = System.Drawing.Color.Transparent;
            this.lblTxt.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt.ForeColor = System.Drawing.Color.White;
            this.lblTxt.Location = new System.Drawing.Point(29, 95);
            this.lblTxt.Name = "lblTxt";
            this.lblTxt.Size = new System.Drawing.Size(841, 308);
            this.lblTxt.TabIndex = 1;
            this.lblTxt.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblAlt1
            // 
            this.lblAlt1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAlt1.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlt1.ForeColor = System.Drawing.Color.White;
            this.lblAlt1.Location = new System.Drawing.Point(3, 0);
            this.lblAlt1.Name = "lblAlt1";
            this.lblAlt1.Size = new System.Drawing.Size(1096, 59);
            this.lblAlt1.TabIndex = 7;
            this.lblAlt1.Click += new System.EventHandler(this.lblAlt1_Click);
            // 
            // altsPanel
            // 
            this.altsPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.altsPanel.ColumnCount = 1;
            this.altsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.altsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.altsPanel.Controls.Add(this.lblAlt5, 0, 4);
            this.altsPanel.Controls.Add(this.lblAlt4, 0, 3);
            this.altsPanel.Controls.Add(this.lblAlt3, 0, 2);
            this.altsPanel.Controls.Add(this.lblAlt2, 0, 1);
            this.altsPanel.Controls.Add(this.lblAlt1, 0, 0);
            this.altsPanel.Location = new System.Drawing.Point(29, 417);
            this.altsPanel.Name = "altsPanel";
            this.altsPanel.RowCount = 5;
            this.altsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.altsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.altsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.altsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.altsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.altsPanel.Size = new System.Drawing.Size(1102, 297);
            this.altsPanel.TabIndex = 8;
            this.altsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblAlt5
            // 
            this.lblAlt5.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAlt5.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlt5.ForeColor = System.Drawing.Color.White;
            this.lblAlt5.Location = new System.Drawing.Point(3, 236);
            this.lblAlt5.Name = "lblAlt5";
            this.lblAlt5.Size = new System.Drawing.Size(1096, 61);
            this.lblAlt5.TabIndex = 11;
            // 
            // lblAlt4
            // 
            this.lblAlt4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAlt4.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlt4.ForeColor = System.Drawing.Color.White;
            this.lblAlt4.Location = new System.Drawing.Point(3, 177);
            this.lblAlt4.Name = "lblAlt4";
            this.lblAlt4.Size = new System.Drawing.Size(1096, 59);
            this.lblAlt4.TabIndex = 10;
            // 
            // lblAlt3
            // 
            this.lblAlt3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAlt3.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlt3.ForeColor = System.Drawing.Color.White;
            this.lblAlt3.Location = new System.Drawing.Point(3, 118);
            this.lblAlt3.Name = "lblAlt3";
            this.lblAlt3.Size = new System.Drawing.Size(1096, 59);
            this.lblAlt3.TabIndex = 9;
            // 
            // lblAlt2
            // 
            this.lblAlt2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAlt2.Font = new System.Drawing.Font("Century Gothic", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlt2.ForeColor = System.Drawing.Color.White;
            this.lblAlt2.Location = new System.Drawing.Point(3, 59);
            this.lblAlt2.Name = "lblAlt2";
            this.lblAlt2.Size = new System.Drawing.Size(1096, 59);
            this.lblAlt2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1158, 576);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 45);
            this.button1.TabIndex = 9;
            this.button1.Text = "Iniciar Timer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // questionPic
            // 
            this.questionPic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.questionPic.BackColor = System.Drawing.Color.White;
            this.questionPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.questionPic.Location = new System.Drawing.Point(891, 92);
            this.questionPic.Name = "questionPic";
            this.questionPic.Size = new System.Drawing.Size(428, 296);
            this.questionPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.questionPic.TabIndex = 2;
            this.questionPic.TabStop = false;
            this.questionPic.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1158, 628);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 45);
            this.button2.TabIndex = 12;
            this.button2.Text = "Mostrar Dica";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.lblDica);
            this.panel1.Controls.Add(this.btnHide);
            this.panel1.Location = new System.Drawing.Point(335, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 420);
            this.panel1.TabIndex = 13;
            this.panel1.Visible = false;
            // 
            // lblDica
            // 
            this.lblDica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDica.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDica.ForeColor = System.Drawing.Color.White;
            this.lblDica.Location = new System.Drawing.Point(30, 25);
            this.lblDica.Name = "lblDica";
            this.lblDica.Size = new System.Drawing.Size(587, 290);
            this.lblDica.TabIndex = 8;
            this.lblDica.Text = " ";
            // 
            // btnHide
            // 
            this.btnHide.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHide.BackColor = System.Drawing.Color.Red;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Location = new System.Drawing.Point(512, 359);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(111, 40);
            this.btnHide.TabIndex = 7;
            this.btnHide.Text = "Fechar";
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(1224, 690);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Voltar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 1000;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.White;
            this.circularProgressBar1.InnerColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(1158, 417);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.Honeydew;
            this.circularProgressBar1.OuterMargin = -25;
            this.circularProgressBar1.OuterWidth = 26;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.circularProgressBar1.ProgressWidth = 25;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar1.Size = new System.Drawing.Size(147, 153);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 15;
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.Value = 100;
            // 
            // frmJogoPergunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.circularProgressBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.altsPanel);
            this.Controls.Add(this.questionPic);
            this.Controls.Add(this.lblTxt);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJogoPergunta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ETESP Quiz";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmJogoPergunta_Load);
            this.altsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionPic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTxt;
        private System.Windows.Forms.PictureBox questionPic;
        private System.Windows.Forms.Label lblAlt1;
        private System.Windows.Forms.TableLayoutPanel altsPanel;
        private System.Windows.Forms.Label lblAlt5;
        private System.Windows.Forms.Label lblAlt4;
        private System.Windows.Forms.Label lblAlt3;
        private System.Windows.Forms.Label lblAlt2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDica;
        private RoundedButton btnHide;
        private System.Windows.Forms.Button button3;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
    }
}