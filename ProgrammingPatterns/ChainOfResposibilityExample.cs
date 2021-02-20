using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingPatterns
{
    public class ChainOfResposibilityExample
    {
        public interface IHandler
        {
            void SetNext(IHandler handler);
            void Handle(object request);
        }

        public abstract class BaseHandler : IHandler
        {
            protected IHandler _next;
            public virtual void Handle(object request)
            {
                if (_next != null)
                {
                    _next.Handle(request);
                }
            }

            public void SetNext(IHandler handler)
            {
                _next = handler;
            }
        }

        public class PrepareHandler : BaseHandler
        {
            public override void Handle(object request)
            {
                if (request is Cookie cookie && !cookie.IsPrepared)
                {
                    cookie.Prepare();
                    Console.WriteLine("Preparing");
                }
                base.Handle(request);
            }
        }

        public class BakeHandler : BaseHandler
        {
            public override void Handle(object request)
            {
                if (request is Cookie cookie && cookie.IsPrepared)
                {
                    var rand = new Random();
                    while (cookie.BakedStatus == Cookie.State.Unbaked)
                    {
                        var time = rand.Next(3, 8);
                        cookie.Bake(time);
                        Console.WriteLine($"Baking {time} minutes");
                    }
                }
                base.Handle(request);
            }
        }

        public class EatHandler : BaseHandler
        {
            public override void Handle(object request)
            {
                if (request is Cookie cookie && cookie.IsPrepared)
                {
                    switch(cookie.BakedStatus)
                    {
                        case Cookie.State.Unbaked:
                            Console.WriteLine("Eu, it's steaky!");
                            break;
                        case Cookie.State.Baked:
                            Console.WriteLine("Om-nom-nom");
                            break;
                        default:
                            Console.WriteLine("Is it a coal?");
                            break;
                    }
                }
                base.Handle(request);
            }
        }

        public class Cookie
        {
            public enum State
            {
                Unbaked,
                Baked,
                Burned
            }

            public bool IsPrepared = false;
            public State BakedStatus = State.Unbaked;
            private int bakeTime = 0;

            public void Prepare() => IsPrepared = true;

            public void Bake(int time)
            {
                bakeTime += time;

                if (bakeTime < 9)
                {
                    BakedStatus = State.Unbaked;
                }
                else if (bakeTime < 12)
                {
                    BakedStatus = State.Baked;
                }
                else
                {
                    BakedStatus = State.Burned;
                }
            }
        }
    }
}
