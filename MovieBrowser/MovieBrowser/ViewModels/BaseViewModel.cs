using MovieBrowser.Helpers;
using MovieBrowser.Models;
using MovieBrowser.Services;

using Xamarin.Forms;

namespace MovieBrowser.ViewModels
{
	public class BaseViewModel : ObservableObject
	{
		public IDataStore<Movie> DataStore => DependencyService.Get<IDataStore<Movie>>();

		bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
		    set => SetProperty(ref _isBusy, value);
		}
		/// <summary>
		/// Private backing field to hold the title
		/// </summary>
		string _title = string.Empty;
		/// <summary>
		/// Public property to set and get the title of the movie
		/// </summary>
		public string Title
		{
			get => _title;
		    set => SetProperty(ref _title, value);
		}
	}
}

