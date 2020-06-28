using System;
using System.Linq;
using System.Text;

using Microsoft.Data.SqlClient;

namespace AddMinion
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=DESKTOP-U1JHA1S;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            string[] minionsInput = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] minionsInfo = minionsInput[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] villainInput = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] villainInfo = villainInput[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string result = AddMinionToDatabase(sqlConnection, minionsInfo, villainInfo);

            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minionsInfo, string[] villainInfo)
        {
            StringBuilder output = new StringBuilder();

            string minionName = minionsInfo[0];
            string minionAge = minionsInfo[1];
            string minionTown = minionsInfo[2];

            string villainName = villainInfo[0];
            string townId = EnsureTownExists(sqlConnection, minionTown, output);

            string villainId = EnsureVillainExists(sqlConnection, villainName, output);

            string insertMinionQueryText = @"INSERT INTO Minions([Name], Age, TownId)
                                            VALUES (@minionName, @minionAge, @townId)";

            using SqlCommand insertMinionCommand = new SqlCommand(insertMinionQueryText, sqlConnection);
            insertMinionCommand.Parameters.AddRange(new[]
            {
                new SqlParameter("@minionName", minionName),
                new SqlParameter("@minionAge", minionAge),
                new SqlParameter("@townId", townId),
            });

            insertMinionCommand.ExecuteNonQuery();

            string getMinionIdQueryText = @"SELECT Id FROM Minions
                                            WHERE [Name] = @minionName";

            using SqlCommand getMinionIdCommand = new SqlCommand(getMinionIdQueryText, sqlConnection);
            getMinionIdCommand.Parameters.AddWithValue("@minionName", minionName);

            string minionId = getMinionIdCommand.ExecuteScalar().ToString();

            string insertIntoMappingQueryText = @"INSERT INTO MinionsVillains(MinionId, VillainId)
                                                VALUES (@minionId, @villainId)";
            using SqlCommand insertIntoMappingCommand = new SqlCommand(insertIntoMappingQueryText, sqlConnection);
            insertIntoMappingCommand.Parameters.AddRange(new[]
            {
               new SqlParameter("@minionId", minionId),
               new SqlParameter("@villainId", villainId)
            });

            insertIntoMappingCommand.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

            return output.ToString().TrimEnd();
        }

        private static string EnsureVillainExists(SqlConnection sqlConnection, string villainName, StringBuilder output)
        {
            string getVillainIdQueryText = @"SELECT Id FROM Villains
                                                    WHERE [Name] = @villainName";

            using SqlCommand getVillainCommand = new SqlCommand(getVillainIdQueryText, sqlConnection);
            getVillainCommand.Parameters.AddWithValue("@villainName", villainName);

            string villainId = getVillainCommand.ExecuteScalar()?.ToString();

            if(villainId == null)
            {
                string getFactorIdQueryText = @"SELECT Id FROM EvilnessFactors 
                                                    WHERE [Name] = 'Evil'";

                using SqlCommand getFactorIdCommand = new SqlCommand(getFactorIdQueryText, sqlConnection);

                string factorId = getFactorIdCommand.ExecuteScalar()?.ToString();

                string insertVillainQueryText = @"INSERT INTO Villains ([Name], EvilnessFactorId)
                                                    Values(@villainName, @factorId)";

                using SqlCommand insertVillainCommand = new SqlCommand(insertVillainQueryText, sqlConnection);
                insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                insertVillainCommand.Parameters.AddWithValue("@factorId", factorId);

                insertVillainCommand.ExecuteNonQuery();

                villainId = getVillainCommand.ExecuteScalar().ToString();

                output.AppendLine($"Villain {villainName} was added to the database.");
            }
            return villainId;
        }

        private static string EnsureTownExists(SqlConnection sqlConnection, string minionTown, StringBuilder output)
        {
            string getTownQueryText = @"SELECT Id FROM Towns
                                                WHERE [Name] = @townName";

            using SqlCommand getTownIdCommand = new SqlCommand(getTownQueryText, sqlConnection);

            getTownIdCommand.Parameters.AddWithValue("@townName", minionTown);

            string townId = getTownIdCommand.ExecuteScalar()?.ToString();

            if(townId == null)
            {
                string insertTownQueryText = @"INSERT INTO Towns ([Name], CountryCode)
                                                    VALUES (@townName, 1)";
                using SqlCommand insertTownCommand = new SqlCommand(insertTownQueryText, sqlConnection);
                insertTownCommand.Parameters.AddWithValue("@townName", minionTown);

                insertTownCommand.ExecuteNonQuery();

                // Gets the id of the new inserted town
                townId = getTownIdCommand.ExecuteScalar().ToString();

                output.AppendLine($"Town {minionTown} was added to the database");
            }

            return townId;
        }
    }
}
