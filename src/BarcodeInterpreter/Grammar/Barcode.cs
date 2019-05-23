using System.Collections.Generic;
using System.Linq;
using BarcodeInterpreter.Interpreter;

namespace BarcodeInterpreter.Grammar
{
    public class Barcode : IExpression
    {
        public ManufacturerId ManufacturerId { get; set; }
        public ItemNumber ItemNumber { get; set; }

        private Digit CalculateCheckDigit(IEnumerable<Digit> barcode)
        {
            // these look backwards but the odds / evens in UPC spec are 1 counted not 0
            var odds = barcode.Where((c, i) => i % 2 == 0).Select(_ => (int)_).Sum() * 3;
            var evens = barcode.Where((c, i) => i % 2 != 0).Select(_ => (int)_).Sum();
            var checkDigit = (10 - ((odds + evens) % 10)) % 10;
            return checkDigit;
        }

        public void Interpret(Context context)
        {
            ManufacturerId.Interpret(context);
            ItemNumber.Interpret(context);
            context.Digits.Add(CalculateCheckDigit(context.Digits));
        }
    }
}
