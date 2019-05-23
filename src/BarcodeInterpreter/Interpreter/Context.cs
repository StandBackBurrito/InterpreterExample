using System;
using System.Collections.Generic;
using System.Linq;
using BarcodeInterpreter.Grammar;

namespace BarcodeInterpreter.Interpreter
{
    public class Context
    {
        public List<Digit> Digits { get; set; } = new List<Digit>();
        public override string ToString()
        {
            return String.Concat(Digits.Select(_ => _.ToString()));
        }

    }
}
