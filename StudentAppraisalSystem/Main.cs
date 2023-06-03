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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string server = "localhost";
            string database = "test";
            string uid = "root";
            string password = "";
            string connectstring = "Server=" + server + ";" + "Database=" + database + ";" 
                + "UID=" + uid + ";" + "Password=" + password + ";";
            MySqlConnection con = new MySqlConnection(connectstring);
            con.Open();
            string query = "INSERT INTO `employee`(`eno`, `ename`, `edesignation`) VALUES ("+textBox1.Text+", '"+textBox2.Text+"', '"+textBox3.Text+"')";
            MySqlCommand cmd = new MySqlCommand(query,con);
            int value = cmd.ExecuteNonQuery();
            MessageBox.Show(value.ToString());
            con.Close();*/
        }

        private void Instructor_Click(object sender, EventArgs e)
        {
            this.Hide();
            var lognins = new LoginInstructor();
            lognins.Closed += (s, args) => this.Close();
            lognins.Show();
        }

        private void Student_Click(object sender, EventArgs e)
        {
            this.Hide();
            var lognins = new LoginStudent();
            lognins.Closed += (s, args) => this.Close();
            lognins.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
