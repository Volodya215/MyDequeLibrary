using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDegueLibrary
{
    internal class DequeEnum<T> : IEnumerator<T>
    {
        private Item<T> head;

        private Item<T> position = new Item<T>();

        internal DequeEnum(Item<T> item)
        {
            head = item;
            position.Next = head;
        }

        public bool MoveNext()
        {
            position = position.Next;
            return position != null;
        }

        public void Reset()
        {
            position.Next = head;
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
