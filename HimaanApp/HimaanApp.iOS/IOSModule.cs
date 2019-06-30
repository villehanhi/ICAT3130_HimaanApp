using Autofac;
using HimaanApp.iOS.Services;
using HimaanApp.Services;

namespace HimaanApp.iOS
{
    public class IOSModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
        }
    }
}
