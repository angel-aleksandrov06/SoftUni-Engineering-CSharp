namespace _01Logger.Core
{
    using System;

    public class Engine
    {
        private readonly CommandInterpreter commandInterpreter;

        public Engine(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;   
        }
        public void Run()
        {

            var input = Console.ReadLine();

            while (true)
            {
                string[] inputInfo = input.Split("|",StringSplitOptions.RemoveEmptyEntries);

                if (input == "END")
                {
                    commandInterpreter.Read(inputInfo);
                    break;
                }

                commandInterpreter.Read(inputInfo);
                input = Console.ReadLine();
            }
        }
    }
}
