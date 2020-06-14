using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.proxy.wallet.src
{
    public class WalletClient : IDisposable
    {
        private string _uriTemplate = "";

        public async Task SendOrderAsync(WalletRequest request)
        { 
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(request), UnicodeEncoding.UTF8, "application/json");

                using (var response = await client.PostAsync(_uriTemplate, stringContent))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception();
                    }
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
