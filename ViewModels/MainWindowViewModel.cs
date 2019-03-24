using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpKmaLab04PersonList.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private bool _isControlEnabled = true;
        #endregion

        #region Properties
       
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

 
    }
}

