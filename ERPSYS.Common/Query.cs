using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.Common
{
    public class Query
    {
        //public Parameter Parameters { get; set; }
        private SqlConnection _sqlConnection;
        private SqlCommand _cmd;
        private SqlDataReader reader;
        private string _query;

        public Query(string query)
        {
            // Parameters = new Parameter();
            _query = query;
        }

        public void AddParameter(string parameter, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameter;
            param.Value = value;
            _cmd.Parameters.Add(param);
        }

        public List<DbEntity> Execute()
        {
            List<DbEntity> results = new List<DbEntity>();
            
            try
            {
                using (var connection = new SqlConnection(Application.DbConnectionString))
                {
                    connection.Open();
                    _cmd = new SqlCommand(_query, connection);

                    using (var reader = _cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DbEntity dbEntity = new DbEntity();
                            for (int field = 0; field < reader.FieldCount; field++)
                            {
                                var columnName = reader.GetName(field);
                                dbEntity[columnName].Name = columnName;
                                dbEntity[columnName].Value = reader[columnName];
                                dbEntity[columnName].Type = reader[columnName].GetType();
                            }
                            results.Add(dbEntity);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            catch(SqlException sqlEx)
            {
                throw new Exception("Erro ao executar comando SQL" + sqlEx.StackTrace);
            }

            return results;
        }

        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection(Application.DbConnectionString);
            _sqlConnection.Open();
        }
    }
}