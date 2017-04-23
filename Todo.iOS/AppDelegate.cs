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

			return base.FinishedLaunching(app, options);
		}
	}
}