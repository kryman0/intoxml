using IntoXml.Models;
using System.Xml.Linq;

namespace IntoXml.Extensions;

public static class XmlExtensions
{
    public static XmlObject CreateDocument(this XmlObject xml)
    {
        xml.Document = new XDocument();
        return xml;
    }

    public static XmlObject AddRoot(this XmlObject xml, string name)
    {
        xml.Document.Root?.Add(new XElement(name));
        return xml;
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

    public static XElement AddToChild(this XElement element, string name, string value)
    {
        var newElement = new XElement(name, value);
        element.Add(newElement);
        return element;
    }
        
    public static XElement AddChild(this XElement element, string name, string? value = null) =>
        value != null ? element.CreateChildElement(name, value) : element.CreateParentElement(name);

    public static XElement AddChildToParent(this XElement element, string name, string value, string parent)
    {
        var document = element.Document.Root.Element(parent);
        return document;
    }
}