using System;
using DomainApp1.Adapters;
using DomainApp1.Domain;
using DomainApp1.Tools;
using EasyNetQ;
using log4net;
using TDCS.Logging;

namespace DomainApp1.Run
{
    class Program
    {
        static void Main()
        {
            //ConsoleWindowHelper.SetPosition(1155, 650, 400, 200);
            ConsoleWindowHelper.SetPosition(780, 430, 400, 200);

            var settings = Da1Settings.Default;

            var log = LogStarter.Start("DomainApp1.log.config", "Main");

            Console.WriteLine("Starting DomainApp1");

            using (var bus = RbBusFactory.Create(settings))
            {
                var listener = CreateListener(bus, settings, log);

                listener.Start();

                ShowInitialTexts();
                
                Console.ReadLine();
            }
        }

        static Listener CreateListener(IBus bus, Da1Settings settings, ILog log)
        {
            var specification = new ImportantCommentSpecification(settings);

            var responsibleFinder = new DefaultResponsibleFinder();

            var icdPublisher = new RbIcdPublisher(bus);

            var processor = new CommentProcessor(responsibleFinder,specification, icdPublisher, log);

            var listener = new Listener(processor, bus,settings);

            return listener;
        }

        static void ShowInitialTexts()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Processing comments....");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Press <enter> to quit");
            Console.WriteLine();
        }
    }
}
