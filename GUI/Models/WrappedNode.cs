using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class WrappedNode : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public ObservableCollection<WrappedNode> Nodes { get; set; }

        public WrappedNode()
        {
            Nodes = new ObservableCollection<WrappedNode>();
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                ((INotifyPropertyChanged)Nodes).PropertyChanged += value;
            }

            remove
            {
                ((INotifyPropertyChanged)Nodes).PropertyChanged -= value;
            }
        }
    }
}
