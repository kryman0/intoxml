using System.ComponentModel.DataAnnotations.Schema;
using IntoXml.Models;
using Microsoft.Data.SqlClient;

namespace IntoXml.DataExtensions;

public static class AuditLogExtensions
{
    public static T Convert<T>(this SqlDataReader reader, T singleObject)
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            var property = singleObject?.GetType().GetProperty(reader.GetName(i))!;
            var value = reader.IsDBNull(i) ? null : reader.GetValue(i);
            property.SetValue(singleObject, value, null);
        }
        return singleObject;
    }
}