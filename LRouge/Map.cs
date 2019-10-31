namespace LRouge
{
    internal class Map
    {
        private readonly int width;
        private readonly int height;

        private readonly Cell[,] cells;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;

            cells = new Cell[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    cells[y, x] = new Cell();
                }
            }
        }
    }
}