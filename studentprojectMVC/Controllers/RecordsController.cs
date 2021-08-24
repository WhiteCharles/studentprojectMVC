//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using studentprojectMVC.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace studentprojectMVC.Controllers
//{
//    [AllowAnonymous]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RecordsController : ControllerBase
//    {
//        private readonly IRecordRepository _repository;

//        public RecordsController(IRecordRepository repository)
//        {
//            _repository = repository;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            try
//            {
//            var results = await _repository.GetAllRecordsAsync();

//            return Ok(results); 
//            }
//            catch (Exception)
//            {
//                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
//            }
//        }
//    }
//}
