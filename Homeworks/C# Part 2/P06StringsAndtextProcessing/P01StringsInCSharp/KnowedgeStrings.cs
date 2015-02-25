/*Problem 1. Strings in C#.

    Describe the strings in C#.
    What is typical for the string data type?
*/
using System;
using System.Text;
class KnowedgeStrings
{
    static void Main()
    {
        /*What are strings in  C#? string is reference type witch mean it's keep in special memory in Pc called "heap" . All reference 
         * types are asociated there. String is the class from witch we make object of type string. System.String.
         * How can be declarate a string value ? There are many method. but let's see some expamples:
         * string s = "Hello Pesho"; // Syntax: <type> <name>  =  "<value>" . the value text must be suraounded by quotes.
         * string s1 = new String('a' ,50); // this initialization have 8 overload constructors . This one make a string with char 'a' reapeating it 50 times.
        
         * string s = string.Empty;    // an empty string equals to "" ;
         * string s;                  // we can use this too, but after it can't use this variable for comparing and operations with it. 
         * All characters can be represented as string numbers: 1,2,3,4,5,6,7,8,9 ,0  spec. symbols !@#$%^&*()_+ and many others. just must be surounded with quotes.
         * Formating symbols like "\n" for new line and "\t" for tabulation. 
         * Escaping  sitiations for representing '\' and quotes : 2 variants:
         * 1. @" this is "word" is surounded bt quotes" ; will print how it's entered.
         * 2. use slash before symbol like " \"word\" \\ " will prit:  "word" \
         * Operations with strings : most known is concatenation string1 + string2 , or string1 += string2 .
         *      comparing strings : bool result = string11 == string2.
         * Methods with strings: Many - just use name of string and dot after it to have access. or String.
         * Examples: 
         * String s = "Hello World";
         * s.Length // 11;
         * s.IndexOf(W) // 6
         * s[6] // W 
         * s.LastIndexOf(l) // 9 if not found result is -1;
         * String text are representeed like array of chars that starts with index 0;
         * s.SubString(start index , length);
         * s.Substring(start index ) // till end of text;
         * s.Replace("Hello" , "Hi") will return "Hi World";
         * s.Remove(0,5); // will return " World";
         * s.ToLower().s.ToUpper() s.Trim() s.TrimEnd() s.TrimStart();
         * All method above return a new value don't changes current string. Because it's reference type. 
        
         * How to input text from Console ? Console.WriteLine("{0} <- This is your input", Console.ReadLine()); 
         * There are some formating methods: string s = String.Format("this is your number --> {0}" , 2) // result this is your number --> 2
         * Use these bracets {} to make it easier to print varialbles an it's fast for writeing. {0} is first parameter {1} second , {2} third {n} etc..
         * These brackert {} has some options {0:0.000} // 3.141
         * {0:F3} // same
         * {0,6}  will have lenght of six characters on the console like :"    45"
         * {0,-6} same , but allign is right : "45    "
         * Convert to string:
         * int num = 22;
         * string str = num..ToString();
         * .ToString() may have variable formats : ("X") hexadecimal ("E") exponential number ("F") fixed number with point ("P") perentage . etc
         * or Convert.ToString(str, 2) will return binary representation of number .
         * the concatenation of strings is slow . in one for loop with one tousand iteration will be slow. So it will be better useage of class StringBuilder where
         * everything is possible: 
         * StringBuilder newTextString = new StringBuilder();// empty
         * newTextString.Append("This is text"); // using append instead + is't faster
         * newTextSting[2] = 's' . // in strings this is not possible.
        */
       
            
    }
}
