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
    public class NeedViewModel : BaseViewModel
    {
        public ValidatableObject<string> To { get; }
        public ValidatableObject<string> From { get; }
        public ValidatableObject<DateTime> DateSelect { get; }
        public ValidatableObject<string> Seats { get; }
        public ValidatableObject<string> Description { get; }

        public DateTime Mindate { get; private set; }

        public ICommand NeedCmd { get; }

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public NavigationService navigationService = new NavigationService();
        public string RemoteData { get; private set; }

        Action propChangedCallBackNeed => (NeedCmd as Command).ChangeCanExecute;
        public NeedViewModel()
        {

            NeedCmd = new Command(async () => await CreateNeed(), () => !IsBusy);

            Mindate = DateTime.Today;
            To = new ValidatableObject<string>(propChangedCallBackNeed);
            From = new ValidatableObject<string>(propChangedCallBackNeed);
            DateSelect = new ValidatableObject<DateTime>(propChangedCallBackNeed);
            Seats = new ValidatableObject<string>(propChangedCallBackNeed);
            Description = new ValidatableObject<string>(propChangedCallBackNeed);

        }

        /// <summary>
        /// Creates new asked ride
        /// </summary>
        /// <returns></returns>
        async Task CreateNeed()
        {
            IsBusy = true;
            propChangedCallBackNeed();
            await firebaseHelper.AddNeed(To.Value, From.Value, DateSelect.Value, Convert.ToInt32(Seats.Value), Description.Value, (Application.Current as App).AuthToken);
            await Application.Current.MainPage.DisplayAlert("Success", "You have asked a ride successfully.", "OK");
            await navigationService.PushAsync(new MainPage());
            IsBusy = false;
            propChangedCallBackNeed();
        }
    }
}
