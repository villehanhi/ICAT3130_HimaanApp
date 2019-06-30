using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HimaanApp.Helper;
using HimaanApp.Models;
using Xamarin.Forms;

namespace HimaanApp.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        //Commands for buttons
        public ICommand SearchCmd { get; }
        public ICommand NeedSearchCmd { get; }

        Action propChangedCallBack => (SearchCmd as Command).ChangeCanExecute;
        //List of offered rides
        private ObservableCollection<Offer> _OfferItems;
        public ObservableCollection<Offer> OfferItems
        {
            get
            {
                return _OfferItems;

            }
            set
            {
                _OfferItems = value;
                propChangedCallBack();
            }
        }
        //List of asked rides
        private ObservableCollection<Need> _NeedItems;
        public ObservableCollection<Need> NeedItems
        {
            get
            {
                return _NeedItems;
            }
            set
            {
                _NeedItems = value;
                propChangedCallBack();
            }
        }

        public SearchViewModel()
        {
            SearchCmd = new Command(async () => await searchOffersAsync(), () => !IsBusy);
            NeedSearchCmd = new Command(async () => await searchNeedsAsync(), () => !IsBusy);

        }
        /// <summary>
        /// get list of offered rides
        /// </summary>
        /// <returns></returns>
        async Task searchOffersAsync()
        {
            OfferItems = new ObservableCollection<Offer>(await firebaseHelper.SearchOffers());
        }
        /// <summary>
        /// get list of asked rides
        /// </summary>
        /// <returns></returns>
        async Task searchNeedsAsync()
        {
            NeedItems = new ObservableCollection<Need>(await firebaseHelper.SearchNeeds());
        }


    }
}
