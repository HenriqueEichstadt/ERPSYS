using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Common
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
                OpenConnection();
                _cmd = new SqlCommand(_query, _sqlConnection);
                reader = _cmd.ExecuteReader();
                return reader;
            }
            finally
            {/*
                // Fecha o datareader
                if (reader != null)
                {
                    reader.Close();
                }

                // Fecha a conexão
                if (_sqlConnection != null)
                {
                    _sqlConnection.Close();
                }*/
            }
        }

        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection(Startup.ConnectionString);
            _sqlConnection.Open();
        }

    }
}
