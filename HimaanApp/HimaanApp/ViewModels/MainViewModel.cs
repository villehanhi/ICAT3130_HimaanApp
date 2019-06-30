using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using HimaanApp.Services;
using Xamarin.Forms;
using HimaanApp.Views;

namespace HimaanApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand Offer { get; }
        public ICommand Need { get; }
        public ICommand Search { get; }


        public NavigationService navigationService = new NavigationService();
        public string RemoteData { get; private set; }

        Action propChangedCallBackOffer => (Offer as Command).ChangeCanExecute;
        Action propChangedCallBackNeed => (Need as Command).ChangeCanExecute;
        Action propChangedCallBackSearch => (Search as Command).ChangeCanExecute;

        public MainViewModel()
        {
            Offer = new Command<bool>(async (authorized) => await openOffer(authorized), _ => !IsBusy);
            Need = new Command<bool>(async (authorized) => await openNeed(authorized), _ => !IsBusy);
            Search = new Command<bool>(async (authorized) => await openSearch(authorized), _ => !IsBusy);

        }
        /// <summary>
        /// "Offer a ride" buttonclicked
        /// </summary>
        /// <param name="authorized"></param>
        /// <returns></returns>
        async Task openOffer(bool authorized)
        {
            propChangedCallBackOffer();

            if (authorized)
            {
                await navigationService.PushAsync(new OfferPage());
            }
            else
            {
                await navigationService.PushAsync(new LoginPage());
            }
            propChangedCallBackOffer();
        }
        /// <summary>
        /// "Ask for a ride" buttonclicked
        /// </summary>
        /// <param name="authorized"></param>
        /// <returns></returns>
        async Task openNeed(bool authorized)
        {
            propChangedCallBackNeed();

            if (authorized)
            {
                await navigationService.PushAsync(new NeedPage());
            }
            else
            {
                await navigationService.PushAsync(new LoginPage());
            }

            propChangedCallBackNeed();
        }
        /// <summary>
        /// "Search" buttonclicked
        /// </summary>
        /// <param name="authorized"></param>
        /// <returns></returns>
        async Task openSearch(bool authorized)
        {
            propChangedCallBackSearch();

            if (authorized)
            {
                await navigationService.PushAsync(new SearchPage());
            }
            else
            {
                await navigationService.PushAsync(new LoginPage());
            }
            propChangedCallBackSearch();
        }
    }
}
