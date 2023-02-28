using Microsoft.Data.SqlClient;

SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS01; " +
                                        "Database=SoftUni; " +
                                        "Integrated Security=true; " +
                                        "Trust Server Certificate=true; ");

dbCon.Open();
using (dbCon)
{
    // TODO: Use the connection to execute SQL commands here…
    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Employees", dbCon);
    int employeesCount = (int)cmd.ExecuteScalar();
    Console.WriteLine($"Employees count: {employeesCount}");
}

