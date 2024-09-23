namespace EmployeeManagementSystem
{
    partial class EmployeeForm
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
            btnMinForm = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtEmployeeID = new TextBox();
            txtEmployeeName = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            cmbDepartmentID = new ComboBox();
            cmbPositionID = new ComboBox();
            cmbRoleID = new ComboBox();
            txtSalary = new TextBox();
            dataGridView1 = new DataGridView();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnMinForm
            // 
            btnMinForm.Location = new Point(1049, 388);
            btnMinForm.Name = "btnMinForm";
            btnMinForm.Size = new Size(112, 34);
            btnMinForm.TabIndex = 1;
            btnMinForm.Text = "หน้าหลัก";
            btnMinForm.UseVisualStyleBackColor = true;
            btnMinForm.Click += btnMinForm_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(760, 388);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(623, 388);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(488, 388);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(167, 51);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(150, 31);
            txtEmployeeID.TabIndex = 17;
            txtEmployeeID.TextChanged += txtEmployeeID_TextChanged;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(167, 225);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(150, 31);
            txtEmployeeName.TabIndex = 18;
            txtEmployeeName.TextChanged += txtEmployeeName_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(167, 166);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(150, 31);
            txtPassword.TabIndex = 19;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(167, 107);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(150, 31);
            txtUsername.TabIndex = 20;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // cmbDepartmentID
            // 
            cmbDepartmentID.FormattingEnabled = true;
            cmbDepartmentID.Location = new Point(167, 282);
            cmbDepartmentID.Name = "cmbDepartmentID";
            cmbDepartmentID.Size = new Size(182, 33);
            cmbDepartmentID.TabIndex = 21;
            cmbDepartmentID.SelectedIndexChanged += cmbDepartmentID_SelectedIndexChanged;
            // 
            // cmbPositionID
            // 
            cmbPositionID.FormattingEnabled = true;
            cmbPositionID.Location = new Point(167, 339);
            cmbPositionID.Name = "cmbPositionID";
            cmbPositionID.Size = new Size(182, 33);
            cmbPositionID.TabIndex = 22;
            cmbPositionID.SelectedIndexChanged += cmbPositionID_SelectedIndexChanged;
            // 
            // cmbRoleID
            // 
            cmbRoleID.FormattingEnabled = true;
            cmbRoleID.Location = new Point(167, 443);
            cmbRoleID.Name = "cmbRoleID";
            cmbRoleID.Size = new Size(182, 33);
            cmbRoleID.TabIndex = 23;
            cmbRoleID.SelectedIndexChanged += cmbRoleID_SelectedIndexChanged;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(167, 391);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(150, 31);
            txtSalary.TabIndex = 24;
            txtSalary.TextChanged += txtSalary_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(474, 90);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(687, 225);
            dataGridView1.TabIndex = 25;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(613, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 26;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1187, 538);
            Controls.Add(txtSearch);
            Controls.Add(dataGridView1);
            Controls.Add(txtSalary);
            Controls.Add(cmbRoleID);
            Controls.Add(cmbPositionID);
            Controls.Add(cmbDepartmentID);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtEmployeeName);
            Controls.Add(txtEmployeeID);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnMinForm);
            Name = "EmployeeForm";
            Text = "Employee";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMinForm;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtEmployeeID;
        private TextBox txtEmployeeName;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private ComboBox cmbDepartmentID;
        private ComboBox cmbPositionID;
        private ComboBox cmbRoleID;
        private TextBox txtSalary;
        private DataGridView dataGridView1;
        private TextBox txtSearch;
    }
}