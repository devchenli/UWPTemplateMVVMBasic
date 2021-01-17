using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Uwp.UI.Animations;

using UWPTemplateMVVMBasic.Core.Models;
using UWPTemplateMVVMBasic.Core.Services;
using UWPTemplateMVVMBasic.Helpers;
using UWPTemplateMVVMBasic.Services;
using UWPTemplateMVVMBasic.Views;

using Windows.UI.Xaml.Controls;

namespace UWPTemplateMVVMBasic.ViewModels
{
    public class ImageGalleryViewModel : Observable
    {
        public const string ImageGallerySelectedIdKey = "ImageGallerySelectedIdKey";

        private ICommand _itemSelectedCommand;

        public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnItemSelected));

        public ImageGalleryViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            var data = await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets");

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        private void OnItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as SampleImage;
            ImagesNavigationHelper.AddImageId(ImageGallerySelectedIdKey, selected.ID);
            NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            NavigationService.Navigate<ImageGalleryDetailPage>(selected.ID);
        }
    }
}
