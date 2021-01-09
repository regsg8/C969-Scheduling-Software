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
        public Dashboard()
        {
            InitializeComponent();
            today = DateTime.Now;
            selection = DateTime.Now;
            formatDGV();
            checkAppts();
            populateWeek(today);
        }

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

        //give alert for appointments occuring within 15 min of login
        private void checkAppts()
        {
            
        }

        //Display appointments by selected week
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
        }

        //Display appointments by selected month
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
        }


        private void weeklyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (weeklyRadio.Checked)
            {
                populateWeek(selection);
            }
            else populateWeek(today);
        }

        private void monthlyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (monthlyRadio.Checked)
            {
                populateMonth(selection);
            }   
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

//format dgv
//grab all appts within timeframe
//join customer name using appt cust id
//bind data to datagridview


//Test populating dgv with results
//MySqlConnection conn = new MySqlConnection("SERVER=wgudb.ucertify.com; DATABASE=U04qSi; Uid=U04qSi; Pwd=53688318875");
//MySqlCommand getAppt = new MySqlCommand("SELECT * FROM appointment", conn);
//MySqlDataAdapter sda = new MySqlDataAdapter(getAppt);
//DataTable data = new DataTable();
//sda.Fill(data);
//dgv.DataSource = data;

//Test populate sql join
//MySqlConnection conn = new MySqlConnection("SERVER=wgudb.ucertify.com; DATABASE=U04qSi; Uid=U04qSi; Pwd=53688318875");
//MySqlCommand getAppt = new MySqlCommand("SELECT c.customerName, a.type, a.start, a.end, a.appointmentId FROM appointment AS a INNER JOIN customer AS c ON c.customerId = a.customerId", conn);
//MySqlDataAdapter sda = new MySqlDataAdapter(getAppt);
//DataTable data = new DataTable();
//sda.Fill(data);
//currentData.Clear();
//sda.Fill(currentData);
//dgv.DataSource = data;
//MessageBox.Show(currentData.Rows[0][4].ToString());


//Not populating dgv:
//dgv.DataSource = DB.getAppts(parsedStart, parsedEnd);