using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatmanLib
{
    public class Constants
    {
        /// <summary>
        /// Gravity of Earth standard, m/s^2
        /// </summary>
        public const double GravityOfEarthStandard = 9.8068;

        /// <summary>
        /// Gravity of Earth polar, m/s^2
        /// </summary>
        public const double GravityOfEarthPolar = 9.8322;

        /// <summary>
        /// Earth radius, km
        /// </summary>
        public const double EarthRadius = 6378.0;

        /// <summary>
        /// Mu, 
        /// </summary>
        public const double Mu = GravityOfEarthStandard * EarthRadius * EarthRadius * 1000000.0;

        public string GetLogMessage()
        {
            return string.Format(@"------------- Constants -------------
g (stand) (m/s^2) = {0}
g (polar) (m/s^2) = {1}
Earth radius (km) = {2}
Mu = {3}
------------- Constants -------------",
                GravityOfEarthStandard,
                GravityOfEarthPolar,
                EarthRadius,
                Mu);
        }

    }
}
