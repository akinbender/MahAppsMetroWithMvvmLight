using GalaSoft.MvvmLight.Views;

namespace MahAppsMetroMvvmLight.Navigation
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
