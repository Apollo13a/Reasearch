using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatmanLib
{
    public class OrbitInput
    {
        /// <summary>
        /// Perigee, km
        /// </summary>
        public double Perigee
        {
            get;
            set;
        }

        /// <summary>
        /// Apogee, km
        /// </summary>
        public double Apogee
        {
            get;
            set;
        }

        /// <summary>
        /// Inclination, deg
        /// </summary>
        public double Inclination
        {
            get;
            set;
        }

        /// <summary>
        /// Get period, min
        /// </summary>
        /// <param name="gPolar">Gravity of Earth polar, m/s^2</param>
        /// <param name="earthRadius">Earth radius, m</param>
        /// <returns>Period, min</returns>
        public double GetPeriod(double gPolar, double earthRadius)
        {
            return Math.PI * Math.Sqrt(1000.0 * Math.Pow(2.0 * earthRadius + Perigee + Apogee, 3.0) / (2.0 * gPolar)) / earthRadius / 60.0;
        }

        /// <summary>
        /// Get Earth rotation gain, m/s
        /// </summary>
        /// <param name="earthRadius">Earth radius, m</param>
        /// <returns>Earth rotation gain, m/s</returns>
        public double GetEarthRotationGain(double earthRadius)
        {
            return 2.0 * 1000.0 * Math.PI * earthRadius / 24.0 / 3600.0 * Math.Cos(Math.PI / 180.0 * Inclination);
        }

        /// <summary>
        /// Get Perigee velocity (absolute), m/s
        /// </summary>
        /// <param name="gStandard">Gravity of Earth standard, m/s^2</param>
        /// <param name="earthRadius">Earth radius, m</param>
        /// <returns>Perigee velocity (absolute), m/s</returns>
        public double GetPerigeeVelocityAbsolute(double gStandard, double earthRadius)
        {
            return Math.Sqrt(2.0 * 1000.0 * gStandard * earthRadius * (Apogee + earthRadius) / (earthRadius + Perigee) * earthRadius / (2.0 * earthRadius + Perigee + Apogee));
        }

        /// <summary>
        /// Get Perigee velocity (relative), m/s
        /// </summary>
        /// <param name="gStandard">Gravity of Earth standard, m/s^2</param>
        /// <param name="earthRadius">Earth radius, m</param>
        /// <returns>Perigee velocity (relative), m/s</returns>
        public double GetPerigeeVelocityRelative(double gStandard, double earthRadius)
        {
            return GetPerigeeVelocityAbsolute(gStandard, earthRadius) - GetEarthRotationGain(earthRadius);
        }

        /// <summary>
        /// Get Apogee velocity (absolute), m/s
        /// </summary>
        /// <param name="gStandard">Gravity of Earth standard, m/s^2</param>
        /// <param name="earthRadius">Earth radius, m</param>
        /// <returns>Apogee velocity (absolute), m/s</returns>
        public double GetApogeeVelocityAbsolute(double gStandard, double earthRadius)
        {
            return Math.Sqrt(2.0 * 1000.0 * gStandard * earthRadius * (Perigee + earthRadius) / (earthRadius + Apogee) * earthRadius / (2.0 * earthRadius + Perigee + Apogee));
        }

        /// <summary>
        /// Get Apogee velocity (relative), m/s
        /// </summary>
        /// <param name="gStandard">Gravity of Earth standard, m/s^2</param>
        /// <param name="earthRadius">Earth radius, m</param>
        /// <returns>Apogee velocity (relative), m/s</returns>
        public double GetApogeeVelocityRelative(double gStandard, double earthRadius)
        {
            return GetApogeeVelocityAbsolute(gStandard, earthRadius) - GetEarthRotationGain(earthRadius);
        }

        public string GetLogMessage()
        {
            return string.Format(@"------------- Orbit -----------------
Perigee (km) = {0}
Apogee (km) = {1}
Inclination (deg) = {2}
------------- Orbit -----------------",
                Perigee,
                Apogee,
                Inclination);
        }

    }
}
