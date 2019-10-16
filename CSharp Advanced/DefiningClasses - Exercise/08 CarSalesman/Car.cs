using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        private const string DefaultValueString = "n/a";
        private const int DefaultValueInt = -1;

        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, DefaultValueString)
        {
        }

        public Car(string model, Engine engine, string color)
            : this( model, engine, DefaultValueInt, color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine, DefaultValueInt, DefaultValueString)
        {
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine(Engine.ToString());
            sb.AppendLine(this.weight == -1
                ? $"    Weight: n/a"
                : $"    Weight: {this.weight}"
                );
            sb.Append($"  Color: {this.color}");

            return sb.ToString();
        }
    }
}
