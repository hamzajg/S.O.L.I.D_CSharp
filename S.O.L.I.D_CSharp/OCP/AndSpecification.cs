using System;
namespace S.O.L.I.D_CSharp.OCP
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> First, Second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return First.IsSatisfied(t) && Second.IsSatisfied(t);
        }
    }
}
