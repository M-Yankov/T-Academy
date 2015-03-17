using System;
using System.Text;

class Call
{
    private DateTime date;
    private string phonenumber;
    private uint duarion;

    public Call(DateTime date, string phoneNumber, uint duarion)
    {
        // can be validation condition implemented
        this.Date = date;
        this.PhoneNumber = phoneNumber;
        this.Duration = duarion;

    }
    public DateTime Date
    {
        get { return this.date; }
        set { this.date = value; }
    }
    public string PhoneNumber
    {
        get { return this.phonenumber; }
        set { this.phonenumber = value; }
    }
    public uint Duration
    {
        get { return this.duarion; }
        set { this.duarion = value; }
    }
    public override string ToString()
    {
        StringBuilder final = new StringBuilder();
        final.AppendFormat("{0:dd.MM.yyyy}\t{1}\t{2}", this.Date, this.PhoneNumber, this.Duration);
        return final.ToString();
    }
}