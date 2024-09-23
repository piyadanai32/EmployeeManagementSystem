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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
            LoadDepartmentData(); // โหลดข้อมูล Department
            LoadPositionData();   // โหลดข้อมูล Position
            LoadRoleData();       // โหลดข้อมูล Role
            LoadEmployeeData();   // โหลดข้อมูลพนักงานลงใน DataGridView

        }
        // ฟังก์ชันสำหรับดึงข้อมูล Department
        private void LoadDepartmentData()
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT DepartmentID, DepartmentName FROM Department";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbDepartmentID.DataSource = dt;
                        cmbDepartmentID.DisplayMember = "DepartmentName"; // ชื่อที่จะแสดงใน ComboBox
                        cmbDepartmentID.ValueMember = "DepartmentID"; // ค่า ID ที่จะถูกส่ง
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูล Department: " + ex.Message);
                    }
                }
            }
        }

        // ฟังก์ชันสำหรับดึงข้อมูล Position
        private void LoadPositionData()
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT PositionID, PositionName FROM Position";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbPositionID.DataSource = dt;
                        cmbPositionID.DisplayMember = "PositionName"; // ชื่อที่จะแสดงใน ComboBox
                        cmbPositionID.ValueMember = "PositionID"; // ค่า ID ที่จะถูกส่ง
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูล Position: " + ex.Message);
                    }
                }
            }
        }

        // ฟังก์ชันสำหรับดึงข้อมูล Role
        private void LoadRoleData()
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT RoleID, RoleName FROM Role";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbRoleID.DataSource = dt;
                        cmbRoleID.DisplayMember = "RoleName"; // ชื่อที่จะแสดงใน ComboBox
                        cmbRoleID.ValueMember = "RoleID"; // ค่า ID ที่จะถูกส่ง
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูล Role: " + ex.Message);
                    }
                }
            }
        }

        private void LoadEmployeeData()
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    // คำสั่ง SQL สำหรับดึงข้อมูลพนักงาน
                    string query = @"
            SELECT 
                Employee.EmployeeID, 
                Employee.Username, 
                Employee.Password,  -- รักษา Password ในการดึงข้อมูล
                Employee.EmployeeName, 
                Department.DepartmentID, 
                Department.DepartmentName, 
                Position.PositionID, 
                Position.PositionName, 
                Employee.Salary, 
                Role.RoleID, 
                Role.RoleName
            FROM 
                Employee
            JOIN Department ON Employee.DepartmentID = Department.DepartmentID
            JOIN Position ON Employee.PositionID = Position.PositionID
            JOIN Role ON Employee.RoleID = Role.RoleID";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt); // เติมข้อมูลใน DataTable

                        // ตั้งค่า DataSource ของ DataGridView เพื่อแสดงข้อมูล
                        dataGridView1.DataSource = dt;

                        // ปรับแต่ง DataGridView เช่น การตั้งค่า Column Header Text
                        dataGridView1.Columns["EmployeeID"].HeaderText = "Employee ID";
                        dataGridView1.Columns["Username"].HeaderText = "Username";
                        dataGridView1.Columns["EmployeeName"].HeaderText = "Employee Name";
                        dataGridView1.Columns["DepartmentName"].HeaderText = "Department";
                        dataGridView1.Columns["PositionName"].HeaderText = "Position";
                        dataGridView1.Columns["Salary"].HeaderText = "Salary";
                        dataGridView1.Columns["RoleName"].HeaderText = "Role";

                        // ซ่อนคอลัมน์ Password
                        if (dataGridView1.Columns["Password"] != null)
                        {
                            dataGridView1.Columns["Password"].Visible = false;
                        }

                        // ซ่อนคอลัมน์ที่ไม่ต้องการแสดงใน DataGridView
                        if (dataGridView1.Columns["DepartmentID"] != null)
                        {
                            dataGridView1.Columns["DepartmentID"].Visible = false;
                        }
                        if (dataGridView1.Columns["PositionID"] != null)
                        {
                            dataGridView1.Columns["PositionID"].Visible = false;
                        }
                        if (dataGridView1.Columns["RoleID"] != null)
                        {
                            dataGridView1.Columns["RoleID"].Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการดึงข้อมูลพนักงาน: " + ex.Message);
                }
            }
        }


        private void ClearFields()
        {
            txtEmployeeID.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmployeeName.Clear();
            cmbDepartmentID.SelectedIndex = -1; // รีเซ็ต ComboBox
            cmbPositionID.SelectedIndex = -1;   // รีเซ็ต ComboBox
            txtSalary.Clear();
            cmbRoleID.SelectedIndex = -1;       // รีเซ็ต ComboBox
            txtSearch.Clear();
        }

        private void btnMinForm_Click(object sender, EventArgs e)
        {
            MinForm minForm = new MinForm();
            minForm.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal salary;
            if (!decimal.TryParse(txtSalary.Text, out salary))
            {
                MessageBox.Show("กรุณากรอกจำนวนเงินที่ถูกต้องในช่องเงินเดือน");
                return;
            }
            bool success = EmployeeService.AddEmployee(
                txtEmployeeID.Text,
                txtUsername.Text,
                txtPassword.Text,
                txtEmployeeName.Text,
                cmbDepartmentID.SelectedValue.ToString(),
                cmbPositionID.SelectedValue.ToString(),
                decimal.Parse(txtSalary.Text),
                cmbRoleID.SelectedValue.ToString()
            );

            if (success)
            {
                MessageBox.Show("เพิ่มพนักงานสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); // เคลียร์ฟิลด์เมื่อเพิ่มข้อมูลสำเร็จ
                LoadEmployeeData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการแก้ไขข้อมูลพนักงานหรือไม่?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = EmployeeService.UpdateEmployee(
                    txtEmployeeID.Text,
                    !string.IsNullOrEmpty(txtUsername.Text) ? txtUsername.Text : null,
                    !string.IsNullOrEmpty(txtPassword.Text) ? txtPassword.Text : null, // ส่ง Password เฉพาะเมื่อกรอก
                    !string.IsNullOrEmpty(txtEmployeeName.Text) ? txtEmployeeName.Text : null,
                    cmbDepartmentID.SelectedValue?.ToString(),
                    cmbPositionID.SelectedValue?.ToString(),
                    decimal.TryParse(txtSalary.Text, out decimal salary) ? salary : (decimal?)null,
                    cmbRoleID.SelectedValue?.ToString()
                );

                if (success)
                {
                    MessageBox.Show("แก้ไขข้อมูลพนักงานสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); // เคลียร์ฟิลด์เมื่อแก้ไขข้อมูลสำเร็จ
                    LoadEmployeeData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการลบพนักงานหรือไม่?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool success = EmployeeService.DeleteEmployee(txtEmployeeID.Text);

                if (success)
                {
                    MessageBox.Show("ลบข้อมูลพนักงานสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields(); // เคลียร์ฟิลด์เมื่อเพิ่มข้อมูลสำเร็จ
                    LoadEmployeeData();
                }
            }
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPositionID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRoleID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                txtEmployeeName.Text = row.Cells["EmployeeName"].Value.ToString();

                // ตั้งค่า ComboBox เฉพาะเมื่อค่าใน ComboBox ตรงกับข้อมูลที่คลิก
                if (cmbDepartmentID.Items.Cast<DataRowView>().Any(item => item["DepartmentID"].ToString() == row.Cells["DepartmentID"].Value.ToString()))
                {
                    cmbDepartmentID.SelectedValue = row.Cells["DepartmentID"].Value.ToString();
                }

                if (cmbPositionID.Items.Cast<DataRowView>().Any(item => item["PositionID"].ToString() == row.Cells["PositionID"].Value.ToString()))
                {
                    cmbPositionID.SelectedValue = row.Cells["PositionID"].Value.ToString();
                }

                txtSalary.Text = row.Cells["Salary"].Value.ToString();

                if (cmbRoleID.Items.Cast<DataRowView>().Any(item => item["RoleID"].ToString() == row.Cells["RoleID"].Value.ToString()))
                {
                    cmbRoleID.SelectedValue = row.Cells["RoleID"].Value.ToString();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchValue))
            {
                using (SqlConnection connection = ManagementSystem.GetConnection())
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        // ค้นหา EmployeeID ที่มีคำที่ค้นหาในตาราง
                        string query = @"
                SELECT 
                    Employee.EmployeeID, 
                    Employee.Username, 
                    Employee.Password, 
                    Employee.EmployeeName, 
                    Employee.DepartmentID, 
                    Employee.PositionID, 
                    Employee.Salary, 
                    Employee.RoleID
                FROM 
                    Employee
                WHERE 
                    Employee.EmployeeID LIKE @EmployeeID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // ใช้พารามิเตอร์ LIKE เพื่อค้นหาคำที่เหมือนใน EmployeeID
                            command.Parameters.AddWithValue("@EmployeeID", "%" + searchValue + "%");

                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            // แสดงผลใน DataGridView
                            dataGridView1.DataSource = dataTable;

                            // ซ่อนคอลัมน์ Password
                            if (dataGridView1.Columns["Password"] != null)
                            {
                                dataGridView1.Columns["Password"].Visible = false;
                            }

                            // เช็คว่าพิมพ์ EmployeeID ครบแล้วหรือยัง
                            if (dataTable.Rows.Count == 1 && searchValue == dataTable.Rows[0]["EmployeeID"].ToString())
                            {
                                // ถ้าพบ EmployeeID ที่ตรงกับการค้นหาเพียงหนึ่งแถว
                                SqlDataReader reader = command.ExecuteReader();

                                if (reader.Read())
                                {
                                    txtEmployeeID.Text = reader["EmployeeID"].ToString();
                                    txtUsername.Text = reader["Username"].ToString();
                                    txtPassword.Text = reader["Password"].ToString(); // แสดง Password ใน TextBox
                                    txtEmployeeName.Text = reader["EmployeeName"].ToString();
                                    txtSalary.Text = reader["Salary"].ToString();

                                    // ตั้งค่า ComboBox สำหรับ Department, Position และ Role
                                    if (cmbDepartmentID.Items.Cast<DataRowView>().Any(item => item["DepartmentID"].ToString() == reader["DepartmentID"].ToString()))
                                    {
                                        cmbDepartmentID.SelectedValue = reader["DepartmentID"].ToString();
                                    }

                                    if (cmbPositionID.Items.Cast<DataRowView>().Any(item => item["PositionID"].ToString() == reader["PositionID"].ToString()))
                                    {
                                        cmbPositionID.SelectedValue = reader["PositionID"].ToString();
                                    }

                                    if (cmbRoleID.Items.Cast<DataRowView>().Any(item => item["RoleID"].ToString() == reader["RoleID"].ToString()))
                                    {
                                        cmbRoleID.SelectedValue = reader["RoleID"].ToString();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการค้นหาพนักงาน: " + ex.Message);
                    }
                }
            }
            else
            {
                // ถ้าไม่ได้พิมพ์อะไร ให้เคลียร์ฟิลด์และโหลดข้อมูลทั้งหมด
                ClearFields();
                LoadEmployeeData();
            }
        }
    }
}
