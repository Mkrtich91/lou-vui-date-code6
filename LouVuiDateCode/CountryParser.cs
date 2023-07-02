using System;

namespace LouVuiDateCode
{
    public static class CountryParser
    {
        /// <summary>
        /// Gets a an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
        public static Country[] GetCountry(string factoryLocationCode)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            return factoryLocationCode switch
            {
                "A0" or "A1" or "A2" or "AA" or "AH" or "AN" or "AR" or "AS" or "BA" or "BJ" or "BU" or "DR" or "DU" or "DT" or "CO" or "CT" or "CX" or "ET" or "FL" =>
                    new Country[] { Country.France, Country.USA },
                "LW" => new Country[] { Country.France, Country.Spain },
                "MB" or "MI" or "NO" or "RA" or "RI" or "SF" or "SL" or "SN" or "SP" or "SR" or "TJ" or "TH" or "TR" or "TS" or "VI" or "VX" =>
                    new Country[] { Country.France },
                "LP" or "OL" => new Country[] { Country.Germany },
                "BC" or "BO" or "CE" or "FO" or "MA" or "OB" or "RC" or "RE" or "SA" or "TD" =>
                    new Country[] { Country.Italy },
                "CA" or "LO" or "LB" or "LM" or "GI" => new Country[] { Country.Spain },
                "DI" or "FA" => new Country[] { Country.Switzerland },
                "FC" or "FH" or "LA" or "OS" => new Country[] { Country.USA },
                "SD" => new Country[] { Country.USA, Country.France },
                _ => throw new ArgumentException("Invalid factory location code.")
            };
        }
    }
}
