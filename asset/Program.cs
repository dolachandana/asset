
using System.Security.Cryptography.X509Certificates;

List<gadget> gadlist = new List<gadget>();
int day=0;

while (true)
{
    computer c1 = new computer();
    Console.Write("Type :");
    string g = Console.ReadLine();
    if (g.ToLower().Trim() == "computer")
    {

        c1.type = "computer";

        Console.Write("Brand :");
        c1.brand = Console.ReadLine();
        Console.Write("Model :");
        c1.model = Console.ReadLine();
        Console.Write("Office(spain,sweden,USA):");
        c1.office = Console.ReadLine();
        Console.Write("Purchase date(yyyy-mm-dd):");
        string d = Console.ReadLine();
        DateTime dt1 = Convert.ToDateTime(d);
        //DateTime dt2 = DateTime.Now;
        //TimeSpan diff = dt2 - dt1;
        //day= diff.Days;
        
          c1.dt = dt1;
        Console.Write("price in USD:");
        string p = Console.ReadLine();
        bool isint = int.TryParse(p, out int value);
        if (isint)
        {
            c1.price = value;
            if (c1.office.ToLower().Trim() == "spain")
            {
                c1.currency = "EUR";
                int mul = value * 1;
                c1.todayprice = mul;
            }
            else if (c1.office.ToLower().Trim() == "sweden")
            {
                c1.currency = "SEK";
                double mul = value * 10.98;
                c1.todayprice = mul;
            }
            else
            {
                c1.currency = "USD";
                c1.todayprice = value;
            }
        }
        
        gadlist.Add(c1);
    }
    else if (g.ToLower().Trim() == "phone")
    {
        mobile m1 = new mobile();
        m1.type = "phone";

        Console.Write("Brand :");
        m1.brand = Console.ReadLine();
        Console.Write("Model :");
        m1.model = Console.ReadLine();
        Console.Write("Office(sweden,spain,USA):");
        m1.office = Console.ReadLine();
        Console.Write("Purchase date(yyyy-mm-dd):");
        string f = Console.ReadLine();
        DateTime dt1 = Convert.ToDateTime(f);
       // DateTime dt2 = DateTime.Now;
        
        //TimeSpan diff = dt2 - dt1;
      //  day = diff.TotalDays;

        m1.dt = dt1;
        Console.Write("price in USD:");

        string p = Console.ReadLine();
        bool isint = int.TryParse(p, out int value);
        if (isint)
        {
            m1.price = value;
            if (m1.office.ToLower().Trim() == "spain")
            {
                m1.currency = "EUR";
                int mul = value * 1;
                m1.todayprice = mul;
            }
            else if (m1.office.ToLower().Trim() == "sweden")
            {
                m1.currency = "SEK";
                double mul = value * 10.98;
                m1.todayprice = mul;
            }
            else
            {
                m1.currency = "USD";
                m1.todayprice = value;
            }
        }

        gadlist.Add(m1);
    }
    Console.WriteLine("quit");
    string q = Console.ReadLine();
    if (q.ToLower().Trim() == "quit") { break; }
}



Console.WriteLine("---------------------------------------------------------------------------------");
Console.WriteLine("Type".PadRight(6) +
           "Brand".PadRight(13) +
          "Model".PadRight(10) +
          "Offices".PadRight(11) +
          "PDate".PadRight(18) +
          "Price".PadRight(15) +
          "Currency".PadRight(11) +
          "LocalPrice".PadRight(11)
          );


List<gadget> sortedgad = gadlist.OrderBy(n => n.type).ToList();
List<gadget> sorteddate = sortedgad.OrderBy(n => n.dt).ToList();
List<gadget> sortedoffice = sorteddate.OrderBy(n => n.office).ToList();
List<gadget> sorteddt = sortedoffice.OrderBy(n => n.dt).ToList();
Console.WriteLine("---------------------------------------------------------------------------------");


/*foreach (var g in sortedgad)
{
    Console.WriteLine(g.type.PadRight(10) + g.brand.PadRight(10) + g.model.PadRight(10) + g.office.PadRight(10) + g.dt.ToString("yyyy-MM-dd").PadRight(20) + g.price.ToString().PadRight(10) + g.currency.PadRight(10) + g.todayprice);
}
Console.WriteLine("_____________");
List<gadget> sorteddate = sortedgad.OrderBy(n => n.dt).ToList();
foreach (var g in sorteddate)
{
    Console.WriteLine(g.type.PadRight(10) + g.brand.PadRight(10) + g.model.PadRight(10) + g.office.PadRight(10) + g.dt.ToString("yyyy-MM-dd").PadRight(20) + g.price.ToString().PadRight(10) + g.currency.PadRight(10) + g.todayprice);

}
Console.WriteLine("_____________");
List<gadget> sortedoffice = sorteddate.OrderBy(n => n.office).ToList();
foreach (var g in sortedoffice)
{
    Console.WriteLine(g.type.PadRight(10) + g.brand.PadRight(10) + g.model.PadRight(10) + g.office.PadRight(10) + g.dt.ToString("yyyy-MM-dd").PadRight(20) + g.price.ToString().PadRight(10) + g.currency.PadRight(10) + g.todayprice);
}
Console.WriteLine("_____________");
List<gadget> sorteddt = sortedoffice.OrderBy(n => n.dt).ToList();*/
foreach (var g in sorteddt)
{
    DateTime dt2 = DateTime.Now;
    var dt3 = g.dt;
    TimeSpan diff = dt2 - dt3;
    if (diff.TotalDays>=1005 && diff.TotalDays <= 1095)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(g.type.PadRight(10) + g.brand.PadRight(10) + g.model.PadRight(10) + g.office.PadRight(10) + g.dt.ToString("yyyy-MM-dd").PadRight(20) + g.price.ToString().PadRight(14) + g.currency.PadRight(13) + g.todayprice);
    Console.ResetColor();
    }
    else if(diff.TotalDays >= 915 && diff.TotalDays<=1005)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine(g.type.PadRight(10) + g.brand.PadRight(10) + g.model.PadRight(10) + g.office.PadRight(10) + g.dt.ToString("yyyy-MM-dd").PadRight(20) + g.price.ToString().PadRight(14) + g.currency.PadRight(13) + g.todayprice);
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine(g.type.PadRight(10) + g.brand.PadRight(10) + g.model.PadRight(10) + g.office.PadRight(10) + g.dt.ToString("yyyy-MM-dd").PadRight(20) + g.price.ToString().PadRight(14) + g.currency.PadRight(13) + g.todayprice);
    }

}
Console.ReadLine();
class gadget
{
    public string type;
    public string brand;
    public string model;
    public string office;
    public DateTime dt;
    public int price;
    public string currency;
    public double todayprice;

}
class computer : gadget
{ }
class mobile : gadget
{ }

