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
using System.Drawing.Printing;

namespace EmployeeManagementSystem
{
    public partial class SalaryReportForm : Form
    {
        public SalaryReportForm()
        {
            InitializeComponent();
            LoadEmployeeIDs(); // โหลดข้อมูล EmployeeID เมื่อฟอร์มถูกสร้างขึ้น
        }
        private PrintDocument printDocument = new PrintDocument();
        private string printContent = "";
        // โหลด EmployeeID ทั้งหมดลงใน ComboBox
        private void LoadEmployeeIDs()
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT EmployeeID FROM Employee";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbEmployeeID.Items.Add(reader["EmployeeID"].ToString());
                        }
                    }
                }
            }
        }
        // ฟังก์ชันดึงเงินเดือนของพนักงานจากฐานข้อมูล
        private decimal GetEmployeeSalary(string employeeID)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT Salary FROM Employee WHERE EmployeeID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    connection.Open();

                    object result = command.ExecuteScalar(); // ดึงค่า Salary จากฐานข้อมูล
                    if (result != null)
                    {
                        return Convert.ToDecimal(result); // คืนค่าเงินเดือนเป็น decimal
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูลพนักงานที่เลือก");
                        return 0;
                    }
                }
            }
        }
        // ฟังก์ชันดึงจำนวนวันที่เช็คอินและไม่ได้เช็คอิน
        private void LoadAttendanceData(string employeeID, int month, int year)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                // ดึงจำนวนวันที่เช็คอิน
                string queryCheckIn = @"
                SELECT COUNT(*) 
                FROM Attendance 
                WHERE EmployeeID = @EmployeeID AND MONTH(CheckInTime) = @Month AND YEAR(CheckInTime) = @Year";

                using (SqlCommand command = new SqlCommand(queryCheckIn, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);
                    connection.Open();
                    int checkInDays = (int)command.ExecuteScalar();
                    txtCheckInDays.Text = checkInDays.ToString();
                }

                // ดึงจำนวนวันที่ไม่ได้เช็คอิน (สามารถใช้ DateTime.DaysInMonth เพื่อหาจำนวนวันในเดือน)
                int totalDaysInMonth = DateTime.DaysInMonth(year, month);
                int missedDays = totalDaysInMonth - Convert.ToInt32(txtCheckInDays.Text);
                txtMissedDays.Text = missedDays.ToString();
            }
        }
        private void ClearFormFields()
        {
            txtSearch.Clear();

            txtTotalDaysInMonth.Clear();
            txtCheckInDays.Clear();
            txtMissedDays.Clear();
            txtRegularHolidays.Clear();
            txtEffectiveMissedDays.Clear();
            txtSalary.Clear();
            txtDeduction.Clear();
            txtNetSalary.Clear();
            txtSearch.Clear();
        }
        private void RefreshDataGrid()
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT EmployeeID, Salary, Month, Year, TotalDaysInMonth, CheckInDays, MissedDays, RegularHolidays, EffectiveMissedDays, Deduction, NetSalary FROM SalaryReport";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable; // ผูกข้อมูลใหม่กับ DataGridView
            }
        }
        private void LoadSalaryReports()
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT EmployeeID, Salary, Month, Year, TotalDaysInMonth, CheckInDays, MissedDays, RegularHolidays, EffectiveMissedDays, Deduction, NetSalary FROM SalaryReport";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable; // ผูกข้อมูลกับ DataGridView
            }
        }

        private void btnMinForm_Click(object sender, EventArgs e)
        {
            MinForm minForm = new MinForm();
            minForm.Show();
            this.Hide();
        }

        private void dtpReportDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ดึง EmployeeID จาก ComboBox
            string selectedEmployeeID = cmbEmployeeID.SelectedItem.ToString();

            // เรียกใช้ฟังก์ชันเพื่อดึงข้อมูลเงินเดือน (Salary) ของพนักงานที่ถูกเลือก
            decimal salary = GetEmployeeSalary(selectedEmployeeID);

            // แสดงเงินเดือนใน txtSalary
            txtSalary.Text = salary.ToString("F2");

            // เรียกใช้ฟังก์ชันเพื่อโหลดข้อมูลการเช็คอินและไม่ได้เช็คอิน
            DateTime selectedDate = dtpMonthYear.Value;
            int month = selectedDate.Month;
            int year = selectedDate.Year;
            LoadAttendanceData(selectedEmployeeID, month, year);
        }

        private void dtpMonthYear_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpMonthYear.Value;
            int month = selectedDate.Month;
            int year = selectedDate.Year;

            int totalDays = DateTime.DaysInMonth(year, month);
            txtTotalDaysInMonth.Text = totalDays.ToString();
        }

        private void txtTotalDaysInMonth_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCheckInDays_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMissedDays_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRegularHolidays_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEffectiveMissedDays_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDeduction_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNetSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnbtnCalculateSalary_Click(object sender, EventArgs e)
        {
            try
            {
                decimal salary = Convert.ToDecimal(txtSalary.Text);
                int missedDays = Convert.ToInt32(txtMissedDays.Text);
                int regularHolidays = Convert.ToInt32(txtRegularHolidays.Text);

                // คำนวณจำนวนวันที่ขาดงานหลังหักวันหยุดปกติ
                int effectiveMissedDays = missedDays - regularHolidays;
                if (effectiveMissedDays < 0) effectiveMissedDays = 0;

                // แสดงใน txtEffectiveMissedDays
                txtEffectiveMissedDays.Text = effectiveMissedDays.ToString();

                // คำนวณการหักเงิน
                decimal deduction = effectiveMissedDays * 300;
                txtDeduction.Text = deduction.ToString("F2");

                // คำนวณเงินเดือนสุทธิ
                decimal netSalary = salary - deduction;
                txtNetSalary.Text = netSalary.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการคำนวณ: " + ex.Message);
            }
        }

        private void SalaryReportForm_Load(object sender, EventArgs e)
        {
            // ตั้งค่า DateTimePicker ให้แสดงเฉพาะเดือนและปี
            dtpMonthYear.CustomFormat = "MMMM yyyy"; // แสดงเดือนและปี
            dtpMonthYear.Format = DateTimePickerFormat.Custom; // ใช้รูปแบบที่กำหนดเอง
            dtpMonthYear.Value = DateTime.Now; // ตั้งค่าเริ่มต้นเป็นเดือนและปีปัจจุบัน
            // โหลดข้อมูล SalaryReport เข้า DataGridView
            LoadSalaryReports();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeID = cmbEmployeeID.SelectedItem.ToString();
                DateTime selectedDate = dtpMonthYear.Value;
                int month = selectedDate.Month;
                int year = selectedDate.Year;
                int totalDaysInMonth = Convert.ToInt32(txtTotalDaysInMonth.Text);
                int checkInDays = Convert.ToInt32(txtCheckInDays.Text);
                int missedDays = Convert.ToInt32(txtMissedDays.Text);
                int regularHolidays = Convert.ToInt32(txtRegularHolidays.Text);
                int effectiveMissedDays = Convert.ToInt32(txtEffectiveMissedDays.Text);
                decimal salary = Convert.ToDecimal(txtSalary.Text);
                decimal deduction = Convert.ToDecimal(txtDeduction.Text);
                decimal netSalary = Convert.ToDecimal(txtNetSalary.Text);

                bool success = SalaryReportService.AddSalaryReport(employeeID, month, year, totalDaysInMonth, checkInDays, missedDays, regularHolidays, effectiveMissedDays, salary, deduction, netSalary);
                if (success)
                {
                    MessageBox.Show("เพิ่มรายงานเงินเดือนสำเร็จ");
                    ClearFormFields(); // เคลียร์ข้อมูลหลังจากลบ
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มรายงานเงินเดือน");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeID = cmbEmployeeID.SelectedItem.ToString();
                DateTime selectedDate = dtpMonthYear.Value;
                int month = selectedDate.Month;
                int year = selectedDate.Year;

                int totalDaysInMonth = Convert.ToInt32(txtTotalDaysInMonth.Text);
                int checkInDays = Convert.ToInt32(txtCheckInDays.Text);
                int missedDays = Convert.ToInt32(txtMissedDays.Text);
                int regularHolidays = Convert.ToInt32(txtRegularHolidays.Text);
                int effectiveMissedDays = Convert.ToInt32(txtEffectiveMissedDays.Text);
                decimal salary = Convert.ToDecimal(txtSalary.Text);
                decimal deduction = Convert.ToDecimal(txtDeduction.Text);
                decimal netSalary = Convert.ToDecimal(txtNetSalary.Text);

                bool success = SalaryReportService.UpdateSalaryReport(employeeID, month, year, totalDaysInMonth, checkInDays, missedDays, regularHolidays, effectiveMissedDays, salary, deduction, netSalary);
                if (success)
                {
                    MessageBox.Show("แก้ไขรายงานเงินเดือนสำเร็จ");
                    ClearFormFields(); // เคลียร์ข้อมูลหลังจากลบ
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการแก้ไขรายงานเงินเดือน");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeID = cmbEmployeeID.SelectedItem.ToString();
                DateTime selectedDate = dtpMonthYear.Value;
                int month = selectedDate.Month;
                int year = selectedDate.Year;

                bool success = SalaryReportService.DeleteSalaryReport(employeeID, month, year);
                if (success)
                {
                    MessageBox.Show("ลบรายงานเงินเดือนสำเร็จ");
                    ClearFormFields(); // เคลียร์ข้อมูลหลังจากลบ
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบรายงานเงินเดือน");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ตรวจสอบว่าคลิกที่ row ใด
            if (e.RowIndex >= 0)
            {
                // เลือกแถวที่คลิก
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // นำข้อมูลจาก DataGridView มาแสดงใน TextBox ต่างๆ
                cmbEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                txtSalary.Text = row.Cells["Salary"].Value.ToString();
                dtpMonthYear.Value = new DateTime(
                    Convert.ToInt32(row.Cells["Year"].Value),
                    Convert.ToInt32(row.Cells["Month"].Value),
                    1 // ตั้งค่าเป็นวันที่ 1 ในเดือนที่เลือก
                );
                txtTotalDaysInMonth.Text = row.Cells["TotalDaysInMonth"].Value.ToString();
                txtCheckInDays.Text = row.Cells["CheckInDays"].Value.ToString();
                txtMissedDays.Text = row.Cells["MissedDays"].Value.ToString();
                txtRegularHolidays.Text = row.Cells["RegularHolidays"].Value.ToString();
                txtEffectiveMissedDays.Text = row.Cells["EffectiveMissedDays"].Value.ToString();
                txtDeduction.Text = row.Cells["Deduction"].Value.ToString();
                txtNetSalary.Text = row.Cells["NetSalary"].Value.ToString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // รวบรวมข้อมูลที่ต้องการพิมพ์
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("Employee Salary Report");
            reportBuilder.AppendLine("----------------------------");
            reportBuilder.AppendLine($"Employee ID: {cmbEmployeeID.Text}");
            reportBuilder.AppendLine($"Month/Year: {dtpMonthYear.Value.ToString("MMMM yyyy")}");
            reportBuilder.AppendLine($"Salary: {txtSalary.Text}");
            reportBuilder.AppendLine($"Total Days in Month: {txtTotalDaysInMonth.Text}");
            reportBuilder.AppendLine($"Check-In Days: {txtCheckInDays.Text}");
            reportBuilder.AppendLine($"Missed Days: {txtMissedDays.Text}");
            reportBuilder.AppendLine($"Regular Holidays: {txtRegularHolidays.Text}");
            reportBuilder.AppendLine($"Effective Missed Days: {txtEffectiveMissedDays.Text}");
            reportBuilder.AppendLine($"Deduction: {txtDeduction.Text}");
            reportBuilder.AppendLine($"Net Salary: {txtNetSalary.Text}");
            printContent = reportBuilder.ToString();

            // เปิด PrintDialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print(); // พิมพ์เอกสาร
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // ตั้งค่าฟอนต์และจัดตำแหน่ง
            Font font = new Font("Arial", 12);
            float lineHeight = font.GetHeight();
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            e.Graphics.DrawString(printContent, font, Brushes.Black, x, y);
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
                        connection.Open();

                        // ค้นหาข้อมูลตามเงื่อนไขที่ระบุ
                        string query = @"
                        SELECT EmployeeID, Salary, Month, Year, TotalDaysInMonth, CheckInDays, MissedDays, RegularHolidays, EffectiveMissedDays, Deduction, NetSalary
                        FROM SalaryReport
                        WHERE EmployeeID LIKE @EmployeeID OR Month = @Month OR Year = @Year";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", "%" + searchValue + "%");

                            int month;
                            int year;

                            // ตรวจสอบการแปลงค่า
                            if (int.TryParse(searchValue, out month))
                            {
                                command.Parameters.AddWithValue("@Month", month);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@Month", DBNull.Value);
                            }

                            if (int.TryParse(searchValue, out year))
                            {
                                command.Parameters.AddWithValue("@Year", year);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@Year", DBNull.Value);
                            }

                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            // แสดงผลใน DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการค้นหา: " + ex.Message);
                    }
                }
            }
            else
            {
                
                LoadSalaryReports(); // โหลดข้อมูลทั้งหมดหากไม่มีคำค้นหา
            }
        }
    }
}
