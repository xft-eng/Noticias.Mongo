namespace Connvert.Infrastructure.Data.DbContext
{
    public interface IDatabaseConfig
    {
        string DatabaseName { get; set; }

        string ConnectionString { get; set; }
    }
}
