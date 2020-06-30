using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace _8.IncreaseMinionAge
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-U1JHA1S;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            var minionsIds = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();


            string result = updateMinionNamesAndAge(sqlConnection, minionsIds);

            Console.WriteLine(result);
        }

        private static string updateMinionNamesAndAge(SqlConnection sqlConnection, int[] minionsIds)
        {
            StringBuilder sb = new StringBuilder();

            string increaseQueryText = @" UPDATE Minions
                                   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                    WHERE Id = @Id";

            foreach (var Id in minionsIds)
            {
                using SqlCommand increaseCmd = new SqlCommand(increaseQueryText, sqlConnection);
                increaseCmd.Parameters.AddWithValue("@Id", Id);
                increaseCmd.ExecuteNonQuery();
            }

            string GetNewNameAndAgeQueryText = @"SELECT Name, Age FROM Minions";

            using SqlCommand GetNewNameAndAgeCmd = new SqlCommand(GetNewNameAndAgeQueryText, sqlConnection);
            using SqlDataReader reader = GetNewNameAndAgeCmd.ExecuteReader();

            while (reader.Read())
            {
                string minionName = reader["Name"]?.ToString();
                string minionAge = reader["Age"]?.ToString();
                sb.AppendLine($"{minionName} {minionAge}");
            }

            return sb.ToString().Trim();
        }
    }
}
