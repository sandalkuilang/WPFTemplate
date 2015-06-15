using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTemplate.ViewModels
{
    public interface IInvoiceCommand
    {
        ICommand PrintCommand { get; set; }

    }
}
