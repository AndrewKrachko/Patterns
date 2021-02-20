using ProgrammingPatterns;
using System;
using static ProgrammingPatterns.ChainOfResposibilityExample;
using static ProgrammingPatterns.FactoryExample;
using static ProgrammingPatterns.StrategyExample;
using static ProgrammingPatterns.TemplateExample;

namespace Check
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singleton:");

            var singletonA = SingletonExample.GetSingletonExample();
            var singletonB = SingletonExample.GetSingletonExample();

            singletonA.SaySomethign();
            singletonB.SaySomethign();

            Console.WriteLine("\nFactory:");

            var orcishFactory = new OrcishFactory();
            var peasant = orcishFactory.GetOrc(OrcType.Peasant);
            var grunt = orcishFactory.GetOrc(OrcType.Grunt);
            var troll = orcishFactory.GetOrc(OrcType.Troll);

            Console.Write(peasant.ToString() + ": ");
            peasant.Roar();
            Console.Write(grunt.ToString() + ": ");
            grunt.Roar();
            Console.Write(troll.ToString() + ": ");
            troll.Roar();

            Console.WriteLine("\nFactory:");

            var chainAprep = new PrepareHandler();
            var chainEat = new EatHandler();
            chainAprep.SetNext(chainEat);

            var chainBprep = new PrepareHandler();
            var chainBake = new BakeHandler();
            chainBprep.SetNext(chainBake);
            chainBake.SetNext(chainEat);

            chainAprep.Handle(new Cookie());
            chainBprep.Handle(new Cookie());
            chainBprep.Handle(new Cookie());
            chainBprep.Handle(new Cookie());

            Console.WriteLine("\nStrategy:");

            var contextA = new Context(new HelloAction());
            var contextB = new Context(new ByeAction());

            contextA.DoIt();
            Console.WriteLine();
            contextB.DoIt();

            Console.WriteLine("\nStrategy:");

            var typicalCowboyEntry = new TypicalCowboyEnterSaloon();
            var dumbassCowboyEntry = new DumbassCowboyEnterSaloon();

            typicalCowboyEntry.EnterSaloon();
            Console.WriteLine();
            dumbassCowboyEntry.EnterSaloon();
        }
    }
}
