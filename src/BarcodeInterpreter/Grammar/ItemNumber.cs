using System.Collections.Generic;
using BarcodeInterpreter.Collections.Generic;
using BarcodeInterpreter.Interpreter;

namespace BarcodeInterpreter.Grammar
{
    public class ItemNumber : LimitedEnumerable<Digit>, IExpression
    {
        public ItemNumber(IReadOnlyList<Digit> collection) : base(collection)
        {

        }

        protected override int MinLength => 5;

        protected override int MaxLength => 5;

        public void Interpret(Context context)
        {
            foreach (Digit digit in _collection)
            {
                digit.Interpret(context);
            }
        }
    }
}
