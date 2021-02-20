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
                ActionC();
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

        public class TypicalCowboyEnterSaloon : EnterSaloonAbstractBehaviour
        {
            protected override void ActionA()
            {
                Console.WriteLine("Saying hello to everyone"); ;
            }

            protected override void ActionB()
            {
                Console.WriteLine("Asking for a drink");
            }

            protected override void ActionC()
            {
                Console.WriteLine("Shoting a drink");
            }
        }

        public class DumbassCowboyEnterSaloon : EnterSaloonAbstractBehaviour
        {
            protected override void ActionA()
            {
                Console.WriteLine("Asking everyone who is gay here");
            }

            protected override void ActionB()
            {
                Console.WriteLine("Kicking chair");
            }

            protected override void ActionC()
            {
                Console.WriteLine("Getting hit by axe");
            }

            protected override void HookA()
            {
                Console.WriteLine("Fall down on the floor");
            }
        }
    }
}
