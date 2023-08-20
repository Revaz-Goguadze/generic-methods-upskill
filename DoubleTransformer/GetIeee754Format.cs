using System;
using System.Runtime.InteropServices;
using GenericMethods.Interfaces;

namespace DoubleTransformer
{
    /// <summary>
    /// Transformer class for double.
    /// </summary>
    public class GetIeee754Format : ITransformer<double, string>
    {
        /// <summary>
        /// Transform double value to IEEE754 format <see>
        ///     <cref>https://www.wikiwand.com/en/IEEE_754</cref>
        /// </see>
        /// in the string form.
        /// </summary>
        /// <param name="obj">The double value.</param>
        /// <returns>The IEEE754 format in the string form.</returns>
        public string Transform(double obj)
        {
            DoubleToLongConverter converter = new DoubleToLongConverter(obj);
            long longNumber = converter.LongTerm;
            const int bitsInByte = 8;
            const int bitsCount = sizeof(double) * bitsInByte;
            char[] result = new char[bitsCount];
            result[0] = longNumber < 0 ? '1' : '0';
            for (int i = bitsCount - 2, j = 1; i >= 0; i--, j++)
            {
                result[j] = (longNumber & (1L << i)) != 0 ? '1' : '0';
            }

            return new string(result);
        }

        [StructLayout(LayoutKind.Explicit)]
        private readonly struct DoubleToLongConverter
        {
            [field: FieldOffset(0)]
            public readonly long LongTerm;

            [FieldOffset(0)]
            private readonly double doubleTerm;

            public DoubleToLongConverter(double doubleTerm)
                : this() => this.doubleTerm = doubleTerm;
        }
    }
}
