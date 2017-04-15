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
    public partial class Equation : Form
    {
        public Equation()
        {
            InitializeComponent();
            showOrHideIfNeed(true);
        }

        private void showOrHideIfNeed(bool show)
        {
            label1.Visible = show;
            label2.Visible = show;
            label3.Visible = show;
            textBox1.Visible = show;
            textBox2.Visible = show;
            textBox5.Visible = show;
            textBox7.Visible = show;

            label4.Visible = !show;
            label5.Visible = !show;
            textBox3.Visible = !show;
            textBox4.Visible = !show;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ans1 = "";
            String ans2 = "";


            if (radioButton1.Checked)
            {
                double a, b, c;
                bool ok = false;
                double d, x1, x2;


                ok = Double.TryParse(textBox1.Text, out a) | Double.TryParse(textBox2.Text, out b) | Double.TryParse(textBox3.Text, out c);

                if (!ok) MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    d = b * b - 4 * a * c;

                    if (d < 0)
                    {
                        double im = Sqrt(-d) / 2;

                        x1 = -b / 2;
                        x2 = -b / 2;

                        ans1 = Convert.ToString(x1) + " + i * " + Convert.ToString(im);
                        ans2 = Convert.ToString(x2) + " - i * " + Convert.ToString(im);
                    }

                    if (d >= 0)
                    {
                        x1 = (-b + Sqrt(d)) / 2;
                        x2 = (-b - Sqrt(d)) / 2;

                        ans1 = Convert.ToString(x1);
                        ans2 = Convert.ToString(x2);
                    }

                    if (a == 0 && b == 0 && c == 0) ans1 = "верное тождество";
                }
            }

            if (radioButton2.Checked)
            {
                double k, b;
                bool ok = false;
                double x;

                ok = Double.TryParse(textBox4.Text, out k) | Double.TryParse(textBox5.Text, out b);

                if (!ok || (k == 0 && b != 0)) MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    x = -b / k;

                    ans1 = Convert.ToString(x);

                    if (k == 0 && b == 0) ans1 = "верное тождество";
                }
            }

            textBox6.Text = ans1;
            textBox7.Text = ans2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            showOrHideIfNeed(true);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            showOrHideIfNeed(false);
        }
    }
}
