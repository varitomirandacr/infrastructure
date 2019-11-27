using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Creational.Singleton
{
    // Simple Singleton
    public class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        public static Singleton GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public static void BusinessLogic()
        {
            // ...
        }
    }

    // Thread-Safe Singleton
    public class ThreadSafeSingleton
    {
        private ThreadSafeSingleton() { }

        private static ThreadSafeSingleton _instance;

        // sync threads
        private static readonly object _lock = new object();

        public static ThreadSafeSingleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeSingleton();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        public string Value { get; set; }
    }

    // Real World Scenario
    public class LoadBalancer
    {
        private static readonly LoadBalancer _instance = new LoadBalancer();
        private List<Server> _servers = new List<Server>();
        private Random _random = new Random();

        private LoadBalancer()
        {
            _servers = new List<Server>
            {
                new Server { Name = "SRV-01-APP", IP = "192.168.20.10" },
                new Server { Name = "SRV-02-APP", IP = "192.168.20.11" },
                new Server { Name = "SRV-03-APP", IP = "192.168.20.12" },
                new Server { Name = "SRV-04-APP", IP = "192.168.20.13" },
                new Server { Name = "SRV-05-APP", IP = "192.168.20.14" }
            };
        }

        private static object syncLock = new object();
        public static LoadBalancer GetLoadBalancer()
        {
            // using thread-safe lock
            /*
             if (_instance == null)  
             {
                  lock (syncLock) 
                  {
                      if (_instance == null)  
                      {
                          _instance = new LoadBalancer();
                      }
                  }
             }
             */

            // When using the compiler after creating 
            // the readonly instance
            return _instance;
        }

        public string Server
        {
            get
            {
                int next = _random.Next(_servers.Count);
                return _servers[next].ToString();
            }
        }
    }

    public class Server
    {
        // Gets or sets server name
        public string Name { get; set; }
        // Gets or sets server IP address
        public string IP { get; set; }

        public override string ToString()
        {
            return $"Server: {Name} - IP: {IP}";
        }
    }
}
