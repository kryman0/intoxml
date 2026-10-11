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
    
    public static List<string> BuildXml(Node node, List<string> elements, int iterator = 0)
    {
        if (!node.HasChildren)
            elements.Add($"<{node.Name}>{node.Value}</{node.Name}>");
        foreach (var child in node.Children)
        {
            if (child.HasChildren)
            {
                elements.Add($"<{node.Name}>");
                BuildXml(child, elements, iterator + 1);
            }
        }
        
        return elements;
    }
}