using System.Xml.Serialization;

namespace GetNextNumber.Models;

[XmlType(Namespace = "http://tempuri.org/")]
public class GetNextNumberResponse
{
    [XmlElement("GetNextNumberResult")]
    public string GetNextNumberResult { get; set; } = null!;
}
