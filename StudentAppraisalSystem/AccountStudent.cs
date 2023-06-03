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
    public partial class AccountStudent : Form
    {
        Connection connection;
        public AccountStudent()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            studentid.Text = "";
            studentname.Text = "";
            cmbcourse.Text = "";
            cmdyearlevel.Text = "";
            course.Text = "";
            dateofbirth.Text = "";
            username.Text = "";
            password.Text = "";
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            string StudentID = studentid.Text;
            string StudentName = studentname.Text;
            string Course = cmbcourse.Text;
            string YearLevel = cmdyearlevel.Text;
            string ContactNo = course.Text;
            string DateofBirth = dateofbirth.Text;
            string StudentStatus = Sstatus.Text;
            string Username = username.Text;
            string Password = password.Text;
            string InsUsername = lblinstructorname.Text;
            string InstructorID = lblinstructorid.Text;

            if (isNotEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO studentaccount VALUES('','" + StudentID + "','" + StudentName + "','" + Course + "','" + YearLevel + "','" + ContactNo + "','" + DateofBirth + "','"+StudentStatus+"','" + Username + "','" + Password + "','" + InsUsername + "','" + InstructorID +"')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                studentid.Text = "";
                studentname.Text = "";
                cmbcourse.Text = "";
                cmdyearlevel.Text = "";
                course.Text = "";
                dateofbirth.Text = "";
                Sstatus.Text = "";
                username.Text = "";
                password.Text = "";

                string instructorid = this.lblinstructorid.Text;
                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True"; //Set your MySQL connection string here.
                string query = "Select * from studentaccount where instructorID = '" + instructorid + "'"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }

            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }

        }

        bool isNotEmpty()
        {
            if (studentid.Text.Equals("") ||
                studentname.Text.Equals("") ||
                cmbcourse.Text.Equals("") ||
                cmdyearlevel.Text.Equals("") ||
                course.Text.Equals("") ||
                dateofbirth.Text.Equals("") ||
                Sstatus.Text.Equals("")||
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

        private void AccountStudent_Load(object sender, EventArgs e)
        {
            studentname.Text = "Last First MI.";
            lblinstructorid.Text = LoginInstructor.passText;
           lblinstructorname.Text = LoginInstructor.passsText;

            string instructorID = lblinstructorid.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True"; //Set your MySQL connection string here.
            string query = "Select * from studentaccount where instructorID = '" + instructorID + "'"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }

            var connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            using (var connections = new MySqlConnection(connectionStrings))
            {
                connections.Open();
                var querys = "SELECT program FROM addcourse";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbcourse.Items.Add(reader.GetString("program"));
                        }
                    }
                }
            }

            var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT yearlevel FROM yearlevel";
                using (var commandss = new MySqlCommand(queryss, connectionss))
                {
                    using (var reader = commandss.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmdyearlevel.Items.Add(reader.GetString("yearlevel"));
                        }
                    }
                }
            }


        }

        private void dateofbirth_ValueChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                id.Text = row.Cells["ID"].Value.ToString();
                studentid.Text = row.Cells["StudentID"].Value.ToString();
                studentname.Text = row.Cells["StudentName"].Value.ToString();
                cmbcourse.Text = row.Cells["Program"].Value.ToString();
                cmdyearlevel.Text = row.Cells["YearLevel"].Value.ToString();
                course.Text = row.Cells["ContactNo"].Value.ToString();
                dateofbirth.Text = row.Cells["DateofBirth"].Value.ToString();
                Sstatus.Text = row.Cells["StudentStatus"].Value.ToString();
                username.Text = row.Cells["username"].Value.ToString();
                password.Text = row.Cells["password"].Value.ToString();
                // etc.
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            string ID = id.Text;
            string StudentID = studentid.Text;
            string StudentName = studentname.Text;
            string Course = cmbcourse.Text;
            string YearLevel = cmdyearlevel.Text;
            string ContactNo = course.Text;
            string DateofBirth = dateofbirth.Text;
            string StudentStatus = Sstatus.Text;
            string Username = username.Text;
            string Password = password.Text;


            if (isNotEmpty())
            {

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal; Convert Zero Datetime=True";
                // Update the properties of the row with ID 1
                string query = "UPDATE `studentaccount` SET `StudentId`='" + StudentID + "', `StudentName`='" + StudentName + "', `Program`='" + Course + "', `YearLevel`='" + YearLevel + "',`ContactNo`='" + ContactNo + "', `DateofBirth`='" + DateofBirth + "',`StudentStatus`='"+StudentStatus+"', `username`='" + Username + "', `password`='" + Password + "'WHERE id = '" + ID + "'";
                string querya = "UPDATE `studentrating` SET `StudentId`='" + StudentID + "', `StudentName`='" + StudentName + "'WHERE StudentId = '" + StudentID + "'";

                MySqlConnection databaseConnections = new MySqlConnection(connectionString);
                MySqlCommand commandDatabases = new MySqlCommand(querya, databaseConnections);
                commandDatabases.CommandTimeout = 60;
                MySqlDataReader readers;

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    databaseConnections.Open();
                    readers = commandDatabases.ExecuteReader();
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();

                    MessageBox.Show("Succesfully Update!!!");

                    id.Text = "";
                    studentid.Text = "";
                    studentname.Text = "";
                    cmbcourse.Text = "";
                    cmdyearlevel.Text = "";
                    course.Text = "";
                    dateofbirth.Text = "";
                    Sstatus.Text = "";
                    username.Text = "";
                    password.Text = "";

                    // Succesfully updated
                    string instructorID = lblinstructorid.Text;
                    string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True"; //Set your MySQL connection string here.
                    string querys = "Select * from studentaccount where instructorID = '" + instructorID + "'"; // set query to fetch data "Select * from  tabelname"; 
                    using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];
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

        private void Delete_Click(object sender, EventArgs e)
        {
            string Id = id.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            // Delete the item with ID 1
            string query = "DELETE FROM `studentaccount` WHERE id = '" + Id + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Delete Succesfully");
                // Succesfully deleted

                id.Text = "";
                studentid.Text = "";
                studentname.Text = "";
                cmbcourse.Text = "";
                cmdyearlevel.Text = "";
                course.Text = "";
                dateofbirth.Text = "";
                Sstatus.Text = "";
                username.Text = "";
                password.Text = "";

                string instructorid = lblinstructorid.Text;
                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
                string querys = "Select * from studentaccount where instructorID = '"+instructorid+"'"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInstructor forminstructor = new FormInstructor();
            forminstructor.ShowDialog();
        }

        private void studentname_Leave(object sender, EventArgs e)
        {
            if (studentname.Text == "")
            {
                studentname.Text = "Last First MI.";
            }
        }

        private void studentname_Enter(object sender, EventArgs e)
        {
            if (studentname.Text == "Last First MI.")
            {
                studentname.Text = "";
            }
        }
    }
}
