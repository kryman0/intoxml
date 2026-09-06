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
    
    public static async Task<object> ExecuteSql<T>(string sql, CancellationToken cancellationToken)
    {
        await using var connection = GetConnectionToDatabase();
        var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        await connection.OpenAsync(cancellationToken);
        var reader = await cmd.ExecuteReaderAsync(cancellationToken);
        
        // if (typeof(T).IsGenericType)
        // {
        //     return GetList(reader, cancellationToken);
        // }
        
        var auditLogs = new List<AuditLog>();
        while (await reader.ReadAsync(cancellationToken))
        {
            auditLogs.Add(reader.ConvertIntoAuditLog());
        }
        reader.Close();
        return auditLogs;
    }

    // private IEnumerable<T> GetList(SqlDataReader reader, CancellationToken token)
    // {
    //     
    // }
}