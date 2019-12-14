using MortalEngines.Entities.Contracts;
using System;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints - 40, defensePoints + 30, InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;

                this.AttackPoints -= 40;
                this.DefensePoints += 30;


            }
            else
            {
                this.DefenseMode = false;

                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string mode = string.Empty;
            if (this.DefenseMode == true)
            {
                mode = "ON";
            }
            else
            {
                mode = "OFF";
            }

            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defense: {mode}");
            return sb.ToString().TrimEnd();
        }
    }
}
