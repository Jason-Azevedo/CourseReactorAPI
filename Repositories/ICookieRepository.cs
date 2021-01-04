using System;
using System.Collections.Generic;
using CourseReactorAPI.Models;

namespace CourseReactorAPI.Repositories
{
    public interface ICookieRepository
    {
       public void Insert(Cookie cookie); 
       public Cookie GetById(int id); 
       public List<Cookie> GetByAmount(int amount);
       public void Update(Cookie item);
       public void Delete(int id);
    }
}