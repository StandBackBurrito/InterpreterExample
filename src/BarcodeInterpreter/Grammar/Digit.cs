using System;
using BarcodeInterpreter.Interpreter;

namespace BarcodeInterpreter.Grammar
{
    [System.Diagnostics.DebuggerDisplay("{_value}")]
    public struct Digit : IExpression
    {
        private int _value;

        public static readonly Digit MinValue = new Digit() { _value = 0 };
        public static readonly Digit MaxValue = new Digit() { _value = 9 };

        private Digit(int digit)
        {
            if (digit < MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), $"Value cannot be less then {nameof(Digit.MinValue)}");
            }

            if (digit > MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), $"Value cannot be more then {nameof(Digit.MaxValue)}");
            }

            _value = digit;
        }

        public static implicit operator Digit(int digit)
        {
            return new Digit(digit);
        }

        public static implicit operator int(Digit digit)
        {
            return digit._value;
        }

        // operators for other numeric types...

        public override string ToString()
        {
            return _value.ToString();
        }

        public void Interpret(Context context)
        {
            context.Digits.Add(_value);
        }
    }
}
