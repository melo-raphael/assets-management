using Dapper.Contrib.Extensions;
using projeto.tcc.order.managament.domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.data.Queries.AssetsQueries
{
    public class AssetsQueries : Queries<Assets>, IAssetsQuery
    {
        public async Task<IEnumerable<Assets>> GetAssetsPerPage()
        {
            SqlMapperExtensions.TableNameMapper = (type) =>
            {
                return $"\"{type.Name}\"";
            };

            using (var connection = Connection)
            {
              
                connection.Open();

                var assets = await connection.GetAllAsync<Assets>();

                return assets;
            }
        }
    }
}
