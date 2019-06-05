using System;
namespace S.O.L.I.D_CSharp.OCP
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
