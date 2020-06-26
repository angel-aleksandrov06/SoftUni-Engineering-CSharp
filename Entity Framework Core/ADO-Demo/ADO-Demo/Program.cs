using Microsoft.Data.SqlClient;
using System;

namespace ADO_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection("Server=.;Database=SoftUni;Integrated Security=true"))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT [FirstName], LastName FROM [EMPLOYEES] WHERE FirstName LIKE 'N%'", sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    Console.WriteLine(firstName + " " + lastName);
                }
            }
        }
    }
}
