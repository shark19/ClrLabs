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
    public partial class Extremum : Form
    {
        public Extremum()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        double f(double x)
        {
            return ((Pow(x, 4) / 8) - x * Sin(14 * x));
        }

        double df(double x)
        {
            return 0.5 * ((Pow(x, 3)) - 2 * Sin(14 * x) - 28 * x * (Cos(14 * x)));
        }

        double d2f(double x)
        {
            return -28 * (Cos(14 * x) + x * (1.5 * x + 196 * Sin(14 * x)));
        }

        double droot(double x, double eps)
        {
            double x1 = 0.0;
            double pr = 0.0;
            do
            {
                x1 = x - (f(x) / df(x));
                pr = Abs(x - x1);
                x = x1;


            } while (pr <= eps);

            return x;
        }

        double extremum(double x, double eps, ref int maxmin)
        {
            double y = droot(x, eps);
            //if ((df(y) + eps) > (df(y) - eps))
            if (d2f(y) < 0)
            {
                maxmin = 1;
            }
            //else if ((df(y) + eps) < (df(y) - eps))
            else if (d2f(y) > 0)
            {
                maxmin = 2;
            }
            else
            {
                maxmin = 3;
            }

            return y;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double x1 = 0.9;
            double x2 = 2.2;
            double x3 = 1.38;
            double x4 = -0.2;
            double x5 = 0;
            double x6 = -100;

            double eps = 0.00001;

            int maxmin1 = 0;
            int maxmin2 = 0;
            int maxmin3 = 0;
            int maxmin4 = 0;
            int maxmin5 = 0;
            int maxmin6 = 0;

            label7.Text = "x1 = " + Convert.ToString(x1);
            label8.Text = "x2 = " + Convert.ToString(x2);
            label9.Text = "x3 = " + Convert.ToString(x3);
            label10.Text = "x4 = " + Convert.ToString(x4);
            label11.Text = "x5 = " + Convert.ToString(x5);
            label12.Text = "x6 = " + Convert.ToString(x6);



            if (f(x1) * d2f(x1) == 0)
            {
                textBox1.Text = "Нет решения";
                textBox4.Text = "-";
                textBox7.Text = "-";
            }
            else
            {
                textBox1.Text = Convert.ToString(extremum(x1, eps, ref maxmin1));
                if (maxmin1 == 1)
                {
                    textBox4.Text = "Да";
                    textBox7.Text = "максимум";
                }
                if (maxmin1 == 2)
                {
                    textBox4.Text = "Да";
                    textBox7.Text = "минимум";
                }

                if (maxmin1 == 3)
                {
                    textBox4.Text = "Нет";
                    textBox7.Text = "-";
                }
            }

            if (f(x2) * d2f(x2) == 0)
            {
                textBox2.Text = "Нет решения";
                textBox5.Text = "-";
                textBox8.Text = "-";
            }
            else
            {
                textBox2.Text = Convert.ToString(extremum(x2, eps, ref maxmin2));
                if (maxmin2 == 1)
                {
                    textBox5.Text = "Да";
                    textBox8.Text = "максимум";
                }
                if (maxmin2 == 2)
                {
                    textBox5.Text = "Да";
                    textBox8.Text = "минимум";
                }

                if (maxmin2 == 3)
                {
                    textBox5.Text = "Нет";
                    textBox8.Text = "-";
                }
            }

            if (f(x3) * d2f(x3) <= 0)
            {
                textBox3.Text = "Нет решения";
                textBox6.Text = "-";
                textBox9.Text = "-";
            }
            else
            {
                textBox3.Text = Convert.ToString(extremum(x3, eps,ref maxmin3));
                if (maxmin3 == 1)
                {
                    textBox6.Text = "Да";
                    textBox9.Text = "максимум";
                }
                if (maxmin3 == 2)
                {
                    textBox6.Text = "Да";
                    textBox9.Text = "минимум";
                }

                if (maxmin3 == 3)
                {
                    textBox6.Text = "Нет";
                    textBox9.Text = "-";
                }
            }

            if (f(x4) * d2f(x4) <= 0)
            {
                textBox10.Text = "Нет решения";
                textBox11.Text = "-";
                textBox12.Text = "-";
            }
            else
            {
                textBox10.Text = Convert.ToString(extremum(x4, eps, ref maxmin4));
                if (maxmin4 == 1)
                {
                    textBox11.Text = "Да";
                    textBox12.Text = "максимум";
                }
                if (maxmin4 == 2)
                {
                    textBox11.Text = "Да";
                    textBox12.Text = "минимум";
                }

                if (maxmin4 == 3)
                {
                    textBox11.Text = "Нет";
                    textBox12.Text = "-";
                }
            }

            if (f(x5) * d2f(x5) <= 0)
            {
                textBox13.Text = "Нет решения";
                textBox14.Text = "-";
                textBox15.Text = "-";
            }
            else
            {
                textBox13.Text = Convert.ToString(extremum(x5, eps,ref maxmin5));
                if (maxmin5 == 1)
                {
                    textBox14.Text = "Да";
                    textBox15.Text = "максимум";
                }
                if (maxmin5 == 2)
                {
                    textBox14.Text = "Да";
                    textBox15.Text = "минимум";
                }

                if (maxmin5 == 3)
                {
                    textBox14.Text = "Нет";
                    textBox15.Text = "-";
                }
            }

            if (f(x6) * d2f(x6) <= 0)
            {
                textBox16.Text = "Нет решения";
                textBox17.Text = "-";
                textBox18.Text = "-";
            }
            else
            {
                textBox16.Text = Convert.ToString(extremum(x6, eps, ref maxmin6));
                if (maxmin6 == 1)
                {
                    textBox17.Text = "Да";
                    textBox18.Text = "максимум";
                }
                if (maxmin6 == 2)
                {
                    textBox17.Text = "Да";
                    textBox18.Text = "минимум";
                }

                if (maxmin6 == 3)
                {
                    textBox17.Text = "Нет";
                    textBox18.Text = "-";
                }
            }
        }
    }
}
