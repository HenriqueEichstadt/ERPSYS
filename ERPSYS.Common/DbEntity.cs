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
    public class DbEntity : IDataReader
    {
        private SqlDataReader _sqlDataReader;

        public void SetDataReader(SqlDataReader reader)
        {
            _sqlDataReader = reader;
        }
        
        public void Dispose()
        {
            _sqlDataReader?.Dispose();
        }

        public T ConvertToModel<T>() where T : new()
        {
            if(_sqlDataReader == null)
                throw new Exception($"Nenhuma consulta foi realizada");
            
            var listObj = new List<T>();
            T obj = new T();

            var sqlDataReaderColumns = Enumerable.Range(0, _sqlDataReader.FieldCount).Select(_sqlDataReader.GetName).ToList();
            
            foreach (var column in sqlDataReaderColumns)
            {
                object info = _sqlDataReader[column];
                PropertyInfo property = obj.GetType().GetProperty(column);
                property?.SetValue(obj, info);
            }
            return obj;
        }
        
        public bool GetBoolean(int i)
        {
            return _sqlDataReader.GetBoolean(i);
        }

        public byte GetByte(int i)
        {
            return _sqlDataReader.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return _sqlDataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return _sqlDataReader.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return _sqlDataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            return _sqlDataReader.GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return _sqlDataReader.GetDataTypeName(i);
        }

        public DateTime GetDateTime(int i)
        {
            return _sqlDataReader.GetDateTime(i);
        }

        public decimal GetDecimal(int i)
        {
            return _sqlDataReader.GetDecimal(i);
        }

        public double GetDouble(int i)
        {
            return _sqlDataReader.GetDouble(i);
        }

        public Type GetFieldType(int i)
        {
            return _sqlDataReader.GetFieldType(i);
        }

        public float GetFloat(int i)
        {
            return _sqlDataReader.GetFloat(i);
        }

        public Guid GetGuid(int i)
        {
            return _sqlDataReader.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            return _sqlDataReader.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            return _sqlDataReader.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            return _sqlDataReader.GetInt64(i);
        }

        public string GetName(int i)
        {
            return _sqlDataReader.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return _sqlDataReader.GetOrdinal(name);
        }

        public string GetString(int i)
        {
            return _sqlDataReader.GetString(i);
        }

        public object GetValue(int i)
        {
            return _sqlDataReader.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            return _sqlDataReader.GetValues(values);
        }

        public bool IsDBNull(int i)
        {
            return _sqlDataReader.IsDBNull(i);
        }

        public int FieldCount => _sqlDataReader.FieldCount;

        public object this[int i] => _sqlDataReader[i];

        public object this[string name] => _sqlDataReader[name];

        public void Close()
        {
            _sqlDataReader.Close();
        }

        public DataTable GetSchemaTable()
        {
            return _sqlDataReader.GetSchemaTable();
        }

        public bool NextResult()
        {
            return _sqlDataReader.NextResult();
        }

        public bool Read()
        {
            return _sqlDataReader.Read();
        }

        public int Depth => _sqlDataReader.Depth;
        public bool IsClosed => _sqlDataReader.IsClosed;
        public int RecordsAffected => _sqlDataReader.RecordsAffected;
    }
}