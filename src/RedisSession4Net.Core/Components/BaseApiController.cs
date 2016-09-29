using RedisSession4Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RedisSession4Net.Core.Components
{
    public abstract class BaseApiController<T> : ApiController
        where T : ISessionPropertities, new()
    {
        private string _sessionId;
        private RedisHelper _redis;
        private T _session;

        private RedisHelper Redis
        {
            get
            {
                if (_redis == null)
                {
                    _redis = new RedisHelper(this.SessionId);
                }
                return _redis;
            }
        }

        private string SessionId
        {
            get
            {
                if (_sessionId != null)
                {
                    return _sessionId;
                }

                _sessionId = HttpContext.Current.Request.Cookies["SessionId"]?.Value;
                if (_sessionId == null)
                {
                    _sessionId = Guid.NewGuid().ToString("N");
                    var cookie = new HttpCookie("SessionId", this.SessionId);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }

                return _sessionId;
            }
            set
            {
                _sessionId = value;
            }
        }

        protected T Session
        {
            get
            {
                if (_session == null)
                {
                    _session = this.Redis.GetSession<T>();
                }

                return _session;
            }
        }

        [NonAction]
        protected void ClearSession()
        {
            HttpContext.Current.Response.Cookies.Remove(this.SessionId);
        }
    }
}
