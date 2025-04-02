// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntDesign
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items is null)
            {
                return;
            }

            foreach (var item in items)
            {
                action.Invoke(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T, int> action)
        {
            if (items is null)
            {
                return;
            }

            var index = 0;
            foreach (var item in items)
            {
                action.Invoke(item, index);
                index++;
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> items, Func<T, Task> func)
        {
            if (items is null)
            {
                return;
            }

            foreach (var item in items) await func(item);
        }

        public static bool IsIn<T>(this T source, params T[] array)
        {
            if (array is null)
            {
                return false;
            }

            return array.Contains(source);
        }

        public static bool IsIn<T>(this T source, params ReadOnlySpan<T> span)
        {
            if (span.IsEmpty)
            {
                return false;
            }

            if (source is IEquatable<T> eq)
            {
                for (var i = 0; i < span.Length; i++)
                {
                    if (eq.Equals(span[i]))
                    {
                        return true;
                    }
                }
            }
            else
            {
                var comparer = EqualityComparer<T>.Default;
                for (var i = 0; i < span.Length; i++)
                {
                    if (comparer.Equals(source, span[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static T[] Append<T>(this T[] array, T item)
        {
            if (array == null)
            {
                return [item];
            }
            Array.Resize(ref array, array.Length + 1);
            array[^1] = item;

            return array;
        }

        public static T[] Remove<T>(this T[] array, T item)
        {
            if (array is not { Length: > 0 })
            {
                return [];
            }

            if (item is null)
            {
                return Array.FindAll(array, x => x is not null);
            }
            return Array.FindAll(array, x => !item.Equals(x));
        }

        /// <summary>
        /// add item to items when condition is true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="condition"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IList<T> AddIf<T>(this IList<T> items, bool condition, T item)
        {
            items ??= [];
            if (condition)
            {
                items.Add(item);
            }
            return items;
        }
    }
}
