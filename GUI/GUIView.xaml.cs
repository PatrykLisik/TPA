using System.Windows;
using ViewModel;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy GUIView.xaml
    /// </summary>
    public partial class GUIView : Window
    {
        public GUIView()
        {
            InitializeComponent();
            //DataContext = new GUIViewModel();
        }
    }
}
