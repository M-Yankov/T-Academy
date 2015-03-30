/*Problem 1. Student class
    Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties.
    Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
  
 * Problem 2. IClonable
    Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.
 
 * Problem 3. IComparable
    Implement the IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order).

*/

namespace P01Students
{
    using System;
    class MainMethodHere
    {
        static void Main()
        {
            
            //int res = "Atanas".CompareTo("Branimir");

            Student equalStud1 = new Student("Pesho", "Georgiev", "Stratiev", 215677, "Sofia 1440, str.Todor Aleksandrov #12", "pesho@abv.bg", "0895623333", "OOP", Speciality.Programing, Univercity.TelerikAcademy, Faculty.InforamtionScience);
            Student equalStud2 = new Student("Pesho", "Ivanov", "Stratiev", 215677, "Sofia 3215, bul.Goce Delchev #16", "example@abv.bg", "0825953378", "UIDesign", Speciality.Mobiletechnologies, Univercity.TelerikAcademy, Faculty.InforamtionScience);
            Console.WriteLine(equalStud1);
            Console.WriteLine("Hash code of {1}: {0}", equalStud1.GetHashCode(), equalStud1.PfirstName);
            Console.WriteLine("\n{0}", equalStud2);
            Console.WriteLine("Hash code of {0}: {1}", equalStud2.PfirstName, equalStud2.GetHashCode());
            Console.WriteLine("---------\nAre students equal: " + equalStud1.Equals(equalStud2) + "\n");  // true

            Student diffStud1 = new Student("Evlogi", "Ivanov", "Hristov", 215677, "Munchen , blv.Hainz", "frankfurt@host.gr", "+034525234", "OOP", Speciality.Infomationtechnologies, Univercity.SoftwareAcademy, Faculty.InforamtionScience);
            Student diffStud2 = new Student("Nikolay", "Ivanov", "Kostov", 215677, "Sofia 1440, str.Aleksander Malinov", "niki@gmail.com", "0875723731", "OOP", Speciality.ComputerScince, Univercity.TelerikAcademy, Faculty.InforamtionScience);
            Console.WriteLine("Comparing new students: {0} and {1}\n Result: {2}", diffStud1.PfirstName, diffStud2.PfirstName, diffStud2.Equals(diffStud1));
            Console.WriteLine("{0} == {1} : {2}  \n{0} != {1} : {3}", diffStud1.PfirstName, diffStud2.PfirstName, diffStud1 == diffStud2 ,diffStud1 != diffStud2);
            //Cloning
            Console.WriteLine("\n----Try to clone----\n");
            // Change setting to copied object and then compare them

            var fullCopyofStudent = (Student)diffStud1.Clone();
            Console.WriteLine("Comparing new object with old: {0}\n", fullCopyofStudent == diffStud1);
            fullCopyofStudent.PfirstName = "Doncho"; // Important !!! Changing name ...
            Console.WriteLine("Change first name to new obj. Are they equals: {0}\n Answer: newObj.FirstName = {1}\n\t oldObj2.FirstName = {2}", fullCopyofStudent == diffStud1 , fullCopyofStudent.PfirstName , diffStud1.PfirstName);
            //Comparing

            Console.WriteLine("\n----Try to compare----\n");
            ComparingObjs(equalStud1.CompareTo(equalStud2)); // equalStud1 & equalStud2;
            ComparingObjs(diffStud1.CompareTo(diffStud2)); //diffStud1 & diffStud2
            ComparingObjs(equalStud2.CompareTo(fullCopyofStudent)); // equalStud2 & fullCopyofStudent
            
        }
        public static void ComparingObjs(int value)
        {
            if (value < 0)
            {
                Console.WriteLine("Objects are not in order!");
            }
            else if (value == 0)
            {
                Console.WriteLine("Object are equal.");
            }
            else
            {
                Console.WriteLine("Objects are in correct order.");
            }
        }
    }
}
