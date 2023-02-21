using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Models;
using System.Collections.Generic;
namespace ItlaFlixApp.DAL.Interfaces
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(Movie movie);
        List<MovieModel> GetAll();
        Movie Get(int id);
        bool Exists (int  cod_pelicula);  
    }
}
