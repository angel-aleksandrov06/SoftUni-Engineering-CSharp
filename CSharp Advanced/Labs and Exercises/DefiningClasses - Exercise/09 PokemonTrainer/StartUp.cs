using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();

            var command = Console.ReadLine();

            while (command != "Tournament")
            {
                var commandParts = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var trainerName = commandParts[0];
                var pokemonName = commandParts[1];
                var pokemonElement = commandParts[2];
                var pokemonHealth = int.Parse(commandParts[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                var trainer = trainers[trainerName];


                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainer.Pokemons.Add(pokemon);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var element = command;

                foreach (var currentTrainer in trainers)
                {
                    if (currentTrainer.Value.Pokemons.Any(p => p.Element == element))
                    {
                        currentTrainer.Value.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in currentTrainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        currentTrainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }

                command = Console.ReadLine();
            }

            var result = trainers
                .OrderByDescending(x => x.Value.Badges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value.Badges} {item.Value.Pokemons.Count}");
            }
        }
    }
}
