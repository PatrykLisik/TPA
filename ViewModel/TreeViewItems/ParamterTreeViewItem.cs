using Logic.ReflectionMetadata;
using System;

namespace ViewModel.TreeViewItems
{
    public class ParamterTreeViewItem : TreeViewItem
    {
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
