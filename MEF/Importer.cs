using System.Collections.Generic;
using System.Configuration;

namespace MEF
{
    public class Importer<T> : List<T>
    {
        public T GetImport()
        {
            System.Collections.Specialized.NameValueCollection settings = ConfigurationManager.AppSettings;
            string result = settings[typeof(T).Name];
            var a = Find(item => item.GetType().Name == result);
            return a;
        }
    }
}
