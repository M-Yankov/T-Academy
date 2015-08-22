using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlowConditionalStatement
{
    class Task_3
    {

        public void TaskMethod()
        {
            // ## Task 3. Refactor the following loop

            int counter = 0;
            do
            {
                if (counter % 10 == 0)
                {
                    Console.WriteLine(array[counter]);
                    counter = ValidateExpectedValue(counter);
                    counter++;
                }
                else
                {
                    Console.WriteLine(array[counter]);
                    counter++;
                }

                // More code here
                if (counter == 666)
                {
                    Console.WriteLine("Value Found");
                }
            } while (counter < 100);


        }

        private static int ValidateExpectedValue(int index)
        {
            if (array[index] == expectedValue)
            {
                index = 666;
            }
            return index;
        }

    }
}
