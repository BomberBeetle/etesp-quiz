namespace Protótipo_Guimel
{
    partial class frmParticpantes
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
            this.btnEdit1 = new System.Windows.Forms.Button();
            this.btnEdit2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEdit1
            // 
            this.btnEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit1.BackColor = System.Drawing.Color.Lime;
            this.btnEdit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnEdit1.Location = new System.Drawing.Point(367, 215);
            this.btnEdit1.Name = "btnEdit1";
            this.btnEdit1.Size = new System.Drawing.Size(245, 79);
            this.btnEdit1.TabIndex = 0;
            this.btnEdit1.Text = "Editar Participantes";
            this.btnEdit1.UseVisualStyleBackColor = false;
            this.btnEdit1.Click += new System.EventHandler(this.BtnEdit1_Click);
            // 
            // btnEdit2
            // 
            this.btnEdit2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit2.BackColor = System.Drawing.Color.Lime;
            this.btnEdit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnEdit2.Location = new System.Drawing.Point(367, 337);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(245, 79);
            this.btnEdit2.TabIndex = 1;
            this.btnEdit2.Text = "Editar Equipes";
            this.btnEdit2.UseVisualStyleBackColor = false;
            this.btnEdit2.Click += new System.EventHandler(this.btnEdit2_Click);
            // 
            // frmParticpantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 657);
            this.Controls.Add(this.btnEdit1);
            this.Controls.Add(this.btnEdit2);
            this.Name = "frmParticpantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Editar particpantes ou equipe";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEdit1;
        private System.Windows.Forms.Button btnEdit2;
    }
}