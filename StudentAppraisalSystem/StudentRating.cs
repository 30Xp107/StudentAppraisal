using DGVPrinterHelper;
using Library;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace StudentAppraisalSystem
{
    public partial class StudentRating : Form
    {
        Connection connection;
        public StudentRating()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void StudentRating_Load(object sender, EventArgs e)
        {
            lblinstructorname.Text = LoginInstructor.passsText;
            lblinstructorid.Text = LoginInstructor.passText;

            string instructorid = lblinstructorid.Text;
            var connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            using (var connections = new MySqlConnection(connectionStrings))
            {
                connections.Open();
                var querys = "SELECT * FROM studentaccount where instructorID = '"+instructorid+"'";
                using (var commands = new MySqlCommand(querys, connections))
                {
                    using (var reader = commands.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbStudent.Items.Add(reader.GetString("StudentName"));
                        }
                    }
                }
            }

            var connectionStringsss = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            using (var connectionsss = new MySqlConnection(connectionStringsss))
            {
                connectionsss.Open();
                var querysss = "SELECT yearlevel FROM yearlevel";
                using (var commandss = new MySqlCommand(querysss, connectionsss))
                {
                    using (var reader = commandss.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbYearLevel.Items.Add(reader.GetString("yearlevel"));
                        }
                    }
                }
            }

            var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM addsubject";
                using (var commandss = new MySqlCommand(queryss, connectionss))
                {
                    using (var reader = commandss.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cmbSubject.Items.Add(reader.GetString("Subject"));
                        }
                    }
                }
            }
            
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

        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbStudent.Text == "")
            {
                txtCourse.Text = "";
                txtStudentID.Text = "";
                cmbYearLevel.Text = "";
                cmbSubject.Text = "";
                txtfingra.Text = "";
            }

            string StudentName = cmbStudent.Text;
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
                            txtStudentID.Text = readers.GetValue(1).ToString();
                            txtCourse.Text = readers.GetValue(3).ToString();
                            cmbYearLevel.Text = readers.GetValue(4).ToString();
                            txtStuStatus.Text = readers.GetValue(7).ToString();

                        }
                    }
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInstructor FmIns = new FormInstructor();
            FmIns.Show();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            cmbStudent.Text = "";
            txtCourse.Text = "";
            txtStudentID.Text = "";
            cmbYearLevel.Text = "";
            cmbSubject.Text = "";
            txtfingra.Text = "";
            cmbProceed.Text = "";
            txtStuStatus.Text = "";
            if(rbt1stsem.Checked)
            {
                rbt1stsem.Checked = false;
            }
            else if(rbt2ndsem.Checked)
            {
                rbt2ndsem.Checked = false;
            }

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (rbt1stsem.Checked)
            {
                string StudentID = txtStudentID.Text;
                string StudentName = cmbStudent.Text;
                string Course = txtCourse.Text;
                string YearLevel = cmbYearLevel.Text;
                string InsUsername = lblinstructorname.Text;
                string InstructorID = lblinstructorid.Text;
                string Subject = cmbSubject.Text;
                string Descrip = txtDescrip.Text;
                string Credit = txtCredit.Text;
                string Semester = rbt1stsem.Text;
                string Final = txtfingra.Text;
                string Proceed = cmbProceed.Text;
                string Status = txtStuStatus.Text;

                if (isNotEmpty())
                {
                    connection.OpenConnection();
                    string insert = "INSERT INTO studentrating VALUES('','" + StudentName + "','" + StudentID + "','" + Course + "','" + YearLevel + "','" + Subject + "','" + Descrip + "','" + Credit + "','" + Semester + "','" + Final + "','"+Proceed+"','"+Status+"','" + InsUsername + "','" + InstructorID + "')";
                    MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Saved!");
                    connection.CloseConnection();
                    txtStudentID.Text = "";
                    cmbStudent.Text = "";
                    txtCourse.Text = "";
                    cmbYearLevel.Text = "";
                    cmbSubject.Text = "";
                    txtDescrip.Text = "";
                    txtCredit.Text = "";
                    rbt1stsem.Checked = false;
                    txtfingra.Text = "";
                    cmbProceed.Text = "";
                    txtStuStatus.Text = "";


                    string instructorid = this.lblinstructorid.Text;
                    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True"; //Set your MySQL connection string here.
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

                }
                else
                {
                    MessageBox.Show("Please fill in all the fields");
                }




                bool isNotEmpty()
                {
                    if (txtStudentID.Text.Equals("") ||
                        cmbStudent.Text.Equals("") ||
                        txtCourse.Text.Equals("") ||
                        cmbYearLevel.Text.Equals("") ||
                        cmbSubject.Text.Equals("") ||
                        txtDescrip.Text.Equals("") ||
                        txtCredit.Text.Equals("") ||
                        rbt1stsem.Text.Equals("") ||
                        cmbProceed.Text.Equals("")||
                        txtStuStatus.Text.Equals("")||
                        txtfingra.Text.Equals(""))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else if (rbt2ndsem.Checked)
            {
                string StudentID = txtStudentID.Text;
                string StudentName = cmbStudent.Text;
                string Course = txtCourse.Text;
                string YearLevel = cmbYearLevel.Text;
                string InsUsername = lblinstructorname.Text;
                string InstructorID = lblinstructorid.Text;
                string Subject = cmbSubject.Text;
                string Descrip = txtDescrip.Text;
                string Credit = txtCredit.Text;
                string Semester = rbt2ndsem.Text;
                string Final = txtfingra.Text;
                string Proceed = cmbProceed.Text;
                string Status = txtStuStatus.Text;

                if (isNotEmpty())
                {
                    connection.OpenConnection();
                    string insert = "INSERT INTO studentrating VALUES('','" + StudentName + "','" + StudentID + "','" + Course + "','" + YearLevel + "','" + Subject + "','" + Descrip + "','" + Credit + "','" + Semester + "','" + Final + "','"+Proceed+"','"+Status+"','" + InsUsername + "','" + InstructorID + "')";
                    MySqlCommand comm = new MySqlCommand(insert, connection.DatabaseConnection());
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Saved!");
                    connection.CloseConnection();
                    txtStudentID.Text = "";
                    cmbStudent.Text = "";
                    txtCourse.Text = "";
                    cmbYearLevel.Text = "";
                    cmbSubject.Text = "";
                    txtDescrip.Text = "";
                    txtCredit.Text = "";
                    rbt2ndsem.Checked = false;
                    txtfingra.Text = "";
                    cmbProceed.Text = "";
                    txtStuStatus.Text = "";


                    string instructorid = this.lblinstructorid.Text;
                    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True"; //Set your MySQL connection string here.
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

                }
                else
                {
                    MessageBox.Show("Please fill in all the fields");
                }




                bool isNotEmpty()
                {
                    if (txtStudentID.Text.Equals("") ||
                        cmbStudent.Text.Equals("") ||
                        txtCourse.Text.Equals("") ||
                        cmbYearLevel.Text.Equals("") ||
                        cmbSubject.Text.Equals("") ||
                        txtDescrip.Text.Equals("") ||
                        txtCredit.Text.Equals("") ||
                        rbt2ndsem.Text.Equals("")||
                        cmbProceed.Text.Equals("")||
                        txtStuStatus.Text.Equals("")||
                        txtfingra.Text.Equals(""))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if(rbt1stsem.Checked)
            {
                string ID = lblid.Text;
                string Subject = cmbSubject.Text;
                string Final = txtfingra.Text;
                string Proceed = cmbProceed.Text;
                string Semesters = rbt1stsem.Text;
                string Status = txtStuStatus.Text;


                if (isNotEmpty())
                {

                    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal; Convert Zero Datetime=True";
                    // Update the properties of the row with ID 1
                    string query = "UPDATE `studentrating` SET `Course`='" + Subject + "', `Semester`='"+Semesters+"', `FinalGrade`='" + Final + "', `Proceed`='"+Proceed+"',  `StudentStatus`='"+Status+"'WHERE ID = '" + ID + "'";

                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    try
                    {
                        databaseConnection.Open();
                        reader = commandDatabase.ExecuteReader();

                        MessageBox.Show("Succesfully Update!!!");

                        cmbStudent.Text = "";
                        txtStudentID.Text = "";
                        txtCourse.Text = "";
                        cmbYearLevel.Text = "";
                        cmbSubject.Text = "";
                        rbt1stsem.Checked = false;
                        txtfingra.Text = "";
                        txtfingra.Text = "";
                        cmbProceed.Text = "";
                        txtStuStatus.Text = "";

                        // Succesfully updated
                        string instructorID = lblinstructorid.Text;
                        string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True"; //Set your MySQL connection string here.
                        string querys = "Select * from studentrating where instructorID = '" + instructorID + "'"; // set query to fetch data "Select * from  tabelname"; 
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
            else if(rbt2ndsem.Checked)
            {
                string ID = lblid.Text;
                string Subject = cmbSubject.Text;
                string Final = txtfingra.Text;
                string Semesters = rbt2ndsem.Text;
                string Proceed = cmbProceed.Text;
                string Status = txtStuStatus.Text;


                if (isNotEmpty())
                {

                    string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal; Convert Zero Datetime=True";
                    // Update the properties of the row with ID 1
                    string query = "UPDATE `studentrating` SET `Course`='" + Subject + "',`Semester`='"+Semesters+"', `FinalGrade`='" + Final + "',`Proceed`='"+Proceed+"',`StudentStatus`='"+Status+"'WHERE ID = '" + ID + "'";

                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    try
                    {
                        databaseConnection.Open();
                        reader = commandDatabase.ExecuteReader();

                        MessageBox.Show("Succesfully Update!!!");

                        cmbStudent.Text = "";
                        txtStudentID.Text = "";
                        txtCourse.Text = "";
                        cmbYearLevel.Text = "";
                        cmbSubject.Text = "";
                        rbt2ndsem.Checked = false;
                        txtfingra.Text = "";
                        cmbProceed.Text = "";
                        txtStuStatus.Text = "";

                        // Succesfully updated
                        string instructorID = lblinstructorid.Text;
                        string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal;convert zero datetime=True"; //Set your MySQL connection string here.
                        string querys = "Select * from studentrating where instructorID = '" + instructorID + "'"; // set query to fetch data "Select * from  tabelname"; 
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
        }
        bool isNotEmpty()
        {
            if (cmbStudent.Text.Equals("") ||
                txtStudentID.Text.Equals("") ||
                txtCourse.Text.Equals("") ||
                cmbYearLevel.Text.Equals("") ||
                cmbSubject.Text.Equals("") ||
                cmbProceed.Text.Equals("")||
                txtStuStatus.Text.Equals("")||
                txtfingra.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
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
                lblid.Text = row.Cells["ID"].Value.ToString();
                cmbStudent.Text = row.Cells["StudentName"].Value.ToString();
                txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
                txtCourse.Text = row.Cells["Program"].Value.ToString();
                cmbYearLevel.Text = row.Cells["YearLevel"].Value.ToString();
                cmbSubject.Text = row.Cells["Course"].Value.ToString();
                txtfingra.Text = row.Cells["FinalGrade"].Value.ToString();
                cmbProceed.Text = row.Cells["Proceed"].Value.ToString();
                txtStuStatus.Text = row.Cells["StudentStatus"].Value.ToString();

                if (row.Cells["Semester"].Value.Equals("1st Semester"))
                {
                    rbt1stsem.Checked = true;
                }
                else
                    rbt2ndsem.Checked = true;
                // etc.
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string Id = lblid.Text;
            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            // Delete the item with ID 1
            string query = "DELETE FROM `studentrating` WHERE ID = '" + Id + "'";

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

                cmbStudent.Text = "";
                txtStudentID.Text = "";
                txtCourse.Text = "";
                cmbYearLevel.Text = "";
                cmbSubject.Text = "";
                txtfingra.Text = "";
                txtfingra.Text = "";
                cmbProceed.Text = "";
                txtStuStatus.Text = "";

                if(rbt1stsem.Checked)
                {
                    rbt1stsem.Checked = false;
                }
                else if (rbt2ndsem.Checked)
                {
                    rbt2ndsem.Checked = false;
                }

                string instructorid = lblinstructorid.Text;
                string connectionStrings = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
                string querys = "Select * from studentrating where instructorID = '" + instructorid + "'"; // set query to fetch data "Select * from  tabelname"; 
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubject.Text == "")
            {
                txtDescrip.Text = "";
                txtCredit.Text = "";
            }

            string Subject = cmbSubject.Text;
            var connectionStringss = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal";
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM addsubject where Subject = '" + Subject + "'";
                using (var commandss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readers = commandss.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (readers.Read())
                        {
                            txtDescrip.Text = readers.GetValue(2).ToString();
                            txtCredit.Text = readers.GetValue(3).ToString();

                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblinstructorname_Click(object sender, EventArgs e)
        {

        }

        private void lblinstructorid_Click(object sender, EventArgs e)
        {

        }

        private void rbt1stsem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbt2ndsem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtfingra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYearLevel_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblid_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbProceed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCourse_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtStuStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prints NIA = new Prints();
            NIA.Show();
            this.Hide();


            /*string studentname = cmbStudent.Text;
            string program = txtCourse.Text;

            DGVPrinter printer = new DGVPrinter();
            printer.Title = studentname;
            printer.SubTitle = program;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "University of Antique";
            printer.FooterSpacing = 15;
            printer.PageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView1);*/
        }
    }
}
