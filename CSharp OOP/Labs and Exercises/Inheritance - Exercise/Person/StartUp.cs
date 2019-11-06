namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Person person = new Person("Gosho", -10);

                System.Console.WriteLine(person.Name);
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}