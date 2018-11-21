using Logic.ReflectionMetadata;
using System;

namespace ViewModel.TreeViewItems
{
    public class AssemblyMetadataTreeViewItem : TreeViewItem
    {
        readonly AssemblyMetadata assemblyMetada;

        public AssemblyMetadataTreeViewItem(AssemblyMetadata assemblyMetada)
        {
            this.assemblyMetada = assemblyMetada ?? throw new ArgumentNullException(nameof(assemblyMetada));
            this.Name = assemblyMetada.Name;
        }

        protected override void BuildMyself()
        {
            foreach(NamespaceMetadata _namespaceMetadata in assemblyMetada.Namespaces)
            {
                this.Children.Add(new NamesapceTreeViewItem(_namespaceMetadata));
            }
        }
    }
}
