using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;
        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count => heroes.Count;

        public void Add(Hero hero)
        {
            heroes.Add(hero);
        }

        public void Remove(string name)
        {
            if (heroes.Any(x => x.Name == name))
            {
                heroes.Remove(heroes.Find(x => x.Name == name));
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = heroes[0];

            foreach (var item in heroes)
            {
                if (item.Item.Strength > hero.Item.Strength)
                {
                    hero = item;
                }
            }
            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = heroes[0];

            foreach (var item in heroes)
            {
                if (item.Item.Ability > hero.Item.Ability)
                {
                    hero = item;
                }
            }
            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = heroes[0];

            foreach (var item in heroes)
            {
                if (item.Item.Intelligence > hero.Item.Intelligence)
                {
                    hero = item;
                }
            }
            return hero;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var hero in heroes)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
