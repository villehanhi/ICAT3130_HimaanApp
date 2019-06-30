using Autofac;
using Xamarin.Forms;
using HimaanApp.ViewModels;

namespace HimaanApp.Views
{
    public partial class NeedPage : ContentPage
    {
        public NeedPage()
        {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<NeedViewModel>();
        }
    }
}
