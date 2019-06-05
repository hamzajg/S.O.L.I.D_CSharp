using System;
using System.Collections.Generic;

namespace S.O.L.I.D_CSharp.OCP
{
    public class BetterFilter : IFilter<Product>
    {
        public BetterFilter()
        {
        }

        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach (var item in items)
            {
                if (specification.IsSatisfied(item))
                    yield return item;
            }
        }
    }
}
