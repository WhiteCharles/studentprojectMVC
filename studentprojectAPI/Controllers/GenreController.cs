using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentprojectAPI.DTOmodels;
using studentprojectAPI.ResourceParameters;
using studentprojectAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/genres")]
    //[Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository genreRepository,
            IMapper mapper)
        {
            _genreRepository = genreRepository ??
                throw new ArgumentNullException(nameof(genreRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet()]
        //[HttpHead]
        //public ActionResult<IEnumerable<GenreDto>> GetGenres(
        //    [FromQuery] GenresResourceParameters genresResourceParameters)
        //{
        //    var genresFromRepo = _recordRepository.GetGenres(genresResourceParameters);
        //    return Ok(_mapper.Map<IEnumerable<GenreDto>>(genresFromRepo));
        //}

        // GET api/genres
        /// <summary>
        /// GET Genres
        /// </summary>
        /// <returns>Retrieve Genres</returns>
        /// <response code="200">Returns the Genres</response>
        /// <response code="400">GET Request not processed</response>
        /// <response code="404">Genres to GET not found</response>
        /// <response code="500">Internal Server Error</response>
        //[HttpGet]
        [HttpGet()]
        [HttpHead]  // retrieve info in response headers without transporting the response body
        public ActionResult<IEnumerable<GenreDTO>> GetGenres()
        {
            //throw new Exception("This is and unhandled exception.");
            var genresFromRepo = _genreRepository.GetGenres();
            var genres = new List<GenreDTO>();

            if (genresFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GenreDTO>(genresFromRepo));
        }

        // GET api/genre
        /// <summary>
        /// GET a Genre
        /// </summary>
        /// <returns>Retrieve a Genre</returns>
        /// <response code="200">Returns the specific Genre</response>
        /// <response code="400">GET Request not processed</response>
        /// <response code="404">Genre to GET not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        //[HttpGet("{genreId:guid}", Name = "GetGenre")]
        [HttpGet("{genreId}")]
        public IActionResult GetGenre(Guid genreId)
        {
            //throw new Exception("This is and unhandled exception.");
            var genreFromRepo = _genreRepository.GetGenre(genreId);

            if (genreFromRepo == null)
            {
                return NotFound();
            }

            //return Ok(_mapper.Map<GenreDto>(genreFromRepo));
            return Ok(_mapper.Map<GenreDTO>(genreFromRepo));
        }

        //[HttpPost]
        //public ActionResult<GenreDto> CreateGenre(GenreForCreationDto genre)
        //{
        //    var genreEntity = _mapper.Map<Entities.Genre>(genre);
        //    _recordRepository.AddGenre(genreEntity);
        //    _recordRepository.Save();

        //    var genreToReturn = _mapper.Map<GenreDto>(genreEntity);
        //    return CreatedAtRoute("GetGenre",
        //        new { genreId = genreToReturn.Id },
        //        genreToReturn);
        //}

        //[HttpOptions]
        //public IActionResult GetGenresOptions()
        //{
        //    Response.Headers.Add("Allow", "GET,OPTIONS,POST");
        //    return Ok();
        //}

        //[HttpDelete("{genreId}")]
        //public ActionResult DeleteGenre(Guid genreId)
        //{
        //    var genreFromRepo = _recordRepository.GetGenre(genreId);

        //    if (genreFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    _recordRepository.DeleteGenre(genreFromRepo);

        //    _recordRepository.Save();

        //    return NoContent();
        //}
    }
}
