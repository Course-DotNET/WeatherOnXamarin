using System;
using System.ComponentModel;
using Weather.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Weather.Models;

namespace Weather.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}