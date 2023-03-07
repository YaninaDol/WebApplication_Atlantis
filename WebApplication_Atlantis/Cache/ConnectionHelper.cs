using StackExchange.Redis;

namespace WebApplication_Atlantis
{
    public class ConnectionHelper
    {
        private static Lazy<ConnectionMultiplexer> _lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get { return _lazyConnection.Value; }
        }

        static ConnectionHelper()
        {
            _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisUrl"]);
            });
        }
    }
}
