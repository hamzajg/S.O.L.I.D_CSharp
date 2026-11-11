using System;
namespace S.O.L.I.D_CSharp.OCP
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _first;
        private readonly ISpecification<T> _second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            _first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            _second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return _first.IsSatisfied(t) && _second.IsSatisfied(t);
        }
    }
}
