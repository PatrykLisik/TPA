using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ViewModel.TreeViewItems
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(AssemblyMetadataTreeViewItem))]
    [KnownType(typeof(MethodTreeViewItem))]
    [KnownType(typeof(NamesapceTreeViewItem))]
    [KnownType(typeof(ParamterTreeViewItem))]
    [KnownType(typeof(TypeMetadataTreeViewItem))]
    [KnownType(typeof(PropertyMetadaTreeViewItem))]
    public abstract class TreeViewItem
    {
        public TreeViewItem()
        {
            Children = new ObservableCollection<TreeViewItem>() { null };
            m_WasBuilt = false;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public ObservableCollection<TreeViewItem> Children { get; set; }
        [DataMember]
        public bool IsExpanded
        {
            get { return m_IsExpanded; }
            set
            {
                m_IsExpanded = value;
                if (m_WasBuilt)
                    return;
                Children.Clear();
                BuildMyself();
                m_WasBuilt = true;
            }
        }

        private bool m_WasBuilt;
        private bool m_IsExpanded;
        protected abstract void BuildMyself();

    }
}
