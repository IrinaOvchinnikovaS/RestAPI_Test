namespace RestAPI_Test
{
    public class Config
    {
        private IConfiguration _appConfiguration { get; set; }
        public string _resultFilePath { get; set; }

        public Config(IConfiguration AppConfiguration)
        {
            _appConfiguration = AppConfiguration;

            _resultFilePath = ReadResultFilePath();
        }

        private string ReadResultFilePath()
        {
            string newsContentPath = _appConfiguration.GetSection("PathToResultFolder").Value;

            return (string.IsNullOrEmpty(newsContentPath) || newsContentPath == "\\")
                ? Directory.GetCurrentDirectory()
                : newsContentPath;
        }
    }
}
