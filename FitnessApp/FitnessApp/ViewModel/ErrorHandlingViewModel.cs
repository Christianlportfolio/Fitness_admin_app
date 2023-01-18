using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModel
{
   public class ErrorHandlingViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private bool _isCheckedYes;
        public bool IsCheckedYes
        {
            get { return _isCheckedYes; }
            set
            {
                if (true == value) 
                {
                    IsCheckedNo = false; 
                    _isCheckedYes = value;
                }
                else
                {
                    _isCheckedYes = value;
                }
                OnPropertyChanged("IsCheckedYes");
            }
        }

        private bool _isCheckedNo;
        public bool IsCheckedNo
        {
            get { return _isCheckedNo; }
            set
            {
                if (true == value) 
                {
                    IsCheckedYes = false; 
                    _isCheckedNo = value;
                }
                else
                {
                    _isCheckedNo = value;
                }
                OnPropertyChanged("IsCheckedNo");
            }
        }


        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }

            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
                OnPropertyChanged("HasErrorMessageCprNumber");
                OnPropertyChanged("HasErrorMessageAddress");
                OnPropertyChanged("HasErrorMessageZipCode");
                OnPropertyChanged("HasErrorMessageRegisterNumber");
                OnPropertyChanged("HasErrorMessageContoNumber");
            }

        }


        private bool _hasErrorMessageCprNumber;

        public bool HasErrorMessageCprNumber
        {
            get { return _hasErrorMessageCprNumber; }

            set
            {
                _hasErrorMessageCprNumber = value;
                OnPropertyChanged("HasErrorMessageCprNumber");
            }

        }

        private bool _hasErrorMessageAddress;

        public bool HasErrorMessageAddress
        {
            get { return _hasErrorMessageAddress; }

            set
            {
                _hasErrorMessageAddress = value;
                OnPropertyChanged("HasErrorMessageAddress");
            }

        }


        private bool _hasErrorMessageZipCode;

        public bool HasErrorMessageZipCode
        {
            get { return _hasErrorMessageZipCode; }

            set
            {
                _hasErrorMessageZipCode = value;
                OnPropertyChanged("HasErrorMessageZipCode");
            }

        }


        private bool _hasErrorMessageRegisterNumber;

        public bool HasErrorMessageRegisterNumber
        {
            get { return _hasErrorMessageRegisterNumber; }

            set
            {
                _hasErrorMessageRegisterNumber = value;
                OnPropertyChanged("HasErrorMessageRegisterNumber");
            }

        }

        private bool _hasErrorMessageContoNumber;

        public bool HasErrorMessageContoNumber
        {
            get { return _hasErrorMessageContoNumber; }

            set
            {
                _hasErrorMessageContoNumber = value;
                OnPropertyChanged("HasErrorMessageContoNumber");
            }

        }








    }
}
