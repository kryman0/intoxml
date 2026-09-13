using IntoXml.Data;
using IntoXml.Models;
using IntoXml.Xml;

var cts = new CancellationTokenSource();
var token = cts.Token;

try
{
    var sql = "select * from auditlog";
    var auditLogs = await Database.ReadRows<AuditLog>(sql, token);
    XmlBuilder.BuildXml(auditLogs);
}
catch (OperationCanceledException ex)
{
    Console.WriteLine($"SQL Connection canceled: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Something went wrong: {ex.Message}");
}
