using IntoXml.Data;
using IntoXml.Models;
using IntoXml.Xml;

// var data = MockData.ReadData().Where(x => x.PatientPnr == "191001010101");
// XmlBuilder.BuildXml(data);

var cts = new CancellationTokenSource();
var token = cts.Token;

try
{
    var sql = "select * from auditlog";
    var list = new  List<AuditLog>();
    var dbData = await DbConnection.ReadDataFromDb(sql, token, list);
    
}
catch (OperationCanceledException ex)
{
    Console.WriteLine($"SQL Connection canceled: {ex.Message}");
}

public enum TypeOfObject
{
    List = 1,
    SingleObject = 2
};
