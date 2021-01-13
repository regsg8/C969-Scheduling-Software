
namespace RegGarrettSchedulingSoftware
{
    partial class CustomerManagement
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.titleLabel = new System.Windows.Forms.Label();
            this.addCustomer = new System.Windows.Forms.Button();
            this.editCustomer = new System.Windows.Forms.Button();
            this.deleteCustomer = new System.Windows.Forms.Button();
            this.returnDashboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(16, 48);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(853, 266);
            this.dgv.TabIndex = 0;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.RowHeadersVisible = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(195, 20);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Customer Management";
            // 
            // addCustomer
            // 
            this.addCustomer.Location = new System.Drawing.Point(16, 320);
            this.addCustomer.Name = "addCustomer";
            this.addCustomer.Size = new System.Drawing.Size(127, 23);
            this.addCustomer.TabIndex = 2;
            this.addCustomer.Text = "Add Customer";
            this.addCustomer.UseVisualStyleBackColor = true;
            this.addCustomer.Click += new System.EventHandler(this.addCustomer_Click);
            // 
            // editCustomer
            // 
            this.editCustomer.Location = new System.Drawing.Point(158, 320);
            this.editCustomer.Name = "editCustomer";
            this.editCustomer.Size = new System.Drawing.Size(127, 23);
            this.editCustomer.TabIndex = 3;
            this.editCustomer.Text = "Edit Customer";
            this.editCustomer.UseVisualStyleBackColor = true;
            this.editCustomer.Click += new System.EventHandler(this.editCustomer_Click);
            // 
            // deleteCustomer
            // 
            this.deleteCustomer.Location = new System.Drawing.Point(300, 320);
            this.deleteCustomer.Name = "deleteCustomer";
            this.deleteCustomer.Size = new System.Drawing.Size(127, 23);
            this.deleteCustomer.TabIndex = 4;
            this.deleteCustomer.Text = "Delete Customer";
            this.deleteCustomer.UseVisualStyleBackColor = true;
            this.deleteCustomer.Click += new System.EventHandler(this.deleteCustomer_Click);
            // 
            // returnDashboard
            // 
            this.returnDashboard.Location = new System.Drawing.Point(442, 320);
            this.returnDashboard.Name = "returnDashboard";
            this.returnDashboard.Size = new System.Drawing.Size(127, 23);
            this.returnDashboard.TabIndex = 5;
            this.returnDashboard.Text = "Close";
            this.returnDashboard.UseVisualStyleBackColor = true;
            this.returnDashboard.Click += new System.EventHandler(this.returnDashboard_Click);
            // 
            // CustomerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 391);
            this.Controls.Add(this.returnDashboard);
            this.Controls.Add(this.deleteCustomer);
            this.Controls.Add(this.editCustomer);
            this.Controls.Add(this.addCustomer);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.dgv);
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            this.Name = "CustomerManagement";
            this.Text = "Scheduling Software";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button addCustomer;
        private System.Windows.Forms.Button editCustomer;
        private System.Windows.Forms.Button deleteCustomer;
        private System.Windows.Forms.Button returnDashboard;
    }
}