namespace EmployeeManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim(); // ตัดช่องว่างหน้าและหลังออก
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้และรหัสผ่าน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // ออกจากฟังก์ชันหากข้อมูลไม่ครบ
            }

            try
            {
                if (AuthService.Login(username, password))
                {
                    MessageBox.Show("ล็อกอินสำเร็จ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string fetchedEmployeeID = AuthService.GetEmployeeID(username); // ดึง EmployeeID จาก username
                    string userRole = AuthService.GetUserRole(username); // ดึง Role จาก username

                    // ตรวจสอบ Role ของผู้ใช้
                    if (userRole.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        // หากเป็น admin ให้ไปหน้า MinForm
                        MinForm adminForm = new MinForm();
                        adminForm.Show();
                    }
                    else if (userRole.Equals("user", StringComparison.OrdinalIgnoreCase))
                    {
                        // หากเป็น user ให้ไปหน้า AttendanceForm
                        AttendanceForm attendanceForm = new AttendanceForm(fetchedEmployeeID);
                        attendanceForm.Show();
                    }

                    this.Hide(); // ซ่อนฟอร์มล็อกอิน
                }
                else
                {
                    MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // สลับการแสดงรหัสผ่าน
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0'; // แสดงรหัสผ่าน
            }
            else
            {
                txtPassword.PasswordChar = '*'; // ซ่อนรหัสผ่าน
            }
        }
    }
}
