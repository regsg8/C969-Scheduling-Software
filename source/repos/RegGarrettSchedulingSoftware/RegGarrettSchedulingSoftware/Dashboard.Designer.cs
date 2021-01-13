
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
            this.cal.Location = new System.Drawing.Point(18, 81);
            this.cal.Name = "cal";
            this.cal.TabIndex = 1;
            this.cal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cal_DateChanged);
            // 
            // weeklyRadio
            // 
            this.weeklyRadio.AutoSize = true;
            this.weeklyRadio.Checked = true;
            this.weeklyRadio.Location = new System.Drawing.Point(67, 52);
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
            this.monthlyRadio.Location = new System.Drawing.Point(134, 52);
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
            this.dgv.Location = new System.Drawing.Point(308, 81);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(603, 331);
            this.dgv.TabIndex = 4;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.RowHeadersVisible = false;
            // 
            // addAppt
            // 
            this.addAppt.Location = new System.Drawing.Point(18, 255);
            this.addAppt.Name = "addAppt";
            this.addAppt.Size = new System.Drawing.Size(227, 23);
            this.addAppt.TabIndex = 5;
            this.addAppt.Text = "New Appoinment";
            this.addAppt.UseVisualStyleBackColor = true;
            this.addAppt.Click += new System.EventHandler(this.addAppt_Click);
            // 
            // editAppt
            // 
            this.editAppt.Location = new System.Drawing.Point(308, 418);
            this.editAppt.Name = "editAppt";
            this.editAppt.Size = new System.Drawing.Size(227, 23);
            this.editAppt.TabIndex = 6;
            this.editAppt.Text = "Edit Appointment";
            this.editAppt.UseVisualStyleBackColor = true;
            this.editAppt.Click += new System.EventHandler(this.editAppt_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(16, 448);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(227, 23);
            this.exit.TabIndex = 7;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // manageCust
            // 
            this.manageCust.Location = new System.Drawing.Point(16, 389);
            this.manageCust.Name = "manageCust";
            this.manageCust.Size = new System.Drawing.Size(227, 23);
            this.manageCust.TabIndex = 8;
            this.manageCust.Text = "Manage Customers";
            this.manageCust.UseVisualStyleBackColor = true;
            this.manageCust.Click += new System.EventHandler(this.manageCust_Click);
            // 
            // lookUpCustomer
            // 
            this.lookUpCustomer.Location = new System.Drawing.Point(541, 418);
            this.lookUpCustomer.Name = "lookUpCustomer";
            this.lookUpCustomer.Size = new System.Drawing.Size(225, 23);
            this.lookUpCustomer.TabIndex = 9;
            this.lookUpCustomer.Text = "Look Up Customer";
            this.lookUpCustomer.UseVisualStyleBackColor = true;
            this.lookUpCustomer.Click += new System.EventHandler(this.lookUpCustomer_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 483);
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
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            this.Name = "Dashboard";
            this.Text = "Schedule Software";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
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
    }
}