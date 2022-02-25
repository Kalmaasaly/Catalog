namespace Catalog.Settings
{
  public class MongoDBSettigs
  {
    public string Host { get; set; }
    public int Port { get; set; }
    public string ConmectionString 
    {
       get{
         return $"mongodb://{Host}:{Port}";
       }
    }
  }
}