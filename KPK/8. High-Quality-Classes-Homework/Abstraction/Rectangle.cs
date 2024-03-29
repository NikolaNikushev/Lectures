﻿using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
