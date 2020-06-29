using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5._ChangeTownNamesCasing
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-U1JHA1S;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            string givenCountry = Console.ReadLine();

            string result = ChangeTownNames(sqlConnection, givenCountry);

            Console.WriteLine(result);
        }

        private static string ChangeTownNames(SqlConnection sqlConnection, string givenCountry)
        {
            StringBuilder sb = new StringBuilder();

            string updateNamesQueryText = @"UPDATE Towns
                                   SET Name = UPPER(Name)
                                   WHERE CountryCode = (SELECT c.Id FROM Countries c WHERE c.Name = @countryName)";

            using SqlCommand updateNamesCmd = new SqlCommand(updateNamesQueryText, sqlConnection);
            updateNamesCmd.Parameters.AddWithValue("@countryName", givenCountry);

            int changesRows = updateNamesCmd.ExecuteNonQuery();

            if (changesRows == 0)
            {
                sb.AppendLine("No town names were affected.");

                return sb.ToString().Trim();
            }

            sb.AppendLine($"{changesRows} town names were affected.");

            string getChangeTownNamesQueryText = @"SELECT t.Name 
                                                    FROM Towns t
                                                    JOIN Countries c ON c.Id = t.CountryCode
                                                    WHERE c.Name = @countryName";

            using SqlCommand getChangeTownNamesCmd = new SqlCommand(getChangeTownNamesQueryText, sqlConnection);

            getChangeTownNamesCmd.Parameters.AddWithValue("@countryName", givenCountry);

            using SqlDataReader reader = getChangeTownNamesCmd.ExecuteReader();

            sb.Append("[");

            var towns = new List<string>();

            while (reader.Read())
            {
                string townName = reader["Name"]?.ToString().Trim();
                towns.Add(townName);
            }

            sb.AppendJoin(", ", towns);
            sb.Append("]");

            return sb.ToString().Trim();
        }
    }
}
