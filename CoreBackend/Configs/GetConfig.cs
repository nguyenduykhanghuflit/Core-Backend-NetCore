namespace CoreBackend.Configs
{
    public class GetConfig
    {
        private readonly IConfiguration _configuration;

        public GetConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetPokerConectionString()
        {
            return _configuration.GetConnectionString("POKER");
        }
    }
}
