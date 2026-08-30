using Microsoft.Data.SqlClient;
namespace IntoXml.Data;

public class DbConnection
{
    private const string _connStr = "Application Name=IntoXml;Data Source=(local);Initial Catalog=Test;Integrated Security=true;Trust Server Certificate=true";

    private static SqlConnection GetConnectionToDatabase()
    {
        return new SqlConnection(_connStr);
    }
    
    public static async Task<object> ExecuteSql(string sql, CancellationToken cancellationToken)
    {
        await using var connection = GetConnectionToDatabase();
        var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        await connection.OpenAsync(cancellationToken);
        var reader = await cmd.ExecuteReaderAsync(cancellationToken);
        var list = new object[reader.FieldCount];
        reader.GetValues(list);
        return list;
    }
}