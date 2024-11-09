// TVShowService.cs
using TvShowApi.Models;

namespace TvShowApi.Services
{
    public class TVShowService : ITVShowService
    {
        private readonly List<TVShow> _tvShows;


        public TVShowService()
        {
            _tvShows = new List<TVShow>
            {
                new TVShow { Id = 1, Name = "Mr. Robot", Favorite = true },
                new TVShow { Id = 2, Name = "Deadpool & Wolverine", Favorite = true },
                new TVShow { Id = 3, Name = "The Social Dilemma", Favorite = true },
                new TVShow { Id = 4, Name = "Fast and furious", Favorite = false },
            };
        }
        //memory data as a DB

        public IEnumerable<TVShow> GetAll() => _tvShows;

        public TVShow GetById(int id) => _tvShows.FirstOrDefault(t => t.Id == id);//juts a function to figure out our param, T = tvshow row 

        public void Add(TVShow tvShow)
        {
            tvShow.Id = _tvShows.Any() ? _tvShows.Max(t => t.Id) + 1 : 1;
            _tvShows.Add(tvShow); // agrega a la lista

        }

        public void Update(TVShow tvShow)
        {
            var existingTVShow = GetById(tvShow.Id);
            if (existingTVShow != null)
            {
                existingTVShow.Name = tvShow.Name;
                existingTVShow.Favorite = tvShow.Favorite;//make the change
            }
        }

        public void Delete(int id)
        {
            var tvShow = GetById(id);
            if (tvShow != null)
            {
                _tvShows.Remove(tvShow);//method to delete from our list 
            }
        }
    }
}
