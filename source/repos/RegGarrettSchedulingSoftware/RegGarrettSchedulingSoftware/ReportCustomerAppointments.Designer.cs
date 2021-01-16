
namespace RegGarrettSchedulingSoftware
{
    partial class ReportCustomerAppointments
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.exitButton = new System.Windows.Forms.Button();
            this.customerCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(225, 20);
            this.titleLabel.TabIndex = 21;
            this.titleLabel.Text = "Appointments by Customer";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(16, 80);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(603, 298);
            this.dgv.TabIndex = 27;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(544, 415);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 26;
            this.exitButton.Text = "Close";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // customerCombo
            // 
            this.customerCombo.FormattingEnabled = true;
            this.customerCombo.Location = new System.Drawing.Point(16, 42);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(121, 21);
            this.customerCombo.TabIndex = 25;
            this.customerCombo.SelectedIndexChanged += new System.EventHandler(this.customerCombo_SelectedIndexChanged);
            // 
            // ReportCustomerAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.customerCombo);
            this.Controls.Add(this.titleLabel);
            this.Name = "ReportCustomerAppointments";
            this.Text = "Scheduling Software";
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ComboBox customerCombo;
    }
}