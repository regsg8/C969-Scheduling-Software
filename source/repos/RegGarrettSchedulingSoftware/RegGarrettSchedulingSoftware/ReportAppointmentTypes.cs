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
    public partial class ReportAppointmentTypes : Form
    {
        DataTable types = new DataTable();
        DateTime selection;
        public ReportAppointmentTypes()
        {
            InitializeComponent();
            selection = DateTime.Now;
            formatPicker();
            setupCombo();
            formatDGV();
            refreshDGV();
        }

        //Formats the DateTimePicker to only display month and year
        private void formatPicker()
        {
            monthPicker.Format = DateTimePickerFormat.Custom;
            monthPicker.CustomFormat = "MM/yyyy";
        }

        //Returns the first and last dates of the month of the given date
        private List<DateTime> getMonthRange(DateTime date)
        {
            DateTime start = new DateTime(date.Year, date.Month, 1);
            DateTime end = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            TimeSpan hours = new TimeSpan(23, 59, 59);
            end = end + hours;
            List<DateTime> range = new List<DateTime> { start, end };
            return range;
        }

        //Formats ComboBox and populates with all appointment types
        private void setupCombo()
        {
            types = DB.getApptTypes();
            typeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            typeCombo.DataSource = types;
            typeCombo.DisplayMember = types.Columns[0].ToString();
            typeCombo.ValueMember = types.Columns[0].ToString();
        }

        //Sets up DataGridView to display appointments
        private void formatDGV()
        {
            dgv.ColumnCount = 4;
            dgv.Columns[0].HeaderText = "Customer";
            dgv.Columns[0].DataPropertyName = "customerName";
            dgv.Columns[1].HeaderText = "Type";
            dgv.Columns[1].DataPropertyName = "type";
            dgv.Columns[2].HeaderText = "Start";
            dgv.Columns[2].DataPropertyName = "start";
            dgv.Columns[3].HeaderText = "End";
            dgv.Columns[3].DataPropertyName = "end";
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                c.Width = 150;
            }
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
        }

        //Refreshes DataGridView with new appointment data
        private void refreshDGV()
        {
            if (typeCombo.SelectedValue != null)
            {
                DataRowView selected = typeCombo.SelectedItem as DataRowView;
                string type = selected.Row[0].ToString();
                dgv.DataSource = null;
                dgv.DataSource = DB.getTypeAppts(type, getMonthRange(selection));
            }
        }

        //Triggers DataGridView update with selected month
        private void monthPicker_ValueChanged(object sender, EventArgs e)
        {
            selection = monthPicker.Value;
            refreshDGV();
        }

        //Triggers DataGridView update with selected type
        private void typeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv.DataSource != null)
            {
                refreshDGV();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
