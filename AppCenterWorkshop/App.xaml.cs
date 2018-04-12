using System;

using Xamarin.Forms;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace AppCenterWorkshop
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public App()
        {
            InitializeComponent();

            AppCenter.Start("android=d7d60576-6532-482e-bfee-953ced2ff72a;" + "ios=b0502e2b-7c31-4dee-a6f2-a865d8ab7668;", typeof(Analytics), typeof(Crashes));

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }
    }
}
