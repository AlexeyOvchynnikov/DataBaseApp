using Android.App;
using Android.Content.PM;
using Android.OS;
using DataBaseApp.Droid.Autofac;

namespace DataBaseApp.Droid
{
    [Activity(Label = "DataBaseApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            var application = new App(new PlatformSpecificModule());
            LoadApplication(application);
        }
    }
}
