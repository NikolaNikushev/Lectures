using System;

namespace Abstraction
{
    abstract class Figure : IFigurable
    {
        public virtual double Width { get; private set; }
        public virtual double Height { get; private set; }

        public Figure(double width, double height)
        {
            if (double.TryParse(width.ToString(), out width))
            {
                if (width <= 0)
                {
                    throw new ArgumentException("Width should be a positive, non zero number");
                }
            }
            else
            {
                throw new FormatException("Entered width is not a number");
            }

            if (double.TryParse(height.ToString(), out height))
            {
                if (height <= 0)
                {
                    throw new ArgumentException("Height should be a positive, non zero number");
                }
            }
            else
            {
                throw new FormatException("Entered height is not a number");
            }

            this.Width = width;
            this.Height = height;
        }

        public virtual double CalculatePerimeter()
        {
            throw new EntryPointNotFoundException("This figure is not specified");
        }

        public virtual double CalculateSurface()
        {
            throw new EntryPointNotFoundException("This figure is not specified");
        }
    }
}
