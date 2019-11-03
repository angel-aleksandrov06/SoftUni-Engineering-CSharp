namespace P03_JediGalaxy
{
    public class Galaxy
    {
        private int rows;
        private int cols;

        public Galaxy(int[] dimestions)
        {
            this.rows = dimestions[0];
            this.cols = dimestions[1];
            this.Matrix = new int[rows, cols];
        }

        public int[,] Matrix { get; set; }

        public void Create()
        {
            int value = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.Matrix[i, j] = value++;
                }
            }
        }

        public void MoveEvil(Evil evil)
        {
            while (evil.RowOfEvil >= 0 && evil.ColOfEvil >= 0)
            {
                if (evil.RowOfEvil >= 0 && evil.RowOfEvil < this.Matrix.GetLength(0) && evil.ColOfEvil >= 0 && evil.ColOfEvil < this.Matrix.GetLength(1))
                {
                    this.Matrix[evil.RowOfEvil, evil.ColOfEvil] = 0;
                }
                evil.RowOfEvil--;
                evil.ColOfEvil--;
            }
        }

        public long MovePlayer(Player player, long sumOfPoints)
        {
            while (player.RowOfPlayer >= 0 && player.ColOfPlayer < this.Matrix.GetLength(1))
            {
                if (player.RowOfPlayer >= 0 && player.RowOfPlayer < this.Matrix.GetLength(0) && player.ColOfPlayer >= 0 && player.ColOfPlayer < this.Matrix.GetLength(1))
                {
                    sumOfPoints += this.Matrix[player.RowOfPlayer, player.ColOfPlayer];
                }

                player.ColOfPlayer++;
                player.RowOfPlayer--;
            }

            return sumOfPoints;
        }
    }
}
