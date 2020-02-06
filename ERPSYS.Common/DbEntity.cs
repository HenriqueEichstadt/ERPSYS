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
        private Dictionary<string, ColumnDb> _dbFields = new Dictionary<string, ColumnDb>();
        
        //public SqlDataReader Field => _sqlDataReader;

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

        public ColumnDb this[string field]
        {
            get { return RetornaObjetoCasoExista(field); }
            set => _dbFields.Add(field, value);
        }

        public void SetValue(string field, object value)
        {
            _dbFields.Add(field, value);
        }

        private ColumnDb RetornaObjetoCasoExista(string field)
        {
            if (!_dbFields.ContainsKey(field))
                throw new Exception($"O Campo {field} não foi encontrado na lista de campos da entidade");
                
                return _dbFields[field];
        }

        public object GetValue()
        {
            return null;
        }
    }
}