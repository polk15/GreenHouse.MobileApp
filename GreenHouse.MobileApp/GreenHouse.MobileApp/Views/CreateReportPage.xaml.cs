using GreenHouse.Mobile.Core.Models;
using GreenHouse.Mobile.Infrastructure.graphql;
using GreenHouse.Mobile.Views;
using GreenHouse.MobileApp.Constants;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHouse.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateReportPage : ContentPage
    {
        public CreateReportPage()
        {
            InitializeComponent();
            Button_GetLocationAuto.Clicked += async delegate
            {
                var geoInfo = await CrossGeolocator.Current.GetPositionAsync(new TimeSpan(0, 0, 10), null, true);
                if (geoInfo == null)
                {
                    X.Text = "Could not get Location";
                    Y.Text = "";
                }
                else
                {
                    var location = new Point
                    {
                        X = geoInfo.Latitude,
                        Y = geoInfo.Longitude
                    };
                    X.Text = location.X.ToString();
                    Y.Text = location.Y.ToString();
                }
            };
            Btn_Add.Clicked += async delegate
            {
                var manager = new GraphQlClientManager();
                var report = await manager.SendMutationAsync<Report>("report", "addReport", GraphQlRequestFactory.CreateReportMutationAdd(AppSettings.CurrentUser,$"{ X.Text} {Y.Text }",Description.Text, IsScheduled.IsChecked));
                if (!IsScheduled.IsChecked)
                {
                    Application.Current.MainPage = new MainnPage();
                }
                else
                {
                    Application.Current.MainPage = new ScheduleCreatePage();
                }
            };
        }
    }
}