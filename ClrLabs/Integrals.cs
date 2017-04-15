using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wednesday
{
    public partial class Integrals : Form
    {
        private double a, b, n, accuracy;

        public Integrals()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(square_method(a, b, n));
        }

        private double square_method(double a, double b, double n)
        {
            double dx, sum, x;
            int i;
            dx = (b - a) / n;
            a = a + dx / 2;
            sum = 0;
            for (i = 0; i < n; i++)
            {
                x = a + i * dx;
                sum += f(x);
            }
            return dx * sum;
        }

        private double f(double x)
        {
            return x * x * x;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(trapeze_method(a, b, n));
        }

        private double trapeze_method(double a, double b, double n)
        {
            double dx, sum, x;
            int i;
            dx = (b - a) / n;
            sum = (f(a) + f(b)) / 2.0;
            for (i = 1; i < n; i++)
            {
                x = a + i * dx;
                sum += f(x);
            }
            return dx * sum;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Text = Convert.ToString(parabola_method(a, b, n));
        }

        private double parabola_method(double a, double b, double n) {
            double dx, sum, x;
            double y = 0;
            int i;
            if (n % 2 != 0)
            {
                n++;
            }
            sum = f(a);
            dx = (b - a) / n;
            for (i = 1; i <= n / 2; i++)
            {
                x = a + (2 * i - 1) * dx;
                sum += 4 * f(x);
                x += dx;
                y = f(x);
                sum += 2 * y;
            }
            return (sum - y) * dx / 3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double x = square_method(a, b, n);
            double temp = n;
            while(x > accuracy)
            {
                x = square_method(a, b, temp /= 2);
            }
            textBox8.Text = Convert.ToString(x);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double x = trapeze_method(a, b, n);
            double temp = n;
            while (x > accuracy)
            {
                x = trapeze_method(a, b, temp /= 2);
            }
            textBox9.Text = Convert.ToString(x);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double x = parabola_method(a, b, n);
            double temp = n;
            while (x > accuracy)
            {
                x = parabola_method(a, b, temp /= 2);
            }
            textBox10.Text = Convert.ToString(x);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            accuracy = Convert.ToDouble(textBox7.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            n = Convert.ToDouble(textBox3.Text);
        }
    }
}
