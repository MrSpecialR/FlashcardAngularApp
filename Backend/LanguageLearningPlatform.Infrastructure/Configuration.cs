namespace LanguageLearningPlatform.Infrastructure
{
    using System;
    using System.Text;

    public class Configuration
    {
        public const string ConnectionString = "Server=.\\SQLEXPRESS;Database=LanguageLearningPlatform;Trusted_Connection=True;Integrated Security=True;MultipleActiveResultSets=true";

        // Example key - proof of concept, should be kept in secrets.json
        public static Byte[] Key { get; } = Encoding.UTF8.GetBytes("ca50e8fe1fb56a0bda7be616548aa207");
    }
}
