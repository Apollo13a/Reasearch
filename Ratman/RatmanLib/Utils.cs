namespace RatmanLib
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public static class Utils
    {
        public static string ToLogMessage(this object obj)
        {
            var log = new StringBuilder();
            var type = obj.GetType();

            log.AppendLine($"----------- {type.Name} -----------");

            var props = (from pi in type.GetProperties(BindingFlags.Instance | BindingFlags.Public) orderby pi.Name select pi).ToArray();
            foreach (var propertyInfo in props)
            {
                var val = propertyInfo.GetValue(obj);
                string str;
                if (val is double[])
                {
                    var array = (double[])val;
                    str = $"[{string.Join("; ", array)}]";
                }
                else
                {
                    str = val == null ? "NULL" : val.ToString();
                }

                log.AppendLine($"{propertyInfo.Name} = '{str}'");
            }

            log.AppendLine($"----------- {type.Name} -----------");

            return log.ToString();
        }

        public static T[] GetColumn<T>(this T[,] array, int columnIndex)
        {
            int rowCount = array.GetLength(0);
            T[] column = new T[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                column[i] = array[i, columnIndex];
            }

            return column;
        }

        public static T[][] GetColumns<T>(this T[,] array)
        {
            int rowCount = array.GetLength(0);
            int columnCount = array.GetLength(1);
            T[][] columns = new T[columnCount][];
            for (int j = 0; j < columnCount; j++)
            {
                T[] column = new T[rowCount];
                columns[j] = column;
                for (int i = 0; i < rowCount; i++)
                {
                    column[i] = array[i, j];
                }
            }

            return columns;
        }

    }
}
