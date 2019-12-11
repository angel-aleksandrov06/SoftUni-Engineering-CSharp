namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int DefaultBulletPerBarrel = 10;
        private const int DefaultTotoalBullets = 100;
        private const int PistolDamage = 1;

        public Pistol(string name)
            : base(name, DefaultBulletPerBarrel, DefaultTotoalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - PistolDamage <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel--;
                this.BulletsPerBarrel = DefaultBulletPerBarrel;
                this.TotalBullets -= DefaultBulletPerBarrel;

                return PistolDamage;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel--;
                return PistolDamage;
            }

            return 0;
        }
    }
}
