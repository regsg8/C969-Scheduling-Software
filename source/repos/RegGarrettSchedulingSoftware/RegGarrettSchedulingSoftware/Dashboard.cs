using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RegGarrettSchedulingSoftware
{
    public partial class Dashboard : Form
    {
        DateTime today;
        DateTime selection;
        DataTable currentData = new DataTable();
        public static string userID;
        public static string userName;
        //Sets up lambda to apply DRY principle for formatting Columns in multiple DataGridViews
        public delegate void Format(DataGridViewColumn c);
        public static Format format = (c) =>
        {
            c.Width = 150;
            c.SortMode = DataGridViewColumnSortMode.NotSortable;
        };

        public Dashboard(string id, string username)
        {
            InitializeComponent();
            today = DateTime.Now;
            selection = DateTime.Now;
            userID = id;
            userName = username;
            formatDGV();
            checkAppts();
            populateWeek(today);
        }

        //Formats the apppointments DataGridView
        private void formatDGV()
        {
            dgv.ColumnCount = 4;
            foreach (DataGridViewColumn column in dgv.Columns) 
            {
                //Uses lambda to shorten syntax of applying common formats to all columns
                format(column);
            }
            dgv.Columns[0].HeaderText = "Customer";
            dgv.Columns[0].DataPropertyName = "customerName";
            dgv.Columns[1].HeaderText = "Type";
            dgv.Columns[1].DataPropertyName = "type";
            dgv.Columns[2].HeaderText = "Start";
            dgv.Columns[2].DataPropertyName = "start";
            dgv.Columns[3].HeaderText = "End";
            dgv.Columns[3].DataPropertyName = "end";
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //Gives alert if an appointment starts within 15 min of login
        private void checkAppts()
        {
            
        }

        //Displays appointments by selected week
        private void populateWeek(DateTime date)
        {
            cal.RemoveAllBoldedDates();
            int day = (int)date.DayOfWeek;
            string start = date.AddDays(-day).ToString();
            string end = date.AddDays(7 - day).ToString();
            DateTime count = Convert.ToDateTime(start);
            for (int i = 0; i < 7; i++)
            {
                cal.AddBoldedDate(count.AddDays(i));
            }
            cal.UpdateBoldedDates();
            DateTime parsedStart = DateTime.Parse(start);
            DateTime parsedEnd = DateTime.Parse(end);
            List<DateTime> dates = new List<DateTime> { parsedStart, parsedEnd };
            dgv.DataSource = DB.getAppts(dates);
            currentData = DB.getAppts(dates);
        }

        //Displays appointments by selected month
        private void populateMonth(DateTime date)
        {
            cal.RemoveAllBoldedDates();
            string start = date.Month.ToString() + "/01/" + date.Year.ToString();
            int days = 31;
            if (date.Month == 2) days = 29;
            if (date.Month == 4 || date.Month == 6 || date.Month == 9 || date.Month == 11) days = 30;
            DateTime count = Convert.ToDateTime(start);
            for (int i = 0; i < days; i++)
            {
                cal.AddBoldedDate(count.AddDays(i));
            }
            cal.UpdateBoldedDates();
            DateTime parsedStart = DateTime.Parse(start);
            DateTime parsedEnd = date.AddDays(days);
            List<DateTime> dates = new List<DateTime> { parsedStart, parsedEnd };
            dgv.DataSource = DB.getAppts(dates);
            currentData = DB.getAppts(dates);
        }


        private void weeklyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (weeklyRadio.Checked)
            {
                populateWeek(selection);
            }
        }

        private void monthlyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (monthlyRadio.Checked)
            {
                populateMonth(selection);
            }   
        }

        //Populates either weekly or monthly appointments based on radio selection
        private void cal_DateChanged(object sender, DateRangeEventArgs e)
        {
            selection = cal.SelectionRange.Start;
            if (weeklyRadio.Checked)
            {
                populateWeek(selection);
            }
            else
            {
                populateMonth(selection);
            }
        }

        private void addAppt_Click(object sender, EventArgs e)
        {
            AddAppointment addApp = new AddAppointment();
            addApp.ShowDialog();
        }

        private void editAppt_Click(object sender, EventArgs e)
        {
            //fetch selected appt and open modify appointment form
            
        }

        private void manageCust_Click(object sender, EventArgs e)
        {
            CustomerManagement custMan = new CustomerManagement();
            custMan.ShowDialog();
        }

        //Pulls up customer by selected Id
        private void lookUpCustomer_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(currentData.Rows[dgv.CurrentCell.RowIndex][0]);
            DataTable data = new DataTable();
            data = DB.getOneCustomer(id);
            MessageBox.Show
                (
                    $"    Name:  {data.Rows[0][0]}\n" +
                    $"   Phone:  {data.Rows[0][1]}\n"+
                    $"Address:  {data.Rows[0][2]}\n" +
                    $"        City:  {data.Rows[0][3]}\n"+
                    $"Country:  {data.Rows[0][4]}"
                );
        }

        //Gathers list of textboxes
        public static List<TextBox> getTextBoxes(Form form)
        {
            List<TextBox> textBoxes = new List<TextBox>();
            foreach (Control c in form.Controls)
            {
                if (c is TextBox)
                {
                    textBoxes.Add(c as TextBox);
                }
            }
            return textBoxes;
        }

        //Creates a messagebox string for any empty textboxes
        public static string getEmptyTextboxError(List<TextBox> textboxes)
        {
            string mbString = "";
            List<string> errors = new List<string>();
            //Uses lambda to shorten syntax of cycling through textboxes
            textboxes.ForEach(t =>
                            {
                                 if (t.Text.ToString() == "")
                                {
                                    string e = "";
                                    if (t.Name.ToString() == "nameInput") e = "Name";
                                    if (t.Name.ToString() == "phoneInput") e = "Phone";
                                    if (t.Name.ToString() == "addressInput") e = "Address";
                                    if (t.Name.ToString() == "cityInput") e = "City";
                                    if (t.Name.ToString() == "countryInput") e = "Country";
                                    if (t.Name.ToString() == "zipInput") e = "Zip Code";
                                    errors.Add(e);
                                }
                            }
            );
            if (errors.Count != 0)
            {
                //Uses lambda to shorten syntax of cycling through strings
                errors.ForEach(s =>
                            {
                                mbString = mbString + $"{s} cannot be blank\n";   
                            }
                );
            }
            return mbString;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
