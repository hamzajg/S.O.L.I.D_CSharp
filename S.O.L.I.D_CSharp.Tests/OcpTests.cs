using System;
using System.Linq;
using S.O.L.I.D_CSharp.OCP;
using Xunit;

namespace S.O.L.I.D_CSharp.Tests
{
    /// <summary>
    /// OCP: a new filter is a new <see cref="ISpecification{T}"/>, never an edit
    /// to <see cref="BetterFilter"/>.
    /// </summary>
    public class OcpTests
    {
        private static readonly Product Apple = new Product("Apple", Color.Green, Size.Small);
        private static readonly Product Tree = new Product("Tree", Color.Green, Size.Large);
        private static readonly Product House = new Product("House", Color.Blue, Size.Large);

        private static readonly Product[] Products = { Apple, Tree, House };

        [Fact]
        public void ColorSpecificationKeepsTheMatchingProducts()
        {
            var green = new BetterFilter()
                .Filter(Products, new ColorSpecification(Color.Green))
                .Select(p => p.Name);

            Assert.Equal(new[] { "Apple", "Tree" }, green);
        }

        [Fact]
        public void SizeSpecificationKeepsTheMatchingProducts()
        {
            var large = new BetterFilter()
                .Filter(Products, new SizeSpecification(Size.Large))
                .Select(p => p.Name);

            Assert.Equal(new[] { "Tree", "House" }, large);
        }

        [Fact]
        public void AndSpecificationRequiresBothConditions()
        {
            var largeAndBlue = new BetterFilter()
                .Filter(Products, new AndSpecification<Product>(
                    new SizeSpecification(Size.Large),
                    new ColorSpecification(Color.Blue)))
                .Select(p => p.Name);

            Assert.Equal(new[] { "House" }, largeAndBlue);
        }

        [Fact]
        public void AndSpecificationIsFalseWhenOnlyOneSideMatches()
        {
            var greenAndLarge = new AndSpecification<Product>(
                new ColorSpecification(Color.Green),
                new SizeSpecification(Size.Small));

            Assert.True(greenAndLarge.IsSatisfied(Apple));
            Assert.False(greenAndLarge.IsSatisfied(Tree));
        }

        [Fact]
        public void FilteringNothingYieldsNothing()
        {
            var nothing = new BetterFilter()
                .Filter(Array.Empty<Product>(), new ColorSpecification(Color.Green));

            Assert.Empty(nothing);
        }

        [Fact]
        public void AndSpecificationRejectsAMissingSide()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new AndSpecification<Product>(null, new ColorSpecification(Color.Green)));
            Assert.Throws<ArgumentNullException>(() =>
                new AndSpecification<Product>(new ColorSpecification(Color.Green), null));
        }

        [Fact]
        public void ProductRejectsAMissingName()
        {
            Assert.Throws<ArgumentNullException>(() => new Product(null, Color.Red, Size.Small));
        }
    }
}
