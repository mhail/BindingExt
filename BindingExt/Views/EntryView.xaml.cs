using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BindingExt
{
	public partial class EntryView : ContentPage
	{
		public static readonly Binding Name = Binding.Create<EntryViewModel>(vm=>vm.Name);
		public static readonly Binding Email = Binding.Create<EntryViewModel>(vm=>vm.Email);
		public static readonly Binding Submit = Binding.Create<EntryViewModel>(vm=>vm.SubmitCommand);

		public EntryView ()
		{
			InitializeComponent ();
		}
	}
}

