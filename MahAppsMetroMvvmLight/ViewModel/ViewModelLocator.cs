/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MahAppsMetroMvvmLight"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MahAppsMetroMvvmLight.Navigation;
using System;

namespace MahAppsMetroMvvmLight.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SetupNavigation();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<PageOneViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<HelpViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public HomeViewModel HomeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public PageOneViewModel PageOneViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PageOneViewModel>();
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
            }
        }

        public HelpViewModel HelpViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HelpViewModel>();
            }
        }

        private static void SetupNavigation()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IFrameNavigationService, FrameNavigationService>();
            }
            else
            {
                var navigationService = new FrameNavigationService();
                navigationService.Configure("Home", new Uri("../View/Home.xaml", UriKind.Relative));
                navigationService.Configure("PageOne", new Uri("../View/PageOne.xaml", UriKind.Relative));
                navigationService.Configure("Settings", new Uri("../View/Settings.xaml", UriKind.Relative));
                navigationService.Configure("Help", new Uri("../View/Help.xaml", UriKind.Relative));
                SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
            }

        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}