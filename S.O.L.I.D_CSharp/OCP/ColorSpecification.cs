using System;
namespace S.O.L.I.D_CSharp.OCP
{
    public class ColorSpecification : ISpecification<Product>
    {
        private Color Color;
        public ColorSpecification(Color color)
        {
            Color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == Color;
        }
    }
}
