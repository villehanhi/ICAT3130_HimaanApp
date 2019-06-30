using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Firebase.Auth;

namespace HimaanApp.Droid
{
    [Activity(Label = "HimaanApp.Android", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //Options for firebase authentication
            FirebaseOptions options = new FirebaseOptions.Builder()
                .SetApiKey("AIzaSyAqk5UYOpQBZErOsXqWROajo1qkx_uQV0c")
                .SetApplicationId("1:81747878099:android:b59e30d886e4323f")
                .Build();
            FirebaseApp app = FirebaseApp.InitializeApp(this, options);
            FirebaseAuth authInstance = FirebaseAuth.GetInstance(app);
            LoadApplication(new App(new DroidModule()));
        }
    }
}
