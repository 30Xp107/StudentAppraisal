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
    public partial class AccountInstructor : Form
    {
        Connection connection;
        public AccountInstructor()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            
        }

        bool isNotEmpty()
        {
            if (instructorid.Text.Equals("") ||
                instructorname.Text.Equals("") ||
                contactno.Text.Equals("") ||
                dateofbirth.Text.Equals("") ||
                username.Text.Equals("") ||
                password.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AccountInstructor_Load(object sender, EventArgs e)
        {

            lblinstructorid.Text = LoginInstructor.passText;

            string instructorids = lblinstructorid.Text;
            var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True";
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM instructoraccount where InstructorID = '" + instructorids + "'";
                using (var commandss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readers = commandss.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (readers.Read())
                        {
                            instructorid.Text = readers.GetValue(1).ToString();
                            instructorname.Text = readers.GetValue(2).ToString();
                            contactno.Text = readers.GetValue(3).ToString();
                            dateofbirth.Text = readers.GetValue(4).ToString();
                            username.Text = readers.GetValue(5).ToString();
                            password.Text = readers.GetValue(6).ToString();
                        }
                    }
                }
            }

        }

      
        private void Update_Click(object sender, EventArgs e)
        {
            string ID = lblinstructorid.Text;
            string InstructorID = instructorid.Text;
            string InstructorName = instructorname.Text;
            string ContactNo = contactno.Text;
            string DateofBirth = dateofbirth.Text;
            string Username = username.Text;
            string Password = password.Text;


            if (isNotEmpty())
            {

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal; Convert Zero Datetime=True";
                // Update the properties of the row with ID 1
                string query = "UPDATE `instructoraccount` " +
                    "SET `InstructorID`='" + InstructorID + "', `InstructorName`='" + InstructorName + "',`ContactNo`='" + ContactNo + "', `DateofBirth`='" + DateofBirth + "', `username`='" + Username + "', `password`='" + Password + "'WHERE InstructorID = '" + ID + "'";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();

                    MessageBox.Show("Succesfully Update!!!");

                    string instructorids = lblinstructorid.Text;
                    var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True";
                    using (var connectionss = new MySqlConnection(connectionStringss))
                    {
                        connectionss.Open();
                        var queryss = "SELECT * FROM instructoraccount where InstructorID = '" + instructorids + "'";
                        using (var commandss = new MySqlCommand(queryss, connectionss))
                        {
                            using (var readers = commandss.ExecuteReader())
                            {
                                //Iterate through the rows and add it to the combobox's items
                                while (readers.Read())
                                {
                                    instructorid.Text = readers.GetValue(1).ToString();
                                    instructorname.Text = readers.GetValue(2).ToString();
                                    contactno.Text = readers.GetValue(3).ToString();
                                    dateofbirth.Text = readers.GetValue(4).ToString();
                                    username.Text = readers.GetValue(5).ToString();
                                    password.Text = readers.GetValue(6).ToString();
                                }
                            }
                        }
                    }

                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Ops, maybe the id doesn't exists ?
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInstructor forminstructor = new FormInstructor();
            forminstructor.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
