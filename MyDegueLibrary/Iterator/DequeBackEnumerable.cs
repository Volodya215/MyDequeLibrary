using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDegueLibrary
{
    internal class DequeBackEnumerable<T> : IEnumerable<T>
    {
        private Item<T> tail;
        internal DequeBackEnumerable(Item<T> tail)
        {
            this.tail = tail;
        }
        public DequeBackEnum<T> GetEnumerator()
        {
            return new DequeBackEnum<T>(tail);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
