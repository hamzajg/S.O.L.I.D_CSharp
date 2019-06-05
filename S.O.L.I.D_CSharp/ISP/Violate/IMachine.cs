using System;
namespace S.O.L.I.D_CSharp.ISP.Violate
{
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
}
