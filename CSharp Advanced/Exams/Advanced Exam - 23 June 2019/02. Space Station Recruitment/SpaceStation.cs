using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private ICollection<Astronaut> astronauts;

        public SpaceStation(string name, int capacity)
        {
            this.astronauts = new List<Astronaut>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.astronauts.Count;
        

        public void Add(Astronaut astronaut)
        {
            if (this.astronauts.Count < this.Capacity)
            {
                this.astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.Name == name)
                {
                    this.astronauts.Remove(astronaut);
                    return true;
                }
            }
            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut result = this.astronauts.OrderByDescending(x => x.Age).FirstOrDefault();

            return result;
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.astronauts.FirstOrDefault(a => a.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in astronauts)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
