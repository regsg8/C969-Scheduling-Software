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
            textboxes = getTextBoxes(this);
            string error = getEmptyTextboxError(textboxes);
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

        //Gathers list of textboxes
        public static List<TextBox> getTextBoxes(Form form)
        {
            List<TextBox> textBoxes = new List<TextBox>();
            foreach (Control c in form.Controls)
            {
                if (c is TextBox)
                {
                    textBoxes.Add(c as TextBox);
                }
            }
            return textBoxes;
        }

        //Creates a messagebox string for any empty textboxes
        public static string getEmptyTextboxError(List<TextBox> textboxes)
        {
            string mbString = "";
            List<string> errors = new List<string>();
            //Uses lambda to shorten syntax of cycling through textboxes
            textboxes.ForEach(t =>
            {
                if (t.Text.ToString() == "")
                {
                    string e = "";
                    if (t.Name.ToString() == "nameInput") e = "Name";
                    if (t.Name.ToString() == "phoneInput") e = "Phone";
                    if (t.Name.ToString() == "addressInput") e = "Address";
                    if (t.Name.ToString() == "cityInput") e = "City";
                    if (t.Name.ToString() == "countryInput") e = "Country";
                    if (t.Name.ToString() == "zipInput") e = "Zip Code";
                    errors.Add(e);
                }
            }
            );
            if (errors.Count != 0)
            {
                //Uses lambda to shorten syntax of cycling through strings
                errors.ForEach(s =>
                {
                    mbString = mbString + $"{s} cannot be blank\n";
                }
                );
            }
            return mbString;
        }

        private void cancelCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
