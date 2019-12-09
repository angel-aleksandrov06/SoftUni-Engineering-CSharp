namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;

    using Astronauts.Contracts;
    using Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            if (astronauts.Sum(x => x.Oxygen) <= 0)
            {
                return;
            }

            foreach (IAstronaut astronaut in astronauts)
            {
                while (astronaut.CanBreath)
                {
                    if (planet.Items.Count > 0)
                    {
                        string item = planet.Items.FirstOrDefault();
                        astronaut.Bag.AddItem(item);
                        planet.RemoveItem(item);
                        astronaut.Breath();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
