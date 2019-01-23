using System.ComponentModel.Composition;

namespace ViewModel
{
    [Export(typeof(IRepositoryLoader))]
    public class MDFLoader : IRepositoryLoader
    {
        public string GetPathTorepostory()
        {
            return new WindowPathGeter().GetPath(".mdf");
        }
    }
}
