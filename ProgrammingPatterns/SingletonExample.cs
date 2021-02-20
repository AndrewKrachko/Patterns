using System;

namespace ProgrammingPatterns
{
    public class SingletonExample
    {
        private static SingletonExample _singletonExample;

        private SingletonExample()
        {

        }

        public static SingletonExample GetSingletonExample()
        {
            if(_singletonExample == null)
            {
                _singletonExample = new SingletonExample();
            }

            return _singletonExample;
        }

        public void SaySomethign()
        {
            Console.WriteLine($"I am {_singletonExample.GetHashCode()}, nice to meet you!");
        }
    }
}
