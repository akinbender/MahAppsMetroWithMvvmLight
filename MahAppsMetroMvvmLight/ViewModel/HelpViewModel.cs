using GalaSoft.MvvmLight;
using MahAppsMetroMvvmLight.Navigation;

namespace MahAppsMetroMvvmLight.ViewModel
{
    public class HelpViewModel : ViewModelBase
    {
        IFrameNavigationService _navigationService;
        private string _myProperty = "HelpPageText";
        public string HelpPageText
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

        public HelpViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
