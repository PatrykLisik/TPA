using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Serialization
{
    public class XMLSerializer<T> : IRepositoryActions<T>
    {
        public T LoadFromRepository(string fileName)
        {
            DataContractSerializer s = new DataContractSerializer(typeof(T));
            FileStream f = new FileStream(fileName, FileMode.Open);
            XmlDictionaryReader r = XmlDictionaryReader.CreateTextReader(f, new XmlDictionaryReaderQuotas { MaxDepth = int.MaxValue });
            T value = (T)s.ReadObject(r);
            r.Close();
            f.Close();
            return value;
        }

        public void SaveToRepository(T data, string fileName)
        {
            FileStream f = new FileStream(fileName, FileMode.Create);
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            XmlWriter w = XmlWriter.Create(f, settings);
            DataContractSerializer s = new DataContractSerializer(typeof(T),
            null,
            0x7FFF /*maxItemsInObjectGraph*/,
            false /*ignoreExtensionDataObject*/,
            true /*preserveObjectReferences : this is where the magic happens */,
            null /*dataContractSurrogate*/);
            s.WriteObject(w, data);
            w.Close();
            f.Close();
        }
    }
}
