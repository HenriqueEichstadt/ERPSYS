using System;

namespace ERPSYS.Common
{
    public class ColumnDb
    {
        public string Name { get; set; }
        public int Ordinal { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }

        public string GetString()
        {
            return Convert.ToString(Value);
        }
        public int GetInt32()
        {
            return Convert.ToInt32(Value);
        }

        public bool GetBoolean()
         {
             return Convert.ToBoolean(Value);
         }

         public byte GetByte()
         {
             return Convert.ToByte(Value);
         }

         public char GetChar()
         {
             return Convert.ToChar(Value);
         }

         public short GetInt16()
         {
             return Convert.ToInt16(Value);
         }

         public long GetInt64()
         {
             return Convert.ToInt64(Value);
         }

         public float GetFloat()
         {
             return Convert.ToSingle(Value);
         }

         public double GetDouble()
         {
             return Convert.ToDouble(Value);
         }

         public Decimal GetDecimal()
         {
             return Convert.ToDecimal(Value);
         }

         public DateTime GetDateTime()
         {
             return Convert.ToDateTime(Value);
         }

         
    }
}