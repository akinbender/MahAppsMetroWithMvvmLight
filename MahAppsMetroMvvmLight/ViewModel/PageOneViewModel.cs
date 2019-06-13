using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MahAppsMetroMvvmLight.Navigation;

namespace MahAppsMetroMvvmLight.ViewModel
{
    public class PageOneViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _myProperty = "PageOneText";
        public string PageOneText
        {
            get => _myProperty;

            set
            {
                if (_myProperty == value)
                {
                    return;
                }

                _myProperty = value;
                RaisePropertyChanged();
            }
        }
        public PageOneViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
