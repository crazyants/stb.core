/*---------------------------------------------------------------------------------------------
 * Copyright (c) STB Chain. All rights reserved.
 * Licensed under the Source EULA. See License in the project root for license information.
 * Source code : https://github.com/stbchain
 * Website : http://www.soft2b.com/
 *---------------------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace STB.Core
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     解决foreach时可能数据为null的问题
        ///     <example>
        ///         foreach(var item in list.ToNotNull()){ /* ... */ }
        ///     </example>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ie"></param>
        /// <returns></returns>
        public static List<T> ToNotNull<T>(this IEnumerable<T> ie)
        {
            return ie?.ToList() ?? new List<T>();
        }

        /// <summary>
        ///     将集合转换为只读集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            if (source is ReadOnlyCollection<T> readOnlyCollection)
                return readOnlyCollection;
            return new ReadOnlyCollection<T>(source.ToList());
        }

        public static List<object> ToObjectList(this IEnumerable source)
        {
            var list = new List<object>();
            var enumberable = source.GetEnumerator();
            do
            {
                list.Add(enumberable.Current);
            } while (enumberable.MoveNext());
            return list;
        }

        
        public static Func<T, TKey> MehodLambda<T, TKey>(string propertyName)
        {
            var p = Expression.Parameter(typeof(T), "p");
            Expression body = Expression.Property(p, typeof(T).GetTypeInfo().GetProperty(propertyName));
            var lambda = Expression.Lambda<Func<T, TKey>>(body, p);
            return lambda.Compile();
        }
 
        /// <summary>
        ///     Source元素 与 any 是否有交集
        ///     即 Source元素是否包含any元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="any"></param>
        /// <returns></returns>
        public static bool HasAny<T>(this IEnumerable<T> source, IEnumerable<T> any)
        {
            foreach (var item in source)
                if (any.Contains(item))
                    return true;
            return false;
        }

        /// <summary>
        ///     All 是否是 Source的子集
        ///     退出 All是否全部包含在Source元素集中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="all"></param>
        /// <returns></returns>
        public static bool HasAll<T>(this IEnumerable<T> source, IEnumerable<T> all)
        {
            foreach (var item in all)
                if (!source.Contains(item))
                    return false;
            return true;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            var hash = new HashSet<TKey>();
            return source.Where(p => hash.Add(keySelector(p)));
        }
    }
}