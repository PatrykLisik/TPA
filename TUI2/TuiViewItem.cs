using Logic.ReflectionMetadata;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TUI2
{
    public class TuiViewItem
    {
        internal IEnumerable<IInternalGeter> rest;
        public TuiViewItem()
        {
            Children = new ObservableCollection<TuiViewItem>() { null };
            m_WasBuilt = false;
        }
        public string Name { get; set; }
        public ObservableCollection<TuiViewItem> Children { get; set; }
        public bool IsExpanded
        {
            get { return m_IsExpanded; }
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
        private void BuildMyself()
        {
            foreach (IInternalGeter namespace_conteriner in rest)
            {
                IEnumerable<IInternalGeter>  internal_obj = namespace_conteriner.GetInternals();
                if (internal_obj is null)
                {
                    Children.Add(new TuiViewItem
                    {
                        Name = namespace_conteriner.ToString(),
                    });
                }
                else
                {
                    Children.Add(new TuiViewItem
                    {
                        Name = namespace_conteriner.ToString(),
                        rest = internal_obj
                    });
                }



            }

        }

    }
}
