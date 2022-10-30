namespace iTechArt.Service.Helpers
{
    public sealed class EnvironmentHelper
    {
        public static string WebRootPath { get; set; }
        public static string AttachmentPath => Path.Combine(WebRootPath, "files");
    }
}
