using GreenHouse.Mobile.Infrastructure.graphql;
using GreenHouse.MobileApp.Views;
using System;
using Plugin.Geolocator;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHouse.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportsPage : ContentPage
    {
        public ReportsPage()
        {
           InitializeComponent();
            AddReport.Clicked += async delegate
            {
                await Create_Clicked();
            };
        }

        public async Task Create_Clicked()
        {
            await Navigation.PushAsync(new CreateReportPage());
        }
    }
}