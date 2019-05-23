using System;
using BarcodeInterpreter.Grammar;
using BarcodeInterpreter.Interpreter;

namespace BarcodeInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var barcode = new Barcode()
            {
                ManufacturerId = new ManufacturerId(new Digit[] { 0, 7, 5, 6, 7, 8 }),
                ItemNumber = new ItemNumber(new Digit[] { 1, 6, 4, 1, 2 })
            };

            var context = new Context();
            barcode.Interpret(context);

            Console.WriteLine($"Barcode: {context}");
            Console.ReadKey();
        }
    }
}
