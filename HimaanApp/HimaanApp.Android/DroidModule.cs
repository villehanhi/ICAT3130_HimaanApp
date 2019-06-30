using Autofac;
using HimaanApp.Droid.Service;
using HimaanApp.Services;

namespace HimaanApp.Droid
{
    class DroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
        }
    }
}