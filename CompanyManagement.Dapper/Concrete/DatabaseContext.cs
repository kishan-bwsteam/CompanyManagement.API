using Dapper;
using SqlDapper.Abstract;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SqlDapper.Concrete
{
    public class DatabaseContext : IDatabaseContext, IDisposable
    {
        private readonly IDbConnection _dbConnection;

        public DatabaseContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _dbConnection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
        }
        public async Task OpenConnectionAsync()
        {
            if (_dbConnection.State == ConnectionState.Closed)
            {
                if (_dbConnection is SqlConnection sqlConn)
                {
                    await sqlConn.OpenAsync();
                }
                else
                {
                    _dbConnection.Open(); // fallback
                }
            }
        }



        public void CloseConnection()
        {
            if (_dbConnection.State != ConnectionState.Closed)
                _dbConnection.Close();
        }

        public void Dispose()
        {
            CloseConnection();
            _dbConnection.Dispose();
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            await OpenConnectionAsync();
            try
            {
                return await _dbConnection.QueryAsync<T>(sql, param, transaction, commandType: commandType);
            }
            finally
            {
                CloseConnection();
            }
        }

        public async Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            await OpenConnectionAsync();
            try
            {
                return await _dbConnection.QueryAsync(sql, param, transaction, commandType: commandType);
            }
            finally
            {
                CloseConnection();
            }
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            await OpenConnectionAsync();
            try
            {
                return await _dbConnection.QueryMultipleAsync(sql, param, transaction, commandType: commandType);
            }
            finally
            {
                CloseConnection();
            }
        }

        public async Task<IEnumerable<T>> QueryWithExecutionTimeAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            await OpenConnectionAsync();
            try
            {
                return await _dbConnection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
            finally
            {
                CloseConnection();
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(
            string sql,
            Func<TFirst, TSecond, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = null,
            CommandType? commandType = null)
        {
            await OpenConnectionAsync();
            try
            {
                return await _dbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
            }
            finally
            {
                CloseConnection();
            }
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            await OpenConnectionAsync();
            try
            {
                return await _dbConnection.ExecuteAsync(sql, param, transaction, commandType: commandType);
            }
            finally
            {
                CloseConnection();
            }
        }


        public int Execute(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return RunWithConnection(() => _dbConnection.Execute(sql, param, transaction, null, commandType));
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return RunWithConnection(() => _dbConnection.Query<T>(sql, param, transaction, true, null, commandType));
        }

        public IEnumerable<dynamic> Query(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return RunWithConnection(() => _dbConnection.Query(sql, param, transaction, true, null, commandType));
        }

        public SqlMapper.GridReader QueryMultiple(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryMultiple(_dbConnection ,sql, param, transaction, null, commandType);
        }

        public IEnumerable<T> QueryWithExecutionTime<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return RunWithConnection(() => _dbConnection.Query<T>(sql, param, transaction, true, commandTimeout, commandType));
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(
            string sql,
            Func<TFirst, TSecond, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = null,
            CommandType? commandType = null)
        {
            return RunWithConnection(() => _dbConnection.Query(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType));
        }

        private T RunWithConnection<T>(Func<T> query)
        {
            try
            {
                OpenConnection();
                return query();
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
