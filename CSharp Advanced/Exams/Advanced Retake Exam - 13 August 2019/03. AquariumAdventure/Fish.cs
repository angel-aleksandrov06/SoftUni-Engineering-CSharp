using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure
{
    public class Fish
    {
        private string name;
        private string color;
        private int fins;

        public Fish(string name, string color, int fins)
        {
            Name = name;
            Color = color;
            Fins = fins;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Fins
        {
            get { return fins; }
            set { fins = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Fish: {this.Name}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Number of fins: {this.Fins}");

            return sb.ToString().Trim();
        }
    }
}
