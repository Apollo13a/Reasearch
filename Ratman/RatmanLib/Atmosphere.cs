using MathNet.Numerics;
using MathNet.Numerics.Interpolation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatmanLib
{
    public enum AtmosphereType
    {
        Ratman = 0,
        NASA = 1,
        GOST = 2,
        NASAAndGOSTv1 = 3,
        NASAAndGOSTv2 = 4
    }

    public class Atmosphere
    {
        private static readonly double[,] gostAtmosphere = new double[,]
            {
                { -2000, 1.4782 },
                { -1500, 1.4114 },
                { -1000, 1.347 },
                { -500, 1.2849 },
                { 0, 1.225 },
                { 500, 1.1673 },
                { 1000, 1.1117 },
                { 1500, 1.0581 },
                { 2000, 1.0065 },
                { 2500, 0.9569 },
                { 3000, 0.9093 },
                { 4000, 0.8194 },
                { 5000, 0.7365 },
                { 6000, 0.6601 },
                { 7000, 0.59 },
                { 8000, 0.5258 },
                { 9000, 0.4671 },
                { 10000, 0.4135 },
                { 11000, 0.3648 },
                { 12000, 0.3119 },
                { 14000, 0.2279 },
                { 16000, 0.1665 },
                { 18000, 0.1216 },
                { 20000, 0.0889 },
                { 24000, 0.0469 },
                { 28000, 0.0251 },
                { 32000, 0.0136 },
                { 36000, 7.26e-3 },
                { 40000, 4.00e-3 },
                { 50000, 1.03e-3 },
                { 60000, 3.00e-4 },
                { 80000, 1.85e-5 },
                { 100000, 5.55e-7 },
                { 150000, 2.00e-9 },
                { 200000, 2.52e-10 },
                { 300000, 1.92e-11 },
                { 500000, 5.21e-13 },
                { 700000, 3.07e-14 },
                { 1000000, 3.56e-15 }
            };

        private static readonly IInterpolation gostInterpolation;

        static Atmosphere()
        {
            gostInterpolation = Interpolate.Linear(gostAtmosphere.GetColumn(0), gostAtmosphere.GetColumn(1));
        }

        public AtmosphereType Type { get; set; }

        /// <summary>
        /// Air density, 
        /// </summary>
        public double AirDensity
        {
            get
            {
                switch (Type)
                {
                    case AtmosphereType.Ratman:
                        return 1.29;

                    case AtmosphereType.GOST:
                        return 1.225;

                    case AtmosphereType.NASA:
                    case AtmosphereType.NASAAndGOSTv1:
                    case AtmosphereType.NASAAndGOSTv2:
                        return 1.226613787;
                }

                return 0.0;
            }
        }

        public double GetTemperature(double altitude)
        {
            switch (Type)
            {
                case AtmosphereType.NASA:
                case AtmosphereType.NASAAndGOSTv1:
                case AtmosphereType.NASAAndGOSTv2:
                    return GetTemperatureNASA(altitude);

                case AtmosphereType.Ratman:
                case AtmosphereType.GOST:
                    // TODO
                    return 0.0;
            }

            return 0.0;
        }

        public double GetDensity(double altitude)
        {
            switch (Type)
            {
                case AtmosphereType.NASA:
                case AtmosphereType.NASAAndGOSTv1:
                case AtmosphereType.NASAAndGOSTv2:
                    return GetDensityNASA(altitude);

                case AtmosphereType.GOST:
                    return GetDensityGOST(altitude);

                case AtmosphereType.Ratman:
                    // TODO
                    return 0.0;
            }

            return 0.0;
        }

        private double GetTemperatureNASA(double altitude)
        {
            double result;
            if (altitude < 11000)
            {
                result = 15.04 - 0.00649 * altitude;
            }
            else if (altitude < 25000)
            {
                result = -56.46;
            }
            else
            {
                result = -131.21 + 0.00299 * altitude;
            }

            return result;
        }

        private double GetDensityNASA(double altitude)
        {
            double p;
            var t = GetTemperatureNASA(altitude);

            if (altitude < 11000)
            {
                p = 101.29 * Math.Pow((t + 273.1) / 288.08, 5.256);
            }
            else if (altitude < 25000)
            {
                p = 22.65 * Math.Exp(1.73 - 0.000157 * altitude);
            }
            else
            {
                p = 2.488 * Math.Pow((t + 273.1) / 216.6, -11.388);
            }

            var density = p / (0.2869 * (t + 273.1)) / 1.226613787;

            if (Type == AtmosphereType.NASAAndGOSTv1)
            {
                if (altitude > 80000 && altitude <= 100000)
                {
                    density = 0.000001;
                }
                else if (altitude > 100000 && altitude <= 150000)
                {
                    density = 0.00000001;
                }
                else if (altitude > 150000 && altitude <= 200000)
                {
                    density = 0.0000000005;
                }
                else if (altitude > 200000 && altitude <= 300000)
                {
                    density = 0.00000000005;
                }
            }
            else if (Type == AtmosphereType.NASAAndGOSTv2)
            {
                if (altitude > 80000)
                {
                    density = GetDensityGOST(altitude);
                }
            }

            return density;
        }

        private double GetDensityGOST(double altitude)
        {
            return gostInterpolation.Interpolate(altitude);
        }
    }
}
