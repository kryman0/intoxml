using IntoXml.Helpers;

namespace IntoXml.Models;

public class Node(string name, int id, string? value = null)
{
    public int Id => id;
    public string Name => name; 
    public string? Value => value;
    public List<Node> Children = new();
    public bool HasChildren => Children.Any();
    public XmlObject? Document { get; set; }
}