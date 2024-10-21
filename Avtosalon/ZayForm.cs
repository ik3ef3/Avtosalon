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
    public partial class ZayForm : Form
    {
        public ZayForm(string user_type)
        {
            InitializeComponent();
            this.user_type = user_type;
            if (user_type == "user")
            {
                button3.Enabled = false;
                button3.Visible = false;
                button4.Enabled = false;
                button4.Visible = false;
            }
        }

        string user_type;

        readonly string connectionString = "Data Source=LAPTOP-QD256AK9;Initial Catalog=Avtosalon;Integrated Security=True";

        private void ZayForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtosalonDataSet.Zayavki". При необходимости она может быть перемещена или удалена.
            this.zayavkiTableAdapter.Fill(this.avtosalonDataSet.Zayavki);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queary = "Select * from Zayavki Where ID = @id";
                SqlCommand cmd = new SqlCommand(queary, sqlConnection);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Table");
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Insert Into Zayavki Values(@client, @manager, @idcar, @dop, @opis, @status)";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@client", textBox2.Text);
                    cmd.Parameters.AddWithValue("@manager", textBox3.Text);
                    cmd.Parameters.AddWithValue("@idcar", textBox4.Text);
                    cmd.Parameters.AddWithValue("@dop", textBox5.Text);
                    cmd.Parameters.AddWithValue("@opis", textBox6.Text);
                    cmd.Parameters.AddWithValue("@status", textBox7.Text);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            this.zayavkiTableAdapter.Fill(this.avtosalonDataSet.Zayavki);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Update Zayavki Set client_login = @client, manager_login = @manager, car_ID = @idcar, Addons = @dop, Primechanie = @opis, Status = @status where ID = @id";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@client", textBox2.Text);
                    cmd.Parameters.AddWithValue("@manager", textBox3.Text);
                    cmd.Parameters.AddWithValue("@idcar", textBox4.Text);
                    cmd.Parameters.AddWithValue("@dop", textBox5.Text);
                    cmd.Parameters.AddWithValue("@opis", textBox6.Text);
                    cmd.Parameters.AddWithValue("@status", textBox7.Text);
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            this.zayavkiTableAdapter.Fill(this.avtosalonDataSet.Zayavki);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Delete from Zayavki where ID = @id ";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            this.zayavkiTableAdapter.Fill(this.avtosalonDataSet.Zayavki);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm(user_type);
            frm.Show();
            this.Hide();
        }

        private void ZayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
