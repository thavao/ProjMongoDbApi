using Newtonsoft.Json;
using ProjMongoDbApi.Models;

namespace ProjMongoDbApi.Services
{
    public class PostOfficeServices
    {
        static readonly HttpClient address = new HttpClient();
        public static async Task<AddressDTO> GetAddress(string cep)
        {
            try
            {
                HttpResponseMessage response = await address.GetAsync($"http://viacep.com.br/ws/{cep}/json/");
                response.EnsureSuccessStatusCode();
                string addr = await response.Content.ReadAsStringAsync();
                AddressDTO addressDTO = JsonConvert.DeserializeObject<AddressDTO>(addr);
                return addressDTO;
            }
            catch(HttpRequestException ex)
            {
                throw;
            }
        }
    }
}
