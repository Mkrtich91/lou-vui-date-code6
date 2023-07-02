using System;
using System.Globalization;

namespace LouVuiDateCode
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode), "The date code cannot be null or empty.");
            }

            if (!uint.TryParse("19" + dateCode[..2], out manufacturingYear))
            {
                throw new ArgumentException("Invalid manufacturing year in the date code.", nameof(dateCode));
            }

            if (!uint.TryParse(dateCode[2..], out manufacturingMonth))
            {
                throw new ArgumentException("Invalid manufacturing month in the date code.", nameof(dateCode));
            }

            if (dateCode.Length < 3 || dateCode.Length > 4 || manufacturingMonth < 1 || manufacturingMonth > 12 || manufacturingYear > 1989 || manufacturingYear < 1980)
            {
                throw new ArgumentException("Agument exception!");
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length < 5 || dateCode.Length > 6)
            {
                throw new ArgumentException("Invalid date code.");
            }

            factoryLocationCode = dateCode[(dateCode.Length - 2) ..];

            if (!uint.TryParse("19" + dateCode[..2], out manufacturingYear))
            {
                throw new ArgumentException("Invalid manufacturing year.");
            }

            if (!uint.TryParse(dateCode[2..^2], out manufacturingMonth))
            {
                throw new ArgumentException("Invalid manufacturing month.");
            }

            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentException("error");
            }

            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentException("error");
            }

            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length < 5 || dateCode.Length > 6 || dateCode[1] == '0')
            {
                throw new ArgumentException("Invalid date code.");
            }

            if (dateCode[0] == 'S' || dateCode[0] == 'V')
            {
                factoryLocationCode = dateCode[0..2];
                if (!uint.TryParse("20" + dateCode[3] + dateCode[5], out manufacturingYear))
                {
                    throw new ArgumentException("Invalid manufacturing year.");
                }

                char a = dateCode[2];
                char b = dateCode[4];
                string c = a.ToString() + b.ToString();
                if (!uint.TryParse(c, out manufacturingMonth))
                {
                    throw new ArgumentException("Invalid manufacturing month.");
                }

                if (manufacturingMonth <= 0 || manufacturingMonth > 12)
                {
                    throw new ArgumentException("error1");
                }

                if (manufacturingYear < 1990 || manufacturingYear > 2006)
                {
                    throw new ArgumentException("error5");
                }

                factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
            }
            else
            {
                factoryLocationCode = dateCode[0..2];
                if (!uint.TryParse("19" + dateCode[3] + dateCode[5], out manufacturingYear))
                {
                    throw new ArgumentException("Invalid manufacturing year.");
                }

                char a = dateCode[2];
                char b = dateCode[4];
                string c = a.ToString() + b.ToString();
                if (!uint.TryParse(c, out manufacturingMonth))
                {
                    throw new ArgumentException("Invalid manufacturing month.");
                }

                if (manufacturingMonth <= 0 || manufacturingMonth > 12)
                {
                    throw new ArgumentException("error1");
                }

                if (manufacturingYear < 1990 || manufacturingYear > 2006)
                {
                    throw new ArgumentException("error2");
                }

                factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingWeek"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingWeek">A manufacturing week to return.</param>
        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length <= 5 || (dateCode[0] == 'R' && dateCode[1] != 'C') ^ dateCode == "RI0017")
            {
                throw new ArgumentException("Invalid date code.");
            }

            factoryLocationCode = dateCode[0..2];
            if (!uint.TryParse("20" + dateCode[3] + dateCode[5], out manufacturingYear))
            {
                    throw new ArgumentException("Invalid manufacturing year.");
            }

            char a = dateCode[2];
            char b = dateCode[4];
            string c = a.ToString() + b.ToString();
            if (!uint.TryParse(c, out manufacturingWeek))
            {
                    throw new ArgumentException("Invalid manufacturing month.");
            }

            if (manufacturingWeek < 0 || manufacturingWeek > 53)
            {
                    throw new ArgumentException("error1");
            }

            if (manufacturingYear < 2007)
            {
                    throw new ArgumentException("error2");
            }

            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
        }
    }
}
