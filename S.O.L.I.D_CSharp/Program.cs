using System;
using System.Diagnostics;
using S.O.L.I.D_CSharp.SRP;

namespace S.O.L.I.D_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");

            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"Journal.txt";
            p.SaveToFIle(j, filename, true);
            Process.Start(filename);
        }
    }
}
