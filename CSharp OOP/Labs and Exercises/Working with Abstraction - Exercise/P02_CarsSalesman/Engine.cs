namespace P02_CarsSalesman
{
    using System.Text;

    public class Engine
    {
        private const string offset = "  ";
        private const string defaultEfficiencyValue = "n/a";

        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
            : this(model, power, -1, defaultEfficiencyValue)
        {
        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, defaultEfficiencyValue)
        {
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power, -1, efficiency)
        {
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Model { get; private set; }

        public override string ToString()
        {
            var resultDisplacement = this.displacement == -1 ? "n/a" : this.displacement.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{offset}{this.Model}:\n");
            sb.AppendFormat($"{offset}{offset}Power: {this.power}\n");
            sb.AppendFormat($"{offset}{offset}Displacement: {resultDisplacement}\n");
            sb.AppendFormat($"{offset}{offset}Efficiency: {this.efficiency}\n");

            return sb.ToString();
        }
    }
}
