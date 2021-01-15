
namespace RegGarrettSchedulingSoftware
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.cal = new System.Windows.Forms.MonthCalendar();
            this.weeklyRadio = new System.Windows.Forms.RadioButton();
            this.monthlyRadio = new System.Windows.Forms.RadioButton();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.addAppt = new System.Windows.Forms.Button();
            this.editAppt = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.manageCust = new System.Windows.Forms.Button();
            this.lookUpCustomer = new System.Windows.Forms.Button();
            this.byType = new System.Windows.Forms.Button();
            this.deleteAppt = new System.Windows.Forms.Button();
            this.schedules = new System.Windows.Forms.Button();
            this.customerAppts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(97, 20);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Dashboard";
            // 
            // cal
            // 
            this.cal.Location = new System.Drawing.Point(646, 52);
            this.cal.Name = "cal";
            this.cal.TabIndex = 1;
            this.cal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cal_DateChanged);
            // 
            // weeklyRadio
            // 
            this.weeklyRadio.AutoSize = true;
            this.weeklyRadio.Checked = true;
            this.weeklyRadio.Location = new System.Drawing.Point(695, 23);
            this.weeklyRadio.Name = "weeklyRadio";
            this.weeklyRadio.Size = new System.Drawing.Size(61, 17);
            this.weeklyRadio.TabIndex = 2;
            this.weeklyRadio.TabStop = true;
            this.weeklyRadio.Text = "Weekly";
            this.weeklyRadio.UseVisualStyleBackColor = true;
            this.weeklyRadio.CheckedChanged += new System.EventHandler(this.weeklyRadio_CheckedChanged);
            // 
            // monthlyRadio
            // 
            this.monthlyRadio.AutoSize = true;
            this.monthlyRadio.Location = new System.Drawing.Point(762, 23);
            this.monthlyRadio.Name = "monthlyRadio";
            this.monthlyRadio.Size = new System.Drawing.Size(62, 17);
            this.monthlyRadio.TabIndex = 3;
            this.monthlyRadio.TabStop = true;
            this.monthlyRadio.Text = "Monthly";
            this.monthlyRadio.UseVisualStyleBackColor = true;
            this.monthlyRadio.CheckedChanged += new System.EventHandler(this.monthlyRadio_CheckedChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(16, 52);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(603, 331);
            this.dgv.TabIndex = 4;
            // 
            // addAppt
            // 
            this.addAppt.Location = new System.Drawing.Point(16, 389);
            this.addAppt.Name = "addAppt";
            this.addAppt.Size = new System.Drawing.Size(146, 23);
            this.addAppt.TabIndex = 5;
            this.addAppt.Text = "New Appointment";
            this.addAppt.UseVisualStyleBackColor = true;
            this.addAppt.Click += new System.EventHandler(this.addAppt_Click);
            // 
            // editAppt
            // 
            this.editAppt.Location = new System.Drawing.Point(168, 389);
            this.editAppt.Name = "editAppt";
            this.editAppt.Size = new System.Drawing.Size(146, 23);
            this.editAppt.TabIndex = 6;
            this.editAppt.Text = "Edit Appointment";
            this.editAppt.UseVisualStyleBackColor = true;
            this.editAppt.Click += new System.EventHandler(this.editAppt_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(646, 389);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(227, 23);
            this.exit.TabIndex = 7;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // manageCust
            // 
            this.manageCust.Location = new System.Drawing.Point(646, 236);
            this.manageCust.Name = "manageCust";
            this.manageCust.Size = new System.Drawing.Size(227, 23);
            this.manageCust.TabIndex = 8;
            this.manageCust.Text = "Manage Customers";
            this.manageCust.UseVisualStyleBackColor = true;
            this.manageCust.Click += new System.EventHandler(this.manageCust_Click);
            // 
            // lookUpCustomer
            // 
            this.lookUpCustomer.Location = new System.Drawing.Point(473, 389);
            this.lookUpCustomer.Name = "lookUpCustomer";
            this.lookUpCustomer.Size = new System.Drawing.Size(146, 23);
            this.lookUpCustomer.TabIndex = 9;
            this.lookUpCustomer.Text = "Look Up Customer";
            this.lookUpCustomer.UseVisualStyleBackColor = true;
            this.lookUpCustomer.Click += new System.EventHandler(this.lookUpCustomer_Click);
            // 
            // byType
            // 
            this.byType.Location = new System.Drawing.Point(646, 288);
            this.byType.Name = "byType";
            this.byType.Size = new System.Drawing.Size(227, 23);
            this.byType.TabIndex = 10;
            this.byType.Text = "Appointments by Type";
            this.byType.UseVisualStyleBackColor = true;
            this.byType.Click += new System.EventHandler(this.reports_Click);
            // 
            // deleteAppt
            // 
            this.deleteAppt.Location = new System.Drawing.Point(320, 389);
            this.deleteAppt.Name = "deleteAppt";
            this.deleteAppt.Size = new System.Drawing.Size(146, 23);
            this.deleteAppt.TabIndex = 11;
            this.deleteAppt.Text = "Delete Appointment";
            this.deleteAppt.UseVisualStyleBackColor = true;
            this.deleteAppt.Click += new System.EventHandler(this.deleteAppt_Click);
            // 
            // schedules
            // 
            this.schedules.Location = new System.Drawing.Point(646, 346);
            this.schedules.Name = "schedules";
            this.schedules.Size = new System.Drawing.Size(227, 23);
            this.schedules.TabIndex = 12;
            this.schedules.Text = "Consultant Schedules";
            this.schedules.UseVisualStyleBackColor = true;
            this.schedules.Click += new System.EventHandler(this.schedules_Click);
            // 
            // customerAppts
            // 
            this.customerAppts.Location = new System.Drawing.Point(646, 317);
            this.customerAppts.Name = "customerAppts";
            this.customerAppts.Size = new System.Drawing.Size(227, 23);
            this.customerAppts.TabIndex = 13;
            this.customerAppts.Text = "Appointments by Customer";
            this.customerAppts.UseVisualStyleBackColor = true;
            this.customerAppts.Click += new System.EventHandler(this.customerAppts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(646, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Reports:";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 434);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerAppts);
            this.Controls.Add(this.schedules);
            this.Controls.Add(this.deleteAppt);
            this.Controls.Add(this.byType);
            this.Controls.Add(this.lookUpCustomer);
            this.Controls.Add(this.manageCust);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.editAppt);
            this.Controls.Add(this.addAppt);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.monthlyRadio);
            this.Controls.Add(this.weeklyRadio);
            this.Controls.Add(this.cal);
            this.Controls.Add(this.titleLabel);
            this.Name = "Dashboard";
            this.Text = "Schedule Software";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.MonthCalendar cal;
        private System.Windows.Forms.RadioButton weeklyRadio;
        private System.Windows.Forms.RadioButton monthlyRadio;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button addAppt;
        private System.Windows.Forms.Button editAppt;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button manageCust;
        private System.Windows.Forms.Button lookUpCustomer;
        private System.Windows.Forms.Button byType;
        private System.Windows.Forms.Button deleteAppt;
        private System.Windows.Forms.Button schedules;
        private System.Windows.Forms.Button customerAppts;
        private System.Windows.Forms.Label label1;
    }
}