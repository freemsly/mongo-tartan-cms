﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Used to modify properties of an object returned from a LINQ query
        /// </summary>
        public static TSource Set<TSource>(this TSource input, 
            Action<TSource> updater)
        {
            updater(input);
            return input;
        }
    }
}
