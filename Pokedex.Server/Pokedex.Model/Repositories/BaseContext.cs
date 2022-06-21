using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Pokedex.Model.Repositories
{
    public class BaseContext : IAsyncDisposable
    {
        private SqlConnection _connection;

        protected BaseContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        protected async Task<DataSet> ExecuteDataSetAsync(string query, Hashtable? parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            if(_connection.State != ConnectionState.Open)
            {
                await _connection.OpenAsync();
            }

            using(var cmd = _connection.CreateCommand())
            {
                cmd.CommandType = commandType;
                cmd.CommandText = query;

                if(parameters != null)
                {
                    foreach(string key in parameters.Keys)
                    {
                        cmd.Parameters.AddWithValue(key, parameters[key]);
                    }
                }

                using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }

        protected async Task<bool> ExecuteQueryAsync(string query, Hashtable? parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            if(_connection.State != ConnectionState.Open)
            {
                await _connection.OpenAsync();
            }

            using(var cmd = _connection.CreateCommand())
            {
                cmd.CommandType = commandType;
                cmd.CommandText = query;

                if (parameters != null)
                {
                    foreach (string key in parameters.Keys)
                    {
                        cmd.Parameters.AddWithValue(key, parameters[key]);
                    }
                }

                var result = await cmd.ExecuteScalarAsync();
                return result != null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if(_connection.State != ConnectionState.Closed)
            {
                await _connection.CloseAsync();
            }

            await _connection.DisposeAsync();
        }
    }
}

