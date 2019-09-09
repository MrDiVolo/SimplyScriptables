using System.Collections.Generic;
using UnityEngine;

namespace SimplyTools.Scriptables
{
    namespace Extras
    {
        /// <summary>
        /// A derivative of <see cref="SOList{T}"/> that doesn't expose the list itself,
        /// and (by default) checks when an item is added if it's already in the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class SOSafeList<T> : SOList<T>
        {
            [SerializeField] private bool checkContains = false;

            public new T this[int index]
            {
                get
                {
                    if (index > -1 && index < Capacity)
                        return base[index];
                    return default;
                }
                set
                {
                    if (index > -1 && index < Capacity)
                        base[index] = value;
                }
            }

            public new void Add(T _item)
            {
                if (!checkContains || !Contains(_item))
                    base.Add(_item);
            }

            public new void AddRange(IEnumerable<T> collection)
            {
                if (!checkContains)
                    base.AddRange(collection);
                else
                {
                    foreach (T item in collection)
                        if (!Contains(item))
                            base.Add(item);
                }
            }
        }
    }
}