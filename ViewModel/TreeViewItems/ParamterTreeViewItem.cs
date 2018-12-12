using Logic.ReflectionMetadata;

namespace ViewModel.TreeViewItems
{
    public class ParamterTreeViewItem : TreeViewItem
    {
        private readonly ParameterMetadata parameter;

        public ParamterTreeViewItem()
        {
        }

        public ParamterTreeViewItem(ParameterMetadata parameter)
        {
            this.parameter = parameter;
            Name = parameter.TypeMetadata.TypeName + " " + parameter.Name;
        }

        protected override void BuildMyself()
        {
            Children.Add(new TypeMetadataTreeViewItem(parameter.TypeMetadata));
        }
    }
}
