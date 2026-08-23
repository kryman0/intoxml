using IntoXml.Models;
using System.Xml.Linq;

namespace IntoXml.Xml;

public static class XmlBuilder
{
    public static void BuildXml(IEnumerable<AuditLog> auditLogs)
    {
        var patient = auditLogs.FirstOrDefault(x => x.PatientPnr == "191001010101");
        
        var patientElement = new XElement("Patient",
            new XElement("Namn", patient.PatientFirstname + " " + patient.PatientLastname),
            new XElement("Pnr", patient.PatientPnr));

        foreach (var logsByYear in auditLogs.GroupBy(x => x.LogDate.Year))
        {
            var doc = new XDocument(
                new XElement("PlaneradeÅtgärder",
                    new XElement(patientElement)
                )
            );
            
            foreach (var log in logsByYear)
            {
                var user = new XElement("Användare",
                    new XElement("Namn", log.UserFirstname + " " + log.UserLastname),
                    new XElement("Pnr", log.UserPnr),
                    new XElement("Tidpunkt", log.LogDate),
                    log.Insats != null ? XElement.Parse(log.Insats) : null);
                doc.Root.Add(user);
            }

            var filename = Path.Combine(Environment.CurrentDirectory,
                $"Signeringslista_{patient.PatientFirstname}_{patient.PatientLastname}_{logsByYear.Key}.xml");
            
            doc.Save(filename);
        }
    }
}