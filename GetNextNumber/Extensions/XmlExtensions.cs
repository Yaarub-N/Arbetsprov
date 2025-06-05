using System.Xml.Serialization;

namespace GetNextNumber.Extensions;

public static class XmlExtensions
{
    public static T DeserializeXml<T>(string xml)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(xml);
        return (T)serializer.Deserialize(reader)!;
    }
}
