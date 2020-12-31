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

        private void InitializeTables()
        {
        }

        public void AddFakeDataToTables()
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

    static class CookieQueries
    {
        public const string CREATE_TABLE = 
            @"CREATE TABLE IF NOT EXISTS Cookies (
                Name VARCHAR(40),
                Desc VARCHAR(344),
                Ingredients TEXT,
                Recipe TEXT
            )"; 

        public const string INSERT = 
            @"INSERT INTO Cookies (Name, Desc, Ingredients, Recipe) VALUES (?,?,?,?)";

        public const string GET_BY_ID = 
            @"SELECT * FROM Cookies WHERE rowid = ?";

        public const string GET_BY_AMOUNT = 
            @"SELECT * FROM Cookies LIMIT ?";

        public const string UPDATE = 
            @"UPDATE Cookies SET
                Name = ?,
                Desc = ?,
                Ingredients = ?,
                Recipe = ?
                WHERE rowid = ?";

        public const string DELETE = 
            @"DELETE FROM Cookies WHERE rowrowid = ?";
    }
}