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
    public partial class ModifyCustomer : Form
    {
        private static int currentId;
        public ModifyCustomer(int id)
        {
            InitializeComponent();
            currentId = id;
            populateFields(currentId);
        }

        //Looks up customer by ID and populates textbox fields
        private void populateFields(int id)
        {
            DataTable cust;
            cust = DB.getOneCustomer(id);
            if (cust.Rows.Count != 1)
            {
                MessageBox.Show("Error retrieving customer, please try again.");
                CustomerManagement custMan = new CustomerManagement();
                custMan.Show();
                this.Close();
            }
            else
            {
                nameInput.Text = cust.Rows[0][0].ToString();
                phoneInput.Text = cust.Rows[0][1].ToString();
                addressInput.Text = cust.Rows[0][2].ToString();
                cityInput.Text = cust.Rows[0][3].ToString();
                countryInput.Text = cust.Rows[0][4].ToString();
                zipInput.Text = cust.Rows[0][5].ToString();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Check to make sure all textbox fields have values

        }

        private void cancelCustomer_Click(object sender, EventArgs e)
        {
            CustomerManagement custMan = new CustomerManagement();
            custMan.Show();
            this.Close();
        }
    }
}
