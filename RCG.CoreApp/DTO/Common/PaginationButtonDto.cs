using System;
using System.Collections.Generic;
using System.Text;

namespace RCG.CoreApp.DTO.Common
{
    public class PaginationButtonDto : BaseDto
    {
        public int Number { get; set; }
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; this.OnPropertyChanged("IsSelected"); }
        }

    }
}
