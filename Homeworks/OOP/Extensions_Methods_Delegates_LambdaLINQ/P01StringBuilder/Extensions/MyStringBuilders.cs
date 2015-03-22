

namespace P01StringBuilder.Extensions
{
    using System;
    using System.Text;
    static class MyStringBuilders
    {
        
        public static StringBuilder MySubstring(this string str, int index , int length)
        {
            if (length >= str.Length)
            {
                throw new ArgumentOutOfRangeException("", "Lenght must not be bigger than original string lenght.");    
            }
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append(str.Substring(index,length));
            return strBuild;
        }
    }
}
