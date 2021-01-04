using System;
using System.Collections.Generic;
using CourseReactorAPI.Models;
using System.Data.SQLite;

namespace CourseReactorAPI.Repositories
{
    public sealed class CookieRepository : ICookieRepository
    {
        private SQLiteConnection _conn;

        public CookieRepository(string conn)
        {
            _conn = new SQLiteConnection(conn);
            _conn.Open();

            using var cmd = new SQLiteCommand(CookieQueries.CREATE_TABLE, _conn);
            cmd.ExecuteNonQuery();
        }

        public void AddFakeDataToTables()
        {

        }

        public void Insert(Cookie cookie)
        {
            using var cmd = new SQLiteCommand(CookieQueries.INSERT, _conn);

            cmd.Parameters.AddWithValue("$Name", cookie.Name);
            cmd.Parameters.AddWithValue("$Desc", cookie.Description);
            cmd.Parameters.AddWithValue("$Recipe", cookie.Recipe);
            cmd.ExecuteNonQuery();
        }
        public Cookie GetById(int id)
        {
            using var cmd = new SQLiteCommand(CookieQueries.GET_BY_ID, _conn);
            cmd.Parameters.AddWithValue("$Id", id);

            using var reader = cmd.ExecuteReader();
            reader.Read();

            return new Cookie
            {
                Id               = reader.GetInt32(0),
                Name             = reader.GetString(1),
                Description      = reader.GetString(2),
                Recipe           = reader.GetString(3)
            };
        }

        public List<Cookie> GetByAmount(int amount)
        {
            var cookies = new List<Cookie>();
            using var cmd = new SQLiteCommand(CookieQueries.GET_BY_AMOUNT, _conn);
            cmd.Parameters.AddWithValue("$Limit", amount);

            using var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                var cookie = new Cookie
                {
                    Id               = reader.GetInt32(0),
                    Name             = reader.GetString(1),
                    Description      = reader.GetString(2),
                    Recipe           = reader.GetString(3)
                };

                cookies.Add(cookie);
            }

            return cookies;
        }

        public void Update(Cookie cookie)
        {
            using var cmd = new SQLiteCommand(CookieQueries.UPDATE, _conn);

            cmd.Parameters.AddWithValue("$Id", cookie.Id);
            cmd.Parameters.AddWithValue("$Name", cookie.Name);
            cmd.Parameters.AddWithValue("$Desc", cookie.Description);
            cmd.Parameters.AddWithValue("$Recipe", cookie.Recipe);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var cmd = new SQLiteCommand(CookieQueries.DELETE, _conn);

            cmd.Parameters.AddWithValue("$Id", id);
            cmd.ExecuteNonQuery();
        }
    }

    static class CookieQueries
    {
        public const string CREATE_TABLE = 
            @"CREATE TABLE IF NOT EXISTS Cookies (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name VARCHAR(40),
                Desc VARCHAR(344),
                Recipe TEXT
            )"; 

        public const string INSERT = 
            @"INSERT INTO Cookies (Name, Desc, Recipe) VALUES ($Name, $Desc, $Recipe)";

        public const string GET_BY_ID = 
            @"SELECT * FROM Cookies WHERE Id = $Id";

        public const string GET_BY_AMOUNT = 
            @"SELECT * FROM Cookies LIMIT $Limit";
        
        public const string UPDATE = 
            @"UPDATE Cookies SET
                Name = $Name,
                Desc = $Desc,
                Recipe = $Recipe,
                WHERE Id = $Id";

        public const string DELETE = 
            @"DELETE FROM Cookies WHERE Id = $Id";
    }
}