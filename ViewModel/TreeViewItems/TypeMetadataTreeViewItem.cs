using Logic.ReflectionMetadata;
using static Logic.ReflectionMetadata.TypeMetadata;

namespace ViewModel.TreeViewItems
{
    public class TypeMetadataTreeViewItem : TreeViewItem
    {
        private TypeMetadata _typeMetadata;

        public TypeMetadataTreeViewItem(TypeMetadata typeMetadata)
        {
            _typeMetadata = typeMetadata;
            Name = GenerateName() + "TypeMetadata";


        }

        public TypeMetadataTreeViewItem()
        {
        }
        #region Name

        private string TypeKindToString(TypeKind typeKind)
        {
            return typeKind.ToString().Replace("Type", "") + " ";
        }
        protected virtual string GenerateName()
        {

            return ModifiersToString() +
                   TypeKindToString(_typeMetadata.TypeKind1) +
                   _typeMetadata.TypeName + GenericParamsToString();
        }
        private string ModifiersToString()
        {
            if (_typeMetadata.Modifiers is null)
                return "";
            return GenericParamsToString();
        }

        private string GenericParamsToString()
        {
            if (_typeMetadata.GenericArguments is null)
                return "";
            return "<" + string.Join(",", _typeMetadata.GenericArguments) + ">";
        }
        #endregion
        protected override void BuildMyself()
        {

            if (_typeMetadata.GenericArguments != null)
                foreach (TypeMetadata _type in _typeMetadata.GenericArguments)
                {
                    Children.Add(new TypeMetadataTreeViewItem(_type));
                }

            if (_typeMetadata.NestedTypes != null)
                foreach (TypeMetadata _type in _typeMetadata.NestedTypes)
                {
                    Children.Add(new TypeMetadataTreeViewItem(_type));
                }

            if (_typeMetadata.Methods != null)
                foreach (MethodMetadata _method in _typeMetadata.Methods)
                {
                    Children.Add(new MethodTreeViewItem(_method));
                }

            if (_typeMetadata.Constructors != null)
                foreach (MethodMetadata _method in _typeMetadata.Constructors)
                {
                    Children.Add(new MethodTreeViewItem(_method));
                }

            if (_typeMetadata.Fields != null)
                foreach (ParameterMetadata parameter in _typeMetadata.Fields)
                {
                    Children.Add(new ParamterTreeViewItem(parameter));
                }
            if(_typeMetadata.Properties != null)
                foreach (PropertyMetadata parameter in _typeMetadata.Properties)
                {
                    Children.Add(new PropertyMetadaTreeViewItem(parameter));
                }

        }
    }
}
