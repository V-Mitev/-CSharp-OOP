namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Width = width;
            Height = height;
        }

        public double Height
        {
            get { return height; }
            private set { height = value; }
        }

        public double Width
        {
            get { return width; }
            private set { width = value; }
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (width + height);
        }

        public override string Draw()
        {
            return $"Drawing {GetType().Name}";
        }
    }
}