using System;
using System.Collections.Generic;
using CourseReactorAPI.Models;
using System.Data.SQLite;

namespace CourseReactorAPI.Repositories
{
    public sealed class CookieRepository : ICookieRepository
    {
        private SQLiteConnection _conn;

        /// <summary>
        ///     Creates the connection to the sqlite db and opens it, 
        ///     thereafter creating the cookie table if it does not exist
        /// </summary>
        /// <param name="conn">
        ///     The string that represents the sqlite connection
        ///     string
        /// </param>
        public CookieRepository(string conn)
        {
            _conn = new SQLiteConnection(conn);
            _conn.Open();

            using var cmd = new SQLiteCommand(CookieQueries.CREATE_TABLE, _conn);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///     Inserts an entry into the cookie table based on the 
        ///     properties of the supplied Cookie object
        /// </summary>
        /// <param name="cookie">The Cookie object to be inserted into the db</param>
        public void Insert(Cookie cookie)
        {
            using var cmd = new SQLiteCommand(CookieQueries.INSERT, _conn);

            cmd.Parameters.AddWithValue("$Name", cookie.Name);
            cmd.Parameters.AddWithValue("$Desc", cookie.Description);
            cmd.Parameters.AddWithValue("$Recipe", cookie.Recipe);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///     Gets the specific entry as a Cookie object
        /// </summary>
        /// <param name="id">The id of the cookie</param>
        /// <returns>A Cookie object instance with the relevant data based on the id</returns>
        public Cookie GetById(int id)
        {
            using var cmd = new SQLiteCommand(CookieQueries.GET_BY_ID, _conn);
            cmd.Parameters.AddWithValue("$Id", id);

            using var reader = cmd.ExecuteReader();
            reader.Read();
            
            // Item not found
            if (!reader.HasRows) return null;

            return new Cookie
            {
                Id               = reader.GetInt32(0),
                Name             = reader.GetString(1),
                Description      = reader.GetString(2),
                Recipe           = reader.GetString(3)
            };
        }

        /// <summary>
        ///     Gets a specified amount of entries as Cookie objects
        /// </summary>
        /// <param name="amount">The amount of cookies to be fetched from the db</param>
        /// <returns>A List of Cookie objects</returns>
        public List<Cookie> GetByAmount(int amount)
        {
            var cookies = new List<Cookie>();
            using var cmd = new SQLiteCommand(CookieQueries.GET_BY_AMOUNT, _conn);
            cmd.Parameters.AddWithValue("$Limit", amount);

            using var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                // Items not found
                if (!reader.HasRows) break;

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

        /// <summary>
        ///     Updates the specific entry based on the provided Cookie objects id
        ///     with that object's properties
        /// </summary>
        /// <param name="cookie">The Cookie to be updated with it's new values</param>
        public void Update(Cookie cookie)
        {
            using var cmd = new SQLiteCommand(CookieQueries.UPDATE, _conn);

            cmd.Parameters.AddWithValue("$Id", cookie.Id);
            cmd.Parameters.AddWithValue("$Name", cookie.Name);
            cmd.Parameters.AddWithValue("$Desc", cookie.Description);
            cmd.Parameters.AddWithValue("$Recipe", cookie.Recipe);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        ///     Deletes an entry based on the id supplied
        /// </summary>
        /// <param name="id">The id of the entry to be deleted</param>
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
                Recipe = $Recipe
                WHERE Id = $Id";

        public const string DELETE = 
            @"DELETE FROM Cookies WHERE Id = $Id";
    }
}