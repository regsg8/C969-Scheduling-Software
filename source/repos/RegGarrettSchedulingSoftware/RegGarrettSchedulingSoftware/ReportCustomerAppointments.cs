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
    public partial class ReportCustomerAppointments : Form
    {
        DataTable customers = new DataTable();
        public ReportCustomerAppointments()
        {
            InitializeComponent();
            setupCombo();
            formatDGV();
            refreshDGV();
        }

        private void setupCombo()
        {
            customers = DB.getCustomers();
            customerCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            customerCombo.DataSource = customers;
            customerCombo.DisplayMember = customers.Columns[1].ToString();
            customerCombo.ValueMember = customers.Columns[0].ToString();
        }

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

        private void refreshDGV()
        {
            if (customerCombo.SelectedValue != null)
            {
                DataRowView selected = customerCombo.SelectedItem as DataRowView;
                string id = selected.Row[0].ToString();
                dgv.DataSource = DB.getCustomerAppts(int.Parse(id));
            }
        }

        private void customerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv.DataSource != null)
            {
                refreshDGV();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
