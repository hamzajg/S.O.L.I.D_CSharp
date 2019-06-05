using System;
using System.Collections.Generic;

namespace S.O.L.I.D_CSharp.DIP.Violate
{
    // Low-Level
    public class Relationships
    {
        private List<(Person, Relationship, Person)> relations 
            = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public List<(Person, Relationship, Person)> Relations => relations;
    }
}
