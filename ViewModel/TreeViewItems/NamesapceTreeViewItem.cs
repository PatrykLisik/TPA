using Logic.ReflectionMetadata;

namespace ViewModel.TreeViewItems
{
    public class NamesapceTreeViewItem : TreeViewItem
    {
        private NamespaceMetadata _namespaceMetadata;

        public NamesapceTreeViewItem()
        {
        }

        public NamesapceTreeViewItem(NamespaceMetadata namespaceMetadata)
        {
            _namespaceMetadata = namespaceMetadata;
            Name = "Namesapce " + _namespaceMetadata.NamespaceName;
        }

        protected override void BuildMyself()
        {
            foreach (TypeMetadata _typeMetadata in _namespaceMetadata.Types)
            {
                Children.Add(new TypeMetadataTreeViewItem(_typeMetadata));
            }
        }
    }
}
