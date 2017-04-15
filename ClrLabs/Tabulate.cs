using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Math;

namespace Wednesday
{
    public partial class Tabulate : Form
    {
        public Tabulate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double tstart = 0;
            double tstop = 0;
            double tstep = 0;
            double a = 0;
            double tx;
            double ty;
            String ta = "";

            bool err = false;

            if (comboBox1.SelectedIndex != -1) ta = comboBox1.Items[comboBox1.SelectedIndex].ToString();

            err = Double.TryParse(textBox1.Text, out tstart) && Double.TryParse(textBox2.Text, out tstop) && Double.TryParse(textBox3.Text, out tstep) && Double.TryParse(ta, out a);

            if (!err || tstart >= tstop || tstep <= 0 || tstep > (tstop - tstart))
            {
                MessageBox.Show("Недопустимые значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else

            {
                while (tstart <= tstop)
                {
                    tx = tstart;
                    ty = ff(tstart, a);
                    
                    listBox1.Items.Add(String.Format("x = {0:f2} y = {1:f2};", tx, ty));

                    tstart += tstep;
                }
            }
        }

        double ff(double x, double a)
        {
            double res = 0;

            if (x < 1) res = 1.5 * Cos(x) * Cos(x);
            if (x == 1) res = 1.8 * a * x;
            if (x > 1 && x <= 2) res = (x - 2) * (x - 2) + 6;
            if (x > 2) res = 3 * Tan(x);

            return res;
        }
    }
}
