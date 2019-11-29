using System;

namespace ERPSYS.Common
{
    public class ColumnDb
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }

        public string GetString()
        {
            return Convert.ToString(Value);
        }
    }
}