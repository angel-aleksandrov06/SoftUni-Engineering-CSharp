using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["motes"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["shards"] = 0;
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            while (true)
            {
                string[] materials = Console.ReadLine().ToLower()
                    .Split(" ");

                bool hasToBreak = false;

                for (int i = 0; i < materials.Length; i+=2)
                {
                    int quantity = int.Parse(materials[i]);
                    string type = materials[i+1];

                    if (type == "motes")
                    {
                        keyMaterials[type] += quantity;

                        if (keyMaterials[type] >= 250)
                        {
                            Console.WriteLine($"Dragonwrath obtained!");
                            keyMaterials[type] -= 250;
                            hasToBreak = true;
                            break;
                        }
                    }

                    else if (type == "fragments")
                    {
                        keyMaterials[type] += quantity;

                        if (keyMaterials[type] >= 250)
                        {
                            Console.WriteLine($"Valanyr obtained!");
                            keyMaterials[type] -= 250;
                            hasToBreak = true;
                            break;
                        }
                    }

                    else if (type == "shards")
                    {
                        keyMaterials[type] += quantity;

                        if (keyMaterials[type] >= 250)
                        {
                            Console.WriteLine($"Shadowmourne obtained!");
                            keyMaterials[type] -= 250;
                            hasToBreak = true;
                            break;
                        }
                    }

                    else
                    {
                        if (!junkMaterials.ContainsKey(type))
                        {
                            junkMaterials[type] = 0;
                        }

                        junkMaterials[type] += quantity;
                    }
                }

                if (hasToBreak)
                {
                    break;
                }
            }

            keyMaterials = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            junkMaterials = junkMaterials
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in keyMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
