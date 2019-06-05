using System;
namespace S.O.L.I.D_CSharp.ISP
{
    public class Photocopier : IPrinter, IScanner
    {
        public Photocopier()
        {
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
