using IntoXml;
using IntoXml.Sql;
using IntoXml.Xml;

var data = MockData.ReadData().Where(x => x.PatientPnr == "191001010101");
XmlBuilder.BuildXml(data);