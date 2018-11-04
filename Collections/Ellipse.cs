namespace Collections
{
    public class Ellipse
    {
        private double x;
        private double y;
        private double radius;

        public double X { get {return x;} }
        public double Y { get {return y;} }
        public double Radius { get { return radius; } }

        public Ellipse(double x = 0, double y = 0, double radius = 0)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }
    }
}
