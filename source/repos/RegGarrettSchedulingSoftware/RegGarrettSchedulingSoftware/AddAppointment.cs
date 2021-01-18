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
    public partial class AddAppointment : Form
    {
        private Dashboard dash;
        public AddAppointment(Dashboard form)
        {
            InitializeComponent();
            formatCustomerDGV();
            formatDTPickers();
            dash = form;
        }

        private void formatCustomerDGV()
        {
            dgv.ColumnCount = 3;
            dgv.Columns[0].Width = 101;
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[0].DataPropertyName = "customerId";
            dgv.Columns[1].Width = 151;
            dgv.Columns[1].HeaderText = "Name";
            dgv.Columns[1].DataPropertyName = "customerName";
            dgv.Columns[2].Width = 151;
            dgv.Columns[2].HeaderText = "Phone";
            dgv.Columns[2].DataPropertyName = "phone";
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = DB.getCustomers();
        }

        //Sets dateTimePickers to select hours instead of dates
        private void formatDTPickers()
        {
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.CustomFormat = "hh:mm tt";
            startTimePicker.ShowUpDown = true;
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.CustomFormat = "hh:mm tt";
            endTimePicker.ShowUpDown = true;
            setTimeValues();
        }

        //Rounds time values up by increments of 15
        private void setTimeValues()
        {
            DateTime now = DateTime.Now;
            TimeSpan rounder = TimeSpan.FromMinutes(15);
            DateTime rounded = new DateTime((now.Ticks + rounder.Ticks - 1) / rounder.Ticks * rounder.Ticks);
            startTimePicker.Value = rounded;
            endTimePicker.Value = startTimePicker.Value.AddMinutes(30);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = startDatePicker.Value.Date.AddHours(startTimePicker.Value.Hour).AddMinutes(startTimePicker.Value.Minute);
                DateTime end = endDatePicker.Value.Date.AddHours(endTimePicker.Value.Hour).AddMinutes(endTimePicker.Value.Minute);
                DateTime startUtc = TimeZoneInfo.ConvertTimeToUtc(start);
                DateTime endUtc = TimeZoneInfo.ConvertTimeToUtc(end);
                DateTime nowUtc = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
                List<DateTime> dates = new List<DateTime> { startUtc, endUtc, nowUtc };
                List<string> formattedDates = DB.formatDates(dates);
                if (DB.checkOverlapping(formattedDates)) throw new Exception("Appointment time overlaps with existing appointment.");
                if (!DB.insideBusinessHours(formattedDates)) throw new Exception("Appointment does not occur within local business hours.");
                if (typeInput.Text.ToString() == "") throw new Exception("Please enter appointment type.");
                int id = int.Parse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString());
                string type = typeInput.Text.ToString();
                DB.newAppointment(id, type, dates);
                //Refreshes dashboard appointment view based on weekly/monthly
                if (dash.weeklyChecked)
                {
                    dash.populateWeek(dash.selection);
                }
                else
                {
                    dash.populateMonth(dash.selection);
                }
                dash.populateWeek(DateTime.Now);
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
