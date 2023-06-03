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
    public partial class AddCourse : Form
    {
        Connection connection;
        public AddCourse()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void btnaddcourse_Click(object sender, EventArgs e)
        {
            string AddCourse = txtaddcourse.Text;

            if (isNotEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO addcourse VALUES('','" + AddCourse + "')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtaddcourse.Text = "";

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
                string query = "Select * from addcourse"; // set query to fetch data "Select * from  tabelname"; 
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
            if (txtaddcourse.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {
            txtaddcourse.Text = "Program";

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
            string query = "Select * from addcourse"; // set query to fetch data "Select * from  tabelname"; 
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string addcourse = txtaddcourse.Text;
            string id = label1.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            // Update the properties of the row with ID 1
            string query = "UPDATE `addcourse` SET `program`='" + addcourse + "' WHERE id = '" + id + "'";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Succesfully Update!!!");
                // Succesfully updated
                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
                string querys = "Select * from addcourse"; // set query to fetch data "Select * from  tabelname"; 
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
                label1.Text = row.Cells["id"].Value.ToString();
                txtaddcourse.Text = row.Cells["program"].Value.ToString();
                // etc.
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string id = label1.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            // Delete the item with ID 1
            string query = "DELETE FROM `addcourse` WHERE id = '" + id + "'";

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
                string querys = "Select * from addcourse"; // set query to fetch data "Select * from  tabelname"; 
                using (MySqlConnection conns = new MySqlConnection(connectionStrings))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(querys, conns))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                label1.Text = "";
                txtaddcourse.Text = "";
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtaddcourse_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaddcourse_Enter(object sender, EventArgs e)
        {
            if (txtaddcourse.Text == "Program")
            {
                txtaddcourse.Text = "";
            }
        }

        private void txtaddcourse_Leave(object sender, EventArgs e)
        {
            if (txtaddcourse.Text == "")
            {
                txtaddcourse.Text = "Program";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
