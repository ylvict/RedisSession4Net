using ServiceStack.Redis;
using System;
using System.Collections;

namespace RedisSession4Net.Core.Cache
{
    public class RedisHelper
    {
        private static RedisConfig RedisConfig = RedisConfig.GetConfig();

        private static PooledRedisClientManager RedisManager
            => new PooledRedisClientManager(RedisConfig.ReadWriteServer, RedisConfig.ReadOnlyServer,
                new RedisClientManagerConfig
                {
                    MaxWritePoolSize = RedisConfig.MaxWritePoolSize,
                    MaxReadPoolSize = RedisConfig.MaxReadPoolSize,
                    AutoStart = RedisConfig.AutoStart,
                });

        public RedisHelper(string sessionId)
        {
            SessionId = sessionId;
        }

        private string SessionId { get; set; }

        private static IRedisClient Client = RedisManager.GetClient();

        private Hashtable SessionSet
        {
            get
            {
                var session = Client.Get<Hashtable>(this.SessionId);
                if (session == null) session = new Hashtable();
                return session;
            }
            set
            {
                Client.Set(SessionId, value, TimeSpan.FromSeconds(RedisConfig.LocalCacheTime));
            }
        }

        public T GetSession<T>()
            where T : ISessionPropertities, new()
        {
            T session = new T();
            session.Redis = this;
            return session;
        }

        public void Add<T>(string key, T value)
        {
            var hash = this.SessionSet;
            if (value == null && hash[key] != null)
                hash.Remove(key);
            else
                hash[key] = value;
            this.SessionSet = hash;
        }

        public T Get<T>(string key, Func<object, T> converter = null)
        {
            var value = this.SessionSet[key];
            if (value == null) return default(T);
            try
            {
                if (converter == null)
                    return (T)value;
                return converter(value);
            }
            catch (Exception) { return default(T); }
        }

        public bool Remove(string key)
        {
            return Client.Remove(key);
        }
    }
}