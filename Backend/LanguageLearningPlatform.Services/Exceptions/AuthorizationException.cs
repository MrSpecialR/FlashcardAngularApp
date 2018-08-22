namespace LanguageLearningPlatform.Services.Exceptions
{
    using System;

    public class AuthorizationException : Exception
    {
        public AuthorizationException()
        {

        }
        public AuthorizationException(string message)
            : base(message)
        {
        }
    }
}