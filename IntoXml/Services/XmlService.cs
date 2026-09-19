using IntoXml.Models;

namespace IntoXml.Services;

public class XmlService
{
    private readonly XmlObject _xmlObject;

    public XmlService(XmlObject xml)
    {
        _xmlObject = xml;
    }
    
    public XmlObject GetXml() => _xmlObject;
}