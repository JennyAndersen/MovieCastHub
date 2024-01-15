﻿using Application.Movies.Queries.GetAllComedy;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComedyController : ControllerBase
    {

        internal readonly IMediator _mediator;

        public ComedyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all comedy movies 

        [HttpGet]
        [Route("getAllComedyMovies")]
        public async Task<IActionResult> GetAllComedyMovies()
        {

            try
            {
                var comedyMovies = await _mediator.Send(new GetAllComedyMoviesQuery());
                return comedyMovies == null ? NotFound("No comedy movies found.") : Ok(comedyMovies);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }

        }
        /*
        // Get ComedyMovie by Title 

        // Get ComedyMovie by Direcgtor 

        // Add new ComedyMovie 

        [HttpPost]
        [Route("addNewComedyMovie")]

        // Update ComedyMovie 

        [HttpPut]
        [Route("updateComedyMovie/{updatedComedyMovieId}")]

        // Delete ComedyMovie by ID 

        [HttpDelete]
        [Route("deleteComedyMovies/{deletedComedyMovieIdw}")]
        */
    }

}