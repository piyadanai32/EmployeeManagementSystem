namespace EmployeeManagementSystem
{
    partial class AttendanceForm
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
            dtpCheckIn = new DateTimePicker();
            btnCheckIn = new Button();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(676, 404);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "ออกจากระบบ";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Location = new Point(238, 164);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(300, 31);
            dtpCheckIn.TabIndex = 3;
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(314, 287);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(112, 34);
            btnCheckIn.TabIndex = 4;
            btnCheckIn.Text = "CheckIn";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // AttendanceForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCheckIn);
            Controls.Add(dtpCheckIn);
            Controls.Add(btnLogout);
            Name = "AttendanceForm";
            Text = "AttendanceForm";
            Load += AttendanceForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogout;
        private DateTimePicker dtpCheckIn;
        private Button btnCheckIn;
    }
}