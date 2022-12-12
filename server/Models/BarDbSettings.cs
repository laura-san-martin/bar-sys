namespace server.Models;

public class BarDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string UserCollectionName { get; set; } = null!;
    public string ProfitCollectionName { get; set; } = null!;
    public string BillsCollectionName { get; set; } = null!;
}