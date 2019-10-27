using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RedisSample.Models
{
    public static class AppInstance
    {
        public static IServiceProvider applicationBuilder { get; set; }
    }
}
