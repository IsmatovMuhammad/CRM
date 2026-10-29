using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class DataBase
{
    private string connection = "Host=localhost;Port=5432;Database=Crm;Username=postgres;Password=1234";
    public IDbConnection Connection() => new NpgsqlConnection(connection);
}