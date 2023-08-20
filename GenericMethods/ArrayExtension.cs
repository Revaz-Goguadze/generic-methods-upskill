using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GenericMethods.Interfaces;

[assembly: InternalsVisibleTo("GenericMethods.Tests")]

namespace GenericMethods
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Filters a source array based on a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source array.</typeparam>
        /// <param name="source">The source array.</param>
        /// <param name="predicate">A <see cref="IPredicate{T}"/> to test each element for a condition.</param>
        /// <returns>An array of elements from the source array that satisfy the condition.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source array or predicate is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static TSource[] Filter<TSource>(this TSource[] source, IPredicate<TSource> predicate)
        {
            CheckArrayNull(source);
            CheckObjectNull(predicate);
            CheckArrayEmpty(source);

            var result = new List<TSource>();
            for (var i = 0; i < source.Length; i++)
            {
                var item = source[i];
                if (predicate.IsMatch(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Transforms each element of source array from one type to another type by some rule.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source array.</typeparam>
        /// <typeparam name="TResult">The type of the elements of result array.</typeparam>
        /// <param name="source">The source array.</param>
        /// <param name="transformer">A <see cref="ITransformer{TSource,TResult}"/> that defines the rule of transformation.</param>
        /// <returns>An array, each element of which is transformed.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array or transformer is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static TResult[] Transform<TSource, TResult>(this TSource[] source, ITransformer<TSource, TResult> transformer)
        {
            CheckArrayNull(source);
            CheckObjectNull(transformer);
            CheckArrayEmpty(source);

            var result = new List<TResult>();
            foreach (var item in source)
            {
                result.Add(transformer.Transform(item));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Gets the elements of a sequence in ascending order by using a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">The source array.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
        /// <returns>An ordered by comparer array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when comparer is null, and one or more elements
        /// in array do not implement the <see cref="IComparable{T}"/>  interface.</exception>
        public static TSource[] SortBy<TSource>(this TSource[] source, IComparer<TSource> comparer)
        {
            CheckArrayNull(source);
            CheckObjectNull(comparer);
            CheckArrayEmpty(source);

            foreach (var item in source)
            {
                if (comparer is null && item is not IComparable<TSource>)
                {
                    throw new ArgumentNullException(nameof(comparer), "One or more elements in array do not implement the IComparable interface");
                }
            }

            for (int i = 0; i < source.Length - 1; i++)
            {
                for (int j = 0; j < source.Length - i - 1; j++)
                {
                    if (comparer!.Compare(source[j], source[j + 1]) > 0)
                    {
                        Swap(ref source[j], ref source[j + 1]);
                    }
                }
            }

            return source;
        }

        /// <summary>
        /// Filters the elements of source array based on a specified type.
        /// </summary>
        /// <typeparam name="TResult">Type selector to return.</typeparam>
        /// <param name="source">The source array.</param>
        /// <returns>A array that contains the elements from source that have type TResult.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array length equal to zero.</exception>
        public static TResult[] TypeOf<TResult>(this object[] source)
        {
            CheckArrayNull(source);
            CheckArrayEmpty(source);

            var result = new List<TResult>();

            for (var i = 0; i < source.Length; i++)
            {
                var item = source[i];
                if (item is TResult results)
                {
                    result.Add(results);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Inverts the order of the elements in a array.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of array.</typeparam>
        /// <param name="source">A array of elements to reverse.</param>
        /// <returns>Revers array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array length equal to zero.</exception>
        public static TSource[] Reverse<TSource>(this TSource[] source)
        {
            CheckArrayNull(source);
            CheckArrayEmpty(source);

            int i = 0;
            int j = source.Length - 1;
            while (i < j)
            {
                Swap(ref source[i], ref source[j]);
                i++;
                j--;
            }

            return source;
        }

        /// <summary>
        /// Swaps two objects.
        /// </summary>
        /// <typeparam name="T">The type of parameters.</typeparam>
        /// <param name="left">First object.</param>
        /// <param name="right">Second object.</param>
        internal static void Swap<T>(ref T left, ref T right) => (left, right) = (right, left);

        /// <summary>
        /// Check array for null.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="array">Array for checking.</param>
        /// <exception cref="ArgumentNullException">Null exception.</exception>
        private static void CheckArrayNull<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array is null");
            }
        }

        /// <summary>
        /// Check object for null.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="obj">Object for checking.</param>
        /// <exception cref="ArgumentNullException">Null exception.</exception>
        private static void CheckObjectNull<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object is null");
            }
        }

        /// <summary>
        /// Check object for length.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="array">Array for checking.</param>
        /// <exception cref="ArgumentException">Argument exception.</exception>
        private static void CheckArrayEmpty<T>(T[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array is empty.", nameof(array));
            }
        }
    }
}
