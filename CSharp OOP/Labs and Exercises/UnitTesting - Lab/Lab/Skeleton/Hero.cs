public class Hero
{
    private string name;
    private int experience;
    private Axe weapon;

    public Hero(string name, Axe axe)
    {
        this.name = name;
        this.experience = 0;
        this.weapon = axe;
    }

    public string Name
    {
        get { return this.name; }
    }

    public int Experience
    {
        get { return this.experience; }
    }

    public Axe Weapon
    {
        get { return this.weapon; }
    }

    public void Attack(Dummy target)
    {
        this.weapon.Attack(target);

        if (target.IsDead())
        {
            this.experience += target.GiveExperience();
        }
    }
}
