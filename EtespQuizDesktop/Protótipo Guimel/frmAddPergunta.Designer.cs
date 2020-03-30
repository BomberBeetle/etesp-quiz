namespace ETESP_Quiz
{
    partial class frmAddPergunta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddPergunta));
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTop = new System.Windows.Forms.ComboBox();
            this.btnDelete = new ETESP_Quiz.RoundedButton();
            this.btnSave = new ETESP_Quiz.RoundedButton();
            this.btnCancel = new ETESP_Quiz.RoundedButton();
            this.txtCorpo = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDif = new System.Windows.Forms.ComboBox();
            this.btnLoadImg = new ETESP_Quiz.RoundedButton();
            this.btnRemImg = new ETESP_Quiz.RoundedButton();
            this.btnPreview = new ETESP_Quiz.RoundedButton();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.btnAlts = new ETESP_Quiz.RoundedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblInts = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDica = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(38, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Matéria:";
            this.toolTip1.SetToolTip(this.label3, "Matéria da pergunta");
            // 
            // comboBoxTop
            // 
            this.comboBoxTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTop.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTop.FormattingEnabled = true;
            this.comboBoxTop.Location = new System.Drawing.Point(143, 363);
            this.comboBoxTop.Name = "comboBoxTop";
            this.comboBoxTop.Size = new System.Drawing.Size(251, 31);
            this.comboBoxTop.TabIndex = 13;
            this.toolTip1.SetToolTip(this.comboBoxTop, "Matéria da pergunta");
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(36, 566);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(119, 40);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Deletar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(36, 441);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 40);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(36, 524);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 40);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCorpo
            // 
            this.txtCorpo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCorpo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorpo.Location = new System.Drawing.Point(143, 103);
            this.txtCorpo.MaxLength = 600;
            this.txtCorpo.Multiline = true;
            this.txtCorpo.Name = "txtCorpo";
            this.txtCorpo.Size = new System.Drawing.Size(728, 118);
            this.txtCorpo.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtCorpo, "Texto no corpo da pergunta. Pode ser deixado em branco se o título já for suficie" +
        "nte.");
            this.txtCorpo.TextChanged += new System.EventHandler(this.txtCorpo_TextChanged);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTitulo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(143, 23);
            this.txtTitulo.MaxLength = 150;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(728, 31);
            this.txtTitulo.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtTitulo, "Título/texto de introdução da pergunta");
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Texto:";
            this.toolTip1.SetToolTip(this.label2, "Texto no corpo da pergunta. Pode ser deixado em branco se o título já for suficie" +
        "nte.");
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Título:";
            this.toolTip1.SetToolTip(this.label1, "Título/texto de introdução da pergunta");
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(619, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "600 caracteres restantes";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(445, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Dificuldade:";
            this.toolTip1.SetToolTip(this.label5, "Dificuldade da pergunta.");
            // 
            // comboBoxDif
            // 
            this.comboBoxDif.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxDif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDif.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDif.FormattingEnabled = true;
            this.comboBoxDif.Location = new System.Drawing.Point(594, 358);
            this.comboBoxDif.Name = "comboBoxDif";
            this.comboBoxDif.Size = new System.Drawing.Size(277, 31);
            this.comboBoxDif.TabIndex = 19;
            this.toolTip1.SetToolTip(this.comboBoxDif, "Dificuldade da pergunta.");
            this.comboBoxDif.SelectedIndexChanged += new System.EventHandler(this.comboBoxDif_SelectedIndexChanged);
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLoadImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadImg.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImg.Location = new System.Drawing.Point(527, 450);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(196, 61);
            this.btnLoadImg.TabIndex = 22;
            this.btnLoadImg.Text = "Carregar Imagem";
            this.toolTip1.SetToolTip(this.btnLoadImg, "Abrir menu de seleção de imagem.");
            this.btnLoadImg.UseVisualStyleBackColor = false;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // btnRemImg
            // 
            this.btnRemImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemImg.BackColor = System.Drawing.Color.Red;
            this.btnRemImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemImg.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemImg.Location = new System.Drawing.Point(527, 534);
            this.btnRemImg.Name = "btnRemImg";
            this.btnRemImg.Size = new System.Drawing.Size(196, 61);
            this.btnRemImg.TabIndex = 23;
            this.btnRemImg.Text = "Remover Imagem";
            this.toolTip1.SetToolTip(this.btnRemImg, "Remove a imagem da questão.");
            this.btnRemImg.UseVisualStyleBackColor = false;
            this.btnRemImg.Click += new System.EventHandler(this.btnRemImg_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(37, 484);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(119, 39);
            this.btnPreview.TabIndex = 24;
            this.btnPreview.Text = "Prever";
            this.toolTip1.SetToolTip(this.btnPreview, "Ver uma prévia de como a pergunta será apresentada para os participantes");
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(38, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Habilitar Pergunta:";
            this.toolTip1.SetToolTip(this.label6, "Define se a pergunta pode aparecer no Quiz.");
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(262, 411);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 26;
            this.toolTip1.SetToolTip(this.checkBox1, "Define se a pergunta pode aparecer no Quiz.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(38, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "Tipo:";
            this.toolTip1.SetToolTip(this.label7, "Tipo da pergunta, dissertativa ou teste.");
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "Dissertativa",
            "Teste"});
            this.comboBoxTipo.Location = new System.Drawing.Point(143, 63);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(728, 31);
            this.comboBoxTipo.TabIndex = 28;
            this.toolTip1.SetToolTip(this.comboBoxTipo, "Tipo da pergunta, dissertativa ou teste.");
            this.comboBoxTipo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipo_SelectedIndexChanged);
            // 
            // btnAlts
            // 
            this.btnAlts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAlts.BackColor = System.Drawing.Color.Orchid;
            this.btnAlts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlts.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlts.Location = new System.Drawing.Point(741, 452);
            this.btnAlts.Name = "btnAlts";
            this.btnAlts.Size = new System.Drawing.Size(137, 143);
            this.btnAlts.TabIndex = 29;
            this.btnAlts.Text = "Editar Alternativas";
            this.toolTip1.SetToolTip(this.btnAlts, "Editar as alternativas da questão (somente para tipos teste)");
            this.btnAlts.UseVisualStyleBackColor = false;
            this.btnAlts.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(174, 441);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // lblInts
            // 
            this.lblInts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInts.AutoSize = true;
            this.lblInts.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInts.ForeColor = System.Drawing.Color.White;
            this.lblInts.Location = new System.Drawing.Point(445, 402);
            this.lblInts.Name = "lblInts";
            this.lblInts.Size = new System.Drawing.Size(237, 25);
            this.lblInts.TabIndex = 30;
            this.lblInts.Text = "Valor de Intensidade: ";
            this.toolTip1.SetToolTip(this.lblInts, "Um valor que serve para comparar quão difícil é esta dificuldade comparada ás out" +
        "ras.");
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(38, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 25);
            this.label9.TabIndex = 31;
            this.label9.Text = "Dica:";
            this.toolTip1.SetToolTip(this.label9, "Dica, que pode ser revelada para os participantes, mas que diminuirá os pontos ga" +
        "nhos. Deixe em branco se não quiser que esteja presente.");
            // 
            // txtDica
            // 
            this.txtDica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDica.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDica.Location = new System.Drawing.Point(143, 261);
            this.txtDica.MaxLength = 150;
            this.txtDica.Multiline = true;
            this.txtDica.Name = "txtDica";
            this.txtDica.Size = new System.Drawing.Size(728, 61);
            this.txtDica.TabIndex = 32;
            this.toolTip1.SetToolTip(this.txtDica, "Dica, que pode ser revelada para os participantes, mas que diminuirá os pontos ga" +
        "nhos. Deixe em branco se não quiser que esteja presente.");
            this.txtDica.TextChanged += new System.EventHandler(this.txtDica_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(619, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(259, 25);
            this.label10.TabIndex = 33;
            this.label10.Text = "150 caracteres restantes";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "png";
            this.openFileDialog1.FileName = "OpenImagemDialog";
            // 
            // frmAddPergunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(38, 38, 43);
            this.ClientSize = new System.Drawing.Size(910, 628);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDica);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblInts);
            this.Controls.Add(this.btnAlts);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnRemImg);
            this.Controls.Add(this.btnLoadImg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxDif);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTop);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCorpo);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddPergunta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ETESP Quiz";
            this.Load += new System.EventHandler(this.frmAddPergunta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTop;
        private ETESP_Quiz.RoundedButton btnDelete;
        private ETESP_Quiz.RoundedButton btnSave;
        private ETESP_Quiz.RoundedButton btnCancel;
        private System.Windows.Forms.TextBox txtCorpo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxDif;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ETESP_Quiz.RoundedButton btnLoadImg;
        private ETESP_Quiz.RoundedButton btnRemImg;
        private ETESP_Quiz.RoundedButton btnPreview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private ETESP_Quiz.RoundedButton btnAlts;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblInts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDica;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}