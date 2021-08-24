using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using studentprojectAPI.DTOmodels;
using studentprojectAPI.Models;
using studentprojectAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace studentprojectAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/genres/{genreId}/records")] // expose records via the genres
    //[Route("api/records")]
    //[Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class RecordController : ControllerBase
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public RecordController(IRecordRepository recordRepository,
            IMapper mapper)
        {
            _recordRepository = recordRepository ??
                throw new ArgumentNullException(nameof(recordRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        //public RecordController(IRecordRepository recordRepository)
        //{
        //    _recordRepository = recordRepository ??
        //        throw new ArgumentNullException(nameof(recordRepository));
        //}

        // GET api/records
        /// <summary>
        /// GET Records
        /// </summary>
        /// <returns>Retrieve Records</returns>
        /// <response code="200">Returns the Records</response>
        /// <response code="400">GET Request not processed</response>
        /// <response code="404">Records to GET not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [HttpGet()]
        public ActionResult<IEnumerable<RecordDTO>> GetRecords()
        {
            throw new Exception("This is and unhandled exception.");
            var recordsFromRepo = _recordRepository.GetRecords();
            var records = new List<RecordDTO>();

            if (recordsFromRepo == null)
            {
                return NotFound("No records found.");
            }
            return Ok(_mapper.Map<IEnumerable<RecordDTO>>(recordsFromRepo));
        }

        // GET api/record
        /// <summary>
        /// GET a Record
        /// </summary>
        /// <returns>Retrieve a Record</returns>
        /// <response code="200">Returns the specific Record</response>
        /// <response code="400">GET Request not processed</response>
        /// <response code="404">Record to GET not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        //[HttpGet("{recordId:guid}", Name = "GetRecord")]
        [HttpGet("{recordId}")]
        public IActionResult GetRecord(Guid recordId)
        {
            try
            {
                var recordFromRepo = _recordRepository.GetRecord(recordId);

                if (recordFromRepo == null)
                {
                    return NotFound($"Record {recordId} not found.");
                }
                return Ok(_mapper.Map<RecordDTO>(recordFromRepo));
            }
            catch (Exception)
            {
                throw new Exception("This is and unhandled exception.");
            }
        }

        // GET api/genres/{recordId}/records
        /// <summary>
        /// GET Records per Genre
        /// </summary>
        /// <returns>Retrieve Records per Genre</returns>
        /// <response code="200">Returns the Record per Genre</response>
        /// <response code="400">GET Request not processed</response>
        /// <response code="404">Record to GET not found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        //[HttpGet("{recordId:guid}", Name = "GetRecord")]
        //[HttpGet("{genreId}")]
        public ActionResult<IEnumerable<RecordDTO>> GetRecordsForGenre(Guid genreId)
        {
            if (!_genreRepository.GenreExists(genreId))
            {
                return NotFound();
            }

            try
            {
                var recordsForGenreFromRepo = _recordRepository.GetRecord(genreId);
                return Ok(_mapper.Map<IEnumerable<RecordDTO>>(recordsForGenreFromRepo));
            }
            catch (Exception)
            {
                throw new Exception("Sorry, Unhandled Exception in Student Project API. Please try again later.");
            }
        }

        [HttpGet("{recordId}", Name = "GetRecordeForGenre")]
        public ActionResult<RecordDTO> GetRecordForGenre(Guid genreId, Guid recordId)
        {
            
            if (!_genreRepository.GenreExists(genreId))
            {
                return NotFound($"No success finding Record {recordId}.");
            }
            try
            {
                var recordForGenreFromRepo = _recordRepository.GetRecord(genreId, recordId);

                if (recordForGenreFromRepo == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<RecordDTO>(recordForGenreFromRepo));
            }
            catch (Exception)
            {
                throw new Exception("Sorry, Unhandled Exception in Student Project API. Please try again later.");
            }            
        }
        // GET api/album/{searchTerm}
        [HttpGet("{searchTerm}")]
        public ActionResult<IEnumerable<Record>> Find(string searchTerm)
        {
            //var foundRecords = MockRecordRepository.AllRecords.Values.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower())); // AppDbContext.Records.Values.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            //if (foundRecords.Count() == 0)
            //    return NotFound();

            //return foundRecords.ToList();
            return NotFound("Record has not been found.");
        }

        // GET api/record/3
        /// <summary>
        /// GET a Record
        /// </summary>
        /// <returns>Retrieve a Record</returns>
        /// <response code="200">Returns the specific Record</response>
        /// <response code="400">GET Request not processed</response>
        /// <response code="404">Record to GET not found</response>
        /// <response code="500">Internal Server Error</response>
        /// 
        [HttpGet("{id:Guid?}")]
        //public IEnumerable<Record> Get()
        public ActionResult<Record> Get(Guid recordId)
        {
            //throw new Exception("This is and unhandled exception.");
            //if (Record.TryGetValue(recordId, out Record record))
            //{
            //    return Ok(record);
            //}
            try
            {
                return _recordRepository.GetRecordById(recordId);
            }
            catch (Exception)
            {
                throw new Exception("Sorry, Unhandled Exception in Student Project API. Please try again later.");
            }
            
            ////{
            ////    return NotFound();
            ////};
            //return NotFound();
        }



        /// <summary>
        /// Delete a Record
        /// </summary>
        /// /// <returns>A record deleted</returns>
        /// <response code="200">If the record is deleted</response>
        /// <response code="204">If no content is available</response>
        /// <response code="400">Deletion Request not processed</response>
        /// <response code="404">Record to delete not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(long id)
        {
            //var record = AppContext;
            return NoContent();
        }

        /// <summary>
        /// Creates a Record.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Record
        ///     {
        ///        "RecordId": 1,
        ///        "name": "Record1",
        ///        "isAvailable": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created Record</returns>
        /// <response code="201">Returns the newly created Record</response>
        /// <response code="204">If no content is available</response>
        /// <response code="400">If the Record is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Record> Create(Record record)
        {
            // .Add(Record);
            // .SaveChanges();

            //return CreatedAtRoute("GetRecord", new { id = Record.RecordId }, Record);
            return null;
        }

    }
}
