using Library;
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

namespace StudentAppraisalSystem
{
    public partial class LoginStudent : Form
    {
        public static string passText;
        public static string passsText;
        Connection connection;
        public LoginStudent()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string myUsername = username.Text;
            string myPassword = password.Text;

            string query = "Select * from studentaccount where " +
           "username='" + myUsername + "' && " +
           "password='" + myPassword + "'";
            connection.OpenConnection();
            MySqlCommand command = new MySqlCommand(query, connection.DatabaseConnection());
            MySqlDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i++;
            }
            if (i > 0)
            {
                FormStudent panel = new FormStudent();
                panel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!");
            }

            string Username = username.Text;
            var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentaccount where username = '" + Username + "'";
                using (var commandss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readers = commandss.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (readers.Read())
                        {
                            label3.Text = readers.GetValue(1).ToString();
                            label4.Text = readers.GetValue(2).ToString();
                        }
                    }
                }
            }

            passText = label3.Text;
            passsText = label4.Text;

            connection.CloseConnection();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }

        private void LoginStudent_Load(object sender, EventArgs e)
        {
            username.Text = "Username";
            password.Text = "Password";
        }
        private void username_Enter(object sender, EventArgs e)
        {
            if (username.Text == "Username")
            {
                username.Text = "";
                username.ForeColor = SystemColors.WindowText;
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Username";
                username.ForeColor = Color.Gray;
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "Password")
            {
                password.Text = "";
                password.ForeColor = SystemColors.WindowText;
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Password";
                password.ForeColor = Color.Gray;
            }
        }
    }
}
