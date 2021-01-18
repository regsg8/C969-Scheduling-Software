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
    public partial class ModifyAppointment : Form
    {
        Dashboard dash;
        private DataTable appt = new DataTable();
        private int currentId;
        public ModifyAppointment(int id, Dashboard form)
        {
            InitializeComponent();
            dash = form;
            currentId = id;
            appt = DB.getOneAppointment(currentId);
            formatDTPickers();
            formatCustomerDGV();
            populateAppt();
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
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DataSource = DB.getCustomers();
        }
        private void formatDTPickers()
        {
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.CustomFormat = "hh:mm tt";
            startTimePicker.ShowUpDown = true;
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.CustomFormat = "hh:mm tt";
            endTimePicker.ShowUpDown = true;
        }
        private void populateAppt()
        {
            int custRow = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (int.Parse(dgv.Rows[i].Cells[0].Value.ToString()) == int.Parse(appt.Rows[0][0].ToString())) 
                {
                    custRow = i;
                }
            }
            typeInput.Text = appt.Rows[0][1].ToString();
            DateTime start = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(appt.Rows[0][2]), Dashboard.timeZone);
            DateTime end = TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(appt.Rows[0][3]), Dashboard.timeZone);
            startDatePicker.Value = start;
            startTimePicker.Value = start;
            endDatePicker.Value = end;
            endTimePicker.Value = end;
            //startDatePicker.Value = Convert.ToDateTime(appt.Rows[0][2].ToString());
            //startTimePicker.Value = Convert.ToDateTime(appt.Rows[0][2].ToString());
            //endDatePicker.Value = Convert.ToDateTime(appt.Rows[0][3].ToString());
            //endTimePicker.Value = Convert.ToDateTime(appt.Rows[0][3].ToString());
            dgv.CurrentCell = dgv.Rows[custRow].Cells[0];
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
