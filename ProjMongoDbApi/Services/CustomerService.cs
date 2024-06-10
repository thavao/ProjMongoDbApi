using MongoDB.Driver;
using ProjMongoDbApi.Models;
using ProjMongoDbApi.Utils;

namespace ProjMongoDbApi.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IProjMongoDbApiDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionsString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionNmae);
        }

        public List<Customer> Get() => _customer.Find(customer => true).ToList();

        public Customer Get(string id) => _customer.Find(customer => customer.Id == id).FirstOrDefault();

        public Customer Update(Customer customer)
        {
            _customer.ReplaceOne(c => c.Id == customer.Id, customer);
            return customer;
        }

        public void Delete(string id)
        {
            _customer.DeleteOne(c => c.Id == id);
        }
    }
}
