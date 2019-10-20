using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenHouse.Mobile.Core.Models;
using GreenHouse.Mobile.Infrastructure.graphql;
using GreenHouse.MobileApp.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHouse.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BtnSignup.Clicked += async delegate { await SigninProcedure(); };
            SignUp.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new SignupPage());
                })

            });
        }

        private async Task SigninProcedure()
        {
            var manager = new GraphQlClientManager();
            var response = await manager.SendMutationAsync<LoginResponse>("login", "login",
                GraphQlRequestFactory.CreateLoginMutation(Email.Text, Password.Text));
            if (response.Success)
            {
                AppSettings.CurrentUser = "430bfa4b-2850-49a2-b21e-a88b18233e0f";
                Application.Current.MainPage = new MainnPage();
            }
            else
            {
                Email.Text = response.Error;
            }
        }
    }
}