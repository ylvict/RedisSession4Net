using System.Configuration;

namespace RedisSession4Net.Core.Cache
{
    public sealed class RedisConfig : ConfigurationSection
    {
        public static RedisConfig GetConfig()
        {
            RedisConfig section = GetConfig("RedisConfig");
            return section;
        }

        public static RedisConfig GetConfig(string sectionName)
        {
            RedisConfig section = ConfigurationManager.GetSection(sectionName) as RedisConfig;
            if (section == null)
                throw new ConfigurationErrorsException("Section " + sectionName + " is not found.");
            return section;
        }

        [ConfigurationProperty(nameof(ReadWriteServerStr), IsRequired = false)]
        public string ReadWriteServerStr
        {
            get
            {
                return (string)base[nameof(ReadWriteServerStr)];
            }
            set
            {
                base[nameof(ReadWriteServerStr)] = value;
            }
        }

        public string[] ReadWriteServer
        {
            get
            {
                return this.ReadWriteServerStr.Split(',');
            }
            set
            {
                this.ReadWriteServerStr = string.Join(",", value);
            }
        }

        [ConfigurationProperty(nameof(ReadOnlyServerStr), IsRequired = false)]
        public string ReadOnlyServerStr
        {
            get
            {
                return (string)base[nameof(ReadOnlyServerStr)];
            }
            set
            {
                base[nameof(ReadOnlyServerStr)] = value;
            }
        }

        public string[] ReadOnlyServer
        {
            get
            {
                return this.ReadOnlyServerStr.Split(',');
            }
            set
            {
                this.ReadOnlyServerStr = string.Join(",", value);
            }
        }

        [ConfigurationProperty(nameof(MaxWritePoolSize), IsRequired = false, DefaultValue = 5)]
        public int MaxWritePoolSize
        {
            get
            {
                int _maxWritePoolSize = (int)base[nameof(MaxWritePoolSize)];
                return _maxWritePoolSize > 0 ? _maxWritePoolSize : 5;
            }
            set
            {
                base[nameof(MaxWritePoolSize)] = value;
            }
        }

        [ConfigurationProperty(nameof(MaxReadPoolSize), IsRequired = false, DefaultValue = 5)]
        public int MaxReadPoolSize
        {
            get
            {
                int _maxReadPoolSize = (int)base[nameof(MaxReadPoolSize)];
                return _maxReadPoolSize > 0 ? _maxReadPoolSize : 5;
            }
            set
            {
                base[nameof(MaxReadPoolSize)] = value;
            }
        }

        [ConfigurationProperty(nameof(AutoStart), IsRequired = false, DefaultValue = true)]
        public bool AutoStart
        {
            get
            {
                return (bool)base[nameof(AutoStart)];
            }
            set
            {
                base[nameof(AutoStart)] = value;
            }
        }

        [ConfigurationProperty(nameof(LocalCacheTime), IsRequired = false, DefaultValue = 36000)]
        public int LocalCacheTime
        {
            get
            {
                return (int)base[nameof(LocalCacheTime)];
            }
            set
            {
                base[nameof(LocalCacheTime)] = value;
            }
        }

        [ConfigurationProperty(nameof(RecordeLog), IsRequired = false, DefaultValue = false)]
        public bool RecordeLog
        {
            get
            {
                return (bool)base[nameof(RecordeLog)];
            }
            set
            {
                base[nameof(RecordeLog)] = value;
            }
        }
    }
}