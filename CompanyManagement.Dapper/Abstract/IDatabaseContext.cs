using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SqlDapper.Abstract
{
    public interface IDatabaseContext
    {
        // Synchronous Methods
        int Execute(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);
        IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);
        IEnumerable<dynamic> Query(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);
        SqlMapper.GridReader QueryMultiple(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);
        IEnumerable<T> QueryWithExecutionTime<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(
            string sql,
            Func<TFirst, TSecond, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = null,
            CommandType? commandType = null
        );

        // Asynchronous Methods
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);
        Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);
        Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);
        Task<IEnumerable<T>> QueryWithExecutionTimeAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(
            string sql,
            Func<TFirst, TSecond, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = null,
            CommandType? commandType = null
        );

        // Connection Management Methods
        void OpenConnection();
        Task OpenConnectionAsync();
        void CloseConnection();
        void Dispose();
    }
}
