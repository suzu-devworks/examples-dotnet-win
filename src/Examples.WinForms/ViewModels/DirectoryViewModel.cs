using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples.WinForms.Abstractions.ComponentModel;
using System.IO;
using System.Collections.ObjectModel;

namespace Examples.WinForms.ViewModels
{
    public class DirectoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DirectoryViewModel()
        {
        }

        public DirectoryViewModel(DirectoryViewModel parent, string path)
        {
            if (!Directory.Exists(path))
                throw new ArgumentException($"directory [{path}] is not found.");

            _model = new DirectoryInfo(path);
            _parent = parent;
            _children = new ReadOnlyCollection<DirectoryViewModel>(new DirectoryViewModel[] { Dummy });
        }

        private static readonly DirectoryViewModel Dummy = new DirectoryViewModel();

        private DirectoryInfo _model;

        public string Name => _model.Name;

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (_isExpanded == value)
                {
                    return;
                }
                _isExpanded = value;
                RaisePropertyChanged(nameof(IsExpanded));
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value)
                {
                    return;
                }
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }

        private DirectoryViewModel _parent;

        public DirectoryViewModel Parent => _parent;

        public bool HasDummy => (_children.Count == 1) && (_children[0] == Dummy);

        private ReadOnlyCollection<DirectoryViewModel> _children;

        public ReadOnlyCollection<DirectoryViewModel> Children
        {
            get
            {
                if (HasDummy)
                {
                    List<DirectoryViewModel> list = new();
                    foreach (var info in _model.GetDirectories())
                    {
                        list.Add(new DirectoryViewModel(this, info.FullName));
                    }
                    _children = new ReadOnlyCollection<DirectoryViewModel>(list);
                }
                return _children;
            }
        }








    }
}
