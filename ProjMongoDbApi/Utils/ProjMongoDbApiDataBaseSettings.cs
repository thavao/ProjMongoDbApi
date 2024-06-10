namespace ProjMongoDbApi.Utils
{
    public class ProjMongoDbApiDataBaseSettings : IProjMongoDbApiDataBaseSettings
    {
        public string CustomerCollectionNmae { get; set; }
        public string AddressCollectionName { get; set; }
        public string ConnectionsString { get; set; }
        public string DatabaseName { get; set; }
    }
}
