using Dapper;
using Dapper.Contrib.Extensions;
using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.data.Queries.AssetsQueries
{
    public class OrderQueries : Queries<Order>, IOrderQuery
    {
        public async Task<IEnumerable<dynamic>> GetActiveOrders(Guid userId)
        {
            SqlMapperExtensions.TableNameMapper = (type) =>
            {
                return $"\"{type.Name}\"";
            };

            using (var connection = Connection)
            {

                connection.Open();

                var sql = $"SELECT * FROM \"Order\" o INNER JOIN \"OrderType\" ot ON o.\"OrderTypeId\" = ot.\"Id\" INNER JOIN \"OrderActive\" oa ON o.\"OrderActiveId\" = oa.\"Id\" WHERE \"UserId\" = '{userId}'";
                var result = await Connection.QueryAsync<dynamic>(sql);

                return result;
            }
        }
    }
}
