using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieBrowser.Models
{
    public class Movie : BaseDataObject
	{
	    [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
	    public bool Video { get; set; }
	    [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }
	    public string Title { get; set; }
	    public double Popularity { get; set; }
	    [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
	    [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }
	    [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }
	    [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }
	    [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
	    public bool Adult { get; set; }
	    public string Overview { get; set; }
	    [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
        public List<string> Genres { get; set; }
	    
	}

    public class MovieList
    {
        public List<Movie> Results { get; set; }
        public int Page { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
