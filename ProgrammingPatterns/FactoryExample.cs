using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingPatterns
{
    public class FactoryExample
    {
        public enum OrcType
        {
            Peasant,
            Grunt,
            Troll
        }

        public interface IOrcishGuy
        {
            void Roar();
        }

        public class Peasant : IOrcishGuy
        {
            public void Roar() => Console.WriteLine("Ok-ok, I will work...");
        }

        public class Grunt : IOrcishGuy
        {
            public void Roar() => Console.WriteLine("Undabu.");
        }

        public class Troll : IOrcishGuy
        {
            public void Roar() => Console.WriteLine("Zul-Jin will be revenged!");
        }

        public class DeafGuy : IOrcishGuy
        {
            public void Roar() => Console.WriteLine("<silence>");
        }

        public class OrcishFactory
        {
            public IOrcishGuy GetOrc(OrcType orcType)
            {
                switch (orcType)
                {
                    case OrcType.Peasant:
                        return new Peasant();
                    case OrcType.Grunt:
                        return new Grunt();
                    case OrcType.Troll:
                        return new Troll();
                    default:
                        return new DeafGuy();
                }
            }
        }
    }
}
