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
        private string userID;
        public Dashboard(string id)
        {
            InitializeComponent();
            today = DateTime.Now;
            selection = DateTime.Now;
            userID = id;
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
                column.Width = 150;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            } 
            dgv.Columns[0].HeaderText = "Customer";
            dgv.Columns[0].DataPropertyName = "customerName";
            dgv.Columns[1].HeaderText = "Type";
            dgv.Columns[1].DataPropertyName = "type";
            dgv.Columns[2].HeaderText = "Start";
            dgv.Columns[2].DataPropertyName = "start";
            dgv.Columns[3].HeaderText = "End";
            dgv.Columns[3].DataPropertyName = "end";
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
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
            dgv.DataSource = DB.getAppts(parsedStart, parsedEnd);
            currentData = DB.getAppts(parsedStart, parsedEnd);
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
            DateTime end = date.AddDays(days);
            dgv.DataSource = DB.getAppts(parsedStart, end);
            currentData = DB.getAppts(parsedStart, end);
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

        private void lookUpCustomer_Click(object sender, EventArgs e)
        {
            //Pulls up customer by selected id
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
