﻿using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;

namespace IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-U1JHA1S;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            int minionId = int.Parse(Console.ReadLine());

            string result = IncreaseMinionAgeById(sqlConnection, minionId);

            Console.WriteLine(result);
        }

        private static string IncreaseMinionAgeById(SqlConnection sqlConnection, int minionId)
        {
            StringBuilder sb = new StringBuilder();

            string procName = "usp_GetOlder";

            using SqlCommand increaseAgeCmd = new SqlCommand(procName, sqlConnection);
            increaseAgeCmd.CommandType = CommandType.StoredProcedure;
            increaseAgeCmd.Parameters.AddWithValue("@minionId", minionId);

            increaseAgeCmd.ExecuteNonQuery();

            string getMinionInfoQueryText = @"SELECT [Name], Age FROM Minions
                                                 WHERE Id = @minionId";

            using SqlCommand getMinionInfoCmd = new SqlCommand(getMinionInfoQueryText, sqlConnection);

            getMinionInfoCmd.Parameters.AddWithValue("@minionId", minionId);

            using SqlDataReader reader = getMinionInfoCmd.ExecuteReader();

            reader.Read();

            string minionName = reader["Name"]?.ToString().Trim();
            string minionAge = reader["Age"]?.ToString().Trim();

            sb.AppendLine($"{minionName} - {minionAge} years old");

            return sb.ToString().TrimEnd();
        }
    }
}
