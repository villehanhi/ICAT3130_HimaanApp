
using Autofac;
using Xamarin.Forms;
using HimaanApp.ViewModels;

namespace HimaanApp.Views
{
	public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<LoginViewModel>();
        }
    }
}