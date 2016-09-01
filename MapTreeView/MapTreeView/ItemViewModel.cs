using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTreeView
{
    /// <summary>
    /// Model of tree item.
    /// </summary>
    class ItemViewModel : INotifyPropertyChanged
    {
        private ItemViewModel parent;
        private string name;
        private ObservableCollection<ItemViewModel> children;

        public ItemViewModel(ItemViewModel parent, string name)
        {
            this.parent = parent;
            this.name = name;
            children = new ObservableCollection<ItemViewModel>();
        }
        /// <summary>
        /// Item's parent
        /// </summary>
        public ItemViewModel Parent
        {
            get { return parent; }
            set
            {
                if (!Equals(parent, value))
                {
                    parent = value;
                    OnPropertyChanged("Parent");
                }
            }
        }
        /// <summary>
        /// Name of item
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        /// <summary>
        /// Item's children
        /// </summary>
        public ObservableCollection<ItemViewModel> Children { get { return children; } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
