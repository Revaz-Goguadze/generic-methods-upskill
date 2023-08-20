using System;
using System.Collections.Generic;

namespace Comparators
{
    /// <summary>
    /// Comparator class for integer type.
    /// </summary>
    public class IntegerByAbsComparer : IComparer<int>
    {
        /// <summary>
        /// Compares two numbers by absolute value.
        /// </summary>
        /// <param name="x">The first value to compare.</param>
        /// <param name="y">The second value to compare.</param>
        /// <returns>Less than zero if absolute value x is less than absolute value y.
        /// Zero if absolute value x equals absolute value y.
        /// Greater than zero if absolute value x is greater than absolute value y.
        /// </returns>
        public int Compare(int x, int y) => (int)(Math.Abs((long)x) - Math.Abs((long)y));
    }
}
