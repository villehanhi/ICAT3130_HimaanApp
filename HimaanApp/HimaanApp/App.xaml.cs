using Autofac;
using Xamarin.Forms;
using HimaanApp.Services;
using HimaanApp.Views;
using HimaanApp.ViewModels;


namespace HimaanApp
{
    public partial class App : Application
    {
        public IContainer Container { get; }
        public string AuthToken { get; set; }

        public App(Module module)
        {
            InitializeComponent();
            Container = BuildContainer(module);
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        IContainer BuildContainer(Module module)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LoginViewModel>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<OfferViewModel>().AsSelf();
            builder.RegisterType<NeedViewModel>().AsSelf();
            builder.RegisterType<SearchViewModel>().AsSelf();
            builder.RegisterType<NavigationService>().AsSelf().SingleInstance();
            builder.RegisterModule(module);
            return builder.Build();
        }
    }
}
