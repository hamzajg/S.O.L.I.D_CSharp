using System;
using System.Collections.Generic;

namespace S.O.L.I.D_CSharp.OCP
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }
}
