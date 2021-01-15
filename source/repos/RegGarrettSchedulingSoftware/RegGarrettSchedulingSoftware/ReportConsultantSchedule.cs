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
    public partial class ReportConsultantSchedule : Form
    {
        private DataTable consultants = new DataTable();
        public ReportConsultantSchedule()
        {
            InitializeComponent();
            setupCombo();
        }

        private void setupCombo()
        {
            consultants = DB.getConsultants();
            consultantCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            consultantCombo.DataSource = consultants;
            consultantCombo.DisplayMember = "userName";
            consultantCombo.ValueMember = "userId";
        }

        private void consultantCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
