// ITVShowService.cs
using TvShowApi.Models;

namespace TvShowApi.Services
{
    public interface ITVShowService
    {
        IEnumerable<TVShow> GetAll();
        TVShow GetById(int id);
        void Add(TVShow tvShow);
        void Update(TVShow tvShow);
        void Delete(int id);
    }
}
