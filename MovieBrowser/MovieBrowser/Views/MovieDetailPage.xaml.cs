
using MovieBrowser.ViewModels;

using Xamarin.Forms;

namespace MovieBrowser.Views
{
	public partial class MovieDetailPage : ContentPage
	{
		MovieDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public MovieDetailPage()
        {
            InitializeComponent();
        }

        public MovieDetailPage(MovieDetailViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;
		}
	}
}
