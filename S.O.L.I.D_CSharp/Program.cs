using System;
using System.Diagnostics;
using S.O.L.I.D_CSharp.DIP;
using S.O.L.I.D_CSharp.LSP;
using S.O.L.I.D_CSharp.OCP;
using S.O.L.I.D_CSharp.OCP.Violate;
using S.O.L.I.D_CSharp.SRP;

namespace S.O.L.I.D_CSharp
{
    class Program
    {
        static int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            // 01 - SRP
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");

            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"Journal.txt";
            p.SaveToFIle(j, filename, true);
            Process.Start(filename);

            // 02 - OCP
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };
            var pf = new ProductFilter();
            Console.WriteLine("Green Product (Old):");
            foreach(var item in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {item.Name} is green");
            }

            var bf = new BetterFilter();
            Console.WriteLine("Green Product (New):");
            foreach (var item in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {item.Name} is green");
            }
            Console.WriteLine("Large Product (New):");
            foreach (var item in bf.Filter(products, new SizeSpecification(Size.Large)))
            {
                Console.WriteLine($" - {item.Name} is large");
            }
            Console.WriteLine("Large Blue Product (New):");
            foreach (var item in bf.Filter(products, new AndSpecification<Product>(new SizeSpecification(Size.Large), new ColorSpecification(Color.Blue))))
            {
                Console.WriteLine($" - {item.Name} is big and blue");
            }

            // 03 - LSP
            var rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}");
            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");

            // 05 - DIP
            var parent = new Person() { Name = "John" };
            var child1 = new Person() { Name = "Chris" };
            var child2 = new Person() { Name = "Mary" };

            var relationships = new DIP.Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            _ = new DIP.Research(relationships);
        }
    }
}
