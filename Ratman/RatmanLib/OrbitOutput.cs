namespace RatmanLib
{
    public class OrbitOutput
    {
        public double Perigee { get; set; }

        public double Apogee { get; set; }

        public double Vxabs { get; set; }

        public double Vabs { get; set; }

        public double E { get; set; }

        public double M { get; set; }

        public double R1 { get; set; }

        public double R2 { get; set; }

        public string GetLogMessage()
        {
            return string.Format(@"------------- OrbitOutput ------------
perigee = {0}
apogee = {1}
Vx (abs) = {2}
V (abs) = {3}
E = {4}
M = {5}
R1 = {6}
R2 = {7}
------------- OrbitOutput ------------",
                Perigee,
                Apogee,
                Vxabs,
                Vabs,
                E,
                M,
                R1,
                R2);
        }
    }
}
