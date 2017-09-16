using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieBrowser.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(MovieBrowser.Services.MovieDataStore))]
namespace MovieBrowser.Services
{
	public class MovieDataStore : IDataStore<Movie>
	{
	    private const string ApiKey = "1f54bd990f1cdfb230adb312546d765d";
	    private const string BaseUrl = "http://api.themoviedb.org/3";

        readonly List<Movie> _movies;
	    private MoviesConfiguration _moviesConfiguration;
	    private Dictionary<int,string> _genres;

	    public MovieDataStore()
	    {
	        _movies = new List<Movie>();
	    }
		public async Task<Movie> GetItemAsync(string id)
		{
			return await Task.FromResult(_movies.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Movie>> GetItemsAsync(bool forceRefresh = false)
		{
		    _moviesConfiguration = await GetConfigurationAsync();
		    if (_moviesConfiguration == null)
		        return null;
		    var genres = await GetGenresAsync();
		    _genres = genres.Genres.ToDictionary(g => g.Id, g => g.Name);
		    var movies = await GetUpcomingMoviesAsync();
            _movies.AddRange(movies.Results);
		    var totalPages = movies.TotalPages;
		    for (int i = 2; i <= totalPages; i++)
		    {
		        movies = await GetUpcomingMoviesAsync(i);
		        _movies.AddRange(movies.Results);
            }
		    var posterWidth = _moviesConfiguration.Images.LogoSizes.Count > 0
		        ? _moviesConfiguration.Images.LogoSizes[0]
		        : "w500";

            foreach (var movie in _movies)
		    {
		        movie.Genres = movie.GenreIds.Select(i => _genres[i]).ToList();
		        movie.PosterPath = $"{_moviesConfiguration.Images.BaseUrl}/{posterWidth}/{movie.PosterPath}";
		        movie.BackdropPath = $"{_moviesConfiguration.Images.BaseUrl}/original/{movie.BackdropPath}";
		    }
			return _movies;
		}

	    private async Task<MoviesConfiguration> GetConfigurationAsync()
	    {
	        return await GetObjectAsync<MoviesConfiguration>("/configuration");
	    }

	    private async Task<GenresList> GetGenresAsync()
	    {
	        return await GetObjectAsync<GenresList>("/genre/movie/list") ;
	    }

        public async Task<Movie> GetMovieAsync(int id)
	    {
	        return await GetObjectAsync<Movie>($"/movie/{id}");
	    }
        
	    public async Task<MovieList> GetUpcomingMoviesAsync(int page = 1)
	    {
	        return await GetObjectAsync<MovieList>($"/movie/upcoming?page={page}");
	    }

	    private async Task<T> GetObjectAsync<T>(string resource) where T : new()
	    {
	        try
	        {
	            var response = await GetDataAsync(CreateUri(resource));
	            if (response.IsSuccessStatusCode)
	            {
	                var content = await response.Content.ReadAsStringAsync();
	                return JsonConvert.DeserializeObject<T>(content);
	            }
	            return default(T);
	        }
	        catch
	        {
	            return default(T);
	        }
	        
        }

	    private async Task<HttpResponseMessage> GetDataAsync(Uri uri)
	    {
	        using (var httpClient = new HttpClient(new HttpClientHandler()))
	        {
	            var httpResponseMessage = await httpClient.GetAsync(uri);
	            return httpResponseMessage;
	        }
	    }

	    private Uri CreateUri(string resource)
	    {
	        var apiSeparator = resource.Contains("?") ? "&" : "?";

            return new Uri($@"{BaseUrl}{resource}{apiSeparator}api_key={ApiKey}");
	    }
	}
}
