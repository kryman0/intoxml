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
            .CreateDocument()
            .AddRoot("PlaneradeÅtgärder");
        
        // var doc2 = XmlExtensions.CreateDocument()
        //     .AddRoot("PlaneradeÅtgärder")
        //     .AddChild("Patient")
        //     .AddChild("Name", patient.PatientFirstname + " " + patient.PatientLastname)
        //     .AddToChild("Name1", patient.PatientFirstname + " " + patient.PatientLastname) // fix the order
        //     .AddToChild("Name2", patient.PatientFirstname + " " + patient.PatientLastname);

        var a = 10;
        
    }
}