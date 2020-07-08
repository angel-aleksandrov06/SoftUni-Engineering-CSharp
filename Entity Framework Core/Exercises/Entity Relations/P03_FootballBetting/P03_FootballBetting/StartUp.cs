namespace P03_FootballBetting
{

    using P03_FootballBetting.Data;
    using P03_FootballBetting.Data.Models;
    using System;
    using System.Linq;

    public class StrtUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();

            var users = context.Users
                .Select(u => new
                {
                    u.Username,
                    u.Email,
                    Name = u.Name == null ? "(No name)" : u.Name,
                    u.Balance
                });

            foreach (var u in users)
            {
                Console.WriteLine($"{u.Username} -> {u.Email} {u.Name} {u.Balance:f2}$");
            }
        }
    }
}
