using System;
using System.Linq;

namespace S.O.L.I.D_CSharp.DIP.Violate
{
    public class Research
    {
        public Research(Relationships relationships)
        {
            var relations = relationships.Relations;
            foreach(var r in relations.Where(
                x => x.Item1.Name == "John" && 
                x.Item2 == Relationship.Parent))
            {
                Console.WriteLine($"John has a chil called {r.Item3.Name}");
            }
        }
    }
}
