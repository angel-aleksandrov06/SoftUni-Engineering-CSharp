namespace _01Logger
{
    using Core;

    class Program
    {
        static void Main(string[] args)
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
