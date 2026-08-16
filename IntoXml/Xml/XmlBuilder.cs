using IntoXml.Models;
using System.Xml.Linq;

namespace IntoXml.Xml;

public static class XmlBuilder
{
    public static void BuildXml(IEnumerable<AuditLog> auditLogs)
    {
        var filename = Path.Combine(Environment.CurrentDirectory, "Patient.xml");
        var patient = auditLogs.FirstOrDefault(x => x.PatientPnr == "191001010101");

        var patientElement = new XElement("Patient",
            new XElement("Namn", patient.PatientFirstname + " " + patient.PatientLastname),
            new XElement("Pnr", patient.PatientPnr));
        
        var doc = new XDocument(
            new XElement("PlaneradeÅtgärder", 
                new XElement(patientElement),
                from al in auditLogs
                select
                    new XElement("Användare",
                        new XElement("Namn", al.UserFirstname + " " + al.UserLastname),
                        new XElement("Pnr", al.UserPnr),
                        new XElement("Tidpunkt", al.LogDate),
                        al.Insats != null ? XElement.Parse(al.Insats) : null
                    )
                )
        );
        doc.Save(filename);
    }
}