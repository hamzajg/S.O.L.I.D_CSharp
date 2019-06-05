using System;
namespace S.O.L.I.D_CSharp.LSP
{
    public class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
        public Square()
        {
        }
    }
}
