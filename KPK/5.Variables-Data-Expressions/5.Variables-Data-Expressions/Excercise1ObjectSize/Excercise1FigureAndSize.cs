using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise1ObjectSize
{
    class Excercise1FigureSize
    {
        public class Figure
        {
            public double Width { get; private set; }
            public double Height { get; private set; }

            public Figure(double width, double height)
            {
                this.Width = width;
                this.Height = height;
            }
        }

        public static Figure GetRotatedSize(Figure figure, double angleToRotateInDegree)
        {
            double angle = angleToRotateInDegree;

            double rotatedWidth = Math.Abs(Math.Cos(angle)) * figure.Width + Math.Abs(Math.Sin(angle)) * figure.Height;
            double rotatedHeight = Math.Abs(Math.Sin(angle)) * figure.Width + Math.Abs(Math.Cos(angle)) * figure.Height;

            return new Figure(rotatedWidth, rotatedHeight);
        }
    }
}
