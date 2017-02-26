using System;
using System.Collections.Generic;
using System.Text;
using Todo;
using Todo.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace Todo.iOS
{
	public class CustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.SpellCheckingType = UITextSpellCheckingType.No;             // No Spellchecking
				Control.AutocorrectionType = UITextAutocorrectionType.No;           // No Autocorrection
				Control.AutocapitalizationType = UITextAutocapitalizationType.None; // No Autocapitalization
				Control.ReturnKeyType = UIReturnKeyType.Go;
			}
		}
	}
}
