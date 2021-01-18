using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegGarrettSchedulingSoftware
{
    public partial class Dashboard : Form
    {
        DateTime today;
        public static TimeZoneInfo timeZone;
        public DateTime selection;
        public bool weeklyChecked = true;
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
            timeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id);
            userID = id;
            userName = username;
            formatDGV();
            checkAppts();
            populateWeek(today);
        }

        //---DASHBOARD SETUP AND CONTROLS---//
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
            dgv.AutoGenerateColumns = false;
        }

        //Gives alert if any appointments starts within 15 min of login
        private void checkAppts()
        {
            DateTime start = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            DateTime end = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now.AddMinutes(15));
            List<DateTime> window = new List<DateTime> { start, end };
            DataTable windowAppts = new DataTable();
            windowAppts = DB.getAppts(window);
            if (windowAppts.Rows.Count > 0)
            {
                string mbString = "You have appointments starting within 15\n minutes with the following customers: \n\n";
                List<string> appts = new List<string>();
                for (int i = 0; i < windowAppts.Rows.Count; i++)
                {
                    appts.Add(windowAppts.Rows[i][1].ToString());
                }
                //Uses lambda to shorten syntax of dynamically building a string
                appts.ForEach(s =>
                {
                    mbString = mbString + $"{s}\n";
                });
                MessageBox.Show(mbString);
            }
        }

        //Displays appointments by selected week
        public void populateWeek(DateTime date)
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
            DateTime parsedStart = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(start));
            DateTime parsedEnd = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(end));
            TimeSpan hours = new TimeSpan(23, 59, 59);
            parsedEnd = parsedEnd + hours;
            List<DateTime> dates = new List<DateTime> { parsedStart, parsedEnd };
            currentData = DB.getAppts(dates);
            refreshDGV(currentData);
        }

        //Displays appointments by selected month
        public void populateMonth(DateTime date)
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
            DateTime startDate = new DateTime(date.Year, date.Month, 1);
            DateTime endDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            TimeSpan hours = new TimeSpan(23, 59, 59);
            endDate = endDate + hours;
            DateTime convertedStart = TimeZoneInfo.ConvertTimeToUtc(startDate);
            DateTime convertedEnd = TimeZoneInfo.ConvertTimeToUtc(endDate);
            List<DateTime> dates = new List<DateTime> { convertedStart, convertedEnd };
            currentData = DB.getAppts(dates);
            refreshDGV(currentData);
            
        }

        //Populates data into DGV
        private void refreshDGV(DataTable data)
        {
            dgv.Rows.Clear();
            for (int i = 0; i < currentData.Rows.Count; i++)
            {
                string name = currentData.Rows[i][1].ToString();
                string type = currentData.Rows[i][2].ToString();
                DateTime start = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(currentData.Rows[i][3].ToString()), timeZone);
                DateTime end = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(currentData.Rows[i][4].ToString()), timeZone);
                dgv.Rows.Add(name, type, start, end);
            }
        }
        
        //Triggers appointment updates when radio button is clicked
        private void weeklyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (weeklyRadio.Checked)
            {
                populateWeek(selection);
                weeklyChecked = true;
            }
        }
        //Triggers appointment updates when radio button is clicked
        private void monthlyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (monthlyRadio.Checked)
            {
                populateMonth(selection);
                weeklyChecked = false;
            }   
        }

        //Populates either weekly or monthly appointments based on radio selection
        public void refreshAppointments()
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

        //Refreshes appointments on date change
        private void cal_DateChanged(object sender, DateRangeEventArgs e)
        {
            refreshAppointments();
        }


        //---APPOINTMENT AND CUSTOMER MANAGEMENT---//
        //Opens a form to edit selected appointment
        private void editAppt_Click(object sender, EventArgs e)
        {
            int id = int.Parse(currentData.Rows[dgv.CurrentCell.RowIndex][5].ToString());
            ModifyAppointment modApp = new ModifyAppointment(id, this);
            modApp.ShowDialog();
        }

        //Opens a form to add a new appointment
        private void addAppt_Click(object sender, EventArgs e)
        {
            AddAppointment addApp = new AddAppointment(this);
            addApp.ShowDialog();
        }

        //Opens confirmation dialog to delete selected appointment
        private void deleteAppt_Click(object sender, EventArgs e)
        {
            string name = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete your appointment with {name}?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                int id = int.Parse(currentData.Rows[dgv.CurrentCell.RowIndex][5].ToString());
                DB.deleteAppointment(id);
                refreshAppointments();
                MessageBox.Show($"Appointment deleted.");
            }
        }

        //Opens a form for customer CRUD
        private void manageCust_Click(object sender, EventArgs e)
        {
            CustomerManagement custMan = new CustomerManagement();
            custMan.ShowDialog();
        }

        //Pulls up dialog with selected customer data
        private void lookUpCustomer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(currentData.Rows[dgv.CurrentCell.RowIndex][0].ToString());
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


        //---REPORTING---//
        //Report on appointments by type
        private void reports_Click(object sender, EventArgs e)
        {
            ReportAppointmentTypes types = new ReportAppointmentTypes();
            types.ShowDialog();
        }

        //Report on appointments by customer
        private void customerAppts_Click(object sender, EventArgs e)
        {
            ReportCustomerAppointments customers = new ReportCustomerAppointments();
            customers.ShowDialog();
        }

        //Report on consultant schedules
        private void schedules_Click(object sender, EventArgs e)
        {
            ReportConsultantSchedule consultants = new ReportConsultantSchedule();
            consultants.ShowDialog();
        }


        //---MISC---//
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
