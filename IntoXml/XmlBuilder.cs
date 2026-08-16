using IntoXml.Models;
using System.Xml.Linq;

namespace IntoXml;

public static class XmlBuilder
{
    public static void BuildXml(IEnumerable<AuditLog> auditLogs)
    {
        // var patientName = auditLogs.FirstOrDefault()
        var patientElement = new XElement("Patient", 
            new XElement("Namn", auditLogs));
        // var patient = new XElement("Patient", );
        
        
        // var doc = new XDocument(
        //     new XElement("PlaneradeÅtgärder",
        //         new XElement(data.FirstOrDefault()) 
        //     ),
        // );
    }
}