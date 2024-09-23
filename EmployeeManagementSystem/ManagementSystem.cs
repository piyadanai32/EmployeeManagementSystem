using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public class ManagementSystem
    {
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User-KK33\\OneDrive\\Desktop\\testC#\\test\\test\\EmployeeManagementSystem\\EmployeeManagementSystem\\ManagementSystem.mdf;Integrated Security=True";

        // ฟังก์ชันสำหรับสร้างการเชื่อมต่อ SQL
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString); // ไม่เปิดการเชื่อมต่อที่นี่
        }

        // ฟังก์ชันสำหรับปิดการเชื่อมต่อ
        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }

    public class AuthService
    {
        public static bool Login(string username, string password)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT COUNT(1) FROM Employee WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password); // ควร Hash password ก่อนใช้งานจริง

                    connection.Open(); // เปิดการเชื่อมต่อที่นี่
                    int result = (int)command.ExecuteScalar();
                    return result > 0; // ถ้าพบผู้ใช้ ให้ return true
                }
            }
        }

        public static string GetEmployeeID(string username)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT EmployeeID FROM Employee WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString(); // คืนค่า EmployeeID เป็น string
                    }
                    else
                    {
                        throw new Exception("ไม่พบผู้ใช้ที่ระบุ");
                    }
                }
            }
        }

        public static string GetUserRole(string username)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = @"
                SELECT r.RoleName
                FROM Employee e
                JOIN Role r ON e.RoleID = r.RoleID
                WHERE e.Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString(); // คืนค่า RoleName
                    }
                    else
                    {
                        throw new Exception("ไม่พบผู้ใช้ที่ระบุ");
                    }
                }
            }
        }
    }

    public class SalaryReportService
    {
        // ฟังก์ชันเพิ่มเงินเดือนพนักงาน
        public static bool AddSalaryReport(string employeeID, int month, int year, int totalDaysInMonth, int checkInDays, int missedDays, int regularHolidays, int effectiveMissedDays, decimal salary, decimal deduction, decimal netSalary)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = @"
        INSERT INTO SalaryReport (EmployeeID, Month, Year, TotalDaysInMonth, CheckInDays, MissedDays, RegularHolidays, EffectiveMissedDays, Salary, Deduction, NetSalary) 
        VALUES (@EmployeeID, @Month, @Year, @TotalDaysInMonth, @CheckInDays, @MissedDays, @RegularHolidays, @EffectiveMissedDays, @Salary, @Deduction, @NetSalary)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@TotalDaysInMonth", totalDaysInMonth);
                    command.Parameters.AddWithValue("@CheckInDays", checkInDays);
                    command.Parameters.AddWithValue("@MissedDays", missedDays);
                    command.Parameters.AddWithValue("@RegularHolidays", regularHolidays);
                    command.Parameters.AddWithValue("@EffectiveMissedDays", effectiveMissedDays);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Deduction", deduction);
                    command.Parameters.AddWithValue("@NetSalary", netSalary);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; // คืนค่า true หากมีการเพิ่มข้อมูลสำเร็จ
                }
            }
        }

        // ฟังก์ชันอัปเดตเงินเดือนพนักงาน
        public static bool UpdateSalaryReport(string employeeID, int month, int year, int totalDaysInMonth, int checkInDays, int missedDays, int regularHolidays, int effectiveMissedDays, decimal salary, decimal deduction, decimal netSalary)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = @"
        UPDATE SalaryReport 
        SET TotalDaysInMonth = @TotalDaysInMonth, CheckInDays = @CheckInDays, MissedDays = @MissedDays, RegularHolidays = @RegularHolidays, 
            EffectiveMissedDays = @EffectiveMissedDays, Salary = @Salary, Deduction = @Deduction, NetSalary = @NetSalary
        WHERE EmployeeID = @EmployeeID AND Month = @Month AND Year = @Year";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@TotalDaysInMonth", totalDaysInMonth);
                    command.Parameters.AddWithValue("@CheckInDays", checkInDays);
                    command.Parameters.AddWithValue("@MissedDays", missedDays);
                    command.Parameters.AddWithValue("@RegularHolidays", regularHolidays);
                    command.Parameters.AddWithValue("@EffectiveMissedDays", effectiveMissedDays);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Deduction", deduction);
                    command.Parameters.AddWithValue("@NetSalary", netSalary);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; // คืนค่า true หากการอัปเดตสำเร็จ
                }
            }
        }

        // ฟังก์ชันลบเงินเดือนพนักงาน
        public static bool DeleteSalaryReport(string employeeID, int month, int year)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = @"
        DELETE FROM SalaryReport 
        WHERE EmployeeID = @EmployeeID AND Month = @Month AND Year = @Year";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; // คืนค่า true หากการลบสำเร็จ
                }
            }
        }

    }
    public class EmployeeService
    {
        public static bool IsUsernameExists(string username)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Employee WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static bool IsPasswordExists(string password)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Employee WHERE Password = @Password"; // ควร Hash password ก่อนใช้งานจริง

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static bool IsPasswordCorrect(string username, string currentPassword)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Employee WHERE Username = @Username AND Password = @Password"; // ควร Hash password ก่อนใช้งานจริง

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", currentPassword);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static string GetCurrentUsername(string employeeID)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT Username FROM Employee WHERE EmployeeID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    connection.Open();
                    return command.ExecuteScalar()?.ToString();
                }
            }
        }

        public static bool AddEmployee(string employeeID, string username, string password, string employeeName, string departmentID, string positionID, decimal salary, string roleID)
        {
            if (IsUsernameExists(username))
            {
                MessageBox.Show("Username นี้มีอยู่แล้ว กรุณาใช้ Username อื่น");
                return false;
            }

            if (IsPasswordExists(password))
            {
                MessageBox.Show("Password นี้มีอยู่แล้ว กรุณาใช้ Password อื่น");
                return false;
            }

            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = @"
                INSERT INTO Employee (EmployeeID, Username, Password, EmployeeName, DepartmentID, PositionID, Salary, RoleID)
                VALUES (@EmployeeID, @Username, @Password, @EmployeeName, @DepartmentID, @PositionID, @Salary, @RoleID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password); // ควรใช้การ Hash ก่อน
                    command.Parameters.AddWithValue("@EmployeeName", employeeName);
                    command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    command.Parameters.AddWithValue("@PositionID", positionID);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@RoleID", roleID);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มพนักงาน: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static bool UpdateEmployee(string employeeID, string username, string newPassword, string employeeName, string departmentID, string positionID, decimal? salary, string roleID)
        {
            List<string> updates = new List<string>();
            if (!string.IsNullOrEmpty(username))
            {
                updates.Add("Username = @Username");
            }
            if (!string.IsNullOrEmpty(newPassword))
            {
                updates.Add("Password = @Password"); // ควร Hash ก่อน
            }
            if (!string.IsNullOrEmpty(employeeName))
            {
                updates.Add("EmployeeName = @EmployeeName");
            }
            if (!string.IsNullOrEmpty(departmentID))
            {
                updates.Add("DepartmentID = @DepartmentID");
            }
            if (!string.IsNullOrEmpty(positionID))
            {
                updates.Add("PositionID = @PositionID");
            }
            if (salary.HasValue)
            {
                updates.Add("Salary = @Salary");
            }
            if (!string.IsNullOrEmpty(roleID))
            {
                updates.Add("RoleID = @RoleID");
            }

            if (updates.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลที่จะอัปเดต");
                return false;
            }

            string query = $"UPDATE Employee SET {string.Join(", ", updates)} WHERE EmployeeID = @EmployeeID";

            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    if (!string.IsNullOrEmpty(username)) command.Parameters.AddWithValue("@Username", username);
                    if (!string.IsNullOrEmpty(newPassword)) command.Parameters.AddWithValue("@Password", newPassword); // ควร Hash ก่อน
                    if (!string.IsNullOrEmpty(employeeName)) command.Parameters.AddWithValue("@EmployeeName", employeeName);
                    if (!string.IsNullOrEmpty(departmentID)) command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    if (!string.IsNullOrEmpty(positionID)) command.Parameters.AddWithValue("@PositionID", positionID);
                    if (salary.HasValue) command.Parameters.AddWithValue("@Salary", salary.Value);
                    if (!string.IsNullOrEmpty(roleID)) command.Parameters.AddWithValue("@RoleID", roleID);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0; // คืนค่า true ถ้าทำสำเร็จ
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการแก้ไขพนักงาน: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static bool DeleteEmployee(string employeeID)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการลบพนักงาน: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
    public class PositionService
    {
        // ฟังก์ชันตรวจสอบ PositionID หรือ PositionName ซ้ำ
        public static bool IsPositionExists(string positionID, string positionName)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Position WHERE PositionID = @PositionID OR PositionName = @PositionName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PositionID", positionID);
                    command.Parameters.AddWithValue("@PositionName", positionName);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0; // คืนค่า true ถ้ามี Position ที่ซ้ำ
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการเช็คตำแหน่ง: " + ex.Message);
                        return true; // เกิดข้อผิดพลาด ควรคืนค่า true เพื่อไม่ให้ทำงานต่อ
                    }
                }
            }
        }

        // ฟังก์ชันเพิ่มตำแหน่ง
        public static bool AddPosition(string positionID, string positionName)
        {
            if (IsPositionExists(positionID, positionName))
            {
                MessageBox.Show("Position ID หรือชื่อซ้ำ กรุณาใช้ข้อมูลอื่น");
                return false;
            }

            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "INSERT INTO Position (PositionID, PositionName) VALUES (@PositionID, @PositionName)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PositionID", positionID);
                    command.Parameters.AddWithValue("@PositionName", positionName);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มตำแหน่ง: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        // ฟังก์ชันแก้ไขตำแหน่ง
        public static bool UpdatePosition(string positionID, string newPositionName)
        {

            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "UPDATE Position SET PositionName = @PositionName WHERE PositionID = @PositionID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PositionID", positionID);
                    command.Parameters.AddWithValue("@PositionName", newPositionName);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0; // คืนค่า true ถ้าแก้ไขสำเร็จ
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการแก้ไขตำแหน่ง: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        // ฟังก์ชันลบตำแหน่ง
        public static bool DeletePosition(string positionID)
        {
            using (SqlConnection connection = ManagementSystem.GetConnection())
            {
                string query = "DELETE FROM Position WHERE PositionID = @PositionID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PositionID", positionID);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0; // คืนค่า true ถ้าลบสำเร็จ
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("เกิดข้อผิดพลาดในการลบตำแหน่ง: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
