namespace P03_JediGalaxy
{
    public class Evil
    {
        public Evil(int[] evil)
        {
            this.RowOfEvil = evil[0];
            this.ColOfEvil = evil[1];
        }

        public int RowOfEvil { get; set; }
        public int ColOfEvil { get; set; }
    }
}
