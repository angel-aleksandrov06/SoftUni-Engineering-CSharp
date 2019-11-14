namespace _03Ferrari
{
    public class Ferrari : IFerrari
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Model { get; } = "488-Spider";

        public string Driver { get; set; }

        public string PushTheGasPedal()
        {
            return "Gas!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }
    }
}
