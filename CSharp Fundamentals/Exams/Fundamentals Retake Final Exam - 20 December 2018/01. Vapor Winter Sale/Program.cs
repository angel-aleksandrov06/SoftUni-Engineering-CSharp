using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var dictGamePrice = new Dictionary<string, double>();
            var dictDLC = new Dictionary<string, string>();

            var dictGamePrice2 = new Dictionary<string, double>();

            var splitedInputGames = input.Split(", ");

            foreach (var game in splitedInputGames)
            {
                if (game.Contains('-'))
                {
                    var splitedGame = game.Split("-");
                    var nameGame = splitedGame[0];
                    double priceofGame = double.Parse(splitedGame[1].ToString());

                    if (!dictGamePrice.ContainsKey(nameGame))
                    {
                        dictGamePrice[nameGame] = priceofGame;
                    }
                }
                else if (game.Contains(':'))
                {
                    var splitedGame = game.Split(":");
                    var nameGame = splitedGame[0];
                    var nameDLC = splitedGame[1];

                    if (dictGamePrice.ContainsKey(nameGame))
                    {
                        if (!dictDLC.ContainsKey(nameGame))
                        {
                            dictDLC[nameGame] = nameDLC;

                            dictGamePrice[nameGame] *= 1.20;
                        }
                    }
                }
            }

            foreach (var game in dictGamePrice)
            {
                var onmind = 0.0;
                if (dictDLC.ContainsKey(game.Key))
                {
                    onmind = dictGamePrice[game.Key]*0.50;
                }
                else
                {
                    onmind = dictGamePrice[game.Key] * 0.80;
                }

                dictGamePrice2[game.Key] = onmind;
            }

            foreach (var item in dictGamePrice2.OrderBy(x=>x.Value))
            {
                if (dictDLC.ContainsKey(item.Key))
                {
                    Console.WriteLine($"{item.Key} - {dictDLC[item.Key]} - {item.Value:F2}");
                }
            }

            foreach (var item in dictGamePrice2.OrderByDescending(x => x.Value))
            {
                if (!dictDLC.ContainsKey(item.Key))
                {
                    Console.WriteLine($"{item.Key} - {item.Value:F2}");
                }
            }
        }
    }
}
