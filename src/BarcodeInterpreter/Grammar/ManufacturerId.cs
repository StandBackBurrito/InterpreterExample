using System.Collections.Generic;
using BarcodeInterpreter.Collections.Generic;
using BarcodeInterpreter.Interpreter;

namespace BarcodeInterpreter.Grammar
{
    public class ManufacturerId : LimitedEnumerable<Digit>, IExpression
    {
        public ManufacturerId(IReadOnlyList<Digit> collection) : base(collection)
        {

        }

        protected override int MinLength => 6;

        protected override int MaxLength => 6;

        public void Interpret(Context context)
        {
            foreach (Digit digit in _collection)
            {
                digit.Interpret(context);
            }
        }
    }
}
