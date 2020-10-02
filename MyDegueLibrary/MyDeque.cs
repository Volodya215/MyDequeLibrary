using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDegueLibrary
{
    public class MyDeque<T> : IEnumerable<T>
    {
        public delegate void MyDequeHandler(object sender, DequeEventArgs<T> e);
        public event MyDequeHandler Notify;

        public int Size { get; private set; } = 0;

        private Item<T> Head;
        private Item<T> Tail;

        public MyDeque() { }
        public MyDeque(T data) => SetHeadItem(data);

        // Add first element in Deque
        private void SetHeadItem(T data)
        {
            var temp = new Item<T>(data);
            Head = Tail = temp;
            Size = 1;
        }


        /// <summary>
        /// Add element at the end of the Deque
        /// </summary>
        /// <param name="data"></param>
        public void AddToBack(T data)
        {
            if (Size == 0)
            {
                SetHeadItem(data);
                return;
            }

            var temp = new Item<T>(data);
            temp.Previous = Tail;
            Tail.Next = temp;
            Tail = temp;
            Size++;
        }

        /// <summary>
        /// Add element at the beginning of the Deque
        /// </summary>
        /// <param name="data"></param>
        public void AddToFront(T data)
        {
            if (Size == 0)
            {
                SetHeadItem(data);
                return;
            }

            var temp = new Item<T>(data);
            temp.Next = Head;
            Head.Previous = temp;
            Head = temp;
            Size++;
        }

        /// <summary>
        /// Delete element from the end of the Deque
        /// </summary>
        /// <returns></returns>
        public void RemoveFromBack()
        {
            if (Size > 0)
            {
                var result = Tail.Data;
                Tail = Tail.Previous;
                Tail.Next = null;
                Size--;

                Notify?.Invoke(this, new DequeEventArgs<T>(result));
            }
            else
                throw new InvalidOperationException("The queue is empty");

        }

        /// <summary>
        ///  Delete element from the begining of the Deque
        /// </summary>
        /// <returns></returns>
        public void RemoveFromFront()
        {
            if (Size > 0)
            {
                var result = Head.Data;
                Head = Head.Next;
                Head.Previous = null;
                Size--;
                Notify?.Invoke(this, new DequeEventArgs<T>(result));
            }
            else
                throw new InvalidOperationException("The queue is empty");

        }

        /// <summary>
        /// Return last element from the Deque
        /// </summary>
        /// <returns></returns>
        public T PeekBack() => Tail != null ? Tail.Data : throw new InvalidOperationException("The deque is empty");

        /// <summary>
        ///  Return first element from the Deque
        /// </summary>
        /// <returns></returns>
        public T PeekFront() => Head != null ? Head.Data : throw new InvalidOperationException("The deque is empty");

        /// <summary>
        /// Clear the deque
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            Head = Tail = null;
            Size = 0;
        }


        /// <summary>
        /// Convert Deque to Array
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            if (Size == 0) throw new InvalidOperationException("The deque is empty");

            var arr = new T[Size];
            var temp = Head;

            for (int i = 0; i < Size; i++)
            {
                arr[i] = temp.Data;
                temp = temp.Next;
            }

            return arr;
        }

        /// <summary>
        /// Check that the Deque is not empty 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => Size == 0;


        public DequeEnum<T> GetEnumerator()
        {
            return new DequeEnum<T>(Head);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        // TODO
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }
    }

    // TODO задом наперед
    public class DequeEnum<T> : IEnumerator<T>
    {
        private Item<T> head;

        private Item<T> position = new Item<T>();

        public DequeEnum(Item<T> item)
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

        // TODO Переписати код
        public T Current
        {
            get
            {
                try
                {
                    return position.Data;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        void IDisposable.Dispose() { }

    }

    public class DequeEventArgs<T>
    {
        // Result
        public T Result { get; }

        public DequeEventArgs(T result) => Result = result;
    }
}
