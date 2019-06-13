using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using MahAppsMetroMvvmLight.Navigation;

namespace MahAppsMetroMvvmLight.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IFrameNavigationService navigationService;
        private HamburgerMenuItemCollection menuItems;
        private HamburgerMenuItemCollection menuOptionItems;
        private RelayCommand _loadedCommand;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            this.CreateMenuItems();
        }

        [PreferredConstructor]
        public MainViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.CreateMenuItems();
        }

        public void CreateMenuItems()
        {
            MenuItems = new HamburgerMenuItemCollection
            {
                new HamburgerMenuIconItem()
                {
                    Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.IndustrySolid },
                    Label = "Home",
                    Command = NavigateToHome
                },
                new HamburgerMenuIconItem()
                {
                    Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.DatabaseSolid },
                    Label = "PageOne",
                    Command = NavigateToPageOne
                }
            };

            MenuOptionItems = new HamburgerMenuItemCollection
            {
                new HamburgerMenuIconItem()
                {
                    Icon = new PackIconMaterial() {Kind = PackIconMaterialKind.Settings},
                    Label = "Settings",
                    Command = NavigateToSettings
                },
                new HamburgerMenuIconItem()
                {
                    Icon = new PackIconMaterial() {Kind = PackIconMaterialKind.Help},
                    Label = "Help",
                    Command = NavigateToHelp
                }
            };
        }


        public HamburgerMenuItemCollection MenuItems
        {
            get { return menuItems; }
            set
            {
                if (Equals(value, menuItems)) return;
                menuItems = value;
                RaisePropertyChanged();
            }
        }

        public HamburgerMenuItemCollection MenuOptionItems
        {
            get { return menuOptionItems; }
            set
            {
                if (Equals(value, menuOptionItems)) return;
                menuOptionItems = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand NavigateToHome => new RelayCommand(() => { navigationService.NavigateTo("Home"); });

        public RelayCommand NavigateToPageOne => new RelayCommand(() => { navigationService.NavigateTo("PageOne"); });

        public RelayCommand NavigateToSettings => new RelayCommand(() => { navigationService.NavigateTo("Settings"); });

        public RelayCommand NavigateToHelp => new RelayCommand(() => { navigationService.NavigateTo("Help"); });
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                       ?? (_loadedCommand = new RelayCommand(
                           () =>
                           {
                               navigationService.NavigateTo("Home");
                           }));
            }
        }
    }
}