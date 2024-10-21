using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtosalon
{
    public partial class MainForm : Form
    {
        public MainForm(string user_type)
        {
            
            InitializeComponent();
            this.user_type = user_type;
            if (user_type == "user")
            {
                button2.Enabled = false;
                button2.Visible = false;
                button3.Enabled = false;
                button3.Visible = false;
            }
            else if (user_type == "manager")
            {
                button3.Enabled = false;
                button3.Visible = false;
            }
        }

        string user_type;

        private void button1_Click(object sender, EventArgs e)
        {
            CarsForm frm = new CarsForm(user_type);
            frm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZayForm frm = new ZayForm(user_type);
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UsersForm frm = new UsersForm(user_type);
            frm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
    }
}
