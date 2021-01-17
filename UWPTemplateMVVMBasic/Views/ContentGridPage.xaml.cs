using System;

using UWPTemplateMVVMBasic.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPTemplateMVVMBasic.Views
{
    public sealed partial class ContentGridPage : Page
    {
        public ContentGridViewModel ViewModel { get; } = new ContentGridViewModel();

        public ContentGridPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.LoadDataAsync();
        }
    }
}
