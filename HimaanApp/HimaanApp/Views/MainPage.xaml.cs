
using Autofac;
using Xamarin.Forms;
using HimaanApp.ViewModels;

namespace HimaanApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<MainViewModel>();
        }
    }
}
