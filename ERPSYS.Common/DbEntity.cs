using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ERPSYS.Common
{
    [DataContract]
    [Serializable]
    public class DbEntity
    {
        private SqlDataReader _sqlDataReader;
        private Dictionary<string, object> _dbFields = new Dictionary<string, object>();

        //public SqlDataReader Field => _sqlDataReader;

        public DbEntity()
        {
        }

        public void Dispose()
        {
            _sqlDataReader?.Dispose();
        }

        public T ConvertToModel<T>() where T : new()
        {
            if (_sqlDataReader == null)
                throw new Exception($"Nenhuma consulta foi realizada");

            var listObj = new List<T>();
            T obj = new T();

            var sqlDataReaderColumns =
                Enumerable.Range(0, _sqlDataReader.FieldCount).Select(_sqlDataReader.GetName).ToList();

            foreach (var column in sqlDataReaderColumns)
            {
                object info = _sqlDataReader[column];
                PropertyInfo property = obj.GetType().GetProperty(column);
                property?.SetValue(obj, info);
            }

            return obj;
        }

        public object this[string field]
        {
            get { return RetornaObjetoCasoExista(field); }
            set { _dbFields.Add(field, value); }
        }

        private object RetornaObjetoCasoExista(string field)
        {
            if (!_dbFields.ContainsKey(field))
                throw new Exception("Campo não enocntrado");
                
                return _dbFields[field];
        }

        public object GetValue()
        {
            return null;
        }

        public int GetInt32()
        {
            Convert.ToInt32(this);
        }

       /* int GetValues(object[] values);

        int GetOrdinal(string name);

        bool GetBoolean(int i);

        byte GetByte(int i);

        long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length);

        char GetChar(int i);

        long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length);

        Guid GetGuid(int i);

        short GetInt16(int i);

        

        long GetInt64(int i);

        float GetFloat(int i);

        double GetDouble(int i);

        string GetString(int i);

        Decimal GetDecimal(int i);

        DateTime GetDateTime(int i);

        IDataReader GetData(int i);

        bool IsDBNull(int i);*/
    }
}