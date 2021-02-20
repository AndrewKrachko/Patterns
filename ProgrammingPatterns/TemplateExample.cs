using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingPatterns
{
    public class TemplateExample
    {
        public abstract class EnterSaloonAbstractBehaviour
        {
            public void EnterSaloon()
            {
                OpenDoor();
                ActionA();
                WalkIn();
                ActionB();
                SitDown();
                HookA();
            }

            protected void OpenDoor() => Console.WriteLine("Just opening the door");

            protected void WalkIn() => Console.WriteLine("Making several steps");

            protected void SitDown() => Console.WriteLine("Taking seat");

            protected abstract void ActionA();
            protected abstract void ActionB();
            protected abstract void ActionC();

            protected virtual void HookA() { }
        }
    }
}
