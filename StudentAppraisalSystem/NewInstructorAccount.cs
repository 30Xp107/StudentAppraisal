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
    public partial class NewInstructorAccount : Form
    {
        Connection connection;
        public NewInstructorAccount()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            string InstructorID = instructorid.Text;
            string InstructorName = instructorname.Text;
            string ContactNo = contactno.Text;
            string DateofBirth = dateofbirth.Text;
            string Username = username.Text;
            string Password = password.Text;
            string InsStatus = txtInsStatus.Text;

            if (isNotEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO instructoraccount VALUES('','" + InstructorID + "','" + InstructorName + "','" + ContactNo + "','" + DateofBirth + "','" + Username + "','" + Password + "','"+ InsStatus +"')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                instructorid.Text = "";
                instructorname.Text = "";
                contactno.Text = "";
                dateofbirth.Text = "";
                username.Text = "";
                password.Text = "";
                txtInsStatus.Text = "";

                lblinstructorid.Text = LoginInstructor.passText;

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal; convert zero datetime=True"; //Set your MySQL connection string here.
                string query = "Select * from instructoraccount"; // set query to fetch data "Select * from  tabelname"; 
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
            if (instructorid.Text.Equals("") ||
                instructorname.Text.Equals("") ||
                contactno.Text.Equals("") ||
                dateofbirth.Text.Equals("") ||
                username.Text.Equals("") ||
                txtInsStatus.Text.Equals("")||
                password.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void NewInstructorAccount_Load(object sender, EventArgs e)
        {
            string instructorID = lblinstructorid.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True"; //Set your MySQL connection string here.
            string query = "Select * from instructoraccount"; // set query to fetch data "Select * from  tabelname"; 
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            lblinstructorid.Text = "";
            instructorid.Text = "";
            instructorname.Text = "";
            contactno.Text = "";
            dateofbirth.Text = "";
            username.Text = "";
            password.Text = "";
            txtInsStatus.Text = "";

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string id = lblinstructorid.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            // Delete the item with ID 1
            string query = "DELETE FROM `instructoraccount` WHERE id = '" + id + "'";

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

                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
                string querys = "Select * from instructoraccount"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                lblinstructorid.Text = "";
                instructorid.Text = "";
                instructorname.Text = "";
                contactno.Text = "";
                username.Text = "";
                password.Text = "";
                dateofbirth.Text = "";
                txtInsStatus.Text = "";
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
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
                lblinstructorid.Text = row.Cells["ID"].Value.ToString();
                instructorid.Text = row.Cells["InstructorID"].Value.ToString();
                instructorname.Text = row.Cells["InstructorName"].Value.ToString();
                contactno.Text = row.Cells["ContactNo"].Value.ToString();
                dateofbirth.Text = row.Cells["DateofBirth"].Value.ToString();
                username.Text = row.Cells["username"].Value.ToString();
                password.Text = row.Cells["password"].Value.ToString();
                txtInsStatus.Text = row.Cells["InstructorStatus"].Value.ToString();
                // etc.
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
            string InstructorStatus = txtInsStatus.Text;


            if (isNotEmpty())
            {

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal; Convert Zero Datetime=True";
                // Update the properties of the row with ID 1
                string query = "UPDATE `instructoraccount` SET `InstructorId`='" + InstructorID + "', `InstructorName`='" + InstructorName + "',`ContactNo`='" + ContactNo + "', `DateofBirth`='" + DateofBirth + "', `username`='" + Username + "', `password`='" + Password + "',`InstructorStatus`='"+InstructorStatus+"'WHERE id = '" + ID + "'";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();

                    MessageBox.Show("Succesfully Update!!!");

                    lblinstructorid.Text = "";
                    instructorid.Text = "";
                    instructorname.Text = "";
                    contactno.Text = "";
                    dateofbirth.Text = "";
                    username.Text = "";
                    password.Text = "";
                    txtInsStatus.Text = "";

                    // Succesfully updated
                    string instructorID = lblinstructorid.Text;
                    string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True"; //Set your MySQL connection string here.
                    string querys = "Select * from instructoraccount"; // set query to fetch data "Select * from  tabelname"; 
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }
    }
}
