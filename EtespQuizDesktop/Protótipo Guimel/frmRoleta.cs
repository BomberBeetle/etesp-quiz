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
    public partial class frmRoleta : Form
    {
        private int speed = 30;
        private Random rndRandom = new Random();
        public int materia;
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.spin);
        public frmRoleta()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
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
            chart1.Series[0]["PieStartAngle"] = 30 * rndRandom.Next(0, 12) + "";
            Color bcol = Color.Transparent;
            chart1.ChartAreas[0].BackColor = bcol;
            sp.PlayLooping();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chart1.Series[0]["PieStartAngle"] == "360")
            {
                chart1.Series[0]["PieStartAngle"] = "0";
            }
            else
            {
                chart1.Series[0]["PieStartAngle"] = (double.Parse(chart1.Series[0]["PieStartAngle"]) + speed) + "";
            }
            label2.Text = System.IO.Path.GetRandomFileName();
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            sp.Stop();
            while (true)
            {
                var rnd = new Random();
                materia = rnd.Next(0, JogoStatic.Materias.Rows.Count);
                if(!JogoStatic.MateriasExcluidas.Contains(materia))
                break;
            }
            label2.Text = JogoStatic.Materias.Rows[materia]["T_NOME"].ToString();
            roundedButton1.Visible = true;
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
