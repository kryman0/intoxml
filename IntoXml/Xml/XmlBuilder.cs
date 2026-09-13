using System.Runtime.CompilerServices;
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

        var doc2 = CreateDocument()
            .AddRoot("PlaneradeÅtgärder")
            .AddChildToParent("Patient", "PlaneradeÅtgärder")
            .AddChildToParent("Name", patient.PatientFirstname + " " + patient.PatientLastname);
        
        // var patientElement2 = CreateParentElement("Patient");
        // var patientNameElement2 = CreateChildElement("Name", patient.PatientFirstname + " " + patient.PatientLastname);
        // patientNameElement2.ToParentAsFirst(patientElement2);
        // patientElement2.ToParentAsFirst(rootElement2);

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

    public static XDocument CreateDocument() =>
        new XDocument();

    private static XElement CreateRootElement(this XDocument document, string name)
    {
        var rootElement = new XElement(name);
        document.AddFirst(rootElement);
        return rootElement;
    }
    private static XElement CreateParentElement(this XElement parent, string name)
    {
        var parentElement = new XElement(name);
        parent.Add(parentElement);
        return parentElement;
    }
    private static XElement CreateChildElement(this XElement child, string name, string value)
    {
        var childElement = new XElement(name, value);
        child.AddFirst(childElement);
        return childElement;
    }
    public static XElement AddChildToParent(this XElement element, string parentElement, string name, string? value = null) =>
        value != null ? element.CreateChildElement(name, value) : element.CreateParentElement(name);
    public static XElement AddRoot(this XDocument document, string name) =>
        document.CreateRootElement(name);
}