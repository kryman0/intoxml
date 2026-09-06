using System.ComponentModel.DataAnnotations.Schema;
using IntoXml.Models;
using Microsoft.Data.SqlClient;

namespace IntoXml.DataExtensions;

public static class AuditLogExtensions
{
    public static AuditLog ConvertIntoAuditLog(this SqlDataReader reader)
    {
        var auditLog = new AuditLog();
        for (int i = 0; i < reader.FieldCount; i++)
        {
            var property = auditLog.GetType().GetProperty(reader.GetName(i))!;
            var value = reader.IsDBNull(i) ? null : reader.GetValue(i);
            property.SetValue(auditLog, value, null);
        }
        return auditLog;
    }
}