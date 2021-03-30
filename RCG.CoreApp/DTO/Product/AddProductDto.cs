using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RCG.CoreApp.DTO
{
    public class AddProductDto
    {
        private long _productId;
        private string _style;
        private string _availableLength;
        private string _avrageWeight;
        private string _price;

        public long ProductId
        {
            get { return _productId; }
            set { _productId = value; this.OnPropertyChanged("ProductId"); }
        }

        public string Style
        {
            get { return _style; }
            set { _style = value; this.OnPropertyChanged("Style"); }
        }

        public string AvailableLength
        {
            get { return _availableLength; }
            set { _availableLength = value; this.OnPropertyChanged("AvailableLength"); }
        }

        public string AvrageWeight
        {
            get { return _avrageWeight; }
            set { _avrageWeight = value; this.OnPropertyChanged("AvrageWeight"); }
        }
        public string Price
        {
            get { return _price; }
            set { _price = value; this.OnPropertyChanged("Price"); }
        }
        public string UpdatedOn { get; set; }
        public string User { get; set; }
        public long ProductMainId { get; set; }
        public bool IsValid { get; set; }
        public string ValidationMessage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
