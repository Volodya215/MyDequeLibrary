using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDegueLibrary
{
    public class DequeEventArgs<T>
    {
        // Result
        public T Result { get; }

        public DequeEventArgs(T result) => Result = result;
    }
}
