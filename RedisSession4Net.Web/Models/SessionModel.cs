using RedisSession4Net.Core.Cache;
using System;

namespace RedisSession4Net.Web.Models
{
    public class SessionModel : ISessionPropertities
    {
        public RedisHelper Redis { get; set; }

        public int SampleInteger
        {
            get { return this.Redis.Get<int>(nameof(SampleInteger), x => Convert.ToInt32(x)); }
            set { this.Redis.Add(nameof(SampleInteger), value); }
        }

        public string SampleString
        {
            get { return this.Redis.Get<string>(nameof(SampleString)); }
            set { this.Redis.Add(nameof(SampleString), value); }
        }

        public bool SampleBoolean
        {
            get { return this.Redis.Get<bool?>(nameof(SampleBoolean), x => Convert.ToBoolean(x)) ?? false; }
            set { this.Redis.Add(nameof(SampleBoolean), value); }
        }

        public DateTime SampleDateTime
        {
            get { return this.GetDateTime(nameof(SampleDateTime)); }
            set { this.SetDateTime(nameof(SampleDateTime), value); }
        }

        private DateTime GetDateTime(string key)
            => this.Redis.Get<DateTime>(key, obj => DateTime.Parse(obj.ToString()));

        private void SetDateTime(string key, DateTime dt)
            => this.Redis.Add(key, dt.ToString());
    }
}