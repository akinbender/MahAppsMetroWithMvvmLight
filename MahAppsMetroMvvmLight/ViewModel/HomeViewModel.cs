using GalaSoft.MvvmLight;
using MahAppsMetroMvvmLight.Navigation;

namespace MahAppsMetroMvvmLight.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private string _myProperty = "HomePageText";
        public string HomePageText
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
        public HomeViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
