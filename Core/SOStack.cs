using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOStack<T> : ScriptableObject
{
    public event Action<T> OnPush;
    public event Action<T> OnPop;

    [SerializeField] private Stack<T> stack = new Stack<T>();
       
    protected virtual void Initialise(IEnumerable<T> collection) => stack = new Stack<T>(collection);
    protected virtual void Initialise(int capacity) => stack = new Stack<T>(capacity);

    protected virtual int Count => stack.Count;

    protected virtual void Clear() => stack.Clear();
    protected virtual bool Contains(T item) => stack.Contains(item);
    protected virtual void CopyTo(T[] array, int arrayIndex) => stack.CopyTo(array, arrayIndex);
    protected virtual Stack<T>.Enumerator GetEnumerator() => stack.GetEnumerator();
    protected virtual T Peek() => stack.Peek();

    public virtual T Pop()
    {
        T item = stack.Pop();
        OnPop?.Invoke(item);
        return item;
    }

    public virtual void Push(T item)
    {
        stack.Push(item);
        OnPush?.Invoke(item);
    }

    protected virtual T[] ToArray() => stack.ToArray();
    protected virtual void TrimExcess() => stack.TrimExcess();
}