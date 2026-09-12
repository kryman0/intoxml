using Microsoft.Data.SqlClient;

namespace IntoXml.DataExtensions;

public static class Extensions
{
    public static T Convert<T>(this SqlDataReader reader)
    {
        var item = Activator.CreateInstance<T>();
        for (int i = 0; i < reader.FieldCount; i++)
        {
            var property = typeof(T).GetProperty(reader.GetName(i));
            var value = reader.IsDBNull(i) ? null : reader.GetValue(i);
            if (property == null)
                continue;
            property.SetValue(item, value);
        }
        return item;
    }
}