// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceToolsGui.AliceToolsProxies.InternalMembers
{
    internal static class UtilitiesInner
    {
        /// <summary>
        /// Throw if <paramref name="arg"/> is null.
        /// </summary>
        /// <returns><paramref name="arg"/></returns>
        public static T EnsureArgumentNull<T>(this T arg, string argName) where T : class
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argName);
            }
            return arg;
        }

        /// <summary>
        /// Throw if <paramref name="value"/> is not has libiconv friendly name.
        /// </summary>
        /// <param name="value"></param>
        /// <returns><paramref name="value"/></returns>
        public static Encoding EnsurePropertyEncoding(this Encoding value) =>
            (value == null || value.IsLibiconvSupported()) ?
                value :
                throw new NotSupportedException("The Encoding instance set to this property does not have libiconv friendly name.");


        /// <summary>
        /// if the bool expression for ensuring property is true, throw an exception.
        /// </summary>
        /// <param name="trueThrow">bool expression</param>
        /// <param name="propertyName">property Name</param>
        public static void TrueThrowPropertyInvalidOperation(this bool trueThrow, string propertyName)
        {
            if (trueThrow)
            {
                throw new InvalidOperationException($"{propertyName} returns invalid value.");
            }
        }

        public static string EnsureArgumentNullOrWhiteSpace(this string arg, string argName)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                throw new ArgumentException($"{argName} is null or empty or only contains white space.", argName);
            }
            return arg;
        }


    }
}
