

namespace P01StringBuilder.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    static class InumerableExt
    {
        /// <summary>
        /// My ext method for Sum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T Sum<T>(this List<T> list)
        {
            T sum = (dynamic)0;
            foreach (var item in list)
            {
                sum += (dynamic)item;
            }
            return sum;
            //return list.Sum();
        }
        /// <summary>
        /// My ext Method for Product
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T Product<T>(this List<T> list)
        {
            T product = (dynamic)1;
            foreach (var item in list)
            {
                product *= (dynamic)item;
            }
            return product;
            
        }
        /// <summary>
        /// My ext Method for Min value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T MyMin<T>(this List<T> list)
        {
            return list.Min();
        }
        /// <summary>
        /// My ext Method for MAx value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T MyMax<T>(this List<T> list)
        {
            return list.Max();
        }
        /// <summary>
        /// My Ext method for averadge
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static decimal Averadge<T>(this List<T> list)
        {
            return (decimal)(Sum(list) / (dynamic)list.Count);
        }
    }

}
