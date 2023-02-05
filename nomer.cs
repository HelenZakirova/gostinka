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
    public partial class nomer : Form
    {
        public nomer()
        {
            InitializeComponent();
            getinfo();
        }

        private void getinfo()
        {
            string query = "SELECT id_nomera, nomer_komnati, etaj, kolichestvo_mest, stoimost_sutki FROM nomer";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //Добавить
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=gostinka;User=root;Password=2375425;");
                MySqlCommand cmd = new MySqlCommand("insert into nomer(id_nomera, nomer_komnati, etaj, kolichestvo_mest, stoimost_sutki) value('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "');", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                getinfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка внесения данных!");
            }
        }

        private void button3_Click(object sender, EventArgs e) //Обновить
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите изменить данные?", "Подтвердите свои действия", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=gostinka;User=root;Password=2375425;");
                MySqlCommand cmd = new MySqlCommand("update nomer set id_nomera ='" + textBox1.Text + "', nomer_komnati = '" + textBox2.Text + "', etaj = '" + textBox3.Text + "', kolichestvo_mest = '" + textBox4.Text + "', stoimost_sutki = '" + textBox5.Text + "' where id_nomera =" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";", conn);
                Console.WriteLine("update nomer set id_nomera ='" + textBox1.Text + "', nomer_komnati = '" + textBox2.Text + "', etaj = '" + textBox3.Text + "', kolichestvo_mest = '" + textBox4.Text + "', stoimost_sutki = '" + textBox5.Text + "' where id_nomera =" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";");
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                getinfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) //Удалить
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите удалить информацию?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string del = "delete from nomer where id_nomera = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
                    do_Action(del);
                    getinfo();
                }
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи! Удаление невозможно.");
            }
        }

        private void do_Action(string del)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(del, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Произшла непредвиденная ошибка!");
            }
        }
    }
}
