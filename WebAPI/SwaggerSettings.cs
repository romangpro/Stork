using System;

namespace WebAPI
{
    public class SwaggerSettings
    {
        public static readonly DateTime DateTime = new DateTime(2019, 1, 1);
        public const string Description = "TODO: Swagger custom Route options";
        public string Name { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
    }
}
