using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using MahAppsMetroMvvmLight.Navigation;

namespace MahAppsMetroMvvmLight.ViewModel
{
    public class SettingsViewModel: ViewModelBase
    {
        IFrameNavigationService _navigationService;
        private string _myProperty = "SettingPageText";
        public string SettingsPageText
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
        public SettingsViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
