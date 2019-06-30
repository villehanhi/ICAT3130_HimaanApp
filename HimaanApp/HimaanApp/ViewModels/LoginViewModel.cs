using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using HimaanApp.Services;
using HimaanApp.Views;

namespace HimaanApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ValidatableObject<string> Email { get; }
        public ValidatableObject<string> Password { get; }
        public ICommand LoginCmd { get; }

        readonly IFirebaseAuthenticator firebaseAuthenticator;
        readonly NavigationService navigationService;

        Action propChangedCallBack => (LoginCmd as Command).ChangeCanExecute;

        public LoginViewModel(IFirebaseAuthenticator firebaseAuthenticator, NavigationService navigationService)
        {
            this.firebaseAuthenticator = firebaseAuthenticator;
            this.navigationService = navigationService;

            LoginCmd = new Command(async () => await Login(), () => Email.IsValid && Password.IsValid && !IsBusy);

            Email = new ValidatableObject<string>(propChangedCallBack, new EmailValidator()) { Value = "hanhi123123123@gmail.com" };
            Password = new ValidatableObject<string>(propChangedCallBack, new PasswordValidator()) { Value = "salasana" };
        }
        /// <summary>
        /// Login, alert if email or password are not ok. 
        /// </summary>
        /// <returns></returns>
        async Task Login()
        {
            IsBusy = true;
            propChangedCallBack();
            try { 
                (Application.Current as App).AuthToken = await firebaseAuthenticator.LoginWithEmailPassword(Email.Value, Password.Value);
                await navigationService.PushAsync(new MainPage());
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Wrong email or password", "OK");
            }
            finally
            {
                IsBusy = false;
                propChangedCallBack();
            }
        }
    }
}
