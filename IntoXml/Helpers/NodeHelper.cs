using System.Text;
using System.Xml.Linq;
using IntoXml.Models;

namespace IntoXml.Helpers;

public static class NodeHelper
{
    public static Node GetById(Node node, int id) => Traverse(node, id);
    private static Node Traverse(Node node, int id)
    {
        if (node.Id == id)
            return node;
        foreach (var child in node.Children)
        {
            if (child.Id == id)
                return child;
            Traverse(child, id);
        }
        return node;
    }
    
    public static void BuildXml(Node node, List<string> elements)
    {
        elements.Add($"<{node.Name}>");
        foreach (var child in node.Children)
        {
            if (child.HasChildren)
                BuildXml(child, elements);
            else
                elements.Add($"<{child.Name}>{child.Value}</{child.Name}>");
        }
        elements.Add($"</{node.Name}>");
    }

    public static XElement CreateXmlElement(List<string> elements)
    {
        var sb = new StringBuilder();
        foreach (var element in elements)
        {
            sb.Append(element);
            sb.AppendLine();
        }
        return XElement.Parse(sb.ToString());
    }
}