using System;
namespace S.O.L.I.D_CSharp.ISP.Violate
{
    public class OldFashionedPrinter : IMachine
    {
        public OldFashionedPrinter()
        {
        }

        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
}
