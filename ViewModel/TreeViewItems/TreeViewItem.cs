﻿using System.Collections.ObjectModel;

namespace ViewModel.TreeViewItems
{
    public abstract class TreeViewItem
    {
        public TreeViewItem()
        {
            Children = new ObservableCollection<TreeViewItem>() { null };
            m_WasBuilt = false;
        }
        public string Name { get; set; }
        public ObservableCollection<TreeViewItem> Children { get; set; }
        public bool IsExpanded
        {
            get => m_IsExpanded;
            set
            {
                m_IsExpanded = value;
                if (m_WasBuilt)
                    return;
                Children.Clear();
                BuildMyself();
                m_WasBuilt = true;
            }
        }

        private bool m_WasBuilt;
        private bool m_IsExpanded;
        protected abstract void BuildMyself();

    }
}
