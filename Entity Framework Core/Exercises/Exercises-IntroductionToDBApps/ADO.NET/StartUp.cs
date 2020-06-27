using System;
using System.Text;

using Microsoft.Data.SqlClient;

namespace ADO.NET
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-U1JHA1S;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            int villainId = int.Parse(Console.ReadLine());

            string result = GetMinionsInfoAboutVillain(sqlConnection, villainId);

            Console.WriteLine(result);
        }

        private static string GetMinionsInfoAboutVillain(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            string villainName = GetVillainName(sqlConnection, villainId);

            if (villainName == null)
            {
                sb.AppendLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                sb.AppendLine($"Villain: {villainName}");
                string getMinionsInfoQueryText = @"SELECT m.[Name], m.Age 
	                                                FROM  Villains v
	                                                LEFT JOIN MinionsVillains mv
	                                                ON v.Id = mv.VillainId
	                                                LEFT JOIN Minions m
	                                                ON m.Id = mv.MinionId
	                                                WHERE v.[Name] = @villionName
	                                                ORDER BY m.[Name]";

                using SqlCommand getMinionsInfoCommand = new SqlCommand(getMinionsInfoQueryText, sqlConnection);
                getMinionsInfoCommand.Parameters
                    .AddWithValue("@villionName", villainName);

                using SqlDataReader reader = getMinionsInfoCommand.ExecuteReader();

               
                int rowNum = 1;
                while (reader.Read())
                {
                    string minionName = reader["Name"]?.ToString();
                    string minionAge = reader["Age"]?.ToString();

                    if(minionName == "" && minionAge == "")
                    {
                        sb.AppendLine("(no minions)");
                        break;
                    }

                    sb.AppendLine($"{rowNum}. {minionName} {minionAge}");
                    rowNum++;
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetVillainName(SqlConnection sqlConnection, int villainId)
        {
            string getVillainNameQueryText = @"SELECT [Name] FROM Villains 
                                                WHERE Id = @villianId";
            using SqlCommand getVillainNameCmd = new SqlCommand(getVillainNameQueryText, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@villianId", villainId);

            string villainName = getVillainNameCmd
                   .ExecuteScalar()?
                   .ToString();

            return villainName;
        }
    }
}
