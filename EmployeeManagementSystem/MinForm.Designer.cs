namespace EmployeeManagementSystem
{
    partial class MinForm
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
            btnLogout = new Button();
            btnEmployee = new Button();
            btnSalaryReport = new Button();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(676, 404);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "ออกจากระบบ";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.Location = new Point(170, 120);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(112, 34);
            btnEmployee.TabIndex = 2;
            btnEmployee.Text = "Employee";
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnSalaryReport
            // 
            btnSalaryReport.Location = new Point(550, 120);
            btnSalaryReport.Name = "btnSalaryReport";
            btnSalaryReport.Size = new Size(140, 34);
            btnSalaryReport.TabIndex = 3;
            btnSalaryReport.Text = "SalaryReport";
            btnSalaryReport.UseVisualStyleBackColor = true;
            btnSalaryReport.Click += btnSalaryReport_Click;
            // 
            // MinForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalaryReport);
            Controls.Add(btnEmployee);
            Controls.Add(btnLogout);
            Name = "MinForm";
            Text = "MinForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogout;
        private Button btnEmployee;
        private Button btnSalaryReport;
    }
}