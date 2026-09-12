using IntoXml.Data;
using IntoXml.Models;

var cts = new CancellationTokenSource();
var token = cts.Token;

try
{
    var sql = "select * from auditlog";
    var auditLogs = await Database.ReadRows<AuditLog>(sql, token);
}
catch (OperationCanceledException ex)
{
    Console.WriteLine($"SQL Connection canceled: {ex.Message}");
}
