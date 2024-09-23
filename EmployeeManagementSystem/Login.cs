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
            string username = txtUsername.Text.Trim(); // �Ѵ��ͧ��ҧ˹�������ѧ�͡
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("��سҡ�͡���ͼ����������ʼ�ҹ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // �͡�ҡ�ѧ��ѹ�ҡ���������ú
            }

            try
            {
                if (AuthService.Login(username, password))
                {
                    MessageBox.Show("��͡�Թ�����", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string fetchedEmployeeID = AuthService.GetEmployeeID(username); // �֧ EmployeeID �ҡ username
                    string userRole = AuthService.GetUserRole(username); // �֧ Role �ҡ username

                    // ��Ǩ�ͺ Role �ͧ�����
                    if (userRole.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        // �ҡ�� admin ����˹�� MinForm
                        MinForm adminForm = new MinForm();
                        adminForm.Show();
                    }
                    else if (userRole.Equals("user", StringComparison.OrdinalIgnoreCase))
                    {
                        // �ҡ�� user ����˹�� AttendanceForm
                        AttendanceForm attendanceForm = new AttendanceForm(fetchedEmployeeID);
                        attendanceForm.Show();
                    }

                    this.Hide(); // ��͹�������͡�Թ
                }
                else
                {
                    MessageBox.Show("���ͼ�����������ʼ�ҹ���١��ͧ", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("�Դ��ͼԴ��Ҵ: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // ��Ѻ����ʴ����ʼ�ҹ
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0'; // �ʴ����ʼ�ҹ
            }
            else
            {
                txtPassword.PasswordChar = '*'; // ��͹���ʼ�ҹ
            }
        }
    }
}
