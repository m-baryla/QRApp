﻿using QRApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PlaylistsPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
