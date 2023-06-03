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
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
            Load += FormStudent_Shown;
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            

        }

        private void FormStudent_Shown(object sender, EventArgs e)
        {

            lblstudentname.Text = LoginStudent.passsText;
            lblstudentid.Text = LoginStudent.passText;

            string studentid = lblstudentid.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
            string query = "Select * from studentrating where StudentID = '"+studentid+"'"; // set query to fetch data "Select * from  tabelname"; 
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }
    }
}
