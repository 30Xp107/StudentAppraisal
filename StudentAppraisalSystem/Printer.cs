using DGVPrinterHelper;
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
    public partial class Printer : Form
    {
        public Printer()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                textBox1.Text = "";
            }

            string StudentName = comboBox1.Text;
            var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentaccount where StudentName = '" + StudentName + "'";
                using (var commandss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readers = commandss.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (readers.Read())
                        {
                            textBox1.Text = readers.GetValue(3).ToString();
                            textBox2.Text = readers.GetValue(1).ToString();

                        }
                    }
                }
            }

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
            string query = "Select * from studentrating where StudentID = '" + textBox2.Text + "'"; // set query to fetch data "Select * from  tabelname"; 
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

        private void Printer_Load(object sender, EventArgs e)
        {
            label1.Text = LoginInstructor.passText;

            string instructorid = label1.Text;
            var connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            using (var connections = new MySqlConnection(connectionStrings))
            {
                connections.Open();
                var querys = "SELECT * FROM studentaccount where instructorID = '" + instructorid + "'";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader.GetString("StudentName"));
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = comboBox1.Text;
            string Program = textBox1.Text;
            string ID = textBox2.Text;
            DGVPrinter printer = new DGVPrinter();
            printer.Title = Name;
            printer.SubTitle = Program;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "University of Antique";
            printer.FooterSpacing = 10;
            printer.PageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentRating NIA = new StudentRating();
            NIA.Show();
            this.Hide();
        }
    }
}
