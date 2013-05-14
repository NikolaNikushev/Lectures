using System;

namespace Abstraction
{
    class Circle : Figure
    {
        public double Radius { get { return this.Width; } }

        public Circle(double radius)
            :base(radius, radius)
        {
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
