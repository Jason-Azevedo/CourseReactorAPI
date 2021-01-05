using System;

namespace CourseReactorAPI.Models
{
    public class CookieValidator
    {
        private readonly CookieValidatorOptions _options;

        public CookieValidator()
        {
            _options = new CookieValidatorOptions();
        }

        public CookieValidator(Action<CookieValidatorOptions> config)
            : this()
        {
            config(_options);
        }

        public bool Validate(Cookie cookie)
        {
            if (_options.IdNotZero)
            {
                if (cookie.Id == 0) return false;
            } 
            else if (_options.NameNotEmpty)
            {
                if (cookie.Name == string.Empty) return false;
            }
            else if (_options.DescNotEmpty)
            {
                if (cookie.Description == string.Empty) return false;
            }
            else if (_options.RecipeNotEmpty)
            {
                if (cookie.Recipe == string.Empty) return false;
            }

            return true;
        }
    }

    public class CookieValidatorOptions 
    {
        public bool IdNotZero { get; set; } = false;
        public bool NameNotEmpty { get; set; } = true;
        public bool DescNotEmpty { get; set; } = true;
        public bool RecipeNotEmpty { get; set; } = true;
    }
}