using Logic.ReflectionMetadata;
using System;
using System.Runtime.Serialization;

namespace ViewModel.TreeViewItems
{
    [DataContract(IsReference = true)]
    public class AssemblyMetadataTreeViewItem : TreeViewItem
    {
        [DataMember]
        AssemblyMetadata assemblyMetada;

        public AssemblyMetadataTreeViewItem()
        {
        }

        public AssemblyMetadataTreeViewItem(AssemblyMetadata assemblyMetada)
        {
            this.assemblyMetada = assemblyMetada ?? throw new ArgumentNullException(nameof(assemblyMetada));
            Name = assemblyMetada.Name;
        }

        protected override void BuildMyself()
        {
            foreach (NamespaceMetadata _namespaceMetadata in assemblyMetada.Namespaces)
            {
                Children.Add(new NamesapceTreeViewItem(_namespaceMetadata));
            }
        }
    }
}
