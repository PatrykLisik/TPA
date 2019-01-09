using Logic.ReflectionMetadata;
using System;

namespace ViewModel.TreeViewItems
{
    public class PropertyMetadaTreeViewItem : TypeMetadataTreeViewItem
    {
        PropertyMetadata propertyMateadata;
        public PropertyMetadaTreeViewItem()
        {
        }

        public PropertyMetadaTreeViewItem(PropertyMetadata prooprtyMateadata):base(prooprtyMateadata.TypeMetadata)
        {
            propertyMateadata = prooprtyMateadata ?? throw new ArgumentNullException(nameof(prooprtyMateadata));
            base.Name = GenerateName();
        }
        protected override string GenerateName()
        {
            return "Property: " + propertyMateadata?.TypeMetadata?.TypeName + " " + propertyMateadata?.Name;
        }

        protected override void BuildMyself()
        {
            base.BuildMyself();
        }
    }
}
