﻿using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using MediatR;

namespace Application.Movies.Commands.Comedies.DeleteComedyMovieById
{
    public class DeleteComedyMovieByIdCommand : IRequest<bool>, IValidate
    {
        public DeleteComedyMovieByIdCommand(Guid movieId)
        {
            MovieId = movieId;
        }

        public Guid MovieId { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(MovieId, new GuidValidator());
        }
    }
}
