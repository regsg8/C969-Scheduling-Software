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
    public partial class AddCustomer : Form
    {
        private CustomerManagement customerM;
        public AddCustomer(CustomerManagement form)
        {
            InitializeComponent();
            customerM = form;
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
                DB.addNewCustomer(nameInput.Text.ToString(), phoneInput.Text.ToString(), addressInput.Text.ToString(), cityInput.Text.ToString(), countryInput.Text.ToString(), zipInput.Text.ToString());
                customerM.refreshDGV();
                this.Close();
            }
        }

        private void cancelCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddCustomer_FormClosed(object sender, EventArgs e)
        {
            
        }
    }
}
