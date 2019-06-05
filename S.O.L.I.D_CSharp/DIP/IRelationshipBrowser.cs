using System;
using System.Collections.Generic;

namespace S.O.L.I.D_CSharp.DIP
{
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
}
