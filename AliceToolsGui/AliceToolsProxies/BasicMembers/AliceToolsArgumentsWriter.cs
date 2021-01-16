// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Text;

using AliceToolsGui.AliceToolsProxies.InternalMembers;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represent a writer for alice-tools arguments building.
    /// </summary>
    /// <remarks>
    /// NEVER initialize this struct directly.
    /// <para>
    /// When appending argument string, white space char (0x20) is auto added. 
    /// </para>
    /// </remarks>
#pragma warning disable CA1815 // Override equals and operator equals on value types
    public readonly ref struct AliceToolsArgumentsWriter
#pragma warning restore CA1815 // Override equals and operator equals on value types
    {
        private const int MAX_ARGUMENTS_LENGTH = 2080;

        private static readonly object s_flagsTypeID = new FlagsAttribute().TypeId;

        private static readonly ConcurrentBag<StringBuilder> s_sbPool = new ConcurrentBag<StringBuilder>();

        internal readonly StringBuilder _innerStringBuilder;

#pragma warning disable IDE0060
        internal AliceToolsArgumentsWriter(int fakeArgument) =>
#pragma warning restore IDE0060
            _innerStringBuilder = s_sbPool.TryTake(out StringBuilder sb) ? sb : new StringBuilder(MAX_ARGUMENTS_LENGTH, MAX_ARGUMENTS_LENGTH);


        /// <summary>
        /// Writes <see cref="string"/> value to writter.
        /// </summary>
        /// <param name="value"><see cref="string"/> value to be written.</param>
        /// <exception cref="InvalidOperationException">This instance is initialized by default constructor.</exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> is null or empty or only contains white space.</exception>
        /// <exception cref="InvalidOperationException">The length of arguments is greater than 2080.</exception>
        public void Write(string value)
        {
            EnsureSBNotNull();
            try
            {
                lock (_innerStringBuilder)
                {
                    value.EnsureArgumentNullOrWhiteSpace(nameof(value));
                    if (_innerStringBuilder[_innerStringBuilder.Length - 1] != ' ')
                    {
                        _innerStringBuilder.Append(' ');
                    }
                    _innerStringBuilder.Append(value);
                }
            }
            catch
            {
                throw new InvalidOperationException("The length of arguments is greater than 2080.");
            }
        }

        /// <summary>
        /// Writes <see cref="Enum"/> value to writter.
        /// </summary>
        /// <typeparam name="TEnum"><see cref="Enum"/> type.</typeparam>
        /// <param name="enumValue"><see cref="Enum"/> value to be written.</param>
        /// <exception cref="InvalidOperationException">This instance is initialized by default constructor.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="enumValue"/> is not defined in enum.</exception>
        /// <remarks>
        ///  If the fields in <typeparamref name="TEnum"/> has <see cref="AliceToolsEnumArgumentAttribute"/> attribute,
        ///  this method will append specified <see cref="AliceToolsEnumArgumentAttribute.Name"/>;
        ///  <para>Otherwise, use <see cref="Enum.ToString()"/> method.</para>
        ///  If specified <typeparamref name="TEnum"/> has <see cref="FlagsAttribute"/> attribute,
        ///  this method will append every value contained in <paramref name="enumValue"/> to writter.
        ///  <para>See also: <seealso cref="AliceToolsEnumArgumentAttribute"/></para>
        /// </remarks>
        public void Write<TEnum>(TEnum enumValue) where TEnum : struct, Enum
        {
            EnsureSBNotNull();

            Type type = enumValue.GetType();

            object flagAttr = type.GetCustomAttributes(true)
                                  .FirstOrDefault(a => (a as Attribute)
                                  .TypeId.Equals(s_flagsTypeID));

            if (flagAttr == null) // not flags enum.
            {
                WriteEnum(enumValue, type);
                return;
            }
            Array enumValues = Enum.GetValues(type);

            for (int i = 0; i < enumValues.Length; i++)
            {
                var value = (TEnum)enumValues.GetValue(i);
                if (enumValue.HasFlag(value))
                {
                    WriteEnum(value, type);
                }
            }
        }



        internal void Release() => s_sbPool.Add(_innerStringBuilder.Clear());

        /// <summary>
        /// Get the <see cref="string"/> of written arguments.
        /// </summary>
        /// <returns>The <see cref="string"/> of written arguments.</returns>
        public override string ToString() => EnsureSBNotNull().ToString();


        private void WriteEnum<T>(T enumValue, Type typeOfT) where T : struct, Enum
        {
            MemberInfo mi = typeOfT.GetMember(enumValue.ToString())
                                   .FirstOrDefault() ?? throw new ArgumentOutOfRangeException(nameof(enumValue));
            AliceToolsEnumArgumentAttribute enmuAttri = mi.GetCustomAttribute<AliceToolsEnumArgumentAttribute>();
            if (enmuAttri == null)
            {
                Write(enumValue.ToString());
            }
            else if (!string.IsNullOrWhiteSpace(enmuAttri.Name))
            {
                Write(enmuAttri.Name);
            }
        }

        private StringBuilder EnsureSBNotNull()
        {
            if (_innerStringBuilder == null)
            {
                throw new InvalidOperationException("This instance is initialized by default constructor.");
            }
            return _innerStringBuilder;
        }


    }
}
