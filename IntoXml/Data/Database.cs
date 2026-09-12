using IntoXml.DataExtensions;
using Microsoft.Data.SqlClient;

namespace IntoXml.Data;

public static class Database
{
    private const string _connStr = "Application Name=IntoXml;Data Source=(local);Initial Catalog=Test;Integrated Security=true;Trust Server Certificate=true";

    public static async Task<List<T>> ReadRows<T>(string sql, CancellationToken cancellationToken)
    {
        var result = await ExecuteSql<T>(sql, cancellationToken);
        return result;
    }
    
    private static SqlConnection GetConnection()
    {
        return new SqlConnection(_connStr);
    }

    private static async Task<List<T>> ExecuteSql<T>(string sql, CancellationToken cancellationToken)
    {
        await using var connection = GetConnection();
        var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        await connection.OpenAsync(cancellationToken);
        var reader = await cmd.ExecuteReaderAsync(cancellationToken);
        var list = new List<T>();
        while (await reader.ReadAsync(cancellationToken))
            list.Add(reader.Convert<T>());
        reader.Close();
        return list;
    }
}