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
        private DataTable cust = new DataTable();
        private static int currentId;
        private string nameUpdate;
        private string phoneUpdate;
        private string addressUpdate;
        private string cityUpdate;
        private string countryUpdate;
        private string zipUpdate;
        public ModifyCustomer(int id)
        {
            InitializeComponent();
            currentId = id;
            cust = DB.getOneCustomer(currentId);
            populateFields();
        }

        //Looks up customer by ID and populates textbox fields
        private void populateFields()
        {
            if (cust.Rows.Count != 1)
            {
                MessageBox.Show("Error retrieving customer, please try again.");
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
            List<TextBox> textboxes = new List<TextBox>();
            textboxes = Dashboard.getTextBoxes(this);
            string error = Dashboard.getEmptyTextboxError(textboxes);
            if (error != "")
            {
                MessageBox.Show(error);
            }
            else
            {
                //Pass "no change" if a field didn't change
                nameUpdate = nameInput.Text.ToString() == cust.Rows[0][0].ToString() ? "no change" : nameInput.Text.ToString();
                phoneUpdate = phoneInput.Text.ToString() == cust.Rows[0][1].ToString() ? "no change" : phoneInput.Text.ToString();
                addressUpdate = addressInput.Text.ToString() == cust.Rows[0][2].ToString() ? "no change" : addressInput.Text.ToString();
                cityUpdate = cityInput.Text.ToString() == cust.Rows[0][3].ToString() ? "no change" : cityInput.Text.ToString();
                countryUpdate = countryInput.Text.ToString() == cust.Rows[0][4].ToString() ? "no change" : countryInput.Text.ToString();
                zipUpdate = zipInput.Text.ToString() == cust.Rows[0][5].ToString() ? "no change" : zipInput.Text.ToString();
                DB.updateCustomer(currentId, nameUpdate, phoneUpdate, addressUpdate, cityUpdate, countryUpdate, zipUpdate);
            }
        }

        private void cancelCustomer_Click(object sender, EventArgs e)
        {
            CustomerManagement custMan = new CustomerManagement();
            custMan.Show();
            this.Close();
        }
    }
}
