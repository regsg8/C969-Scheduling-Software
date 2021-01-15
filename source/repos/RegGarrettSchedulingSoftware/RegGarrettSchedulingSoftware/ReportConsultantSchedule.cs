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
            formatDGV();
            refreshDGV();
        }

        private void setupCombo()
        {
            consultants = DB.getConsultants();
            consultantCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            consultantCombo.DataSource = consultants;
            consultantCombo.DisplayMember = consultants.Columns[1].ToString();
            consultantCombo.ValueMember = consultants.Columns[0].ToString();
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
            if (consultantCombo.SelectedValue != null)
            {
                DataRowView selected = consultantCombo.SelectedItem as DataRowView;
                string id = selected.Row[0].ToString();
                dgv.DataSource = DB.getConsultantAppts(int.Parse(id));
            }
        }

        private void consultantCombo_SelectedIndexChanged(object sender, EventArgs e)
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
