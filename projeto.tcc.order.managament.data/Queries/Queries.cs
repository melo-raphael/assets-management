using Npgsql;
using Npgsql.Logging;
using projeto.tcc.order.managament.domain.SeedWork;
using System;
using System.Data;

namespace projeto.tcc.order.managament.data.Queries
{
    public class Queries<T> : IQueries<T> where T: IAggregateRoot
    {
        private string _connectionString = "Server=database-2.crrtyjh5anqo.sa-east-1.rds.amazonaws.com;Port=5432;Database=tcc_orders;User Id=postgres;Password=polivel12;";
        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_connectionString);
            }
        }
    }
}
