namespace ETESP_Quiz
{
    partial class frmEditPerguntas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPerguntas));
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.headerTp = new System.Windows.Forms.Label();
            this.headerM = new System.Windows.Forms.Label();
            this.headerD = new System.Windows.Forms.Label();
            this.headerT = new System.Windows.Forms.Label();
            this.headerH = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAdd = new ETESP_Quiz.RoundedButton();
            this.btnVoltar = new ETESP_Quiz.RoundedButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(50, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pesquisar Título:";
            this.toolTip1.SetToolTip(this.label2, "Filtrar perguntas por título na tabela");
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(226, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(776, 29);
            this.textBox1.TabIndex = 10;
            this.toolTip1.SetToolTip(this.textBox1, "Filtrar perguntas por título na tabela");
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-149, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1350, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Clique em qualquer pergunta para editar/remover";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(51, 484);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ordenar por:";
            this.toolTip1.SetToolTip(this.label3, "Critério á ser usado para ordenar e agrupar entradas na tabela");
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Título",
            "Dificuldade",
            "Matéria",
            "Tipo"});
            this.comboBox1.Location = new System.Drawing.Point(191, 481);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 31);
            this.comboBox1.TabIndex = 13;
            this.toolTip1.SetToolTip(this.comboBox1, "Critério á ser usado para ordenar e agrupar entradas na tabela");
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.Controls.Add(this.headerTp, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.headerM, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.headerD, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.headerT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.headerH, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(53, 154);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(949, 321);
            this.tableLayoutPanel1.TabIndex = 19;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // headerTp
            // 
            this.headerTp.AutoSize = true;
            this.headerTp.BackColor = System.Drawing.Color.Transparent;
            this.headerTp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerTp.Location = new System.Drawing.Point(646, 1);
            this.headerTp.Name = "headerTp";
            this.headerTp.Size = new System.Drawing.Size(144, 319);
            this.headerTp.TabIndex = 15;
            this.headerTp.Text = "Tipo";
            this.headerTp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerM
            // 
            this.headerM.AutoSize = true;
            this.headerM.BackColor = System.Drawing.Color.Transparent;
            this.headerM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerM.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerM.Location = new System.Drawing.Point(495, 1);
            this.headerM.Name = "headerM";
            this.headerM.Size = new System.Drawing.Size(144, 319);
            this.headerM.TabIndex = 3;
            this.headerM.Text = "Matéria";
            this.headerM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerD
            // 
            this.headerD.AutoSize = true;
            this.headerD.BackColor = System.Drawing.Color.Transparent;
            this.headerD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerD.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerD.Location = new System.Drawing.Point(344, 1);
            this.headerD.Name = "headerD";
            this.headerD.Size = new System.Drawing.Size(144, 319);
            this.headerD.TabIndex = 2;
            this.headerD.Text = "Dificuldade";
            this.headerD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerT
            // 
            this.headerT.AutoSize = true;
            this.headerT.BackColor = System.Drawing.Color.Transparent;
            this.headerT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerT.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerT.Location = new System.Drawing.Point(4, 1);
            this.headerT.Name = "headerT";
            this.headerT.Size = new System.Drawing.Size(333, 319);
            this.headerT.TabIndex = 1;
            this.headerT.Text = "Título";
            this.headerT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headerH
            // 
            this.headerH.AutoSize = true;
            this.headerH.BackColor = System.Drawing.Color.Transparent;
            this.headerH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerH.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerH.Location = new System.Drawing.Point(797, 1);
            this.headerH.Name = "headerH";
            this.headerH.Size = new System.Drawing.Size(148, 319);
            this.headerH.TabIndex = 18;
            this.headerH.Text = "Habilitada";
            this.headerH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(746, 524);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(256, 40);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Adicionar Pergunta";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVoltar.BackColor = System.Drawing.Color.Red;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.Black;
            this.btnVoltar.Location = new System.Drawing.Point(55, 524);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(120, 40);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // frmEditPerguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1053, 619);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnVoltar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditPerguntas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmEditPerguntas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private ETESP_Quiz.RoundedButton btnAdd;
        private ETESP_Quiz.RoundedButton btnVoltar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label headerT;
        private System.Windows.Forms.Label headerM;
        private System.Windows.Forms.Label headerD;
        private System.Windows.Forms.Label headerTp;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label headerH;
    }
}