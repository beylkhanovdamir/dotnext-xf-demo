using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Todo
{
	public class CustomBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry entry)
		{
			entry.TextChanged += OnEntryTextChanged;
			base.OnAttachedTo(entry);
		}

		protected override void OnDetachingFrom(Entry entry)
		{
			entry.TextChanged -= OnEntryTextChanged;
			base.OnDetachingFrom(entry);
		}

		void OnEntryTextChanged(object sender, TextChangedEventArgs args)
		{
			bool isValid = args.NewTextValue.Length < 15;
			((Entry)sender).Text = isValid ? args.NewTextValue : args.OldTextValue;
		}
	}
}
