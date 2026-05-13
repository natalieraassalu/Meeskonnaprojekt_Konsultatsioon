using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.View;
using System.Runtime.Versioning;

namespace Maui;

[SupportedOSPlatform("android24.0")]
[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
                                                    | ConfigChanges.UiMode | ConfigChanges.ScreenLayout
                                                    | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        if (OperatingSystem.IsAndroidVersionAtLeast(30))
        {
#pragma warning disable CA1422
            Window?.SetDecorFitsSystemWindows(true);
#pragma warning restore CA1422
        }

        if (Window?.DecorView != null)
        {
            ViewCompat.SetOnApplyWindowInsetsListener(Window.DecorView, new WindowInsetsListener());
        }
    }

    class WindowInsetsListener : Java.Lang.Object, IOnApplyWindowInsetsListener
    {
        public WindowInsetsCompat OnApplyWindowInsets(Android.Views.View v, WindowInsetsCompat insets)
        {
            var systemBars = insets.GetInsets(WindowInsetsCompat.Type.SystemBars());
            v.SetPadding(systemBars.Left, systemBars.Top, systemBars.Right, systemBars.Bottom);
            return insets;
        }
    }
}