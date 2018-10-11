using System;

namespace WeightLib
{
    
    /// <summary>
    /// Static Class with conversion from Grams to Ounces and vice versa. Has to 1/100,000 margin of error.
    /// </summary>
    public static class Converter
    {/// <summary>
    /// double showing how many grams it takes to make 1 ounce.
    /// </summary>
        private const double GramsPrOunce = 28.34952;

        /// <summary>
        /// converts a weight in grams to ounces.  
        /// </summary>
        /// <param name="grams"></param>
        /// <returns></returns>
        public static double GramsToOunces(double grams)
        {
            return grams / GramsPrOunce;
        }
        /// <summary>
        /// converts a weight in ounces to grams.
        /// </summary>
        /// <param name="ounces"></param>
        /// <returns></returns>
        public static double OuncesToGrams(double ounces)
        {
            return ounces * GramsPrOunce;
        }
    }
}
