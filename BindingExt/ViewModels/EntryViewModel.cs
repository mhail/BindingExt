using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;

namespace BindingExt
{
	public class EntryViewModel : ViewModelBase
	{
		readonly IAppContext _appContext;

		public EntryViewModel(IAppContext context)
		{
			_appContext = context;
		}

		string _name;

		public string Name
		{
			get { return _name; }
			set { Set (() => Name, ref _name, value); }
		}

		string _email;

		public string Email
		{
			get { return _email; }
			set { Set (() => Email, ref _email, value); }
		}

		ICommand _submitCommand;
		public ICommand SubmitCommand
		{
			get { return _submitCommand ?? (_submitCommand = new Command (OnSubmit)); }
		}

		async void OnSubmit()
		{
			var result = await _appContext.Confirm (string.Format ("Name: {0}, Email: {1}", Name, Email));

			System.Diagnostics.Debug.WriteLine (result);

			if (!result) {
				Name = Email = string.Empty;
			}
		}
	}
}

