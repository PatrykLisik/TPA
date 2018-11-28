using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Logic.ReflectionMetadata;

namespace ViewModel.TreeViewItems
{
    [DataContract(IsReference = true)]
    public class PropertyMetadaTreeViewItem : TreeViewItem
    {
        PropertyMetadata propertyMateadata;
        public PropertyMetadaTreeViewItem()
        {
        }

        public PropertyMetadaTreeViewItem(PropertyMetadata prooprtyMateadata)
        {
            this.propertyMateadata = prooprtyMateadata ?? throw new ArgumentNullException(nameof(prooprtyMateadata));
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
