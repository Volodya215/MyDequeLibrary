using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDegueLibrary
{
    internal class Item<T>
    {
        internal T Data { get; set; }

        internal Item<T> Previous { get; set; }
        internal Item<T> Next { get; set; }

        internal Item() { }
        internal Item(T data) => Data = data;

        public override string ToString() => Data.ToString();
    }
}
