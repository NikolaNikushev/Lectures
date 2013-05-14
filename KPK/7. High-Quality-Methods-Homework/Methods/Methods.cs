using System;

namespace Methods
{
    class Methods
    {
        private static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("All sides should be positive and above 0.");
            }

            double P = (a + b + c) / 2;
            double area = Math.Sqrt(P * (P - a) * (P - b) * (P - c));
            return area;
        }

        private static string GetDigitName(int digit)
        {
            if (digit > 9 || digit < 0)
            {
                throw new ArgumentException("A digit is a number between 0 and 9 inclusive. ");
            }

            string digitName = "";
            switch (digit)
            {
                case 0:
                    digitName = "zero";
                    break;
                case 1:
                    digitName = "one";
                    break;
                case 2:
                    digitName = "two";
                    break;
                case 3:
                    digitName = "three";
                    break;
                case 4:
                    digitName = "four";
                    break;
                case 5:
                    digitName = "five";
                    break;
                case 6:
                    digitName = "six";
                    break;
                case 7:
                    digitName = "seven";
                    break;
                case 8:
                    digitName = "eight";
                    break;
                case 9:
                    digitName = "nine";
                    break;
            }
            return digitName;
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("The inputed array has no elements.");
            }

            int maximum = elements[0];
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maximum)
                {
                    maximum = elements[i];
                }
            }
            return maximum;
        }

        private static void PrintNumberInFormat(object number, string format)
        {
            decimal numberParsed = 0;
            if (!decimal.TryParse(number.ToString(), out numberParsed))
            {
                throw new FormatException("You have not inputed a number.");
            }
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", numberParsed);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", numberParsed);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", numberParsed);
            }
            else
            {
                throw new FormatException("Format for printing not found");
            }
        }

        private static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            if (!double.TryParse(x1.ToString(), out x1))
            {
                throw new FormatException("You have not inputed a number of type Double for x1.");
            }

            if (!double.TryParse(y1.ToString(), out y1))
            {
                throw new FormatException("You have not inputed a number of type Double for y1.");
            }

            if (!double.TryParse(x2.ToString(), out x2))
            {
                throw new FormatException("You have not inputed a number of type Double for x2.");
            }

            if (!double.TryParse(y2.ToString(), out y2))
            {
                throw new FormatException("You have not inputed a number of type Double for y2.");
            }

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        private static bool CheckIfHorizontal(double y1, double y2)
        {
            if (!double.TryParse(y1.ToString(), out y1))
            {
                throw new FormatException("You have not inputed a number of type Double for y1.");
            }

            if (!double.TryParse(y2.ToString(), out y2))
            {
                throw new FormatException("You have not inputed a number of type Double for y2.");
            }

            bool isHorizontal = (y1 == y2);
            return isHorizontal;
        }

        private static bool CheckIfVertical(double x1, double x2)
        {
            if (!double.TryParse(x1.ToString(), out x1))
            {
                throw new FormatException("You have not inputed a number of type Double for x1.");
            }

            if (!double.TryParse(x2.ToString(), out x2))
            {
                throw new FormatException("You have not inputed a number of type Double for x2.");
            }

            bool isVertical = (x1 == x2);
            return isVertical;
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(GetDigitName(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintNumberInFormat(1.3, "f");
            PrintNumberInFormat(0.75, "%");
            PrintNumberInFormat(2.30, "r");

            double x1 = 3;
            double x2 = -1;
            double y1 = 3;
            double y2 = 2.5;
            bool horizontal = CheckIfHorizontal(y1, y2);
            bool vertical = CheckIfVertical(x1, x2);
            Console.WriteLine(CalculateDistance(x1, x2, y1, y2));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
