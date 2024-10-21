using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtosalon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        readonly string connectionString = "Data Source=LAPTOP-QD256AK9;Initial Catalog=Avtosalon;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            string user_type;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT role FROM Users WHERE login = @login and password = @password", sqlConnection);
                command.Parameters.AddWithValue("@login", textBox1.Text);
                command.Parameters.AddWithValue("@password", textBox2.Text);

                user_type = (string)command.ExecuteScalar();
            }
            if (user_type == "user" || user_type == "admin" || user_type == "manager")
            {
                MainForm frm = new MainForm(user_type);
                frm.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegForm frm = new RegForm();
            frm.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
