using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ETESP_Quiz
{
    public partial class frmDebug : Form
    {
        private int speed = 90;
        public frmDebug()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmJogoPergunta frmQC = new frmJogoPergunta(QuestionType.Full);
            frmQC.Size = Size;
            frmQC.Location = Location;
            frmQC.ShowDialog(this);
            this.Size = frmQC.Size;
            Location = frmQC.Location;
            Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmJogoPergunta frmQC = new frmJogoPergunta(QuestionType.Title);
            frmQC.Size = Size;
            frmQC.Location = Location;
            frmQC.ShowDialog(this);
            this.Size = frmQC.Size;
            Location = frmQC.Location;
            Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmJogoPergunta frmQC = new frmJogoPergunta(QuestionType.TxtAlts);
            frmQC.Size = Size;
            frmQC.Location = Location;
            frmQC.ShowDialog(this);
            this.Size = frmQC.Size;
            Location = frmQC.Location;
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmJogoPergunta frmQC = new frmJogoPergunta(QuestionType.Img);
            frmQC.Size = Size;
            frmQC.Location = Location;
            frmQC.ShowDialog(this);
            this.Size = frmQC.Size;
            Location = frmQC.Location;
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmJogoPergunta frmQC = new frmJogoPergunta(QuestionType.Txt);
            frmQC.Size = Size;
            frmQC.Location = Location;
            frmQC.ShowDialog(this);
            this.Size = frmQC.Size;
            Location = frmQC.Location;
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmJogoPergunta frmQC = new frmJogoPergunta(QuestionType.Alts);
            frmQC.Size = Size;
            frmQC.Location = Location;
            frmQC.ShowDialog(this);
            this.Size = frmQC.Size;
            Location = frmQC.Location;
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmJogoPergunta frmQC = new frmJogoPergunta(QuestionType.AltsImg);
            frmQC.ShowDialog(this);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmJogoResposta frmQC = new frmJogoResposta(frmJogoResposta.AnswerType.Text);
            frmQC.ShowDialog(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmJogoResposta frmQC = new frmJogoResposta(frmJogoResposta.AnswerType.Alts);
            frmQC.ShowDialog(this);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmJogoMostrarResposta frmQC = new frmJogoMostrarResposta();
            frmQC.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmJogoTelaFinal frmQC = new frmJogoTelaFinal();
            frmQC.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmJogoRanking frmQC = new frmJogoRanking();
            frmQC.ShowDialog();
        }
        private void frmRoleta_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Legends[0].Enabled = true;
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.Legends.Clear();
            chart1.Series[0]["PieStartAngle"] = "0";
            Color bcol = Color.Transparent;
            chart1.ChartAreas[0].BackColor = bcol;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (chart1.Series[0]["PieStartAngle"] == "360")
            {
                chart1.Series[0]["PieStartAngle"] = "0";
            }
            else
            {
                chart1.Series[0]["PieStartAngle"] = (double.Parse(chart1.Series[0]["PieStartAngle"]) + speed) + "";
            }
            if (chart2.Series[0]["PieStartAngle"] == "360")
            {
                chart2.Series[0]["PieStartAngle"] = "0";
            }
            else
            {
                chart2.Series[0]["PieStartAngle"] = (double.Parse(chart2.Series[0]["PieStartAngle"]) + speed) + "";
            }
            if (chart3.Series[0]["PieStartAngle"] == "360")
            {
                chart3.Series[0]["PieStartAngle"] = "0";
            }
            else
            {
                chart3.Series[0]["PieStartAngle"] = (double.Parse(chart3.Series[0]["PieStartAngle"]) + speed) + "";
            }
            if (chart4.Series[0]["PieStartAngle"] == "360")
            {
                chart4.Series[0]["PieStartAngle"] = "0";
            }
            else
            {
                chart4.Series[0]["PieStartAngle"] = (double.Parse(chart4.Series[0]["PieStartAngle"]) + speed) + "";
            }
            if (chart5.Series[0]["PieStartAngle"] == "360")
            {
                chart5.Series[0]["PieStartAngle"] = "0";
            }
            else
            {
                chart5.Series[0]["PieStartAngle"] = (double.Parse(chart5.Series[0]["PieStartAngle"]) + speed) + "";
            }
            if (chart6.Series[0]["PieStartAngle"] == "360")
            {
                chart6.Series[0]["PieStartAngle"] = "0";
            }
            else
            {
                chart6.Series[0]["PieStartAngle"] = (double.Parse(chart6.Series[0]["PieStartAngle"]) + speed) + "";
            }
        }

        private void FrmDebug_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Series[0].Points.Add(1);
            chart1.Legends[0].Enabled = true;
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart1.Legends.Clear();
            chart1.Series[0]["PieStartAngle"] = "0";
            Color bcol = Color.Transparent;
            chart1.ChartAreas[0].BackColor = bcol;
            this.WindowState = FormWindowState.Maximized;
            chart2.Series[0].ChartType = SeriesChartType.Pie;
            chart2.Series[0].Points.Add(1);
            chart2.Series[0].Points.Add(1);
            chart2.Series[0].Points.Add(1);
            chart2.Series[0].Points.Add(1);
            chart2.Series[0].Points.Add(1);
            chart2.Series[0].Points.Add(1);
            chart2.Series[0].Points.Add(1);
            chart2.Legends[0].Enabled = true;
            chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart2.Legends.Clear();
            chart2.Series[0]["PieStartAngle"] = "0";
            bcol = Color.Transparent;
            chart2.ChartAreas[0].BackColor = bcol;
            this.WindowState = FormWindowState.Maximized;
            chart3.Series[0].ChartType = SeriesChartType.Pie;
            chart3.Series[0].Points.Add(1);
            chart3.Series[0].Points.Add(1);
            chart3.Series[0].Points.Add(1);
            chart3.Series[0].Points.Add(1);
            chart3.Series[0].Points.Add(1);
            chart3.Series[0].Points.Add(1);
            chart3.Series[0].Points.Add(1);
            chart3.Legends[0].Enabled = true;
            chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart3.Legends.Clear();
            chart3.Series[0]["PieStartAngle"] = "0";
            bcol = Color.Transparent;
            chart3.ChartAreas[0].BackColor = bcol;
            this.WindowState = FormWindowState.Maximized;
            chart4.Series[0].ChartType = SeriesChartType.Pie;
            chart4.Series[0].Points.Add(1);
            chart4.Series[0].Points.Add(1);
            chart4.Series[0].Points.Add(1);
            chart4.Series[0].Points.Add(1);
            chart4.Series[0].Points.Add(1);
            chart4.Series[0].Points.Add(1);
            chart4.Series[0].Points.Add(1);
            chart4.Legends[0].Enabled = true;
            chart4.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart4.Legends.Clear();
            chart4.Series[0]["PieStartAngle"] = "0";
            bcol = Color.Transparent;
            chart4.ChartAreas[0].BackColor = bcol;
            this.WindowState = FormWindowState.Maximized;
            chart5.Series[0].ChartType = SeriesChartType.Pie;
            chart5.Series[0].Points.Add(1);
            chart5.Series[0].Points.Add(1);
            chart5.Series[0].Points.Add(1);
            chart5.Series[0].Points.Add(1);
            chart5.Series[0].Points.Add(1);
            chart5.Series[0].Points.Add(1);
            chart5.Series[0].Points.Add(1);
            chart5.Legends[0].Enabled = true;
            chart5.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart5.Legends.Clear();
            chart5.Series[0]["PieStartAngle"] = "0";
            bcol = Color.Transparent;
            chart5.ChartAreas[0].BackColor = bcol;
            this.WindowState = FormWindowState.Maximized;
            chart6.Series[0].ChartType = SeriesChartType.Pie;
            chart6.Series[0].Points.Add(1);
            chart6.Series[0].Points.Add(1);
            chart6.Series[0].Points.Add(1);
            chart6.Series[0].Points.Add(1);
            chart6.Series[0].Points.Add(1);
            chart6.Series[0].Points.Add(1);
            chart6.Series[0].Points.Add(1);
            chart6.Legends[0].Enabled = true;
            chart6.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart6.Legends.Clear();
            chart6.Series[0]["PieStartAngle"] = "0";
             bcol = Color.Transparent;
            chart6.ChartAreas[0].BackColor = bcol;
        }
    }
    
}
