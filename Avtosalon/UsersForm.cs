using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtosalon
{
    public partial class UsersForm : Form
    {
        public UsersForm(string user_type)
        {
            this.user_type = user_type;
            InitializeComponent();
        }

        string user_type;

        readonly string connectionString = "Data Source=LAPTOP-QD256AK9;Initial Catalog=Avtosalon;Integrated Security=True";

        private void UsersForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtosalonDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.avtosalonDataSet.Users);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queary = "Select * from Users Where login = @login";
                SqlCommand cmd = new SqlCommand(queary, sqlConnection);
                cmd.Parameters.AddWithValue("@login", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Table");
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Update Users Set role = @role, Фамилия = @sur, Имя = @nam, Адрес = @add, Телефон = @tel, e_mail = @mail where ID = @id";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@role", textBox2.Text);
                    cmd.Parameters.AddWithValue("@sur", textBox3.Text);
                    cmd.Parameters.AddWithValue("@nam", textBox4.Text);
                    cmd.Parameters.AddWithValue("@add", textBox5.Text);
                    cmd.Parameters.AddWithValue("@tel", textBox6.Text);
                    cmd.Parameters.AddWithValue("@mail", textBox6.Text);
                    cmd.Parameters.AddWithValue("@login", textBox6.Text);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            this.usersTableAdapter.Fill(this.avtosalonDataSet.Users);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Delete from Users where login = @login ";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@login", textBox1.Text);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            this.usersTableAdapter.Fill(this.avtosalonDataSet.Users);
        }

        private void UsersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm(user_type);
            frm.Show();
            this.Hide();
        }
    }
}
