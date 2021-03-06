﻿using System;
using System.Linq;
using System.Threading.Tasks;

using UWPTemplateMVVMBasic.Core.Models;
using UWPTemplateMVVMBasic.Core.Services;
using UWPTemplateMVVMBasic.Helpers;

namespace UWPTemplateMVVMBasic.ViewModels
{
    public class ContentGridDetailViewModel : Observable
    {
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public ContentGridDetailViewModel()
        {
        }

        public async Task InitializeAsync(long orderID)
        {
            var data = await SampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }
}
