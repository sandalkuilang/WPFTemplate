using WPFTemplate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI; 
using System.Reactive;
using System.Reactive.Linq;

namespace WPFTemplate.ViewModels
{
    public abstract class BaseCollectionViewModel<T> : BaseBindableModel, ISelectableGridCommand where T : BaseGridRow
    {   
        public ReactiveCommand<object> CheckedHeaderCommand { get; set; }

        public ReactiveCommand<dynamic> CheckedRowCommand { get; set; }


        private bool checkedHeader;
        public bool CheckedHeader
        {
            get
            {
                return checkedHeader;
            }
            set
            {
                if (this.Source.Count == 0 && !checkedHeader)
                    return;

                NotifyIfChanged(ref checkedHeader, value);  
            }
        }

        private MutableObservableCollection<BaseGridRow> selectableRows;

        public MutableObservableCollection<BaseGridRow> SelectableRows
        {
            get
            {
                return selectableRows;
            }
            set
            {
                NotifyIfChanged(ref selectableRows, value);
            }
        }

        public BaseCollectionViewModel()
        {
            SelectableRows = new MutableObservableCollection<BaseGridRow>(); 
            CheckedHeaderCommand = ReactiveCommand.Create();
            CheckedHeaderCommand.Subscribe(x =>
            {
                if (this.Source.Count == 0)
                    return;

                bool check = (bool)x;

                SelectableRows.Clear();
                foreach (T item in this.Source)
                {
                    item.IsSelected = check;
                    item.SelectAll = check;

                    if (item.IsSelected)
                    {
                        SelectableRows.Add(item);
                    }
                    else
                        SelectableRows.Remove(item);
                } 
            }); 
            CheckedRowCommand = ReactiveCommand.Create();
            CheckedRowCommand.Subscribe(x => 
            {
                SelectableRows.Clear();
                foreach (BaseGridRow item in Source)
                {
                    if (item.IsSelected)
                        SelectableRows.Add(item);
                    else
                        SelectableRows.Remove(item);
                }

                if (selectableRows.Count == Source.Count)
                    CheckedHeader = true;
                else
                    CheckedHeader = false; 
            });
        }
 
        public abstract MutableObservableCollection<T> Source { get; set; }
         
    }
}
