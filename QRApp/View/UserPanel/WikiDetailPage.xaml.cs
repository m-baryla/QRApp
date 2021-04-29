﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRApp.View.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WikiDetailPage : ContentPage
    {
		public WikiDetailPage(Wiki _wikiDetail)
        {
            if (_wikiDetail == null)
                throw new ArgumentNullException();

            BindingContext = _wikiDetail;

            InitializeComponent();
        }
	}
}