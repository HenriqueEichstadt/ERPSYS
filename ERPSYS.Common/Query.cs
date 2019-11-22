using System;
using System.Collections.Generic;
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

        public SqlDataReader Execute()
        {
            try
            {
                using (var connection = new SqlConnection(Application.DbConnectionString))
                {
                    connection.Open();
                    _cmd = new SqlCommand(_query, connection);
                    reader = _cmd.ExecuteReader();
                    //DbEntity dbEntity = new DbEntity();
                    //dbEntity.SetDataReader(reader);
                    return reader;    
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
