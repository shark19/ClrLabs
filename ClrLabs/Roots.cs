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
    public partial class Roots : Form
    {
        public Roots()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x1 = 0.9;
            double x2 = 2.2;
            double x3 = 1.38;

            int n1 = 0;
            int n2 = 0;
            int n3 = 0;

            double eps = 0.0001;

            int switchValue = 0;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        switchValue = 0;
                        break;
                    }
                case 1:
                    {
                        switchValue = 1;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("No method selected!!");
                        return;
                    }
            }

            textBox1.Text = Convert.ToString(appfunc(x1, eps, out n1, switchValue));
            textBox4.Text = Convert.ToString(n1);
            textBox2.Text = Convert.ToString(appfunc(x2, eps, out n2, switchValue));
            if ((appfunc(x2, eps, out n2, switchValue) != (appfunc(x2, eps, out n2, switchValue))))
            {
                textBox2.Text = "No root here";
            }
            textBox5.Text = Convert.ToString(n2);
            textBox3.Text = Convert.ToString(appfunc(x3, eps, out n3, switchValue));
            textBox6.Text = Convert.ToString(n3);
        }

        double f(double x)
        {
            return ((Pow(x, 4) / 8) - x * Sin(14 * x));
        }

        double df(double x)
        {
            return 0.5 * ((Pow(x, 3)) - 2 * Sin(14 * x) - 28 * x * (Cos(14 * x)));
        }

        double appfunc(double x, double eps, out int count, int switchValue)
        {
            double x1 = 0.0;
            double pr = 0.0;
            count = 0;
            do
            {
                if (switchValue == 0) // do iterations method
                    x1 = f(x);

                else if (switchValue == 1) // do Newton-Raphson method
                    x1 = x - (f(x) / df(x));

                pr = Abs(x1 - x);
                x = x1;
                count++;


            } while (pr > eps);

            return x;
        }
    }
}
