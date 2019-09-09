using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace SimplyTools.Scriptables
{
    /// <summary>
    /// <see cref="ScriptableObject"/> wrapper for a <see cref="List{T}"/>
    /// </summary>
    /// <typeparam name="T">The <see cref="System.Type"/> used in the <see cref="List{T}"/></typeparam>
    public abstract class SOList<T> : ScriptableObject
    {
        public event Action<T> OnAdd;
        public event Action<T> OnRemove;

        [SerializeField] protected List<T> m_collection = new List<T>();

        protected void Initialise(IEnumerable<T> collection)
        { m_collection = new List<T>(collection); }

        protected void Initialise(int capacity)
        { m_collection = new List<T>(capacity); }

        protected virtual T this[int index]
        {
            get { return m_collection[index]; }
            set { m_collection[index] = value; }
        }

        protected int Count { get { return m_collection.Count; } }

        protected int Capacity
        {
            get { return m_collection.Capacity; }
            set { m_collection.Capacity = value; }
        }

        public void Add(T item)
        {
            m_collection.Add(item);
            OnAdd?.Invoke(item);
        }

        protected void AddRange(IEnumerable<T> collection)
        { m_collection.AddRange(collection); }

        protected ReadOnlyCollection<T> AsReadOnly()
        { return m_collection.AsReadOnly(); }

        protected int BinarySearch(T item)
        { return m_collection.BinarySearch(item); }

        protected int BinarySearch(T item, IComparer<T> comparer)
        { return m_collection.BinarySearch(item, comparer); }

        protected int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        { return m_collection.BinarySearch(index, count, item, comparer); }

        protected void Clear()
        { m_collection.Clear(); }

        protected bool Contains(T item)
        { return m_collection.Contains(item); }

        protected List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        { return m_collection.ConvertAll(converter); }

        protected void CopyTo(int index, T[] array, int arrayIndex, int count)
        { m_collection.CopyTo(index, array, arrayIndex, count); }

        protected void CopyTo(T[] array, int arrayIndex)
        { m_collection.CopyTo(array, arrayIndex); }

        protected void CopyTo(T[] array)
        { m_collection.CopyTo(array); }

        protected bool Exists(Predicate<T> match)
        { return m_collection.Exists(match); }

        protected T Find(Predicate<T> match)
        { return m_collection.Find(match); }

        protected List<T> FindAll(Predicate<T> match)
        { return m_collection.FindAll(match); }

        protected int FindIndex(int startIndex, int count, Predicate<T> match)
        { return m_collection.FindIndex(startIndex, count, match); }

        protected int FindIndex(int startIndex, Predicate<T> match)
        { return m_collection.FindIndex(startIndex, match); }

        protected int FindIndex(Predicate<T> match)
        { return m_collection.FindIndex(match); }

        protected T FindLast(Predicate<T> match)
        { return m_collection.FindLast(match); }

        protected int FindLastIndex(int startIndex, int count, Predicate<T> match)
        { return m_collection.FindLastIndex(startIndex, count, match); }

        protected int FindLastIndex(int startIndex, Predicate<T> match)
        { return m_collection.FindLastIndex(startIndex, match); }

        protected int FindLastIndex(Predicate<T> match)
        { return m_collection.FindLastIndex(match); }

        protected void ForEach(Action<T> action)
        { m_collection.ForEach(action); }

        protected List<T>.Enumerator GetEnumerator()
        { return m_collection.GetEnumerator(); }

        protected List<T> GetRange(int index, int count)
        { return m_collection.GetRange(index, count); }

        protected int IndexOf(T item, int index, int count)
        { return m_collection.IndexOf(item, index, count); }

        protected int IndexOf(T item, int index)
        { return m_collection.IndexOf(item, index); }

        protected int IndexOf(T item)
        { return m_collection.IndexOf(item); }

        protected void Insert(int index, T item)
        { m_collection.Insert(index, item); }

        protected void InsertRange(int index, IEnumerable<T> collection)
        { m_collection.InsertRange(index, collection); }

        protected int LastIndexOf(T item)
        { return m_collection.LastIndexOf(item); }

        protected int LastIndexOf(T item, int index)
        { return m_collection.LastIndexOf(item, index); }

        protected int LastIndexOf(T item, int index, int count)
        { return m_collection.LastIndexOf(item, index, count); }

        public bool Remove(T item)
        {
            bool removed = m_collection.Remove(item);

            if (removed)
                OnRemove?.Invoke(item);

            return removed;
        }

        protected int RemoveAll(Predicate<T> match)
        { return m_collection.RemoveAll(match); }

        protected void RemoveAt(int index)
        { m_collection.RemoveAt(index); }

        protected void RemoveRange(int index, int count)
        { m_collection.RemoveRange(index, count); }

        protected void Reverse(int index, int count)
        { m_collection.Reverse(index, count); }

        protected void Reverse()
        { m_collection.Reverse(); }

        protected void Sort(Comparison<T> comparison)
        { m_collection.Sort(comparison); }

        protected void Sort(int index, int count, IComparer<T> comparer)
        { m_collection.Sort(index, count, comparer); }

        protected void Sort()
        { m_collection.Sort(); }

        protected void Sort(IComparer<T> comparer)
        { m_collection.Sort(comparer); }

        protected T[] ToArray()
        { return m_collection.ToArray(); }

        protected void TrimExcess()
        { m_collection.TrimExcess(); }

        protected bool TrueForAll(Predicate<T> match)
        { return m_collection.TrueForAll(match); }
    }
}