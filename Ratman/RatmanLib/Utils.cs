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
    }
}
