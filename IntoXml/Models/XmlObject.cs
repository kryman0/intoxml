using System.Xml.Linq;

namespace IntoXml.Models;

// validation will be needed to create structure of the xml dom in the correct order
public class XmlObject
{
    public Node? Root  { get; set; }
    public Node? Current { get; set; }
    public XElement? Parent { get; set; }
    public XElement? Child { get; set; }
}