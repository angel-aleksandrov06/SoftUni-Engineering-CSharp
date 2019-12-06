namespace SpaceStation.Models.Bags
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class BackPack : IBag
    {
        public BackPack()
        {
            this.Items = new Collection<string>();
        }

        public ICollection<string> Items { get; private set; }
    }
}
