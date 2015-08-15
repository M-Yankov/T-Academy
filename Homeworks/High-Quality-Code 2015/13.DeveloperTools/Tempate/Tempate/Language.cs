namespace Template{
using System;
using System.Collections;
public class Language
{

	public Language(   int javascriptMark,   int javaMark,   int perlMark,   int xmlMark,   int csharpMark,   int phpMark  )
	{
	
    this.JavaScript = javascriptMark;

    this.Java = javaMark;

    this.Perl = perlMark;

    this.XML = xmlMark;

    this.CSharp = csharpMark;

    this.PHP = phpMark;

	}

	
    public int JavaScript { get; set; }


    public int Java { get; set; }


    public int Perl { get; set; }


    public int XML { get; set; }


    public int CSharp { get; set; }


    public int PHP { get; set; }


    public void Method()
    {
    }
}
}