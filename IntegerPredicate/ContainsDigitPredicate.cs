using System;
using GenericMethods.Interfaces;

namespace IntegerPredicate
{
    /// <summary>
    /// Predicate class for the integer type.
    /// </summary>
    public class ContainsDigitPredicate : IPredicate<int>
    {
        private int digit;

        /// <summary>
        /// Gets or sets digit in the integer number.
        /// </summary>
        public int Digit
        {
            get => this.digit;
            set => this.digit = (value is < 0 or > 9) ? throw new ArgumentOutOfRangeException(nameof(value), "Сan not be less than zero or more then 9.") : value;
        }

        /// <summary>
        /// Determines if a number contains a given digit.
        /// </summary>
        /// <param name="obj">The integer value.</param>
        /// <returns>true if integer value contains given digit; otherwise, false.</returns>
        public bool IsMatch(int obj)
        {
            long longNumber = obj;

            if (this.digit == 0 && longNumber == 0)
            {
                return true;
            }

            longNumber = (longNumber < 0) ? -longNumber : longNumber;

            for (; longNumber != 0; longNumber /= 10)
            {
                if (longNumber % 10 == this.digit)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
