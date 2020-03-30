namespace ETESP_Quiz
{
    partial class frmJogoMostrarResposta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJogoMostrarResposta));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblResposta = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblNomes = new System.Windows.Forms.Label();
            this.lblCertoErrado = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(9, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 91);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "A resposta do grupo {0}:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResposta
            // 
            this.lblResposta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblResposta.BackColor = System.Drawing.Color.Transparent;
            this.lblResposta.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResposta.ForeColor = System.Drawing.Color.White;
            this.lblResposta.Location = new System.Drawing.Point(9, 99);
            this.lblResposta.Name = "lblResposta";
            this.lblResposta.Size = new System.Drawing.Size(800, 134);
            this.lblResposta.TabIndex = 11;
            this.lblResposta.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris fringilla, mi ac " +
    "tristique faucibus, velit felis mollis quam, non dapibus. ";
            this.lblResposta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(359, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 32);
            this.button2.TabIndex = 13;
            this.button2.Text = "Próxima";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblNomes
            // 
            this.lblNomes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNomes.BackColor = System.Drawing.Color.Transparent;
            this.lblNomes.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomes.ForeColor = System.Drawing.Color.White;
            this.lblNomes.Location = new System.Drawing.Point(13, 318);
            this.lblNomes.Name = "lblNomes";
            this.lblNomes.Size = new System.Drawing.Size(800, 100);
            this.lblNomes.TabIndex = 14;
            this.lblNomes.Text = "Integrantes: PrimeiroNome, SegundoNome,TerceiroNome,QuartoNome,QuintoNome";
            this.lblNomes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCertoErrado
            // 
            this.lblCertoErrado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCertoErrado.BackColor = System.Drawing.Color.Transparent;
            this.lblCertoErrado.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCertoErrado.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCertoErrado.Location = new System.Drawing.Point(13, 249);
            this.lblCertoErrado.Name = "lblCertoErrado";
            this.lblCertoErrado.Size = new System.Drawing.Size(800, 52);
            this.lblCertoErrado.TabIndex = 15;
            this.lblCertoErrado.Text = "Está Certa!";
            this.lblCertoErrado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(359, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 10);
            this.button3.TabIndex = 16;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmJogoMostrarResposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(38, 38, 43);
            this.ClientSize = new System.Drawing.Size(819, 482);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblCertoErrado);
            this.Controls.Add(this.lblNomes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblResposta);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmJogoMostrarResposta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ETESP Quiz";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmJogoMostrarResposta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblResposta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblNomes;
        private System.Windows.Forms.Label lblCertoErrado;
        private System.Windows.Forms.Button button3;
    }
}