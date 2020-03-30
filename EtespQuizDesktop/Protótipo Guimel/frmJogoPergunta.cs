using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ETESP_Quiz
{
    
    public enum QuestionType
    {
        Title=0,
        Txt=1,
        Alts=2,
        Img=4,
        TxtAlts = Txt|Alts,
        TxtImg = Txt|Img,
        AltsImg = Alts|Img,
        Full = Txt|Alts|Img
    }
    public partial class frmJogoPergunta : Form
    {
        SoundPlayer sp = new SoundPlayer();
        public int maxTime;
        public bool dicaMostrada = false;
        public frmJogoPergunta(QuestionType mode)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            if (mode == QuestionType.Title)
            {
                lblTxt.Visible = false;
                altsPanel.Visible = false;
                questionPic.Visible = false;
                lblTitle.Location = new Point(lblTitle.Location.X,lblTxt.Location.Y);
            }
            else if (mode == QuestionType.Img)
            {
                lblTxt.Visible = false;
                altsPanel.Visible = false;
                questionPic.Width = lblTitle.Width;
                questionPic.Location = lblTxt.Location;
            }
            else if(mode == QuestionType.Txt)
            {
                altsPanel.Visible = false;
                questionPic.Visible = false;
                lblTxt.Width = lblTitle.Width;
            }
            else if(mode == QuestionType.Alts)
            {
                questionPic.Visible = false;
                altsPanel.Location = lblTxt.Location;
                questionPic.Visible = false;
                lblTxt.Visible = false;
            }
            else if(mode == QuestionType.AltsImg)
            {
                lblTxt.Visible = false;
                questionPic.Width = lblTitle.Width;
                questionPic.Location = lblTxt.Location;
            }
            else if(mode == QuestionType.TxtAlts)
            {
                questionPic.Visible = false;
                lblTxt.Width = lblTitle.Width;
            }
            else if(mode == QuestionType.TxtImg)
            {
                altsPanel.Visible = false;
            }
            else if(mode == QuestionType.Full)
            {
                //Código Provisório!
            }
            sp.Stream = Properties.Resources.tense;
            sp.Load();
        }

        private void FrmJogoPergunta_Load(object sender, EventArgs e)
        {
            (panel1.Controls["btnHide"] as RoundedButton).borderRadius = 15;
            panel1.Visible = false;
            circularProgressBar1.Maximum = maxTime;
            circularProgressBar1.Value = maxTime;
            circularProgressBar1.Text = maxTime.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void lblAlt1_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Iniciar Timer")
            {
                sp.Play();
                timer1.Enabled = true;
                button1.Text = "Finalizar";      
            }
            else
            {
                button1.Click -= button1_Click;
                sp.Stop();
                sp.Dispose();
                timer1.Enabled = false;
                SoundPlayer ring = new SoundPlayer();
                ring.Stream = Properties.Resources.ring;
                ring.PlaySync();
                ring.Stop();
                Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(circularProgressBar1.Value != 0)
            {
                circularProgressBar1.Value--;
                circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            }
            else
            {
                button1.Click -= button1_Click;
                sp.Stop();
                timer1.Enabled = false;
                sp.Dispose();
                SoundPlayer ring = new SoundPlayer();
                ring.Stream = Properties.Resources.ring;
                ring.PlaySync();
                ring.Stop();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            dicaMostrada = true;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
