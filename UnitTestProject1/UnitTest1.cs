using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Windows.Forms;
using Avtosalon;
using System.Data.SqlClient;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        readonly string connectionString = "Data Source=LAPTOP-QD256AK9;Initial Catalog=Avtosalon;Integrated Security=True";

        [TestMethod]
        public void TestMethod1()
        {
            string user_type;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT role FROM Users WHERE login = @login and password = @password", sqlConnection);
                command.Parameters.AddWithValue("@login", "admin");
                command.Parameters.AddWithValue("@password", "1");

                user_type = (string)command.ExecuteScalar();
            }
            if (user_type == "user" || user_type == "admin" || user_type == "manager")
            {
                //MainForm frm = new MainForm(user_type);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            string user_type;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT role FROM Users WHERE login = @login and password = @password", sqlConnection);
                command.Parameters.AddWithValue("@login", "manager2");
                command.Parameters.AddWithValue("@password", "2");

                user_type = (string)command.ExecuteScalar();
            }
            if (user_type == "user" || user_type == "admin" || user_type == "manager")
            {
                //MainForm frm = new MainForm(user_type);
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            string user_type;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT role FROM Users WHERE login = @login and password = @password", sqlConnection);
                command.Parameters.AddWithValue("@login", "user");
                command.Parameters.AddWithValue("@password", "4");

                user_type = (string)command.ExecuteScalar();
            }
            if (user_type == "user" || user_type == "admin" || user_type == "manager")
            {
                //MainForm frm = new MainForm(user_type);
            }
        }
        [TestMethod]
        public void TestMethod4()
        {
            string user_type;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand("SELECT role FROM Users WHERE login = @login and password = @password", sqlConnection);
                command.Parameters.AddWithValue("@login", "necto");
                command.Parameters.AddWithValue("@password", "1");

                user_type = (string)command.ExecuteScalar();
            }
            if (user_type == "user" || user_type == "admin" || user_type == "manager")
            {
                //MainForm frm = new MainForm(user_type);
            }
            else
            {
                throw new Exception("Неверный логин или пароль.");
            }
        }
        [TestMethod]
        public void TestMethod5()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Insert Into Cars Values(@marka, @model, @addons, @opis)";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@marka", "Мерседес");
                    cmd.Parameters.AddWithValue("@model", "М5");
                    cmd.Parameters.AddWithValue("@addons", "-");
                    cmd.Parameters.AddWithValue("@opis", "Автомобиль бизнес-класса");
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        [TestMethod]
        public void TestMethod6()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Update Cars Set Marka = @marka, Model = @model, Addons = @addons, Opisanie = @opis where ID = @id";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@marka", "Мерседес");
                    cmd.Parameters.AddWithValue("@model", "М5");
                    cmd.Parameters.AddWithValue("@addons", "Кожаные сиденья");
                    cmd.Parameters.AddWithValue("@opis", "Автомобиль бизнес-класса");
                    cmd.Parameters.AddWithValue("@id", "6");
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        [TestMethod]
        public void TestMethod7()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string queary = "Delete from Cars where ID = @id ";
                using (SqlCommand cmd = new SqlCommand(queary, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", "6");
                    cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
    }
}
