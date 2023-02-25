using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.DAL.Interfaces
{
    public interface IMovies_GenderRepository
    {
        void Add(Movies_Gender movieGender);
        void Update(Movies_Gender movieGender);
        void Delete(Movies_Gender movieGender);

        Movies_Gender Get(int id);
        bool Exists(string txt_desc);

        List<Movie_GenderModel> GetAll(); 
    }
}
