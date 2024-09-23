namespace EmployeeManagementSystem
{
    partial class SalaryReportForm
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
            cmbEmployeeID = new ComboBox();
            dtpMonthYear = new DateTimePicker();
            txtTotalDaysInMonth = new TextBox();
            txtCheckInDays = new TextBox();
            txtMissedDays = new TextBox();
            txtRegularHolidays = new TextBox();
            txtEffectiveMissedDays = new TextBox();
            txtSalary = new TextBox();
            txtDeduction = new TextBox();
            txtNetSalary = new TextBox();
            dtpReportDate = new DateTimePicker();
            btnbtnCalculateSalary = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            btnPrint = new Button();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnMinForm
            // 
            btnMinForm.Location = new Point(1301, 380);
            btnMinForm.Name = "btnMinForm";
            btnMinForm.Size = new Size(112, 34);
            btnMinForm.TabIndex = 2;
            btnMinForm.Text = "หน้าหลัก";
            btnMinForm.UseVisualStyleBackColor = true;
            btnMinForm.Click += btnMinForm_Click;
            // 
            // cmbEmployeeID
            // 
            cmbEmployeeID.FormattingEnabled = true;
            cmbEmployeeID.Location = new Point(318, 80);
            cmbEmployeeID.Name = "cmbEmployeeID";
            cmbEmployeeID.Size = new Size(182, 33);
            cmbEmployeeID.TabIndex = 3;
            cmbEmployeeID.SelectedIndexChanged += cmbEmployeeID_SelectedIndexChanged;
            // 
            // dtpMonthYear
            // 
            dtpMonthYear.Location = new Point(321, 151);
            dtpMonthYear.Name = "dtpMonthYear";
            dtpMonthYear.Size = new Size(193, 31);
            dtpMonthYear.TabIndex = 4;
            dtpMonthYear.ValueChanged += dtpMonthYear_ValueChanged;
            // 
            // txtTotalDaysInMonth
            // 
            txtTotalDaysInMonth.Location = new Point(320, 216);
            txtTotalDaysInMonth.Name = "txtTotalDaysInMonth";
            txtTotalDaysInMonth.Size = new Size(150, 31);
            txtTotalDaysInMonth.TabIndex = 5;
            txtTotalDaysInMonth.TextChanged += txtTotalDaysInMonth_TextChanged;
            // 
            // txtCheckInDays
            // 
            txtCheckInDays.Location = new Point(319, 266);
            txtCheckInDays.Name = "txtCheckInDays";
            txtCheckInDays.Size = new Size(150, 31);
            txtCheckInDays.TabIndex = 6;
            txtCheckInDays.TextChanged += txtCheckInDays_TextChanged;
            // 
            // txtMissedDays
            // 
            txtMissedDays.Location = new Point(320, 324);
            txtMissedDays.Name = "txtMissedDays";
            txtMissedDays.Size = new Size(150, 31);
            txtMissedDays.TabIndex = 7;
            txtMissedDays.TextChanged += txtMissedDays_TextChanged;
            // 
            // txtRegularHolidays
            // 
            txtRegularHolidays.Location = new Point(320, 380);
            txtRegularHolidays.Name = "txtRegularHolidays";
            txtRegularHolidays.Size = new Size(150, 31);
            txtRegularHolidays.TabIndex = 8;
            txtRegularHolidays.TextChanged += txtRegularHolidays_TextChanged;
            // 
            // txtEffectiveMissedDays
            // 
            txtEffectiveMissedDays.Location = new Point(321, 432);
            txtEffectiveMissedDays.Name = "txtEffectiveMissedDays";
            txtEffectiveMissedDays.Size = new Size(150, 31);
            txtEffectiveMissedDays.TabIndex = 9;
            txtEffectiveMissedDays.TextChanged += txtEffectiveMissedDays_TextChanged;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(319, 482);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(150, 31);
            txtSalary.TabIndex = 10;
            txtSalary.TextChanged += txtSalary_TextChanged;
            // 
            // txtDeduction
            // 
            txtDeduction.Location = new Point(318, 538);
            txtDeduction.Name = "txtDeduction";
            txtDeduction.Size = new Size(150, 31);
            txtDeduction.TabIndex = 11;
            txtDeduction.TextChanged += txtDeduction_TextChanged;
            // 
            // txtNetSalary
            // 
            txtNetSalary.Location = new Point(317, 588);
            txtNetSalary.Name = "txtNetSalary";
            txtNetSalary.Size = new Size(150, 31);
            txtNetSalary.TabIndex = 12;
            txtNetSalary.TextChanged += txtNetSalary_TextChanged;
            // 
            // dtpReportDate
            // 
            dtpReportDate.Location = new Point(1113, 27);
            dtpReportDate.Name = "dtpReportDate";
            dtpReportDate.Size = new Size(300, 31);
            dtpReportDate.TabIndex = 13;
            dtpReportDate.ValueChanged += dtpReportDate_ValueChanged;
            // 
            // btnbtnCalculateSalary
            // 
            btnbtnCalculateSalary.Location = new Point(570, 380);
            btnbtnCalculateSalary.Name = "btnbtnCalculateSalary";
            btnbtnCalculateSalary.Size = new Size(151, 51);
            btnbtnCalculateSalary.TabIndex = 14;
            btnbtnCalculateSalary.Text = "CalculateSalary";
            btnbtnCalculateSalary.UseVisualStyleBackColor = true;
            btnbtnCalculateSalary.Click += btnbtnCalculateSalary_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(757, 380);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(890, 380);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 16;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1037, 380);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(550, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(863, 225);
            dataGridView1.TabIndex = 18;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(755, 446);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(112, 34);
            btnPrint.TabIndex = 19;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(717, 29);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 27;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // SalaryReportForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1450, 688);
            Controls.Add(txtSearch);
            Controls.Add(btnPrint);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnbtnCalculateSalary);
            Controls.Add(dtpReportDate);
            Controls.Add(txtNetSalary);
            Controls.Add(txtDeduction);
            Controls.Add(txtSalary);
            Controls.Add(txtEffectiveMissedDays);
            Controls.Add(txtRegularHolidays);
            Controls.Add(txtMissedDays);
            Controls.Add(txtCheckInDays);
            Controls.Add(txtTotalDaysInMonth);
            Controls.Add(dtpMonthYear);
            Controls.Add(cmbEmployeeID);
            Controls.Add(btnMinForm);
            Name = "SalaryReportForm";
            Text = "SalaryReport";
            Load += SalaryReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMinForm;
        private ComboBox cmbEmployeeID;
        private DateTimePicker dtpMonthYear;
        private TextBox txtTotalDaysInMonth;
        private TextBox txtCheckInDays;
        private TextBox txtMissedDays;
        private TextBox txtRegularHolidays;
        private TextBox txtEffectiveMissedDays;
        private TextBox txtSalary;
        private TextBox txtDeduction;
        private TextBox txtNetSalary;
        private DateTimePicker dtpReportDate;
        private Button btnbtnCalculateSalary;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private Button btnPrint;
        private TextBox txtSearch;
    }
}