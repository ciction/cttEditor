using System;
using System.Collections.Generic;

namespace cttEditor
{
    public class EventTriggeringList<T> : List<T>
    {

        public event EventHandler OnAdd;
        public event EventHandler OnRemove;

        public void Add(T item)
        {
            OnAdd?.Invoke(this, null);
            base.Add(item);
        }

        public void Remove(T item)
        {
            OnRemove?.Invoke(this, null);
            base.Remove(item);
        }

    }

}