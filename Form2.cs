using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gostinka
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bronirovanie Win = new bronirovanie();
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            klient Win = new klient();
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nomer Win = new nomer();
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            oplata Win = new oplata();
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
