using System.Xml.Linq;

namespace IntoXml.Models;

// validation will be needed to create structure of the xml dom in the correct order
public class XmlObject
{
    public XDocument Document { get; set; }
    public XElement Root { get; set; }
    public XElement Parent { get; set; }
    public XElement Child { get; set; }
}