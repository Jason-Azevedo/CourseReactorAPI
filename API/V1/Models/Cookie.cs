using System.Collections.Generic;

namespace CourseReactorAPI.API.v1.Models
{
    public class Cookie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public List<string> Ingredients { get; set; }
        public string Recipe { get; set; }
    }
}