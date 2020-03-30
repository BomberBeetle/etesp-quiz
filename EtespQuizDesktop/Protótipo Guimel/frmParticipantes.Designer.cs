namespace ETESP_Quiz
{
    partial class frmParticipantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParticipantes));
            this.btnEdit1 = new ETESP_Quiz.RoundedButton();
            this.btnEdit2 = new ETESP_Quiz.RoundedButton();
            this.roundButton2 = new WindowsFormsApplication1.RoundButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnEdit1
            // 
            this.btnEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnEdit1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnEdit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnEdit1.Location = new System.Drawing.Point(132, 84);
            this.btnEdit1.Name = "btnEdit1";
            this.btnEdit1.Size = new System.Drawing.Size(245, 79);
            this.btnEdit1.TabIndex = 0;
            this.btnEdit1.Text = "Editar Participantes";
            this.toolTip1.SetToolTip(this.btnEdit1, "Clique aqui para editar, adicionar e remover participantes.");
            this.btnEdit1.UseVisualStyleBackColor = false;
            this.btnEdit1.Click += new System.EventHandler(this.BtnEdit1_Click);
            // 
            // btnEdit2
            // 
            this.btnEdit2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnEdit2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnEdit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnEdit2.Location = new System.Drawing.Point(132, 206);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(245, 79);
            this.btnEdit2.TabIndex = 1;
            this.btnEdit2.Text = "Adicionar Participante";
            this.toolTip1.SetToolTip(this.btnEdit2, "Clique aqui para adicionar um participante.");
            this.btnEdit2.UseVisualStyleBackColor = false;
            this.btnEdit2.Click += new System.EventHandler(this.btnEdit2_Click);
            // 
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.roundButton2.BackgroundImage = global::ETESP_Quiz.Properties.Resources.backbutt;
            this.roundButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundButton2.FlatAppearance.BorderSize = 0;
            this.roundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.roundButton2.Location = new System.Drawing.Point(12, 12);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.Size = new System.Drawing.Size(75, 75);
            this.roundButton2.TabIndex = 6;
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // frmParticipantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(485, 345);
            this.Controls.Add(this.roundButton2);
            this.Controls.Add(this.btnEdit1);
            this.Controls.Add(this.btnEdit2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmParticipantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ETESP Quiz";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private ETESP_Quiz.RoundedButton btnEdit1;
        private ETESP_Quiz.RoundedButton btnEdit2;
        private WindowsFormsApplication1.RoundButton roundButton2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}