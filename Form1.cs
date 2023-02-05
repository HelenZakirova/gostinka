using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_login FROM auth WHERE login= '" + name_box.Text + "' and login_pass = '" + pass_box.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                int result = 0;
                result = Convert.ToInt32(cmDB.ExecuteScalar());
                if (result > 0)
                {
                    Form2 Win = new Form2();
                    Win.Owner = this;
                    this.Hide();
                    Win.Show();
                    name_box.Clear();
                    pass_box.Clear();
                }
                else
                    MessageBox.Show("Возникла ошибка авторизации!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }
    }
}
