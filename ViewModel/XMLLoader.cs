using System.ComponentModel.Composition;

namespace ViewModel
{
    [Export(typeof(IRepositoryLoader))]
    public class XMLLoader : IRepositoryLoader
    {
        public string GetPathTorepostory()
        {
            return new WindowPathGeter().GetPath(".xml");
        }
    }
}
