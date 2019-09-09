using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOStack<T> : ScriptableObject
{
    public event Action<T> OnPush;
    public event Action<T> OnPop;

    [SerializeField] private Stack<T> m_stack = new Stack<T>();
       
    protected virtual void Initialise(IEnumerable<T> collection) => m_stack = new Stack<T>(collection);
    protected virtual void Initialise(int capacity) => m_stack = new Stack<T>(capacity);

    protected virtual int Count => m_stack.Count;

    protected virtual void Clear() => m_stack.Clear();
    protected virtual bool Contains(T item) => m_stack.Contains(item);
    protected virtual void CopyTo(T[] array, int arrayIndex) => m_stack.CopyTo(array, arrayIndex);
    protected virtual Stack<T>.Enumerator GetEnumerator() => m_stack.GetEnumerator();
    protected virtual T Peek() => m_stack.Peek();

    public virtual T Pop()
    {
        T item = m_stack.Pop();
        OnPop?.Invoke(item);
        return item;
    }

    public virtual void Push(T item)
    {
        m_stack.Push(item);
        OnPush?.Invoke(item);
    }

    protected virtual T[] ToArray() => m_stack.ToArray();
    protected virtual void TrimExcess() => m_stack.TrimExcess();
}