namespace _04Telephony
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();
            Smatphone smatphone = new Smatphone();
            smatphone.Call(numbers);
            smatphone.Browse(urls);
        }
    }
}