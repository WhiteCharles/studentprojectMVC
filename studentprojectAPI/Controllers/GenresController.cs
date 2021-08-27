using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
    //[Route("api/genres")]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        //public GenresController(IGenreRepository genreRepository,
        //    IMapper mapper)
        //{
        //    _genreRepository = genreRepository ??
        //        throw new ArgumentNullException(nameof(genreRepository));
        //    _mapper = mapper ??
        //        throw new ArgumentNullException(nameof(mapper));
        //}

        public GenresController(IGenreRepository genreRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()  // getGenres
        {
            try
            {
                var results = await _genreRepository.GetAllGenresAsync();
                //if (false) return BadRequest("Bad stuff happens");
                GenreDTO[] DTOModels = _mapper.Map<GenreDTO[]>(results);
                return Ok(DTOModels);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database not responding");
            }
        }

        [HttpGet("{GenreName}")]
        public async Task<ActionResult<GenreDTO>> Get(string GenreName)
        {
            try
            {
                var result = await _genreRepository.GetGenreAsync(GenreName);

                if (result == null)
                {
                    return NotFound();
                }
                return _mapper.Map<GenreDTO>(result); ;
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database not responding");
            }
        }

        public async Task<ActionResult<GenreDTO>> Post(GenreDTO model)
        {
            try
            {
                var existing = await _genreRepository.GetGenreAsync(model.GenreName);

                if (existing != null)
                {
                    return BadRequest("Genre already present.");
                }

                var MainCategory = _linkGenerator.GetPathByAction("Get", "Genres",
                    new { genreName = model.GenreName }
                    );
                if (string.IsNullOrWhiteSpace(MainCategory))
                {
                    return BadRequest("Could not use current genreName.");
                }

                var genre = _mapper.Map<Models.Genre>(model);

                _genreRepository.Add(genre);

                if (await _genreRepository.SaveChangesAsync())
                {
                    return Created($"/api/genres/{genre.GenreName}", _mapper.Map<GenreDTO>(genre));
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Resource creation failed");
            }

            return BadRequest();
        }

        //[HttpGet()]
        //[HttpHead]
        //public ActionResult<IEnumerable<GenreDto>> GetGenres(
        //    [FromQuery] GenresResourceParameters genresResourceParameters)
        //{
        //    var genresFromRepo = _recordRepository.GetGenres(genresResourceParameters);
        //    return Ok(_mapper.Map<IEnumerable<GenreDto>>(genresFromRepo));
        //}

        //// GET api/genres
        ///// <summary>
        ///// GET Genres
        ///// </summary>
        ///// <returns>Retrieve Genres</returns>
        ///// <response code="200">Returns the Genres</response>
        ///// <response code="400">GET Request not processed</response>
        ///// <response code="404">Genres to GET not found</response>
        ///// <response code="500">Internal Server Error</response>
        ////[HttpGet]
        //[HttpGet()]
        //[HttpHead]  // retrieve info in response headers without transporting the response body
        //public ActionResult<IEnumerable<GenreDTO>> GetGenres()
        //{
        //    //throw new Exception("This is and unhandled exception.");
        //    var genresFromRepo = _genreRepository.GetGenres();
        //    var genres = new List<GenreDTO>();

        //    if (genresFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<GenreDTO>(genresFromRepo));
        //}

        //// GET api/genre
        ///// <summary>
        ///// GET a Genre
        ///// </summary>
        ///// <returns>Retrieve a Genre</returns>
        ///// <response code="200">Returns the specific Genre</response>
        ///// <response code="400">GET Request not processed</response>
        ///// <response code="404">Genre to GET not found</response>
        ///// <response code="500">Internal Server Error</response>
        //[HttpGet]
        ////[HttpGet("{genreId:guid}", Name = "GetGenre")]
        //[HttpGet("{genreId}")]
        //public IActionResult GetGenre(Guid genreId)
        //{
        //    //throw new Exception("This is and unhandled exception.");
        //    var genreFromRepo = _genreRepository.GetGenre(genreId);

        //    if (genreFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    //return Ok(_mapper.Map<GenreDto>(genreFromRepo));
        //    return Ok(_mapper.Map<GenreDTO>(genreFromRepo));
        //}

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
