using Autofac;
using Xamarin.Forms;
using HimaanApp.ViewModels;

namespace HimaanApp.Views
{
    public partial class SearchPage : CarouselPage
    {
        public SearchPage()
        {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<SearchViewModel>();
        }
    }
}
