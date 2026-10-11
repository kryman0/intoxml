using IntoXml.Models;
using System.Xml.Linq;
using IntoXml.Helpers;

namespace IntoXml.Extensions;

public static class XmlExtensions
{
    public static XmlObject CreateRoot(this XmlObject xml, string name, int id)
    {
        xml.Root = new Node(name, id);
        return xml;
    }

    public static Node AddParent(this XmlObject xml, string name, int id)
    {
        var parent = new Node(name, id);
        parent.Document = xml;
        return parent;
    }

    public static XmlObject To(this Node node, int id)
    {
        var xml = node.Document;
        if (xml.Root.Id == id)
        {
            xml.Root.Children.Add(node);
        }
        else
        {
            NodeHelper.GetById(xml.Root, id).Children.Add(node);
        }

        node.Document = null;
        return xml;
    }

    public static Node AddChild(this XmlObject xml, string name, string value, int id)
    {
        var child = new Node(name, id, value);
        child.Document = xml;
        return child;
    }

    public static XmlObject Build(this XmlObject xml)
    {
        var xmlString = string.Empty;
        var elements = new List<string>();
        NodeHelper.BuildXml(xml.Root, elements, 0);
        return xml;
    }
}