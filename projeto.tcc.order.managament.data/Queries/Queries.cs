using Npgsql;
using Npgsql.Logging;
using projeto.tcc.order.managament.domain.SeedWork;
using System;
using System.Data;

namespace projeto.tcc.order.managament.data.Queries
{
    public class Queries<T> : IQueries<T> where T: IAggregateRoot
    {
        private string _connectionString = Environment.GetEnvironmentVariable("ConnectionString");
        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_connectionString);
            }
        }
    }
}
