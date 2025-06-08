using GetNextNumber.Models;
using System.Xml.Serialization;

namespace GetNextNumber.Extensions;

public static class XmlExtensions
{
    public static BaseResponseResult<T> DeserializeXml<T>(string xml)
    {
        if (string.IsNullOrWhiteSpace(xml))
        {
            return new BaseResponseResult<T>
            {
                Success = false,
                StatusCode = 400,
                Message = "Empty XML string."
            };
        }

        try
        {
            var serializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(xml);
            var result = (T?)serializer.Deserialize(reader);

            if (result == null)
            {
                return new BaseResponseResult<T>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = "Something went wrong with deserialization."
                };
            }

            return new BaseResponseResult<T>
            {
                Success = true,
                StatusCode = 200,
                Data = result
            };
        }
        catch (Exception ex)
        {
            return new BaseResponseResult<T>
            {
                Success = false,
                StatusCode = 500,
                Message = ex.Message,
            };
        }
    }
}