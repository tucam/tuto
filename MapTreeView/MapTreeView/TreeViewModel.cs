using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTreeView
{
    class TreeViewModel
    {
        private ObservableCollection<ItemViewModel> items;

        public TreeViewModel()
        {
            items = new ObservableCollection<ItemViewModel>();
            BuildItemViewModels();
        }

        public ObservableCollection<ItemViewModel> Items
        {
            get { return items; }
        }
        private void BuildItemViewModels()
        {
            // level 1
            for (int i = 0; i < 3; i++)
            {
                ItemViewModel itemLevel1 = new ItemViewModel(null, string.Format("Item {0}", i + 1));
                // level 2
                for (int j = 0; j < 3; j++)
                {
                    ItemViewModel itemLevel2 = new ItemViewModel(itemLevel1, string.Format("Item {0}.{1}", i + 1, j + 1));
                    // level 3
                    for (int k = 0; k < 2; k++)
                    {
                        ItemViewModel itemLevel3 = new ItemViewModel(itemLevel2, string.Format("Item {0}.{1}.{2}", i + 1, j + 1, k + 1));

                        itemLevel2.Children.Add(itemLevel3);
                        items.Add(itemLevel3);
                    }

                    itemLevel1.Children.Add(itemLevel2);
                    items.Add(itemLevel2);
                }

                items.Add(itemLevel1);
            }
        }
    }
}
