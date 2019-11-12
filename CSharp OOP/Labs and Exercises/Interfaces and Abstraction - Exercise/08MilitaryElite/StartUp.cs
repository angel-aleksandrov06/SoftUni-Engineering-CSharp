﻿namespace _08MilitaryElite
{
    using System;

    using Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
