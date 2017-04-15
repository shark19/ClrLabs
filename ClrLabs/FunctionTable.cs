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
    public partial class FunctionTable : Form
    {
        public FunctionTable()
        {
            InitializeComponent();
        }

        double f1(double x)
        {
            return x * x;
        }

        double f2(double x)
        {
            return x * x * x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double start, stop, step;
            double res = 0;
            int i = 0;

            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 1;

            start = Convert.ToDouble(textBox1.Text);
            stop = Convert.ToDouble(textBox2.Text);
            step = Convert.ToDouble(textBox3.Text);

            while ((start + step * i) <= stop)
            {
                if (radioButton1.Checked) res = f1(start + step * i);
                if (radioButton2.Checked) res = f2(start + step * i);

                dataGridView1.RowCount = dataGridView1.RowCount + 1;

                dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(start + step * i);
                dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(res);
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
        }
    }
}
