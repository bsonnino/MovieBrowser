using System;
using MovieBrowser.Models;
using MovieBrowser.ViewModels;

using Xamarin.Forms;

namespace MovieBrowser.Views
{
	public partial class MoviesPage : ContentPage
	{
		MoviesViewModel viewModel;

		public MoviesPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new MoviesViewModel();
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Movie;
			if (item == null)
				return;

			await Navigation.PushAsync(new MovieDetailPage(new MovieDetailViewModel(item)));

			// Manually deselect movie
			ItemsListView.SelectedItem = null;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);
		}

	    private async void AboutActivated(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new AboutPage());
        }
	}
}
