using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _2.VillainNames
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-U1JHA1S;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            string result = GetVillainNamesAndCountMinions(sqlConnection);

            Console.WriteLine(result);
        }

        private static string GetVillainNamesAndCountMinions(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            string GetvillainsAndMinionsCountQueryText = @"SELECT v.[Name], COUNT(mv.MinionId) AS [CountMinions]
		                                                        FROM Villains v
		                                                        JOIN MinionsVillains mv
		                                                        ON v.Id = mv.VillainId
		                                                        GROUP BY v.Id, v.[Name]
		                                                        HAVING COUNT(mv.MinionId) > 3
		                                                        ORDER BY CountMinions DESC";

            using SqlCommand getVillainNamesAndCoutnMinionsCmd = new SqlCommand(GetvillainsAndMinionsCountQueryText, sqlConnection);

            using SqlDataReader reader = getVillainNamesAndCoutnMinionsCmd.ExecuteReader();

            while (reader.Read())
            {
                string villainName = reader["Name"]?.ToString().Trim();
                string minionsCount = reader["CountMinions"]?.ToString().Trim();

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
