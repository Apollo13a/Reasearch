using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatmanLib
{
    public class Spaceport
    {
        /// <summary>
        /// Latitude, deg
        /// </summary>
        public double Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// Altitude, m
        /// </summary>
        public double Altitude
        {
            get;
            set;
        }

        /// <summary>
        /// Velocity, m/s
        /// </summary>
        public double Velocity
        {
            get;
            set;
        }

        /// <summary>
        /// Angle, deg
        /// </summary>
        public double Angle
        {
            get;
            set;
        }

        /// <summary>
        /// Get Earth rotation velocity, 
        /// </summary>
        /// <param name="earthRadius">Earth radius, m</param>
        /// <returns>Earth rotation velocity, </returns>
        public double GetEarthRotationVelocity(double earthRadius)
        {
            return 2.0 * 1000.0 * Math.PI * earthRadius / 24.0 / 3600.0 * Math.Cos(Latitude * Math.PI/180.0);
        }

        public string GetLogMessage()
        {
            return string.Format(@"------------- Spaceport -------------
Latitude (deg) = {0}
Altitude (m) = {1}
Velocity (m/s) = {2}
Angle (deg) = {3}
------------- Spaceport -------------",
                Latitude,
                Altitude,
                Velocity,
                Angle);
        }

    }
}
