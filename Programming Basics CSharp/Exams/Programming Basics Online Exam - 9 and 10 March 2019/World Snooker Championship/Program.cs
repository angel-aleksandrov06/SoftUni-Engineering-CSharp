using System;

namespace World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            string etap = Console.ReadLine();
            string Ticket = Console.ReadLine();
            int countTickets = int.Parse(Console.ReadLine());
            char photo = char.Parse(Console.ReadLine());
            double pricetickets = 0;

            switch (Ticket)
            {
                case "Standard":
                    switch (etap)
                    {
                        case "Quarter final":
                            pricetickets = 55.50;
                            break;
                        case "Semi final":
                            pricetickets = 75.88;
                            break;
                        case "Final":
                            pricetickets = 110.10;
                            break;
                        default:
                            break;
                    }

                    break;
                case "Premium":
                    switch (etap)
                    {
                        case "Quarter final":
                            pricetickets = 105.20;
                            break;
                        case "Semi final":
                            pricetickets = 125.22;
                            break;
                        case "Final":
                            pricetickets = 160.66;
                            break;
                        default:
                            break;
                    }

                    break;
                case "VIP":
                    switch (etap)
                    {
                        case "Quarter final":
                            pricetickets = 118.90;
                            break;
                        case "Semi final":
                            pricetickets = 300.40;
                            break;
                        case "Final":
                            pricetickets = 400;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            pricetickets = pricetickets * countTickets;
            double totalPrice = 0;

            if (pricetickets > 4000)
            {
                totalPrice = pricetickets - (0.25 * pricetickets);
            }
            else if (pricetickets > 2500 && pricetickets<=4000)
            {
                totalPrice = pricetickets - (0.10 * pricetickets);
            }
            else
            {
                totalPrice = pricetickets;
            }


            if (photo=='Y'  )
            {
                if (totalPrice > 4000)
                {
                    Console.WriteLine($"{totalPrice:F2}");
                }
                else
                {
                    totalPrice = totalPrice + (40 * countTickets);
                    Console.WriteLine($"{totalPrice:F2}");
                }
                
            }
            else if (photo == 'N')
            {
                Console.WriteLine($"{totalPrice:F2}");
            }
        }
    }
}
