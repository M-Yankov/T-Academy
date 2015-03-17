/*Problem 1. Define class

    Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors).
    Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

Problem 2. Constructors

    Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it).
    Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

Problem 3. Enumeration

    Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

Problem 4. ToString

    Add a method in the GSM class for displaying all information about it.
    Try to override ToString().

Problem 5. Properties

    Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
    Ensure all fields hold correct data at any given time.

Problem 6. Static field

    Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.

Problem 7. GSM test

    Write a class GSMTest to test the GSM class:
        Create an array of few instances of the GSM class.
        Display the information about the GSMs in the array.
        Display the information about the static property IPhone4S.

Problem 8. Calls

    Create a class Call to hold a call performed through a GSM.
    It should contain date, time, dialled phone number and duration (in seconds).

Problem 9. Call history

    Add a property CallHistory in the GSM class to hold a list of the performed calls.
    Try to use the system class List<Call>.

Problem 10. Add/Delete calls

    Add methods in the GSM class for adding and deleting calls from the calls history.
    Add a method to clear the call history.

Problem 11. Call price

    Add a method that calculates the total price of the calls in the call history.
    Assume the price per minute is fixed and is provided as a parameter.

Problem 12. Call history test

    Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
        Create an instance of the GSM class.
        Add few calls.
        Display the information about the calls.
        Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
        Remove the longest call from the history and calculate the total price again.
        Finally clear the call history and print it.

 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            
            GSM phone1 = new GSM("ZTE N281", "ZTE (HK) Ltd", 88.9, "Gergi", new Battery("Hardmodel#", 8, 4, BattertType.Li_Lon), new Display(4.1, 32000));
            GSM phone2 = new GSM("Samsung S4", "Samsung corp.", 128.9, "Ivan", new Battery("newLine", 6, 3, BattertType.NiMH), new Display(4.9, 64000));
            GSM phone3 = new GSM("Nokia N95", "Microsoft Mobile", 100, "Sracimir", new Battery("newLine", 7, 3, BattertType.Li_Lon), new Display(4, 128000));
            GSM phone4 = new GSM("Lenovo S850", "Lenovo Co", 155.5, "Petkan", new Battery("LenBatMod", 5, 2, BattertType.Li_Lon), new Display(4.1, 256000));
            GSM phone5 = new GSM("HTC One M8", "HTC", 654.9, "The King", new Battery("Spectum", 18, 2, BattertType.NiCD), new Display(5, 512000));
            GSM phone6 = new GSM("Motorola Z2", "Motorola corp.", 16.6, "Kloshar", new Battery("SOmemodel", 2, 9, BattertType.Unknown), new Display(1.5, 1024000));
            GSM phone7 = new GSM("Nokia N5", "Microsoft Mobile", 58.9, "Someone", new Battery("Unknown", 8, 3, BattertType.Li_Lon), new Display(3.9, 2048000));
            GSM phone8 = new GSM("Prestigio", "Prestigio Europe", 16.5, "Operator", new Battery("Sd", 8, 5, BattertType.NiCD), new Display(4.1, 4096000));
            GSM phone9 = new GSM("Cat", "Soft Company", 119.2, "Marzelinio", new Battery("Unknown", 5, 2, BattertType.Li_Lon), new Display(3, 8216000));
            GSM[] telefoni = new GSM[] { phone1, phone2, phone3, phone4, phone5, phone6, phone7, phone8, phone9 };
            foreach (var item in telefoni)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine(GSM.iPhone4S);
            Console.WriteLine();
            Console.WriteLine("Press any key to continie with testing calls");
            Console.ReadLine();
            Console.WriteLine("Testing Calls");
            GSMCallHistoryTest();
        }
        public static void GSMCallHistoryTest()
        {
            GSM oboroten = new GSM("Nokia W8", "Nokia Corp.", 220, "Ivanchoy", new Battery("Zbot", 8, 3, BattertType.Li_Lon), new Display(4.2, 555000));
            oboroten.AddCall(new DateTime(2015, 3, 15), "0893345323", 415);
            oboroten.AddCall(new DateTime(2015, 2, 10), "0881500162", 845);
            oboroten.AddCall(new DateTime(2015, 2, 10), "0875916442", 45);
            oboroten.AddCall(new DateTime(2015, 2, 11), "0891500156", 165);
            oboroten.AddCall(new DateTime(2015, 2, 6),  "0891547400", 264);
            oboroten.AddCall(new DateTime(2015, 2, 5),  "0881622317", 942);
            oboroten.AddCall(new DateTime(2015, 2, 9),  "0879455161", 315);
            oboroten.AddCall(new DateTime(2015, 3, 15), "0893345323", 548); // call again to first number
            //Show calls
            oboroten.ShowCallListHystorY();
            // Total calls

            Console.WriteLine("Total price is: ${0:F2}", oboroten.TotalPrice()); 
            //Remove the longest call
            uint max = 0;
            int index = -1;
            foreach (var item in oboroten.CallsHistory)
            {
                if (item.Duration > max)
                {
                    max = item.Duration;
                    index = oboroten.CallsHistory.IndexOf(item);
                }
            }
            oboroten.DeleteCallAtPosition(index);
            // Caling again this metod
            oboroten.ShowCallListHystorY();
            Console.WriteLine("After delete max duration call. Total price is: ${0:F2}", oboroten.TotalPrice());
            
            // Clear the call list
            Console.WriteLine("Delete all calls...");
            oboroten.ClearHystor();
            oboroten.ShowCallListHystorY();
        }
    }
    /*class GSMCallHistoryTest
    //{

        GSM oboroten = new GSM("Nokia W8", "Nokia Corp.", 220, "Ivanchoy", new Battery("Zbot", 8, 3, BattertType.Li_Lon), new Display(4.2, 555000));
        
    }*/
}
