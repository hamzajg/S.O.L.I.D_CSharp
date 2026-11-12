using System;
using S.O.L.I.D_CSharp.ISP;
using Xunit;

namespace S.O.L.I.D_CSharp.Tests
{
    /// <summary>
    /// ISP: <see cref="MultiFunctionMachine"/> asks for an
    /// <see cref="IPrinter"/> and an <see cref="IScanner"/>, not one fat
    /// machine interface, so a device can supply either capability.
    /// </summary>
    public class IspTests
    {
        [Fact]
        public void PrintGoesToTheInjectedPrinter()
        {
            var printer = new SpyPrinter();
            var scanner = new SpyScanner();
            var machine = new MultiFunctionMachine(printer, scanner);
            var document = new Document();

            machine.Print(document);

            Assert.Same(document, printer.Printed);
            Assert.Null(scanner.Scanned);
        }

        [Fact]
        public void ScanGoesToTheInjectedScanner()
        {
            var printer = new SpyPrinter();
            var scanner = new SpyScanner();
            var machine = new MultiFunctionMachine(printer, scanner);
            var document = new Document();

            machine.Scan(document);

            Assert.Same(document, scanner.Scanned);
            Assert.Null(printer.Printed);
        }

        [Fact]
        public void APrinterAloneIsEnoughForThePrintingSide()
        {
            // Only the interface it needs is required — the spy has no scan method.
            var printer = new SpyPrinter();
            IPrinter asInterface = printer;

            asInterface.Print(new Document());

            Assert.NotNull(printer.Printed);
        }

        [Fact]
        public void MultiFunctionMachineRejectsAMissingDevice()
        {
            Assert.Throws<ArgumentNullException>(() => new MultiFunctionMachine(null, new SpyScanner()));
            Assert.Throws<ArgumentNullException>(() => new MultiFunctionMachine(new SpyPrinter(), null));
        }

        private sealed class SpyPrinter : IPrinter
        {
            public Document Printed { get; private set; }

            public void Print(Document d) => Printed = d;
        }

        private sealed class SpyScanner : IScanner
        {
            public Document Scanned { get; private set; }

            public void Scan(Document d) => Scanned = d;
        }
    }
}
