using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            gladiators = new List<Gladiator>();
            this.Name = name;
        }

        public string Name { get; set; }


        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove( string name)
        {
            if (gladiators.Any(x=>x.Name == name))
            {
                gladiators.Remove(gladiators.Find(x => x.Name == name));
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator ui = gladiators[0];

            foreach (var item in gladiators)
            {
                if (item.GetStatPower() > ui.GetStatPower())
                {
                    ui = item;
                }
            }
            return ui;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator ui = gladiators[0];

            foreach (var item in gladiators)
            {
                if (item.GetWeaponPower() > ui.GetWeaponPower())
                {
                    ui = item;
                }
            }
            return ui;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator ui = gladiators[0];

            foreach (var item in gladiators)
            {
                if (item.GetTotalPower() > ui.GetTotalPower())
                {
                    ui = item;
                }
            }
            return ui;
        }

        public int Count
        {
            get
            {
                return gladiators.Count;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {Count} gladiators are participating.");

            return sb.ToString().Trim(); 
        }
    }
}
