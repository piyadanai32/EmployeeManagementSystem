using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class MinForm : Form
    {
        public MinForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // ยืนยันการ Logout กับผู้ใช้
            DialogResult result = MessageBox.Show("คุณต้องการออกจากระบบหรือไม่?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // เปิดฟอร์ม Login (Form1)
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // ปิดฟอร์มปัจจุบัน
                this.Close();
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.Show();
            this.Close();
        }

        private void btnSalaryReport_Click(object sender, EventArgs e)
        {
            SalaryReportForm salaryReportForm = new SalaryReportForm();
            salaryReportForm.Show();
            this.Close();
        }
    }
}
