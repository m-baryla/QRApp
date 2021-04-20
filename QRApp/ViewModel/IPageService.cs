﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QRApp.ViewModel
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PopAsync();
        Task PushModalAsync(Page page);
        Task PopModalAsync();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task<ImageSource> CreatePhotoAsync();
        Task<ImageSource> PickPhotoAsync();


    }
}
