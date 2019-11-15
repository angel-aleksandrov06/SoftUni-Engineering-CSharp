namespace _06BirthdayCelebrations
{
    public interface IPerson : ICitizen
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
