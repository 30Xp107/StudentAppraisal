using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Humanizer.In;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace StudentAppraisalSystem
{
    public partial class Prints : Form
    {
        PrintDocument printDocument = new PrintDocument();
        PrintDialog printDialog = new PrintDialog();
        private int page = 0;
        Bitmap MemoryImage;
        int DefaultHeight = 30;
        int DefaultHeights = 30;
        int DefaultHeightss = 30;
        int DefaultHeightsss = 30;
        int DefaultHeightssss = 30;
        int DefaultHeightsssss = 30;
        int DefaultHeightssssss = 30;
        int DefaultHeightsssssss = 30;
        int DefaultHeightssssssss = 30;
        int DefaultHeightsssssssss = 30;

        private void GetPrintArea(Control pnl)
        {
            page = 0;
            MemoryImage = ControlPrinter.ScrollableControlToBitmap(this.panel2, true, true);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        public Prints()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var bitmap = ControlPrinter.ScrollableControlToBitmap(this.panel2, true, true);
            /*Rectangle pagearea = e.PageBounds;*/
            /*e.Graphics.DrawImage(bitmap, (pagearea.Width / 2) - (panel2.Width / 2), panel2.Location.Y);*/

            var pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, new Rectangle(e.PageBounds.Location, e.PageBounds.Size), new Rectangle(e.PageBounds.Location.X, e.PageBounds.Height * page, e.PageBounds.Width, e.PageBounds.Height), GraphicsUnit.Pixel);
            e.HasMorePages = e.PageBounds.Height * page < panel2.Size.Height;
            page++;
        }
        public void Print()
        {
            GetPrintArea(panel2);
            PrintPreviewDialog preview = new PrintPreviewDialog();
            printDialog.Document = printDocument;

            //preview.Document = printDocument;
            //printDialog.ShowDialog();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
            }
        }

        private void Print_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;

            txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            

            lblinstructorname.Text = LoginInstructor.passsText;
            lblinstructorid.Text = LoginInstructor.passText;

            string instructorid = lblinstructorid.Text;
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
                            cmbStudent.Items.Add(reader.GetString("StudentName"));
                        }
                    }
                }
            }

            /*string connectionString = "datasource=localhost;port=3306;username=root;password=;database=studentappraisal"; //Set your MySQL connection string here.
            string query = "Select * from studentrating where InstructorID = '" + instructorid + "'"; // set query to fetch data "Select * from  tabelname"; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }*/

        }
        private Label FirstSem(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(389, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }

        private Label Subjects(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(99, DefaultHeight);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Description(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Width = 200;
            lbl.Location = new Point(239, DefaultHeight);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Credit(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(549, DefaultHeight);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Rating(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(677, DefaultHeight);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }

        private Label FirstSems(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(389, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }

        private Label Subjectss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(99, DefaultHeights);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Descriptions(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Width = 200;
            lbl.Location = new Point(239, DefaultHeights);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Credits(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(549, DefaultHeights);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Ratings(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(677, DefaultHeights);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label FirstSemss(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(389, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }

        private Label Subjectsss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(99, DefaultHeightss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Descriptionss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Width = 200;
            lbl.Location = new Point(239, DefaultHeightss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Creditss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(549, DefaultHeightss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Ratingss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(677, DefaultHeightss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label FirstSemsss(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(389, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }

        private Label Subjectssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(99, DefaultHeightsss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Descriptionsss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Width = 200;
            lbl.Location = new Point(239, DefaultHeightsss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Creditsss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(549, DefaultHeightsss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Ratingsss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(677, DefaultHeightsss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label FirstSemssss(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(389, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }

        private Label Subjectsssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(99, DefaultHeightssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Descriptionssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Width = 200;
            lbl.Location = new Point(239, DefaultHeightssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Creditssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(549, DefaultHeightssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Ratingssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(677, DefaultHeightssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label FirstSemsssss(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(389, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }

        private Label Subjectssssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(99, DefaultHeightsssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Descriptionsssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Width = 200;
            lbl.Location = new Point(239, DefaultHeightsssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Creditsssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(549, DefaultHeightsssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Ratingsssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(677, DefaultHeightsssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label FirstSemssssss(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(389, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }

        private Label Subjectsssssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(99, DefaultHeightssssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Descriptionssssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Width = 200;
            lbl.Location = new Point(239, DefaultHeightssssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Creditssssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(549, DefaultHeightssssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Ratingssssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(677, DefaultHeightssssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label FirstSemsssssss(string text)
        {
            Label lbl = new Label();
            lbl.Name = "name";
            lbl.Text = text;
            lbl.Location = new Point(389, 5);
            lbl.Visible = true;
            lbl.Width = 200;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }

        private Label Subjectssssssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(99, DefaultHeightsssssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Descriptionsssssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Width = 200;
            lbl.Location = new Point(239, DefaultHeightsssssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Creditsssssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(549, DefaultHeightsssssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }
        private Label Ratingsssssss(string text, int count)
        {
            Label lbl = new Label();
            lbl.Name = "name" + count.ToString();
            lbl.Text = text;
            lbl.Location = new Point(677, DefaultHeightsssssss);
            lbl.Visible = true;
            lbl.ForeColor = Color.Black;
            lbl.Font = new Font("Verdana", 10);
            lbl.Show();
            return lbl;
        }


        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panel16.Controls.Clear();
            if (cmbStudent.Text == "")
            {
                txtProgram.Text = "";
                txtName.Text = "";
                txtStudentID.Text = "";
            }

            string StudentName = cmbStudent.Text;
            string Program = txtProgram.Text;
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
                            txtName.Text = readers.GetValue(2).ToString();
                            txtProgram.Text = readers.GetValue(3).ToString();
                            txtDateofBirth.Text = readers.GetDateTime(6).ToString("MM/dd/yyyy");
                        }
                    }
                }
            }
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentrating where Program = '" + Program + "' AND Semester = '1st Semester' AND YearLevel = '1st Year'";
                using (var commandsss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readerss = commandsss.ExecuteReader())
                    {
                        int count = 0;
                        double text = 0.0;
                        //Iterate through the rows and add it to the combobox's items
                        while (readerss.Read())
                        {
                            count++;
                            this.panel16.Controls.Add(FirstSem("First Semester"));
                            this.panel16.Controls.Add(Subjects(readerss.GetValue(5).ToString(), count));
                            this.panel16.Controls.Add(Description(readerss.GetValue(6).ToString(), count));
                            this.panel16.Controls.Add(Credit(readerss.GetValue(7).ToString(), count));
                            this.panel16.Controls.Add(Rating(readerss.GetValue(9).ToString(), count));
                            DefaultHeight = DefaultHeight + 30;//
                            this.panel16.Height += 40;
                           // this.panel1.Height += 40;
                        }
                    }
                }
            }
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentrating where Program = '" + Program + "' AND Semester = '2nd Semester' AND YearLevel = '1st Year'";
                using (var commandsss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readerss = commandsss.ExecuteReader())
                    {
                        int count = 0;
                        double text = 0.0;
                        //Iterate through the rows and add it to the combobox's items
                        while (readerss.Read())
                        {
                            count++;
                            this.panel17.Controls.Add(FirstSems("Second Semester"));
                            this.panel17.Controls.Add(Subjectss(readerss.GetValue(5).ToString(), count));
                            this.panel17.Controls.Add(Descriptions(readerss.GetValue(6).ToString(), count));
                            this.panel17.Controls.Add(Credits(readerss.GetValue(7).ToString(), count));
                            this.panel17.Controls.Add(Ratings(readerss.GetValue(9).ToString(), count));
                            DefaultHeights = DefaultHeights + 30;//
                            this.panel17.Height += 40;
                          //  this.panel1.Height += 40;
                        }
                    }
                }
            }
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentrating where Program = '" + Program + "' AND Semester = '1st Semester' AND YearLevel = '2nd Year'";
                using (var commandsss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readerss = commandsss.ExecuteReader())
                    {
                        int count = 0;
                        double text = 0.0;
                        //Iterate through the rows and add it to the combobox's items
                        while (readerss.Read())
                        {
                            count++;
                            this.panel18.Controls.Add(FirstSemss("First Semester"));
                            this.panel18.Controls.Add(Subjectsss(readerss.GetValue(5).ToString(), count));
                            this.panel18.Controls.Add(Descriptionss(readerss.GetValue(6).ToString(), count));
                            this.panel18.Controls.Add(Creditss(readerss.GetValue(7).ToString(), count));
                            this.panel18.Controls.Add(Ratingss(readerss.GetValue(9).ToString(), count));
                            DefaultHeightss = DefaultHeightss + 30;//
                            this.panel18.Height += 40;
                            //  this.panel1.Height += 40;
                        }
                    }
                }
            }
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentrating where Program = '" + Program + "' AND Semester = '2nd Semester' AND YearLevel = '2nd Year'";
                using (var commandsss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readerss = commandsss.ExecuteReader())
                    {
                        int count = 0;
                        double text = 0.0;
                        //Iterate through the rows and add it to the combobox's items
                        while (readerss.Read())
                        {
                            count++;
                            this.panel19.Controls.Add(FirstSemsss("Second Semester"));
                            this.panel19.Controls.Add(Subjectssss(readerss.GetValue(5).ToString(), count));
                            this.panel19.Controls.Add(Descriptionsss(readerss.GetValue(6).ToString(), count));
                            this.panel19.Controls.Add(Creditsss(readerss.GetValue(7).ToString(), count));
                            this.panel19.Controls.Add(Ratingsss(readerss.GetValue(9).ToString(), count));
                            DefaultHeightsss = DefaultHeightsss + 30;//
                            this.panel19.Height += 40;
                            //  this.panel1.Height += 40;
                        }
                    }
                }
            }
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentrating where Program = '" + Program + "' AND Semester = '1st Semester' AND YearLevel = '3rd Year'";
                using (var commandsss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readerss = commandsss.ExecuteReader())
                    {
                        int count = 0;
                        double text = 0.0;
                        //Iterate through the rows and add it to the combobox's items
                        while (readerss.Read())
                        {
                            count++;
                            this.panel20.Controls.Add(FirstSemssss("First Semester"));
                            this.panel20.Controls.Add(Subjectsssss(readerss.GetValue(5).ToString(), count));
                            this.panel20.Controls.Add(Descriptionssss(readerss.GetValue(6).ToString(), count));
                            this.panel20.Controls.Add(Creditssss(readerss.GetValue(7).ToString(), count));
                            this.panel20.Controls.Add(Ratingssss(readerss.GetValue(9).ToString(), count));
                            DefaultHeightssss = DefaultHeightssss + 30;//
                            this.panel20.Height += 40;
                            //  this.panel1.Height += 40;
                        }
                    }
                }
            }
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentrating where Program = '" + Program + "' AND Semester = '2nd Semester' AND YearLevel = '3rd Year'";
                using (var commandsss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readerss = commandsss.ExecuteReader())
                    {
                        int count = 0;
                        double text = 0.0;
                        //Iterate through the rows and add it to the combobox's items
                        while (readerss.Read())
                        {
                            count++;
                            this.panel21.Controls.Add(FirstSemsssss("Second Semester"));
                            this.panel21.Controls.Add(Subjectssssss(readerss.GetValue(5).ToString(), count));
                            this.panel21.Controls.Add(Descriptionsssss(readerss.GetValue(6).ToString(), count));
                            this.panel21.Controls.Add(Creditsssss(readerss.GetValue(7).ToString(), count));
                            this.panel21.Controls.Add(Ratingsssss(readerss.GetValue(9).ToString(), count));
                            DefaultHeightsssss = DefaultHeightsssss + 30;//
                            this.panel21.Height += 40;
                            //  this.panel1.Height += 40;
                        }
                    }
                }
            }
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentrating where Program = '" + Program + "' AND Semester = '1st Semester' AND YearLevel = '4th Year'";
                using (var commandsss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readerss = commandsss.ExecuteReader())
                    {
                        int count = 0;
                        double text = 0.0;
                        //Iterate through the rows and add it to the combobox's items
                        while (readerss.Read())
                        {
                            count++;
                            this.panel22.Controls.Add(FirstSemssssss("First Semester"));
                            this.panel22.Controls.Add(Subjectsssssss(readerss.GetValue(5).ToString(), count));
                            this.panel22.Controls.Add(Descriptionssssss(readerss.GetValue(6).ToString(), count));
                            this.panel22.Controls.Add(Creditssssss(readerss.GetValue(7).ToString(), count));
                            this.panel22.Controls.Add(Ratingssssss(readerss.GetValue(9).ToString(), count));
                            DefaultHeightssssss = DefaultHeightssssss + 30;//
                            this.panel22.Height += 40;
                            //  this.panel1.Height += 40;
                        }
                    }
                }
            }
            using (var connectionss = new MySqlConnection(connectionStringss))
            {
                connectionss.Open();
                var queryss = "SELECT * FROM studentrating where Program = '" + Program + "' AND Semester = '2nd Semester' AND YearLevel = '4th Year'";
                using (var commandsss = new MySqlCommand(queryss, connectionss))
                {
                    using (var readerss = commandsss.ExecuteReader())
                    {
                        int count = 0;
                        double text = 0.0;
                        //Iterate through the rows and add it to the combobox's items
                        while (readerss.Read())
                        {
                            count++;
                            this.panel23.Controls.Add(FirstSemsssssss("Second Semester"));
                            this.panel23.Controls.Add(Subjectssssssss(readerss.GetValue(5).ToString(), count));
                            this.panel23.Controls.Add(Descriptionsssssss(readerss.GetValue(6).ToString(), count));
                            this.panel23.Controls.Add(Creditsssssss(readerss.GetValue(7).ToString(), count));
                            this.panel23.Controls.Add(Ratingsssssss(readerss.GetValue(9).ToString(), count));
                            DefaultHeightsssssss = DefaultHeightsssssss + 30;//
                            this.panel23.Height += 40;
                            //  this.panel1.Height += 40;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSchoolYear.Text))
            {
                Print();
            }
            else
            {
                MessageBox.Show("Please Input School Year.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentRating NIA = new StudentRating();
            NIA.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSchoolYear_Leave(object sender, EventArgs e)
        {
        }

        private void txtSchoolYear_Enter(object sender, EventArgs e)
        {
        }
    }
}
