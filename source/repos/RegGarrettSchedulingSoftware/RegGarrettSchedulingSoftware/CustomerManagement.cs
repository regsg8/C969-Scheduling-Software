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
    public partial class CustomerManagement : Form
    {
        public CustomerManagement()
        {
            InitializeComponent();
            formatCustomerDGV();
        }

        private void formatCustomerDGV()
        {
            dgv.ColumnCount = 6;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.Width = 150;
            }
            dgv.Columns[0].Width = 100;
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[0].DataPropertyName = "customerId";
            dgv.Columns[1].HeaderText = "Name";
            dgv.Columns[1].DataPropertyName = "customerName";
            dgv.Columns[2].HeaderText = "Phone";
            dgv.Columns[2].DataPropertyName = "phone";
            dgv.Columns[3].HeaderText = "Address";
            dgv.Columns[3].DataPropertyName = "address";
            dgv.Columns[4].HeaderText = "City";
            dgv.Columns[4].DataPropertyName = "city";
            dgv.Columns[5].HeaderText = "Country";
            dgv.Columns[5].DataPropertyName = "country";
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = DB.getCustomers();
        }
        private void addCustomer_Click(object sender, EventArgs e)
        {

        }

        private void editCustomer_Click(object sender, EventArgs e)
        {

        }

        private void deleteCustomer_Click(object sender, EventArgs e)
        {

        }

        private void returnDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
