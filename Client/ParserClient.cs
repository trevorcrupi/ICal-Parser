using System;
using ICal;

public class ParserClient
{
    public static void Main(string[] args)
    {
        Console.WriteLine("ICal Parser Test");

        ICalReader r = new ICalReader("C:/Projects/ical/Client/test.ics");
        ICalParser parser = new ICalParser(r);
        parser.WriteToConsole();
    }
}
