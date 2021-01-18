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
        DataTable currentData;
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
                //Uses lambda to shorten syntax of applying common formats to all columns
                Dashboard.format(column);
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
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = DB.getCustomers();
            currentData = DB.getCustomers();
        }

        public void refreshDGV()
        {
            dgv.DataSource = DB.getCustomers();
            currentData = DB.getCustomers();
        }
        private void addCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer add = new AddCustomer(this);
            add.ShowDialog();
        }

        //Opens Modify Customer dialog with selected customer's ID
        private void editCustomer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString());
            ModifyCustomer modify = new ModifyCustomer(id, this);
            modify.ShowDialog();
        }

        private void deleteCustomer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString());
            string name = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value.ToString();
            DataTable custAppts = new DataTable();
            custAppts = DB.getCustomerAppts(id);
            if (custAppts.Rows.Count > 0)
            {
                MessageBox.Show($"{name} currently has appointments. You cannot delete {name} until all appointments with {name} have been deleted.");
            }
            else
            {
                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete {name}?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    DB.deleteCustomer(id);
                    refreshDGV();
                    MessageBox.Show($"{name} deleted.");
                }
            }
            
        }

        private void returnDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
