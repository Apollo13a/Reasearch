using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatmanLib.Models
{
    public static class SpaceportLibrary
    {
        public static Spaceport CapCanaveral
        {
            get
            {
                return new Spaceport { Latitude = 28.5, Altitude = 3, Velocity = 0, Angle = 0 };
            }
        }
    }
}
