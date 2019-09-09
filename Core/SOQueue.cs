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
        [SerializeField] protected Queue<T> m_collection = new Queue<T>();
        [SerializeField] private bool m_singleQueueInstance;

        public void Initialise(IEnumerable<T> collection)
        { m_collection = new Queue<T>(collection); }

        public void Initialise(int capacity)
        { m_collection = new Queue<T>(capacity); }

        public int Count { get { return m_collection.Count; } }

        public void Clear() => m_collection.Clear();

        public bool Contains(T item) => m_collection.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => m_collection.CopyTo(array, arrayIndex);

        public T Dequeue()
        { return m_collection.Dequeue(); }

        public void Enqueue(T item)
        {
            if (!m_singleQueueInstance || !Contains(item))
                m_collection.Enqueue(item);
        }

        public Queue<T>.Enumerator GetEnumerator()
        { return m_collection.GetEnumerator(); }

        public T Peek()
        { return m_collection.Peek(); }

        public T[] ToArray()
        { return m_collection.ToArray(); }

        public void TrimExcess()
        { m_collection.TrimExcess(); }
    }
}