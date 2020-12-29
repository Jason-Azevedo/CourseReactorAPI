using System;
using System.Collections.Generic;
using CourseReactorAPI.Models;

namespace CourseReactorAPI.Repositories
{
    public class CookieRepository : ICookieRepository
    {
        public CookieRepository()
        {
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Cookie> GetByAmount(int amount)
        {
            throw new System.NotImplementedException();
        }


        public Cookie GetById(int id)
        {
            return new Cookie {
                Id = id,
                Name = "Chocolate Chip Cookie",
                Description = "This is a chocolate chip cookie!",
                Ingredients = new List<string> {"Flour: 500g", "Milk: 250ml", "Eggs: 3", "Chocolate: 4bars"},
                Recipe = "Google it."
            };
        }

        public void Update(Cookie item)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}