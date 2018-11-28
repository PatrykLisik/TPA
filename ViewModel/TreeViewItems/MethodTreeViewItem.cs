using Logic.ReflectionMetadata;
using System.Runtime.Serialization;

namespace ViewModel.TreeViewItems
{
    [DataContract(IsReference = true)]
    public class MethodTreeViewItem : TreeViewItem
    {
        [DataMember]
        private MethodMetadata _method;

        public MethodTreeViewItem(MethodMetadata method)
        {
            _method = method;
            Name = GenerateName();
        }

        public MethodTreeViewItem()
        {
        }
        #region Name generation 
        private string GenerateName()
        {
            return _method.Modifiers.Item1.Stringify() +
                   _method.Modifiers.Item2.Stringify() +
                   _method.Modifiers.Item3.Stringify() +
                   _method.Modifiers.Item4.Stringify() +
                   _method.ReturnType.TypeName + " " +
                   _method.Name +
                   genericArgsString() +
                   "(" + string.Join(" ,", _method.Parameters) + ")";
        }

        private string genericArgsString()
        {
            string genericArgs;
            if (_method.GenericArguments is null)
            {
                genericArgs = "";
            }
            else
            {
                genericArgs = "<" +
                    string.Join(" ,", _method.GenericArguments) +
                    ">";
            }

            return genericArgs;
        }
        #endregion
        protected override void BuildMyself()
        {
            ;
        }
    }
}
