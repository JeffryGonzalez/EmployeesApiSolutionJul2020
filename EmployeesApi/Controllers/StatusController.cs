using EmployeesApi.Models;
using EmployeesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class StatusController : ControllerBase
    {

        ISystemTime Time;

        public StatusController(ISystemTime time)
        {
            Time = time;
        }



        // GET /status 
        [HttpGet("status")]
        [Produces("application/json")]
        public ActionResult<StatusResponse> GetStatus()
        {
            // 1. TODO: Go check the actual status
            var response = new StatusResponse
            {
                Status = "I'm Giving it all she's got, Captain!",
                CheckedBy = "Scottie",
                LastChecked = Time.GetCurrent().AddMinutes(-15),
                SingletonDemo = Time.GetCreatedAt()
            };
            return Ok(response);
        }

        // 1. Route Params
        /// <summary>
        /// Get a book by giving us the ID of the book.
        /// </summary>
        /// <param name="bookId">The id of the book you want to retrieve</param>
        /// <returns>Information about the books</returns>
        /// <response code="200">This worked! Here is your book</response>
        /// <response code="404">There is no book with that Id. Check yourself</response>
        [HttpGet("books/{bookId:int}")]
        [SwaggerResponse(200, "Everything is groovy", typeof(string))]
        [SwaggerResponse(400, "Cannot find that", typeof(ErrorResponse))]

        public ActionResult GetABook(int bookId)
        {
            // you look it up - if its there, return if not 404
            if (bookId % 2 == 0)
            {
                return Ok($"Getting you info for book {bookId}");
            } else
            {
                return NotFound();
            }
        }
        [HttpGet("blogs/{year:int}/{month:int:range(1,12)}/{day:int}")]
        public ActionResult GetBlogPostsFor(int year, int month, int day)
        {
            return Ok($"Getting blog posts for {month}/{day}/{year}");
        }

        // 2. Query Strings

        [HttpGet("books")] // Filter a collection resource
        public ActionResult GetBooks([FromQuery] string genre = "All")
        {
            return Ok($"Getting you books in the {genre} genre");
        }

        // 3. Briefly Headers
        [HttpGet("whoami")]
        public ActionResult WhoAmiI([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Ok($"I see you are running {userAgent}");
        }

        // 4. Entities

        [HttpPost("games")] // when it calls the method, it creates an instance of game.
        // it deserializes the JSON into game.
        // then it runs the validation attributes and uses the result to populate ModelState.
        public ActionResult AddGame([FromBody] PostGameRequest game)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok($"adding {game.Title} for {game.Platform} for {game.Price.Value:c}");
            }
        }
    }

    public class PostGameRequest : IValidatableObject
    {
        [Required]
        [StringLength(50, ErrorMessage ="That name is too derned long!")]
        public string Title { get; set; }
        [Required]
        public string Platform { get; set; }

        [Required]
        
        public decimal? Price { get; set; }

        [Required]
        public string MPAARating { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title.ToLower() == "fortnite" && Platform.ToLower() == "ps4")
            {
                yield return new ValidationResult("It sucks on the ps4"
                    , new string[] { "Title", "Platform" });
            }
        }
    }


    public class StatusResponse
    {
        public string Status { get; set; }
        public string CheckedBy { get; set; }
        public DateTime LastChecked { get; set; }
        public DateTime SingletonDemo { get; set; }
    }
}
