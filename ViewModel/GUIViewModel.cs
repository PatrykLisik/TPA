using MEF;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using ViewModel.TreeViewItems;

namespace ViewModel
{

    public class GUIViewModel : INotifyPropertyChanged
    {
        #region DataContext
        public ObservableCollection<TreeViewItem> HierarchicalAreas { get; set; }
        public string PathVariable { get; set; }
        public Visibility ChangeControlVisibility { get; set; } = Visibility.Hidden;
        public ICommand Click_Browse { get; }
        public ICommand Show_TreeView { get; }
        public ICommand Save_Button { get; }
        public ICommand Load_Button { get; }
        #endregion

        #region constructors
        [ImportMany(typeof(IFilePathGeter))]
        Importer<IFilePathGeter> pathGeter;

        public GUIViewModel()
        {
            new Bootstrapper().ComposeApplication(this);
            HierarchicalAreas = new ObservableCollection<TreeViewItem>();
            Show_TreeView = new RelayCommand(LoadDLL);
            Click_Browse = new RelayCommand(Browse);
            Save_Button = new RelayCommand(Save);
            Load_Button = new RelayCommand(LoadRepository);
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
        private async void TreeViewLoaded()
        {
            TreeViewItem rootItem = await ViewModelSaverLoader.LoadRootItemFromDLLAsync(PathVariable);
            HierarchicalAreas.Add(rootItem);
        }
        private void Browse()
        {
            string patchToDLL = pathGeter.GetImport().GetPath();
            if (patchToDLL.Length != 0)
            {
                PathVariable = patchToDLL;
                ChangeControlVisibility = Visibility.Visible;
                RaisePropertyChanged("ChangeControlVisibility");
                RaisePropertyChanged("PathVariable");
            }
        }

        private async void Save()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "XML Files|*.xml",
                Title = "Save an XML File"
            };
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                await ViewModelSaverLoader.SaveDLLToRepositoryAsync(saveFileDialog1.FileName, PathVariable);
            }
            else
            {
                MessageBox.Show("No files selected");
            }
        }

        private async void LoadRepository()
        {
            string patchToXML = pathGeter.GetImport().GetPath(".xml");
            if (patchToXML.Length != 0)
            {
                PathVariable = patchToXML;
                HierarchicalAreas.Add(await ViewModelSaverLoader.LoadRootItemFromRepositoryAsync(patchToXML));
                ChangeControlVisibility = Visibility.Visible;
                RaisePropertyChanged("ChangeControlVisibility");
                RaisePropertyChanged("PathVariable");
            }

        }
        #endregion

    }
}
