﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.ReflectionMetadata;

namespace ViewModel.TreeViewItems
{
    public class NamesapceTreeViewItem : TreeViewItem
    {
        private NamespaceMetadata _namespaceMetadata;

        public NamesapceTreeViewItem(NamespaceMetadata namespaceMetadata)
        {
            _namespaceMetadata = namespaceMetadata;
            this.Name = "Namesapce " + _namespaceMetadata.NamespaceName;
        }

        protected override void BuildMyself()
        {
            foreach(TypeMetadata _typeMetadata in _namespaceMetadata.Types)
            {
                Children.Add(new TypeMetadataTreeViewItem(_typeMetadata));
            }
        }
    }
}