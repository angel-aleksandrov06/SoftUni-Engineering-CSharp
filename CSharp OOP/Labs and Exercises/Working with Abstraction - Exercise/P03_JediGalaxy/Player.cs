namespace P03_JediGalaxy
{
    public class Player
    {
        public Player(int[] evil)
        {
            this.RowOfPlayer = evil[0];
            this.ColOfPlayer = evil[1];
        }

        public int RowOfPlayer { get; set; }
        public int ColOfPlayer { get; set; }
    }
}
