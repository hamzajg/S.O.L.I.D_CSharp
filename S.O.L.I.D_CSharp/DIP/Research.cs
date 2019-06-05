using System;
using System.Linq;

namespace S.O.L.I.D_CSharp.DIP
{
    public class Research
    {
        public Research(IRelationshipBrowser browser)
        {
            foreach(var p in browser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a chil called {p.Name}");
            }
        }
    }
}
