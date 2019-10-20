using GreenHouse.Mobile.Core.Models;
using GreenHouse.Mobile.Infrastructure.graphql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHouse.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            Btn_Signup.Clicked += async delegate
            {
                var manager = new GraphQlClientManager();
                var response = await manager.SendMutationAsync<Account>("account", "addAccount", GraphQlRequestFactory.CreateAccountMutation(Entry_Username.Text, Entry_Email.Text, Entry_Password.Text));
            };
        }
        
        public void SignupProcedure(object sender, EventArgs e)
        {
            
        }
    }
}