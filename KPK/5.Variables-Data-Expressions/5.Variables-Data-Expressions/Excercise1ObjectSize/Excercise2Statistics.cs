using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise1ObjectSize
{
    class Excercise2Statistics
    {
        public void PrintStatistics(double[] statistics, int count)
        {
            double maximum = double.MinValue;

            //Gets maximum
            for (int currentStatistic = 0; currentStatistic < count; currentStatistic++)
            {
                if (statistics[currentStatistic] > maximum)
                {
                    maximum = statistics[currentStatistic];
                }
            }

            PrintMaxamimum(maximum);

            double minimum = double.MaxValue;

            //Gets Minimum
            for (int currentStatistic = 0; currentStatistic < count; currentStatistic++)
            {
                if (statistics[currentStatistic] < minimum)
                {
                    minimum = statistics[currentStatistic];
                }
            }

            PrintMinimum(minimum);

            double average = 0;

            //Gets average
            for (int currentStatistic = 0; currentStatistic < count; currentStatistic++)
            {
                average += statistics[currentStatistic];
            }

            PrintAverage(average / count);
        }

        private void PrintValue(double value)
        {
            Console.WriteLine(value);
        }

        private void PrintMaxamimum(double value)
        {
            PrintValue(value);
        }

        private void PrintAverage(double value)
        {
            PrintValue(value);
        }

        private void PrintMinimum(double value)
        {
            PrintValue(value);
        }
    }
}
