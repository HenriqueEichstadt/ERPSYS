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
                            dbEntity["ID"] = reader["ID"];
                            dbEntity["SENHA"] = reader["SENHA"];
                            dbEntity["APELIDO"] = reader["APELIDO"];
                            results.Add(dbEntity);
                        }
                    }

                        /*using (var reader = _cmd.ExecuteReader(CommandBehavior.Default))
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    var index = reader.GetOrdinal(i);
                                    var item = reader.GetValue(index);
                                    reader
                                }   
                            }
                            
                            
                            int ordinal = reader.GetOrdinal("SENHA");
                            var senha = reader.GetValue(ordinal);
                            string nome = "teste";
                        }*/
                    

                  
                    return null;
                }
            }
            finally
            {
                // Fecha o datareader
                //reader?.Close();
                // Fecha a conexão
                //_sqlConnection?.Close();
            }
        }

        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection(Application.DbConnectionString);
            _sqlConnection.Open();
        }
    }
}