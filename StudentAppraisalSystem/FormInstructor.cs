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
    public partial class FormInstructor : Form
    {
        public FormInstructor()
        {
            InitializeComponent();
            Load += FormInstructor_Shown;
        }


        private void FormInstructor_Load(object sender, EventArgs e)
        {
            
        }

        private void AddTeachAcc_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountInstructor accountinstructor = new AccountInstructor();
            accountinstructor.ShowDialog();
        }

        private void AddStudAcc_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountStudent accountstudent = new AccountStudent();
            accountstudent.ShowDialog();
        }

        private void AddCourse_Click(object sender, EventArgs e)
        {
            AddCourse addcourse = new AddCourse();
            addcourse.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSubject addsubject = new AddSubject();
            addsubject.ShowDialog();
        }

        private void btnstudentrating_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentRating studentrating = new StudentRating();
            studentrating.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormInstructor_Shown(object sender, EventArgs e)
        {

            lblinstructorname.Text = LoginInstructor.passsText;
            lblinstructorid.Text = LoginInstructor.passText;
            string instructorid = lblinstructorid.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
            string query = "Select * from studentrating where InstructorID = '" + instructorid + "'"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            label3.Text = LoginInstructor.passssText;
            string label = label3.Text;
            if (label == "Instructor")
            {
                AddCourse.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                AddCourse.Enabled = true;
                button1.Enabled = true;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
