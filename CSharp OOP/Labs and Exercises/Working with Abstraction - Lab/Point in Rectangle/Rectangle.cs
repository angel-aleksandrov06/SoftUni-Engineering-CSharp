namespace Point_in_Rectangle
{
    public class Rectangle
    {
        public Rectangle(Point x, Point y)
        {
            this.TopLeft = x;
            this.BottomRight = y;
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            bool isInHorizontal = this.TopLeft.X <= point.X && this.BottomRight.X >= point.X;
            bool isInVertical = this.TopLeft.Y <= point.Y && this.BottomRight.Y >= point.Y;

            bool isInRectangle = isInHorizontal && isInVertical;

            return isInRectangle;
        }
    }
}
