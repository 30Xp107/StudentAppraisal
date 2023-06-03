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
    public partial class AddSubject : Form
    {
        Connection connection;
        public AddSubject()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string AddSubject = txtaddsubject.Text;
            string AddDescrip = txtDescrip.Text;
            string AddCredit = txtCredit.Text;

            if (isNotEmpty())
            {
                connection.OpenConnection();
                string insert = "INSERT INTO addsubject VALUES('','" + AddSubject + "','" + AddDescrip + "','" + AddCredit + "')";
                MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved!");
                connection.CloseConnection();
                txtaddsubject.Text = "";
                txtDescrip.Text = "";
                txtCredit.Text = ""; 

                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
                string query = "Select * from addsubject"; // set query to fetch data "Select * from  tabelname"; 
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
            if (txtaddsubject.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string addsubject = txtaddsubject.Text;
            string description = txtDescrip.Text;
            string credit = txtCredit.Text;
            string id = label1.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            // Update the properties of the row with ID 1
            string query = "UPDATE `addsubject` SET `Subject`='" + addsubject + "', `Description`='"+ description +"', `Credit`='"+ credit +"' WHERE id = '" + id + "'";

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
                string querys = "Select * from addsubject"; // set query to fetch data "Select * from  tabelname"; 
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            string id = label1.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            // Delete the item with ID 1
            string query = "DELETE FROM `addsubject` WHERE id = '" + id + "'";

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
                string querys = "Select * from addsubject"; // set query to fetch data "Select * from  tabelname"; 
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
                txtaddsubject.Text = "";
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
                txtaddsubject.Text = row.Cells["Subject"].Value.ToString();
                // etc.
            }
        }

        private void AddSubject_Load(object sender, EventArgs e)
        {
            txtaddsubject.Text = "Course";
            txtDescrip.Text = "Description";
            txtCredit.Text = "Credit";

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
            string query = "Select * from addsubject"; // set query to fetch data "Select * from  tabelname"; 
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtaddsubject_Enter(object sender, EventArgs e)
        {
            if (txtaddsubject.Text == "Course")
            {
                txtaddsubject.Text = "";
            }
        }

        private void txtaddsubject_Leave(object sender, EventArgs e)
        {
            if (txtaddsubject.Text == "")
            {
                txtaddsubject.Text = "Course";
            }
        }

        private void txtaddsubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescript_Leave(object sender, EventArgs e)
        {
            if (txtDescrip.Text == "")
            {
                txtDescrip.Text = "Description";
            }
        }

        private void txtDescrip_Enter(object sender, EventArgs e)
        {
            if (txtDescrip.Text == "Description")
            {
                txtDescrip.Text = "";
            }
        }

        private void txtCredit_Leave(object sender, EventArgs e)
        {
            if (txtCredit.Text == "")
            {
                txtCredit.Text = "Credit";
            }

        }

        private void txtCredit_Enter(object sender, EventArgs e)
        {
            if (txtCredit.Text == "Credit")
            {
                txtCredit.Text = "";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
