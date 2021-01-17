using System;

using UWPTemplateMVVMBasic.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPTemplateMVVMBasic.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
