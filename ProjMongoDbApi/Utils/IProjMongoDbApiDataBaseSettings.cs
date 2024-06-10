namespace ProjMongoDbApi.Utils
{
    public interface IProjMongoDbApiDataBaseSettings
    {
        string CustomerCollectionNmae { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionsString { get; set; }
        string DatabaseName { get; set; }
    }
}
