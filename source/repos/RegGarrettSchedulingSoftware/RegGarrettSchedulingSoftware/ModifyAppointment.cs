﻿using System;
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
            startDatePicker.Value = Convert.ToDateTime(appt.Rows[0][2].ToString());
            startTimePicker.Value = Convert.ToDateTime(appt.Rows[0][2].ToString());
            endDatePicker.Value = Convert.ToDateTime(appt.Rows[0][3].ToString());
            endTimePicker.Value = Convert.ToDateTime(appt.Rows[0][3].ToString());
            dgv.CurrentCell = dgv.Rows[custRow].Cells[0];
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (typeInput.Text.ToString() == "")
            {
                MessageBox.Show("Please enter appointment Type");
            }
            else
            {
                DateTime start = startDatePicker.Value.Date.AddHours(startTimePicker.Value.Hour).AddMinutes(startTimePicker.Value.Minute);
                DateTime end = endDatePicker.Value.Date.AddHours(endTimePicker.Value.Hour).AddMinutes(endTimePicker.Value.Minute);
                List<DateTime> dates = new List<DateTime> { start, end };
                int custId = int.Parse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString());
                string type = typeInput.Text.ToString();
                DB.updateAppointment(currentId, custId, type, dates);
                //Refreshes dashboard appoinment view based on weekly/monthly
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
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
