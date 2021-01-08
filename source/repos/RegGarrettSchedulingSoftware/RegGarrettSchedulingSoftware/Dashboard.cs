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
        DateTime selection;
        //public DataTable table = new DataTable();
        public Dashboard()
        {
            InitializeComponent();
            today = DateTime.Now;
            dgv.DataSource = DB.table;
            checkAppts();
            populateWeek(today);
            //MessageBox.Show(Convert.ToDateTime(today).ToString("yyyy-MM-dd HH:mm:ss"));
        }

        //give alert for appointments occuring within 15 min of login
        private void checkAppts()
        {
            
        }

        //Display appointments by selected week
        private void populateWeek(DateTime date)
        {
            cal.RemoveAllBoldedDates();
            DB.table.Clear();
            int day = (int)date.DayOfWeek;
            string start = date.AddDays(-day).ToString();
            string end = date.AddDays(7 - day).ToString();
            DateTime count = Convert.ToDateTime(start);
            for (int i = 0; i < 7; i++)
            {
                cal.AddBoldedDate(count.AddDays(i));
            }
            cal.UpdateBoldedDates();
            DB.getAppts(start, end);
        }

        //Display appoinments by selected month
        private void populateMonth(DateTime date)
        {
            cal.RemoveAllBoldedDates();
            DB.table.Clear();
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
        }


        private void weeklyRadio_CheckedChanged(object sender, EventArgs e)
        {

            populateWeek(selection);
        }

        private void monthlyRadio_CheckedChanged(object sender, EventArgs e)
        {
            populateMonth(selection);
        }

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
            //fetch selected appt and open modify appoinment form
        }

        private void manageCust_Click(object sender, EventArgs e)
        {
            CustomerManagement custMan = new CustomerManagement();
            custMan.ShowDialog();
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
