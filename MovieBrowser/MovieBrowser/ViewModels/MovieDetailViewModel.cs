using MovieBrowser.Models;

namespace MovieBrowser.ViewModels
{
	public class MovieDetailViewModel : BaseViewModel
	{
		public Movie Movie { get; set; }
		public MovieDetailViewModel(Movie movie = null)
		{
			Title = movie?.Title;
			Movie = movie;
		}

	    public string GenreStr => Movie.Genres == null ? "" : string.Join(" ", Movie.Genres);
    }
}