using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetWeaponPower()
        {
            var sum = Weapon.Sharpness + Weapon.Size + Weapon.Solidity;
            
            return sum;
        }

        public int GetStatPower()
        {
            var sum = Stat.Agility + Stat.Flexibility + Stat.Intelligence + Stat.Skills + Stat.Strength;

            return sum;
        }

        public int GetTotalPower()
        {
            var sum = GetStatPower() + GetWeaponPower();
            return sum;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {GetTotalPower()}");
            sb.AppendLine($"  Weapon Power: {GetWeaponPower()}");
            sb.AppendLine($"  Stat Power: {GetStatPower()}");

            return sb.ToString().Trim();
        }
    }
}
