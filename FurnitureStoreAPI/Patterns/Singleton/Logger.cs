
namespace FurnitureStoreAPI.Patterns.Singleton
{
    public sealed class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private List<string> _logs = new List<string>();

        private Logger() { }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            _logs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public List<string> GetAllLogs()
        {
            return new List<string>(_logs);
        }
    }
}
