﻿using Logic.ReflectionMetadata;
using Logic.Serialization;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Input;
using ViewModel.TreeViewItems;
using System.Linq;
using System.Collections.Generic;

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
        public ICommand Click_Button { get; }
        public ICommand Save_Button { get; }
        #endregion

        #region constructors
        readonly IFilePathGeter pathGeter;

        private IRepositoryActions<List<TreeViewItem>> repository { get; set; }
        public GUIViewModel(IFilePathGeter fileGeter)
        {
            HierarchicalAreas = new ObservableCollection<TreeViewItem>();
            repository = new XMLSerializer<List<TreeViewItem>>();
            Click_Button = new RelayCommand(LoadDLL);
            Click_Browse = new RelayCommand(Browse);
            Save_Button = new RelayCommand(Save);
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
            TreeViewItem rootItem = RootItemBuilder.LoadRootItem(PathVariable);
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
            repository.SaveToRepository(HierarchicalAreas.ToList(), @"x.xml");
        }

        private void Load()
        {
            HierarchicalAreas = new ObservableCollection<TreeViewItem>(repository.LoadFromRepository(@"x.xml"));
        }
        #endregion

    }
}
