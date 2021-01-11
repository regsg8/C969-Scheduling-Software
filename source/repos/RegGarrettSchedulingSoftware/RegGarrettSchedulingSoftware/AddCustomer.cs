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
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //maybe put a lambda here to cycle through the textboxes and check for blank boxes
            //inputPanel textbox children?
            string name = firstInput.Text.ToString() + " " + lastInput.Text.ToString();
            DB.addNewCustomer(name, phoneInput.Text.ToString(), addressInput.Text.ToString(), cityInput.Text.ToString(), countryInput.Text.ToString(), zipInput.Text.ToString());
            this.Close();
        }

        private void cancelCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
