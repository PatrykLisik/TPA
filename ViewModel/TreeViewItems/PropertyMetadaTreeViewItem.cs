using Logic.ReflectionMetadata;
using System;

namespace ViewModel.TreeViewItems
{
    public class PropertyMetadaTreeViewItem : TreeViewItem
    {
        PropertyMetadata propertyMateadata;
        public PropertyMetadaTreeViewItem()
        {
        }

        public PropertyMetadaTreeViewItem(PropertyMetadata prooprtyMateadata)
        {
            propertyMateadata = prooprtyMateadata ?? throw new ArgumentNullException(nameof(prooprtyMateadata));
            base.Name = GenerateName();
        }
        private string GenerateName()
        {
            return "Property: " + propertyMateadata.TypeMetadata.TypeName + " " + propertyMateadata.Name;
        }
        protected override void BuildMyself()
        {
            ;
        }
    }
}
