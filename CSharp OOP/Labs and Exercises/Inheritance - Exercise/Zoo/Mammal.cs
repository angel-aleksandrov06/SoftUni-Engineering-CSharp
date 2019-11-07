﻿namespace Zoo
{
    public class Mammal : Animal
    {
        public Mammal(string name) : base(name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
