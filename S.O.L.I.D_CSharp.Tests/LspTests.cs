using S.O.L.I.D_CSharp.LSP;
using Xunit;

namespace S.O.L.I.D_CSharp.Tests
{
    /// <summary>
    /// LSP: the examples are <see cref="Rectangle"/> and its <see cref="Square"/>
    /// subclass. The tests state the invariant a rectangle promises and then show
    /// that a square cannot keep it — the point of the "violate" version.
    /// </summary>
    public class LspTests
    {
        private static int Area(Rectangle rectangle) => rectangle.Width * rectangle.Height;

        [Fact]
        public void ARectangleKeepsTheWidthAndHeightItWasGiven()
        {
            var rectangle = new Rectangle(2, 3);

            Assert.Equal(6, Area(rectangle));
        }

        [Fact]
        public void ARectangleAreaUsesBothSidesIndependently()
        {
            var rectangle = new Rectangle();
            rectangle.Width = 4;
            rectangle.Height = 5;

            Assert.Equal(20, Area(rectangle));
        }

        [Fact]
        public void ASquareIsNotSubstitutableForARectangle()
        {
            Rectangle square = new Square();
            square.Width = 4;
            square.Height = 5;

            // A rectangle would now be 4 wide and 5 tall. The square collapses
            // both to 5, so code written against Rectangle gets a different answer.
            Assert.Equal(20, 4 * 5);
            Assert.NotEqual(20, Area(square));
            Assert.Equal(25, Area(square));
        }

        [Fact]
        public void ASquareStillBehavesLikeASquare()
        {
            Rectangle square = new Square();
            square.Width = 4;

            Assert.Equal(16, Area(square));
        }
    }
}
