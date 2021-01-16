
namespace RegGarrettSchedulingSoftware
{
    partial class ReportAppointmentTypes
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
            this.monthPicker = new System.Windows.Forms.DateTimePicker();
            this.closeButton = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.typeCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(186, 20);
            this.titleLabel.TabIndex = 19;
            this.titleLabel.Text = "Appointments by Type";
            // 
            // monthPicker
            // 
            this.monthPicker.Location = new System.Drawing.Point(16, 44);
            this.monthPicker.Name = "monthPicker";
            this.monthPicker.Size = new System.Drawing.Size(121, 20);
            this.monthPicker.TabIndex = 20;
            this.monthPicker.ValueChanged += new System.EventHandler(this.monthPicker_ValueChanged);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(544, 455);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 21;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(16, 112);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(603, 300);
            this.dgv.TabIndex = 22;
            // 
            // typeCombo
            // 
            this.typeCombo.FormattingEnabled = true;
            this.typeCombo.Location = new System.Drawing.Point(16, 71);
            this.typeCombo.Name = "typeCombo";
            this.typeCombo.Size = new System.Drawing.Size(121, 21);
            this.typeCombo.TabIndex = 23;
            this.typeCombo.SelectedIndexChanged += new System.EventHandler(this.typeCombo_SelectedIndexChanged);
            // 
            // ReportAppointmentTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 490);
            this.Controls.Add(this.typeCombo);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.monthPicker);
            this.Controls.Add(this.titleLabel);
            this.Name = "ReportAppointmentTypes";
            this.Text = "Scheduling Software";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.DateTimePicker monthPicker;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox typeCombo;
    }
}