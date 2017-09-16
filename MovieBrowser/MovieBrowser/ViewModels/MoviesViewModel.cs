using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MovieBrowser.Helpers;
using MovieBrowser.Models;
using Xamarin.Forms;

namespace MovieBrowser.ViewModels
{
	public class MoviesViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Movie> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public MoviesViewModel()
		{
			Title = "Upcoming movies";
			Items = new ObservableRangeCollection<Movie>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(true);
				Items.ReplaceRange(items);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				MessagingCenter.Send(new MessagingCenterAlert
				{
					Title = "Error",
					Message = "Unable to load items.",
					Cancel = "OK"
				}, "message");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}