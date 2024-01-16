﻿using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IMovieRepository
    {
        Task AddMovieAsync<T>(T entity) where T : class;
        Task<List<Comedy>> GetAllComedyMoviesQuery();
        Task<List<Movie>> GetByDirectorAsync(string director);
        Task<List<Movie>> GetByTitleAsync(string title);
    }
}