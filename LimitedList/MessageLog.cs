using System;
using System.Collections.Generic;
using System.Text;

namespace LimitedList
{
   public class MessageLog<T> : LimitedList.LimitedList<T>
    {
        public MessageLog(int capacity) : base(capacity)
        {

        }

        public override bool Add(T item)
        {
            if (IsFull) list.RemoveAt(0);
            list.Add(item); 
            return true;
        }

       
    }
}
