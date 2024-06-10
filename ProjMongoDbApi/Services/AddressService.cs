using MongoDB.Driver;
using ProjMongoDbApi.Models;
using ProjMongoDbApi.Utils;

namespace ProjMongoDbApi.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;

        public AddressService (IProjMongoDbApiDataBaseSettings settings)
        {
            var cliente = new MongoClient(settings.ConnectionsString);
            var database = cliente.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }
                                                      //While true
        public List<Address> Get() => _address.Find(address => true).ToList();
        public Address Get(string id) => _address.Find<Address>(address => address.Id == id).FirstOrDefault();
        public Address Create(Address address)
        {
            _address.InsertOne(address);
            return address;
        }
    }
}
