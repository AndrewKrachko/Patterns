using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingPatterns
{
    public class StrategyExample
    {
        public interface IAction
        {
            void SaySomething();
        }

        public class Context
        {
            private IAction _action;

            public Context(IAction action) => SetAction(action);

            public void SetAction(IAction action) => _action = action;

            public void DoIt()
            {
                Console.WriteLine("What do you want to say?");
                _action.SaySomething();
                Console.WriteLine("It is normal, it is okey to say something like that...");
            }
        }

        public class HelloAction : IAction
        {
            public void SaySomething() => Console.WriteLine("Hello, guys!");
        }

        public class ByeAction : IAction
        {
            public void SaySomething() => Console.WriteLine("Bye, guys!");
        }
    }
}
