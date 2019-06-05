using System;
namespace S.O.L.I.D_CSharp.ISP
{
    public class MultiFunctionMachine : IMultiFunctionDevice
    {

        private IPrinter Printer;
        private IScanner Scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            Printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
            Scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
        }

        public void Print(Document d)
        {
            Printer.Print(d);
        }
        public void Scan(Document d)
        {
            Scanner.Scan(d);
        } // decorator
    }
}
