using UIKit;
using Foundation;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Todo
{
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			// affects all UISwitch controls in the app
			UISwitch.Appearance.OnTintColor = UIColor.FromRGB(0x91, 0xCA, 0x47);

			Forms.Init();
			LoadApplication(new App());

			UISleuth.Inspector.Init();

			// Optional*
			UISleuth.Inspector.ShowAcceptingConnections();

			MobileCenter.Start("37ef0777-8c25-459e-95e9-19a9e5ae5220",
				   typeof(Analytics), typeof(Crashes));

			return base.FinishedLaunching(app, options);
		}
	}
}