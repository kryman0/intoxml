using System.Reflection;
using IntoXml.DataExtensions;
using IntoXml.Models;
using Microsoft.Data.SqlClient;
namespace IntoXml.Data;

public class DbConnection
{
    private const string _connStr = "Application Name=IntoXml;Data Source=(local);Initial Catalog=Test;Integrated Security=true;Trust Server Certificate=true";

    private static SqlConnection GetConnectionToDatabase()
    {
        return new SqlConnection(_connStr);
    }

    public static async Task<List<T>> ReadDataFromDb<T>(string sql, CancellationToken cancellationToken, List<T> list) where T : new()
    {
        list = await ExecuteSql(sql, cancellationToken, list);
        return list;
    }
    
    private static async Task<List<T>> ExecuteSql<T>(string sql, CancellationToken cancellationToken, List<T> list) where T : new()
    {
        await using var connection = GetConnectionToDatabase();
        var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        await connection.OpenAsync(cancellationToken);
        var reader = await cmd.ExecuteReaderAsync(cancellationToken);
        
        while (await reader.ReadAsync(cancellationToken))
        {
            var obj = reader.Convert(new T());
            list.Add(obj);
        }
        reader.Close();
        
        return list;
    }
}