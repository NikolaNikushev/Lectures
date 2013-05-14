using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStructuresStatementsLoops
{
    class Excercise3LoopRefractoring
    {
        private void FindFirstDividedBy(int[] arrayToSearch, int value)
        {
            bool valueIsFound = false;
            for (int currentNumber = 0; currentNumber < arrayToSearch.Length; )
            {
                if (currentNumber % 10 == 0)
                {
                    if (arrayToSearch[currentNumber] == value)
                    {
                        valueIsFound = true;
                        break;
                    }
                }
                Console.WriteLine("Current number = {0}", arrayToSearch[currentNumber]);
                currentNumber++;
            }

            if (valueIsFound)
            {
                Console.WriteLine("Value Found");
            }
            else
            {
                Console.WriteLine("Value not found");
            }
        }

    }
}
