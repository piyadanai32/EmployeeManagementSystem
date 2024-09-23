using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class AttendanceForm : Form
    {
        private string employeeID; // ประกาศตัวแปร employeeID ที่นี่

        public AttendanceForm(string employeeID)
        {
            InitializeComponent();
            this.employeeID = employeeID; // เก็บค่า EmployeeID สำหรับการคำนวณการเข้างาน
        }
        // ฟังก์ชันบันทึกข้อมูลการเข้างาน
        private bool AddAttendanceRecord(string employeeID, DateTime checkInDate)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User-KK33\\OneDrive\\Desktop\\testC#\\test\\test\\EmployeeManagementSystem\\EmployeeManagementSystem\\ManagementSystem.mdf;Integrated Security=True";
            string query = "INSERT INTO Attendance (EmployeeID, CheckInTime) VALUES (@EmployeeID, @CheckInTime)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@CheckInTime", checkInDate);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; // คืนค่า true ถ้าบันทึกสำเร็จ
                }
            }
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

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            // ตั้งค่า DateTimePicker เป็นวันที่ปัจจุบัน
            dtpCheckIn.Value = DateTime.Now;
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            DateTime checkInDate = dtpCheckIn.Value;

            try
            {
                // เรียกฟังก์ชันบันทึกการเข้างาน
                if (AddAttendanceRecord(employeeID, checkInDate))
                {
                    MessageBox.Show("บันทึกการเข้างานสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    // ปิดฟอร์มปัจจุบัน
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถบันทึกการเข้างานได้", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
