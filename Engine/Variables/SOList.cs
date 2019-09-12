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

        [SerializeField] protected List<T> collection = new List<T>();

        protected void Initialise(IEnumerable<T> collection)
        { this.collection = new List<T>(collection); }

        protected void Initialise(int capacity)
        { collection = new List<T>(capacity); }

        protected virtual T this[int index]
        {
            get { return collection[index]; }
            set { collection[index] = value; }
        }

        protected int Count { get { return collection.Count; } }

        protected int Capacity
        {
            get { return collection.Capacity; }
            set { collection.Capacity = value; }
        }

        public void Add(T item)
        {
            collection.Add(item);
            OnAdd?.Invoke(item);
        }

        protected void AddRange(IEnumerable<T> collection)
        { this.collection.AddRange(collection); }

        protected ReadOnlyCollection<T> AsReadOnly()
        { return collection.AsReadOnly(); }

        protected int BinarySearch(T item)
        { return collection.BinarySearch(item); }

        protected int BinarySearch(T item, IComparer<T> comparer)
        { return collection.BinarySearch(item, comparer); }

        protected int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        { return collection.BinarySearch(index, count, item, comparer); }

        protected void Clear()
        { collection.Clear(); }

        protected bool Contains(T item)
        { return collection.Contains(item); }

        protected List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        { return collection.ConvertAll(converter); }

        protected void CopyTo(int index, T[] array, int arrayIndex, int count)
        { collection.CopyTo(index, array, arrayIndex, count); }

        protected void CopyTo(T[] array, int arrayIndex)
        { collection.CopyTo(array, arrayIndex); }

        protected void CopyTo(T[] array)
        { collection.CopyTo(array); }

        protected bool Exists(Predicate<T> match)
        { return collection.Exists(match); }

        protected T Find(Predicate<T> match)
        { return collection.Find(match); }

        protected List<T> FindAll(Predicate<T> match)
        { return collection.FindAll(match); }

        protected int FindIndex(int startIndex, int count, Predicate<T> match)
        { return collection.FindIndex(startIndex, count, match); }

        protected int FindIndex(int startIndex, Predicate<T> match)
        { return collection.FindIndex(startIndex, match); }

        protected int FindIndex(Predicate<T> match)
        { return collection.FindIndex(match); }

        protected T FindLast(Predicate<T> match)
        { return collection.FindLast(match); }

        protected int FindLastIndex(int startIndex, int count, Predicate<T> match)
        { return collection.FindLastIndex(startIndex, count, match); }

        protected int FindLastIndex(int startIndex, Predicate<T> match)
        { return collection.FindLastIndex(startIndex, match); }

        protected int FindLastIndex(Predicate<T> match)
        { return collection.FindLastIndex(match); }

        protected void ForEach(Action<T> action)
        { collection.ForEach(action); }

        protected List<T>.Enumerator GetEnumerator()
        { return collection.GetEnumerator(); }

        protected List<T> GetRange(int index, int count)
        { return collection.GetRange(index, count); }

        protected int IndexOf(T item, int index, int count)
        { return collection.IndexOf(item, index, count); }

        protected int IndexOf(T item, int index)
        { return collection.IndexOf(item, index); }

        protected int IndexOf(T item)
        { return collection.IndexOf(item); }

        protected void Insert(int index, T item)
        { collection.Insert(index, item); }

        protected void InsertRange(int index, IEnumerable<T> collection)
        { this.collection.InsertRange(index, collection); }

        protected int LastIndexOf(T item)
        { return collection.LastIndexOf(item); }

        protected int LastIndexOf(T item, int index)
        { return collection.LastIndexOf(item, index); }

        protected int LastIndexOf(T item, int index, int count)
        { return collection.LastIndexOf(item, index, count); }

        public bool Remove(T item)
        {
            bool removed = collection.Remove(item);

            if (removed)
                OnRemove?.Invoke(item);

            return removed;
        }

        protected int RemoveAll(Predicate<T> match)
        { return collection.RemoveAll(match); }

        protected void RemoveAt(int index)
        { collection.RemoveAt(index); }

        protected void RemoveRange(int index, int count)
        { collection.RemoveRange(index, count); }

        protected void Reverse(int index, int count)
        { collection.Reverse(index, count); }

        protected void Reverse()
        { collection.Reverse(); }

        protected void Sort(Comparison<T> comparison)
        { collection.Sort(comparison); }

        protected void Sort(int index, int count, IComparer<T> comparer)
        { collection.Sort(index, count, comparer); }

        protected void Sort()
        { collection.Sort(); }

        protected void Sort(IComparer<T> comparer)
        { collection.Sort(comparer); }

        protected T[] ToArray()
        { return collection.ToArray(); }

        protected void TrimExcess()
        { collection.TrimExcess(); }

        protected bool TrueForAll(Predicate<T> match)
        { return collection.TrueForAll(match); }
    }
}