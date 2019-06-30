using Autofac;
using Xamarin.Forms;
using HimaanApp.ViewModels;

namespace HimaanApp.Views
{
    public partial class OfferPage : ContentPage
    {
        public OfferPage()
        {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<OfferViewModel>();
        }
    }
}
