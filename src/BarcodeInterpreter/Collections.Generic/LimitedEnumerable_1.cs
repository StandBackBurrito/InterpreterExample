using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BarcodeInterpreter.Collections.Generic
{
    public abstract class LimitedEnumerable<T> : IReadOnlyList<T>
    {
        protected readonly IReadOnlyList<T> _collection;
        protected abstract int MinLength { get; }
        protected abstract int MaxLength { get; }

        public int Count => _collection.Count;

        public T this[int index] => _collection[index];

        public LimitedEnumerable(IReadOnlyList<T> collection)
        {
            if (collection.Count > MaxLength)
            {
                throw new ArgumentOutOfRangeException(nameof(collection), "Collection had too many elements");
            }

            if (collection.Count < MinLength)
            {
                throw new ArgumentOutOfRangeException(nameof(collection), "Collection had too few elements");
            }

            _collection = collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
    }
}
