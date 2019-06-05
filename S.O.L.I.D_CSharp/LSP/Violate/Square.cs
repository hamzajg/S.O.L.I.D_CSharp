using System;
namespace S.O.L.I.D_CSharp.LSP.Violate
{
    public class Square : Rectangle
    {
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }
        public new int Height
        {
            set { base.Width = base.Height = value; }
        }
        public Square()
        {
        }
    }
}
