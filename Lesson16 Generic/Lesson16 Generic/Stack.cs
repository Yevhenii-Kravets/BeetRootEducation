using System.Collections;

namespace Lesson16_Generic
{
    public class Stack<T> : IEnumerable<T>
    {
        private Item? Upper;
        private int Amount;
        public int Count => Amount;

        public void Push(T element) // add
        {
            if(Upper == null)
            {
                Upper = new()
                {
                    Value = element,
                    Previous = null
                };
                Amount++;
            }
            else
            {
                var temp = Upper;
                Upper = new()
                {
                    Value = element,
                    Previous = temp
                };
                Amount++;
            }
        }
        public void Clear() // clear stack list
        {
            Upper = null;
            Amount = 0;
        }

        public T Pop() // return and delete first
        {
            if (Amount > 0)
            {
                var temp = Upper;
                Upper = temp.Previous;

                Amount--;

                return temp.Value;
            }
            else
                throw new InvalidOperationException("The stack is empty.");
        }
        public T Peek() // return and not delete first
        {
            if (Amount > 0)
                return Upper.Value;
            else
                throw new InvalidOperationException("The stack is empty.");
        }

        public void CopyTo(ref T[] array) // copy to array v1
        {
            if (Amount > 0)
            {
                if (Amount != array.Length + 1)
                {
                    var temp = Upper;
                    for (int i = 0; i < Amount; i++)
                    {
                        array[i] = temp.Value;
                        temp = temp.Previous;
                    }
                }
                else
                    throw new InvalidOperationException("The stack size must be equal to the length of the array.");
            }
            else
                throw new InvalidOperationException("The stack is empty.");
        }
        public T[] CopyTo() // copy to array v2
        {
            T[] array = new T[Amount];
            if (Amount > 0)
            {
                var temp = Upper;
                for (int i = 0; i < Amount; i++)
                {
                    array[i] = temp.Value;
                    temp = temp.Previous;
                }
                return array;
            }
            else
                throw new InvalidOperationException("The stack is empty.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = Upper;
            while (temp != null)
            {
                yield return temp.Value;
                temp = temp.Previous;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Item
        {
            public T? Value { get; set; }
            public Item? Previous { get; set; }
        }
    }
}