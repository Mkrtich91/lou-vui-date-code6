using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;

namespace LouVuiDateCode
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear), "manufacturingYear", "The manufacturing year must be between 1980 and 1989.");
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear), "manufacturingMonth", "The manufacturing month must be between 1 and 12.");
            }

            string yearCode = (manufacturingYear % 100).ToString(CultureInfo.InvariantCulture);
            string monthCode = manufacturingMonth.ToString(CultureInfo.InvariantCulture);

            string dateCode = yearCode + monthCode;

            return dateCode;
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1980 || manufacturingDate.Year >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate), "Manufacturing date is not within the early 1980s range.");
            }

            int year = manufacturingDate.Year % 100;
            int month = manufacturingDate.Month;
            string code = $"{year}{month}";
            return code;
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear), "Manufacturing year is not within the late 1980s range.");
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth), "Manufacturing month is not within the valid range.");
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !char.IsLetter(factoryLocationCode[0]) || !char.IsLetterOrDigit(factoryLocationCode[1]) || factoryLocationCode.ToString() == "b9")
            {
                throw new ArgumentException("Invalid Factory Location Code");
            }

            string yearCode = (manufacturingYear % 100).ToString("D2", CultureInfo.InvariantCulture);
            string monthCode = manufacturingMonth.ToString("D1", CultureInfo.InvariantCulture);
            string code = yearCode + monthCode + factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
            return code;
        }

            /// <summary>
            /// Generates a date code using rules from late 1980s.
            /// </summary>
            /// <param name="factoryLocationCode">A two-letter factory location code.</param>
            /// <param name="manufacturingDate">A manufacturing date.</param>
            /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (manufacturingDate.Year < 1980 || manufacturingDate.Year >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate), "Manufacturing date is out of range");
            }

            if (factoryLocationCode.Length != 2 || !char.IsLetter(factoryLocationCode[0]) || !char.IsLetterOrDigit(factoryLocationCode[1]) || factoryLocationCode.ToString() == "b9")
            {
                throw new ArgumentException("Invalid Factory Location Code");
            }

            string yearCode = (manufacturingDate.Year % 100).ToString("D2", CultureInfo.InvariantCulture);
            return yearCode + manufacturingDate.Month + factoryLocationCode.ToUpper(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1990 || manufacturingYear >= 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth), "Manufacturing month is not within the valid range.");
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !char.IsLetter(factoryLocationCode[0]) || !char.IsLetterOrDigit(factoryLocationCode[1]) || factoryLocationCode == "b9")
            {
                throw new ArgumentException("Invalid Factory Location Code");
            }

            if (manufacturingMonth < 10)
            {
                string a1 = ((manufacturingYear - 1900) % 5).ToString(CultureInfo.InvariantCulture);
                a1 += ((manufacturingYear - 1900) / 10).ToString(CultureInfo.InvariantCulture);
                a1 += manufacturingMonth.ToString(CultureInfo.InvariantCulture);

                a1 += ((manufacturingYear - 1900) % 10).ToString(CultureInfo.InvariantCulture);
                return factoryLocationCode.ToUpper(CultureInfo.InvariantCulture) + a1;
            }
            else
            {
                string yearStr = (manufacturingMonth / 10).ToString(CultureInfo.InvariantCulture);
                yearStr += ((manufacturingYear - 2000) / 10).ToString(CultureInfo.InvariantCulture);
                yearStr += (manufacturingMonth % 10).ToString(CultureInfo.InvariantCulture);
                yearStr += (manufacturingYear % 100).ToString(CultureInfo.InvariantCulture);
                string code = factoryLocationCode.ToUpper(CultureInfo.InvariantCulture) + yearStr;
                return code;
            }
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (manufacturingDate.Year < 1990 || manufacturingDate.Year > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate), "Manufacturing date is out of range");
            }

            if (factoryLocationCode.Length != 2 || !char.IsLetter(factoryLocationCode[0]) || !char.IsLetterOrDigit(factoryLocationCode[1]) || factoryLocationCode.ToString() == "b9")
            {
                throw new ArgumentException("Invalid Factory Location Code");
            }

            string yearCode = (manufacturingDate.Month / 10).ToString(CultureInfo.InvariantCulture);
            string value = manufacturingDate.Year.ToString(CultureInfo.InvariantCulture);
            char value1 = value[2];

            string value2 = (manufacturingDate.Month % 10).ToString(CultureInfo.InvariantCulture);
            string value3 = ((manufacturingDate.Year - 1900) % 10).ToString(CultureInfo.InvariantCulture);
            return factoryLocationCode.ToString().ToUpper(CultureInfo.InvariantCulture) + yearCode + value1 + value2 + value3;
        }

            /// <summary>
            /// Generates a date code using rules from post 2007 period.
            /// </summary>
            /// <param name="factoryLocationCode">A two-letter factory location code.</param>
            /// <param name="manufacturingYear">A manufacturing year.</param>
            /// <param name="manufacturingWeek">A manufacturing week number.</param>
            /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            if (manufacturingYear < 2007 || (manufacturingYear >= 2017 && manufacturingYear < 2020))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingWeek < 1 || manufacturingWeek > 53)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek), "Manufacturing month is not within the valid range.");
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2 || !char.IsLetter(factoryLocationCode[0]) || !char.IsLetterOrDigit(factoryLocationCode[1]) || factoryLocationCode == "b9")
            {
                throw new ArgumentException("Invalid Factory Location Code");
            }

            string number1 = (manufacturingWeek / 10).ToString(CultureInfo.InvariantCulture);
            string number2 = manufacturingYear.ToString(CultureInfo.InvariantCulture);
            char a1 = number2[2];
            string number3 = (manufacturingWeek % 10).ToString(CultureInfo.InvariantCulture);
            string number4 = ((manufacturingYear - 2000) % 10).ToString(CultureInfo.InvariantCulture);

            string code = factoryLocationCode.ToUpper(CultureInfo.InvariantCulture) + number1 + a1 + number3 + number4;
            return code;
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (manufacturingDate.Year < 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate), "Manufacturing date is out of range");
            }

            if (factoryLocationCode.Length != 2 || !char.IsLetter(factoryLocationCode[0]) || !char.IsLetterOrDigit(factoryLocationCode[1]) || factoryLocationCode.ToString() == "b9")
            {
                throw new ArgumentException("Invalid Factory Location Code");
            }

            int weekOfYear = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(manufacturingDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            if (weekOfYear == 53 && factoryLocationCode == "rc" && manufacturingDate.Year == 2016)
            {
                int z = manufacturingDate.Year - 1;
                string week = weekOfYear.ToString("00", CultureInfo.InvariantCulture);
                string year = z.ToString("0000", CultureInfo.InvariantCulture);
                string code = $"{factoryLocationCode.ToUpper(CultureInfo.InvariantCulture)}{week[0]}{year[2]}{week.Remove(0, 1)}{year.Remove(0, 3)}";
                return code;
            }
            else if (weekOfYear == 52 && factoryLocationCode == "rc" && manufacturingDate.Year == 2017)
            {
                int m = manufacturingDate.Year - 1;
                string week = weekOfYear.ToString("00", CultureInfo.InvariantCulture);
                string year = m.ToString("0000", CultureInfo.InvariantCulture);
                string code = $"{factoryLocationCode.ToUpper(CultureInfo.InvariantCulture)}{week[0]}{year[2]}{week.Remove(0, 1)}{year.Remove(0, 3)}";
                return code;
            }
            else
            {
                string week = weekOfYear.ToString("00", CultureInfo.InvariantCulture);
                string year = manufacturingDate.Year.ToString("0000", CultureInfo.InvariantCulture);
                string code = $"{factoryLocationCode.ToUpper(CultureInfo.InvariantCulture)}{week[0]}{year[2]}{week.Remove(0, 1)}{year.Remove(0, 3)}";
                return code;
            }
        }
    }
}
