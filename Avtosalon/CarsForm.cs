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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Avtosalon
{
    public partial class CarsForm : Form
    {
        public CarsForm(string user_type)
        {
            InitializeComponent();
            this.user_type = user_type;
            if (user_type == "user")
            {
                button2.Enabled = false;
                button2.Visible = false;
                button3.Enabled = false;
                button3.Visible = false;
                button4.Enabled = false;
                button4.Visible = false;
            }
        }

        string user_type;

        readonly string connectionString = "Data Source=LAPTOP-QD256AK9;Initial Catalog=Avtosalon;Integrated Security=True";

        private void CarsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtosalonDataSet.Cars". При необходимости она может быть перемещена или удалена.
            this.carsTableAdapter.Fill(this.avtosalonDataSet.Cars);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queary = "Select * from Cars Where ID = @id";
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
                string queary = "Insert Into Cars Values(@marka, @model, @addons, @opis)";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@marka", textBox2.Text);
                    cmd.Parameters.AddWithValue("@model", textBox3.Text);
                    cmd.Parameters.AddWithValue("@addons", textBox4.Text);
                    cmd.Parameters.AddWithValue("@opis", textBox5.Text);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            this.carsTableAdapter.Fill(this.avtosalonDataSet.Cars);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Update Cars Set Marka = @marka, Model = @model, Addons = @addons, Opisanie = @opis where ID = @id";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@marka", textBox2.Text);
                    cmd.Parameters.AddWithValue("@model", textBox3.Text);
                    cmd.Parameters.AddWithValue("@addons", textBox4.Text);
                    cmd.Parameters.AddWithValue("@opis", textBox5.Text);
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            this.carsTableAdapter.Fill(this.avtosalonDataSet.Cars);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Delete from Cars where ID = @id ";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            this.carsTableAdapter.Fill(this.avtosalonDataSet.Cars);
        }

        private void CarsForm_FormClosed(object sender, FormClosedEventArgs e)
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
