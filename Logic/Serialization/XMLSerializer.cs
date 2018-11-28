using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Logic.Serialization
{
    [Export(typeof(IRepositoryActions<>))]
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
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StreamWriter wr = new StreamWriter(fileName))
            {
                xs.Serialize(wr, data);
            }
        }
    }
}
