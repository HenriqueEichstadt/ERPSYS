using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ERPSYS.Common
{
    [DataContract]
    [Serializable]
    public class DbEntity : IDisposable
    {
        private SqlDataReader _sqlDataReader;


        public DbEntity(SqlDataReader sqlDataReader)
        {
            _sqlDataReader = sqlDataReader;
        }
        
        [DataMember] public object this[string fieldName] => _sqlDataReader[fieldName];

        public void Dispose()
        {
            _sqlDataReader?.Dispose();
        }

        public List<T> ConvertToModel<T>() where T : new()
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
    }
}