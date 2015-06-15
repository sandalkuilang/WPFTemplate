using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTemplate.ViewModels
{
    public interface IEditGridCommand
    {
        ICommand EditCommand { get; set; }
        ICommand DeleteCommand { get; set; }
    }
}
