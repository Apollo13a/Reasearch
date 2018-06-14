using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatmanLib.Models
{
    public static class SpaceportLibrary
    {
        public static Spaceport CapeCanaveral
        {
            get
            {
                return new Spaceport { Latitude = 28.5, Altitude = 3, Velocity = 0, Angle = 0 };
            }
        }

        public static Spaceport Baikonur
        {
            get
            {
                return new Spaceport { Latitude = 45.63, Altitude = 200, Velocity = 0, Angle = 0 };
            }
        }
    }
}
