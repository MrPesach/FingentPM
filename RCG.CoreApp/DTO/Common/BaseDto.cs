using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RCG.CoreApp.DTO.Common
{
    public class BaseDto
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
