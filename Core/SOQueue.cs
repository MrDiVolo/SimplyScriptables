using System.Collections.Generic;
using UnityEngine;

namespace SimplyTools.Scriptables
{
    /// <summary>
    /// <see cref="ScriptableObject"/> wrapper for a <see cref="Queue{T}"/>
    /// </summary>
    /// <typeparam name="T">The <see cref="System.Type"/> used in the <see cref="Queue{T}"/></typeparam>
    public abstract class SOQueue<T> : ScriptableObject
    {
        [SerializeField] protected Queue<T> collection = new Queue<T>();
        [SerializeField] private bool singleQueueInstance = false;

        public void Initialise(IEnumerable<T> collection)
        { this.collection = new Queue<T>(collection); }

        public void Initialise(int capacity)
        { collection = new Queue<T>(capacity); }

        public int Count { get { return collection.Count; } }

        public void Clear() => collection.Clear();

        public bool Contains(T item) => collection.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => collection.CopyTo(array, arrayIndex);

        public T Dequeue()
        { return collection.Dequeue(); }

        public void Enqueue(T item)
        {
            if (!singleQueueInstance || !Contains(item))
                collection.Enqueue(item);
        }

        public Queue<T>.Enumerator GetEnumerator()
        { return collection.GetEnumerator(); }

        public T Peek()
        { return collection.Peek(); }

        public T[] ToArray()
        { return collection.ToArray(); }

        public void TrimExcess()
        { collection.TrimExcess(); }
    }
}