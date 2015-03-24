using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public enum BattertType
{
    Li_Lon, NiMH, NiCD, Unknown
}
class GSM
{

    private const double taxCallPerMinute = 0.37;

    private List<Call> callsHystory = new List<Call>();

    private string model;
    private string manufacturer;
    private double price;
    private string owner;


    public GSM(string model, string manufac)
        : this(model, manufac, 0, "Unknown", new Battery(), new Display())
    {

    }
    public GSM(string model, string manufac, double price, string owner, Battery battery, Display ekran)  // Constructor
    {
        if (model == null || manufac == null)
        {
            throw new ArgumentNullException("model or manufac.", "Can't be empty.");
        }
        this.Model = model;
        this.Manufacturer = manufac;
        this.Price = price;
        this.Owner = owner;
        this.Battery = battery;
        this.Display = ekran;
        // Battery bateria = new Battery(bateryModel, hoursidle, hoursTalk, type);
        //this.Battery = battery;
        //this.Display = ekran;
    }
    public static GSM iPhone4S = new GSM("iPhone4S", "Apple", 555.55, "Pesho", new Battery("batteryModel5", 6, 2, BattertType.Li_Lon), new Display(4.1, 128000));




    public string Model   // Property 
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public string Manufacturer
    {
        get { return this.manufacturer; } // Property 
        private set { this.manufacturer = value; }
    }
    public double Price  // Property 
    {
        get { return this.price; }
        set { this.price = value; }
    }

    public string Owner  // Property 
    {
        get { return this.owner; }
        set { this.owner = value; }
    }
    public Battery Battery { get; set; }  // it requires me to out "set" in body 
    public Display Display { get; set; }  // it requires me to out "set" in body
    public override string ToString()
    {
        string info = String.Format("Model: {0}\nManufacturer: {1}\nPrice: ${2}\nOwner: {3}\nBattery model: {4}\nBattery idle durability: {5} hours\nBattery talk duravility: {6} hours\nBattery type: {7}\nDisplay size: {8}''\nDisplay colors: {9}",
            this.model,
            this.manufacturer,
            this.price,
            this.owner,
            this.Battery.Model,
            this.Battery.HoursIDL,
            this.Battery.HoursTalk,
            this.Battery.Type,
            this.Display.Size,
            this.Display.Colors);
        return info;
    }

    public List<Call> CallsHistory
    {
        get { return this.callsHystory; }
        set { }
    }

    //methods
    public void AddCall(DateTime date, string phoneNumbreer, uint duration)
    {
        if (phoneNumbreer.Length != 10)
        {
            throw new ArgumentException("Bad Input");
        }
        this.callsHystory.Add(new Call(date, phoneNumbreer, duration));
    }
    public void DeleteCallAtPosition(int index)
    {
        this.callsHystory.RemoveAt(index);
    }
    public void ShowCallListHystorY()
    {
        //string text;
        if (this.callsHystory.Count == 0)
        {
            Console.WriteLine("Call history is empty.");
        }
        else
        {
            Console.WriteLine("Date\t\tPhone\t\tDuration");
            foreach (var item in this.callsHystory) //.OrderBy(x => x.Date)) We can order Calls by date. :)
             {
                //text = String.Format("{0:DD.MM.YYYY} \t{1} \t{2}", item.Date, item.PhoneNumber, item.Duration);
                Console.WriteLine(item);
            }
        }

    }
    public void ClearHystor()
    {
        this.callsHystory.Clear();
    }
    public double TotalPrice()
    {
        double price = 0;
        double sum = 0;
        foreach (var item in this.callsHystory)
        {
            sum += (double)item.Duration;
             
        }
        price = (sum / 60.0) * taxCallPerMinute;
        return price;
    }

}
class Battery
{

    private string model;
    private int hoursIdle;
    private int hoursTalk;
    private BattertType type = new BattertType();

    public Battery()
        : this("", 0, 0, BattertType.Unknown)
    {

    }

    public Battery(string model, int timeIdle, int hour, BattertType type = BattertType.Unknown) // Constructor
    {
        if (model == null)
        {
            throw new ArgumentNullException("mode", "Can not be empty!");
        }
        this.Model = model;
        this.HoursIDL = timeIdle;
        this.HoursTalk = hour;
        this.Type = type;
    }


    public string Model //// Property 
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public int HoursIDL  // Property 
    {
        get { return this.hoursIdle; }
        set { this.hoursIdle = value; }
    }
    public int HoursTalk // Property 
    {
        get { return this.hoursTalk; }
        set { this.hoursTalk = value; }
    }
    public BattertType Type
    {
        get { return this.type; }
        set { this.type = value; }

    }


}
class Display
{
    private double size; // inch
    private int colors;
    public Display()
        : this(0, 0)
    {

    }
    public Display(double inch, int colors)
    {
        this.Size = inch;
        this.Colors = colors;
    }
    public double Size // Property 
    {
        get { return this.size; }
        set { this.size = value; }
    }
    public int Colors
    {
        get { return this.colors; }
        set { this.colors = value; }
    }
}