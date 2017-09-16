using System.Collections.Generic;

namespace MovieBrowser.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GenresList
    {
        public List<Genre> Genres { get; set; }
    }
}
