using System.IO;
using System.Xml.Serialization;

namespace EnduranceJudge.Core.Services.Implementations
{
    public class XmlSerializationService : IXmlSerializationService
    {
        public T Deserialize<T>(string filePath)
        {
            var serializer = new XmlSerializer(typeof(T));

            using var readStream = new StreamReader(filePath);
            var data = (T)serializer.Deserialize(readStream);

            return data;
        }
    }
}
