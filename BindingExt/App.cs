using System;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace BindingExt
{
	public interface IAppContext
	{
		Task<bool> Confirm(string message, string accept = "Ok");
	}

	public class App : Application, IAppContext
	{
		protected readonly NavigationPage Nav;

		public App ()
		{
			var vm = new EntryViewModel (this);

			Nav = new NavigationPage (new EntryView {
				BindingContext = vm,
			});

			// The root page of your application
			MainPage = Nav;
		}

		#region IAppContext implementation

		public Task<bool> Confirm (string message, string accept = "Ok")
		{
			return Nav.DisplayAlert ("Alert", message, accept, "Cancel");
		}

		#endregion

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

