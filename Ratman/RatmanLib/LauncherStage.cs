using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatmanLib
{
    public class LauncherStage
    {
        /// <summary>
        /// Stage number
        /// </summary>
        public int Number
        {
            get;
            set;
        }

        /// <summary>
        /// Stage index in arrays
        /// </summary>
        public int Index
        {
            get
            {
                return Number - 1;
            }
        }

        /// <summary>
        /// Full mass, kg
        /// </summary>
        public double FullMass
        {
            get;
            set;
        }

        /// <summary>
        /// Empty mass, kg
        /// </summary>
        public double EmptyMass
        {
            get;
            set;
        }

        /// <summary>
        /// Specific impulse in atmosphere, s
        /// </summary>
        public double IspAtm
        {
            get;
            set;
        }

        /// <summary>
        /// Specific impulse in vacuum, s
        /// </summary>
        public double IspVac
        {
            get;
            set;
        }

        /// <summary>
        /// Thrust in vacuum, t
        /// </summary>
        public double ThrustVac
        {
            get;
            set;
        }

        /// <summary>
        /// Fuel consumption in vacuum in kg/s
        /// </summary>
        public double FuelConsumption
        {
            get
            {
                return ThrustVac * 1000 / IspVac;
            }
        }

        /// <summary>
        /// Sx
        /// </summary>
        public double Sx
        {
            get;
            set;
        }

        /// <summary>
        /// Sy
        /// </summary>
        public double Sy
        {
            get;
            set;
        }

        /// <summary>
        /// Cx
        /// </summary>
        public double Cx
        {
            get;
            set;
        }

        /// <summary>
        /// Cy
        /// </summary>
        public double Cy
        {
            get;
            set;
        }


        public double GetThrottle(int currentStage, double time)
        {
            return currentStage == Number ? 1.0 : 0.0;
        }

        public string GetLogMessage()
        {
            return string.Format(
                "{0} Full mass (kg) = {1} Empty mass = {2} Isp (atm) (s) = {3} Isp (vac) (s) = {4} Thrust (vac) (t) = {5} Fuel consumption (kg/s) = {6} Sx = {7} Sy = {8} Cx = {9} Cy = {10}", 
                Number, 
                FullMass, 
                EmptyMass, 
                IspAtm, 
                IspVac,
                ThrustVac,
                FuelConsumption,
                Sx,
                Sy,
                Cx,
                Cy);
        }
    }
}
