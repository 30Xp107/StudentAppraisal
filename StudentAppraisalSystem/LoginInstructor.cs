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
    public partial class LoginInstructor : Form
    {
        public static string passText;
        public static string passsText;
        public static string passssText;
        Connection connection;
        public LoginInstructor()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            if(user == "admin" && pass == "admin2022")
            {
                NewInstructorAccount NIA = new NewInstructorAccount();
                NIA.Show();
                this.Hide();
            }
            else
            {
                string myUsername = username.Text;
                string myPassword = password.Text;

                string query = "Select * from instructoraccount where " +
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
                    FormInstructor panel = new FormInstructor();
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
                    var queryss = "SELECT * FROM instructoraccount where username = '" + Username + "'";
                    using (var commandss = new MySqlCommand(queryss, connectionss))
                    {
                        using (var readers = commandss.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (readers.Read())
                            {
                                label3.Text = readers.GetValue(1).ToString();
                                label4.Text = readers.GetValue(2).ToString();
                                label5.Text = readers.GetValue(7).ToString();
                            }
                        }
                    }
                }
                passText = label3.Text;
                passsText = label4.Text;
                passssText = label5.Text;



                connection.CloseConnection();
            }
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginInstructor_Load(object sender, EventArgs e)
        {
            username.Text = "Username";
            password.Text = "Password";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }

        private void username_Enter(object sender, EventArgs e)
        {
            if (username.Text == "Username")
            {
                username.Text = "";
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Username";
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "Password")
            {
                password.Text = "";
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Password";
            }
        }
    }
}
