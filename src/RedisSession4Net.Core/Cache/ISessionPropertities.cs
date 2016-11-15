namespace RedisSession4Net.Core.Cache
{
    public interface ISessionPropertities
    {
        RedisHelper Redis { get; set; }
    }
}
