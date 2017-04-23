using Android.App;
using Android.OS;
using Android.Content.PM;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace Todo
{
	[Activity(Label = "Todo", Icon = "@drawable/icon", MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity :
	global::Xamarin.Forms.Platform.Android.FormsApplicationActivity // superclass new in 1.3
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());

			MobileCenter.Start("e04e4274-9cd7-44fb-a984-70558d46eb82",
				   typeof(Analytics), typeof(Crashes));

			UISleuth.Inspector.Init();

			// Optional*
			UISleuth.Inspector.ShowAcceptingConnections();
		}
	}
}
