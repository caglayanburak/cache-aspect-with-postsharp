using System;

namespace RedisSample.Models
{
    public class Test : ITest
    {
        [CachingAspect]
        public string Get(int id)
        {
            Console.WriteLine("denemet");
            //db call
            return "Test";
        }
    }
    
    public interface ITest
    {
        string Get(int id);
    }
}
