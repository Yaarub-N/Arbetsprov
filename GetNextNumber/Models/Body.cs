using System.Xml.Serialization;

namespace GetNextNumber.Models;

public class Body
{
    [XmlElement("GetNextNumberResponse", Namespace = "http://tempuri.org/")]
    public GetNextNumberResponse? Content { get; set; }
}
