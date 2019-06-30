using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HimaanApp.Services;
using Xamarin.Forms;
using HimaanApp.Views;
using HimaanApp.Helper;

namespace HimaanApp.ViewModels
{
    public class OfferViewModel : BaseViewModel
    {
        public ValidatableObject<string> To { get; }
        public ValidatableObject<string> From { get; }
        public ValidatableObject<DateTime> DateSelect { get; }
        public ValidatableObject<string> Seats { get; }
        public ValidatableObject<string> Description { get; }
        //Minimum date for datepicker
        public DateTime MinDate { get; set; }

        public ICommand OfferCmd { get; }

        //Services
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public NavigationService navigationService = new NavigationService();
        public string RemoteData { get; private set; }

        Action propChangedCallBackOffer => (OfferCmd as Command).ChangeCanExecute;
        public OfferViewModel()
        {

            OfferCmd = new Command(async () => await CreateOffer(), () => !IsBusy);

            MinDate = DateTime.Today;
            To = new ValidatableObject<string>(propChangedCallBackOffer);
            From = new ValidatableObject<string>(propChangedCallBackOffer);
            DateSelect = new ValidatableObject<DateTime>(propChangedCallBackOffer);
            Seats = new ValidatableObject<string>(propChangedCallBackOffer);
            Description = new ValidatableObject<string>(propChangedCallBackOffer);

        }
        //Creates new offer
        async Task CreateOffer()
        {
            IsBusy = true;
            propChangedCallBackOffer();
            await firebaseHelper.AddOffer(To.Value, From.Value, DateSelect.Value, Convert.ToInt32(Seats.Value), Description.Value, (Application.Current as App).AuthToken);
            await Application.Current.MainPage.DisplayAlert("Success", "Offer Added Successfully", "OK");
            await navigationService.PushAsync(new MainPage());
            IsBusy = false;
            propChangedCallBackOffer();
        }
}
}
