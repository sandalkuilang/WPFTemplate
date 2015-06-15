using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTemplate.ViewModels
{
    public class KeyValueOption : BaseGridRow
    {

        private bool isReadOnly = true;
        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                NotifyIfChanged(ref isReadOnly, value);
            }
        }

        public string Id { get; set; }
        public string Description { get; set; }

    }
}
