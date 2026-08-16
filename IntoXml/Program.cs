using IntoXml;

var data = Data.ReadData().Where(x => x.PatientPnr == "191001010101");
XmlBuilder.BuildXml(data);