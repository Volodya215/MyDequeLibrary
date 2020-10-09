using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDegueLibrary
{
    internal class DequeBackEnum<T> : IEnumerator<T>
    {
        private Item<T> tail;

        private Item<T> position = new Item<T>();

        internal DequeBackEnum(Item<T> item)
        {
            tail = item;
            position.Previous = tail;
        }

        public bool MoveNext()
        {
            position = position.Previous;
            return position != null;
        }

        public void Reset()
        {
            position.Previous = tail;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return position.Data;
                }
                catch (NullReferenceException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        void IDisposable.Dispose() { }
    }
}
