using System;
using System.Collections;
using System.Collections.Generic;

namespace LimitedList
{
    public class LimitedList<T> : IEnumerable<T>
    {
        private readonly int capacity;
        protected readonly List<T> list;

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            list = new List<T>(capacity);
        }

        public int Count => list.Count;
        public bool IsFull => capacity <= Count;

        public virtual bool Add(T item)
        {
            if (IsFull) return false;
            list.Add(item);
            return true;
        }

        public bool Remove(T item) => list.Remove(item);

        public IEnumerator<T> GetEnumerator()
        {
            //return list.GetEnumerator();
            foreach (T item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void WriteAll(Action<T> action)
        {
            list.ForEach(i => action.Invoke(i));

            //foreach (var item in list)
            //{
            //    action.Invoke(item);
            //}
        }

    }
}
