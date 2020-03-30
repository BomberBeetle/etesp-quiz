namespace ETESP_Quiz
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ttJogar = new System.Windows.Forms.ToolTip(this.components);
            this.btnGroup = new ETESP_Quiz.RoundedButton();
            this.btnDebug = new ETESP_Quiz.RoundedButton();
            this.btnExit = new ETESP_Quiz.RoundedButton();
            this.btnEditQuiz = new ETESP_Quiz.RoundedButton();
            this.btnParticipantes = new ETESP_Quiz.RoundedButton();
            this.btnJogar = new ETESP_Quiz.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ETESP_Quiz.Properties.Resources.logoQuiz;
            this.pictureBox1.Location = new System.Drawing.Point(434, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(484, 258);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnGroup
            // 
            this.btnGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGroup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnGroup.FlatAppearance.BorderSize = 0;
            this.btnGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroup.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnGroup.Location = new System.Drawing.Point(588, 416);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(160, 50);
            this.btnGroup.TabIndex = 6;
            this.btnGroup.Text = "EQUIPES";
            this.ttJogar.SetToolTip(this.btnGroup, "Clique aqui para adicionar, editar e remover equipes e seus participantes.");
            this.btnGroup.UseVisualStyleBackColor = false;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDebug.FlatAppearance.BorderSize = 0;
            this.btnDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebug.Location = new System.Drawing.Point(632, 650);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 5;
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnExit.Location = new System.Drawing.Point(588, 584);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(160, 50);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "SAIR";
            this.ttJogar.SetToolTip(this.btnExit, "Clique aqui para terminar o programa.");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnEditQuiz
            // 
            this.btnEditQuiz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditQuiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnEditQuiz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditQuiz.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnEditQuiz.FlatAppearance.BorderSize = 0;
            this.btnEditQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditQuiz.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditQuiz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnEditQuiz.Location = new System.Drawing.Point(588, 528);
            this.btnEditQuiz.Name = "btnEditQuiz";
            this.btnEditQuiz.Size = new System.Drawing.Size(160, 50);
            this.btnEditQuiz.TabIndex = 3;
            this.btnEditQuiz.Text = "EDITAR QUIZ";
            this.ttJogar.SetToolTip(this.btnEditQuiz, "Clique aqui para adicionar, editar e remover questões, matérias e dificuldades.");
            this.btnEditQuiz.UseVisualStyleBackColor = false;
            this.btnEditQuiz.Click += new System.EventHandler(this.btnEditQuiz_Click);
            // 
            // btnParticipantes
            // 
            this.btnParticipantes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnParticipantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnParticipantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnParticipantes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnParticipantes.FlatAppearance.BorderSize = 0;
            this.btnParticipantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParticipantes.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParticipantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnParticipantes.Location = new System.Drawing.Point(588, 472);
            this.btnParticipantes.Name = "btnParticipantes";
            this.btnParticipantes.Size = new System.Drawing.Size(160, 50);
            this.btnParticipantes.TabIndex = 2;
            this.btnParticipantes.Text = "PARTICIPANTES";
            this.ttJogar.SetToolTip(this.btnParticipantes, "Clique aqui para adicionar, editar e remover participantes.");
            this.btnParticipantes.UseVisualStyleBackColor = false;
            this.btnParticipantes.Click += new System.EventHandler(this.BtnParticipantes_Click);
            // 
            // btnJogar
            // 
            this.btnJogar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnJogar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.btnJogar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJogar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnJogar.FlatAppearance.BorderSize = 0;
            this.btnJogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.btnJogar.Location = new System.Drawing.Point(588, 360);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(160, 50);
            this.btnJogar.TabIndex = 1;
            this.btnJogar.Text = "JOGAR";
            this.ttJogar.SetToolTip(this.btnJogar, "Clique neste botão para definir as configurações do jogo, e depois começa-lo.");
            this.btnJogar.UseVisualStyleBackColor = false;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEditQuiz);
            this.Controls.Add(this.btnParticipantes);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ETESP Quiz";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ETESP_Quiz.RoundedButton btnJogar;
        private ETESP_Quiz.RoundedButton btnParticipantes;
        private ETESP_Quiz.RoundedButton btnEditQuiz;
        private ETESP_Quiz.RoundedButton btnExit;
        private ETESP_Quiz.RoundedButton btnDebug;
        private ETESP_Quiz.RoundedButton btnGroup;
        private System.Windows.Forms.ToolTip ttJogar;
    }
}

