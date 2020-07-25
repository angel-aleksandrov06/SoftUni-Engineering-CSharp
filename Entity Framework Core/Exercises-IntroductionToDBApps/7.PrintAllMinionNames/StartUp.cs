using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.PrintAllMinionNames
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-U1JHA1S;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            string result = getMinionNamesInMixedOrder(sqlConnection);

            Console.WriteLine(result);
        }

        private static string getMinionNamesInMixedOrder(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            string getAllMinionsNamesQueryText = @"SELECT Name FROM Minions";

            using SqlCommand getAllMinionsNamesCmd = new SqlCommand(getAllMinionsNamesQueryText, sqlConnection);

            using SqlDataReader reader = getAllMinionsNamesCmd.ExecuteReader();

            var minionNames = new List<string>();

            while (reader.Read())
            {
                string curName = reader["Name"]?.ToString();
                if (curName != null)
                {
                    minionNames.Add(curName);
                }
            }

            for (int i = 0; i < minionNames.Count / 2; i++)
            {
                sb.AppendLine(minionNames[i]);
                sb.AppendLine(minionNames[minionNames.Count - 1 - i]);
            }

            if (minionNames.Count % 2 != 0)
            {
                sb.AppendLine(minionNames[minionNames.Count / 2]);
            }

            return sb.ToString().Trim();
        }
    }
}
