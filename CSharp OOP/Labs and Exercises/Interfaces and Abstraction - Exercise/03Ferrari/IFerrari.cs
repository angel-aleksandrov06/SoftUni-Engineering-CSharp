namespace _03Ferrari
{
    public interface IFerrari
    {
        public string Model { get; }

        public string Driver { get; set; }

        public string UseBrakes();

        public string PushTheGasPedal();
    }
}
