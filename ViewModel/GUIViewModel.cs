using Logic.Serialization;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Input;
using ViewModel.TreeViewItems;

namespace ViewModel
{
    [DataContract]
    public class GUIViewModel : INotifyPropertyChanged
    {
        #region DataContext
        [DataMember]
        public ObservableCollection<TreeViewItem> HierarchicalAreas { get; set; }
        public string PathVariable { get; set; }
        public Visibility ChangeControlVisibility { get; set; } = Visibility.Hidden;
        public ICommand Click_Browse { get; }
        public ICommand Show_TreeView { get; }
        public ICommand Save_Button { get; }
        public ICommand Load_Button { get; }
        #endregion

        #region constructors
        readonly IFilePathGeter pathGeter;

        private IRepositoryActions<AssemblyMetadataTreeViewItem> Repository { get; set; }
        public GUIViewModel(IFilePathGeter fileGeter)
        {
            HierarchicalAreas = new ObservableCollection<TreeViewItem>();
            Repository = new XMLSerializer<AssemblyMetadataTreeViewItem>();
            Show_TreeView = new RelayCommand(LoadDLL);
            Click_Browse = new RelayCommand(Browse);
            Save_Button = new RelayCommand(Save);
            Load_Button = new RelayCommand(LoadRepository);
            pathGeter = fileGeter;
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
        #endregion

        #region private
        private void LoadDLL()
        {
            if (PathVariable.Substring(PathVariable.Length - 4) == ".dll")
                TreeViewLoaded();
        }
        private void TreeViewLoaded()
        {
            TreeViewItem rootItem = RootItemBuilder.LoadRootItemFromDLL(PathVariable);
            HierarchicalAreas.Add(rootItem);
        }
        private void Browse()
        {
            string patchToDLL = pathGeter.GetPath();
            if (patchToDLL.Length != 0)
            {
                PathVariable = patchToDLL;
                ChangeControlVisibility = Visibility.Visible;
                RaisePropertyChanged("ChangeControlVisibility");
                RaisePropertyChanged("PathVariable");
            }
        }

        private void Save()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML Files|*.xml";
            saveFileDialog1.Title = "Save an XML File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                Repository.SaveToRepository(RootItemBuilder.LoadRootItemFromDLL(PathVariable), saveFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("No files selected");
            }
        }

        private void LoadRepository()
        {
            string patchToXML = pathGeter.GetPath(".xml");
            if (patchToXML.Length != 0)
            {
                PathVariable = patchToXML;
                HierarchicalAreas.Add(Repository.LoadFromRepository(patchToXML));
                ChangeControlVisibility = Visibility.Visible;
                RaisePropertyChanged("ChangeControlVisibility");
                RaisePropertyChanged("PathVariable");
            }

        }
        #endregion

    }
}
