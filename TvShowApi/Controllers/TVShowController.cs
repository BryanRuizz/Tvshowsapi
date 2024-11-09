using Microsoft.AspNetCore.Mvc;
using TvShowApi.Models;
using TvShowApi.Services;
using TvShowApi.DTOs;

namespace TvShowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TVShowController : ControllerBase
    {
        private readonly ITVShowService _tvShowService;//service interface

        public TVShowController(ITVShowService tvShowService)
        {
            _tvShowService = tvShowService;//constructor
        }


        //get eveything from our services data
        [HttpGet]
        public ActionResult<IEnumerable<TVShow>> GetAll()
        {
            return Ok(_tvShowService.GetAll());
        }


        //an specific tvshow
        [HttpGet("{id}")]
        public ActionResult<TVShow> GetById(int id)
        {
            var tvShow = _tvShowService.GetById(id);
            if (tvShow == null) return NotFound();
            return Ok(tvShow);
        }


        [HttpPost]
        public ActionResult<TVShow> Create(CreateTVShowDto createDto)
        {
            if (createDto == null) return BadRequest("Invalid data.");//validation

            var tvShow = new TVShow
            {
                Name = createDto.Name,
                Favorite = createDto.Favorite
            };
            _tvShowService.Add(tvShow);

            return CreatedAtAction(nameof(GetById), new { id = tvShow.Id }, tvShow);
        }// create a tvshow

        
        
        [HttpPut("{id}")]//param
        public IActionResult Update(int id, UpdateTVShowDto updateDto)
        {
            if (updateDto == null) return BadRequest("Invalid data.");

            var existingTVShow = _tvShowService.GetById(id);//verification if it's really existing 
            if (existingTVShow == null) return NotFound();

            existingTVShow.Name = updateDto.Name;
            existingTVShow.Favorite = updateDto.Favorite;

            _tvShowService.Update(existingTVShow);
            return Ok(existingTVShow);
        }//Updating a tv show 

        
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tvShow = _tvShowService.GetById(id);
            if (tvShow == null) return NotFound();// if it does not exist return 404

            _tvShowService.Delete(id);
            return Ok(id);//else return id
        }
        //


    }
}
