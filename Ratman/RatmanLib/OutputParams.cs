namespace RatmanLib
{
    public class OutputParams
    {
        public double T { get; set; }

        public int Index { get; set; }

        public double CV { get; set; }

        public double CVdelta { get; set; }

        public double V { get; set; }

        public double Vx { get; set; }

        public double Vy { get; set; }

        public double H { get; set; }

        public int Stage { get; set; }

        public double CVreserve { get; set; }

        public double MassT { get; set; }

        public double Pitch { get; set; }

        public string GetLogMessage()
        {
            return string.Format(@"------------- OutputParams ------------
T = {0}
Index = {1}
CV = {2}
V = {3}
Vx = {4}
Vy = {5}
H (km) = {6}
Stage = {7}
Mass (t) = {8}
Pitch = {9}
------------- OutputParams ------------",
                T,
                Index,
                CV,
                V,
                Vx,
                Vy,
                H,
                Stage,
                MassT,
                Pitch);
        }
    }
}
