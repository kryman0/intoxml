using IntoXml.Models;
using IntoXml.Extensions;
using IntoXml.Services;

namespace IntoXml.Helpers;

public static class XmlBuilder
{
    public static void BuildXml(IEnumerable<AuditLog> auditLogs)
    {
        var patient = auditLogs.FirstOrDefault(x => x.PatientPnr == "191001010101");
        
        var xmlService = new XmlService(new XmlObject());
        var xml = xmlService.GetXml();
        xml // validation will be needed to create structure of the xml dom in the correct order
            .CreateRoot("Root", 1)
            .AddParent("Patient", 2).To(1)
            .AddChild("Age", "30", 3).To(2)
            .AddChild("Gender", "Male", 4).To(2)
            .Build();
        
        var a = 10;
        
    }
}