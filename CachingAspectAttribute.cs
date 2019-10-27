using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace RedisSample.Models
{

    [PSerializable]
    public class CachingAspectAttribute : MethodInterceptionAspect
    {
       static IDistributedCache cache;
        static CachingAspectAttribute()
        {
            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                cache = (IDistributedCache)AppInstance.applicationBuilder.GetService(typeof(IDistributedCache));
            }
        }

        public virtual void OnInvoke(MethodInterceptionArgs args)
        {
            var cacheKey = $"{args.Instance.ToString()} - {args.Method.Name} - {args.Arguments[0]}";

            var cachedData = cache.GetString(cacheKey);

            if (!string.IsNullOrEmpty(cachedData))
            {
                args.ReturnValue = cachedData;
                return;
            }

            base.OnInvoke(args);
            cache.SetString(cacheKey, Newtonsoft.Json.JsonConvert.SerializeObject(args.ReturnValue));
        }

    }
}
