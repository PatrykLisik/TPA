using Logic.ReflectionMetadata;
using System;
using System.Runtime.Serialization;

namespace ViewModel.TreeViewItems
{
    [DataContract(IsReference = true)]
    public class ParamterTreeViewItem : TreeViewItem
    {
        [DataMember]
        private readonly ParameterMetadata parameter;

        public ParamterTreeViewItem(ParameterMetadata parameter)
        {
            this.parameter = parameter;
            this.Name = parameter.TypeMetadata.TypeName + " " + parameter.Name;
        }

        protected override void BuildMyself()
        {
            Children.Add(new TypeMetadataTreeViewItem(parameter.TypeMetadata));
        }
    }
}
