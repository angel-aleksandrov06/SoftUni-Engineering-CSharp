namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int DefaultBulletPerBarrel = 50;
        private const int DefaultTotoalBullets = 500;
        private const int RifleDamage = 5;

        public Rifle(string name) 
            : base(name, DefaultBulletPerBarrel, DefaultTotoalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - RifleDamage <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel-= RifleDamage;
                this.BulletsPerBarrel = DefaultBulletPerBarrel;
                this.TotalBullets -= DefaultBulletPerBarrel;

                return RifleDamage;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel-= RifleDamage;
                return RifleDamage;
            }

            return 0;
        }
    }
}
