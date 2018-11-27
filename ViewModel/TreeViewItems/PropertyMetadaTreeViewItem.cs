using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.TreeViewItems
{
    [DataContract(IsReference = true)]
    public class PropertyMetadaTreeViewItem : TreeViewItem
    {
        protected override void BuildMyself()
        {
            throw new NotImplementedException();
        }
    }
}
