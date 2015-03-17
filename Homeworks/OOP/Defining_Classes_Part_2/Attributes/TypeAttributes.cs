/*Problem 11. Version attribute

    Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11).
    Apply the version attribute to a sample class and display its version at runtime. 
 */
using System;
using System.Runtime.InteropServices;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]

public class VersionAttribute : System.Attribute
{
    public double Ver { get; private set; }
    public VersionAttribute(double num)
    {
        this.Ver = num;
    }
}
    [Version(5.0)]
    [Version(5.5)]


class TypeAttributes
{
    static void Main(string[] args)
    {
        Type raw = typeof(TypeAttributes);
        object[] allVersions = raw.GetCustomAttributes(false);
        foreach (VersionAttribute item in allVersions)
        {
            Console.WriteLine("Version {0}", item.Ver );
        }
    }
}
