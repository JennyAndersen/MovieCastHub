﻿using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using Application.Behavior.Validators.Movie;
using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Comedies.UpdateComedyMovieById
{
    public class UpdateComedyMovieByIdCommand : IRequest<Comedy>, IValidate
    {
        public UpdateComedyMovieByIdCommand(UpdateMovieDto updatedComedyMovie, Guid id)
        {
            UpdatedComedyMovie = updatedComedyMovie;
            Id = id;
        }

        public UpdateMovieDto UpdatedComedyMovie { get; }
        public Guid Id { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(Id, new GuidValidator());
            ValidationHelper.ValidateAndThrow(UpdatedComedyMovie, new RatingValidator());
        }
    }
}
