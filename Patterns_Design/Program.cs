using System;
using System.Collections.Generic;
using Patterns_Design.Behavioral.ChainOfResponsibility;
using Patterns_Design.Behavioral.Command;
using Patterns_Design.Behavioral.Interpreter;
using Patterns_Design.Behavioral.Iterator;
using Patterns_Design.Behavioral.Mediator;
using Patterns_Design.Behavioral.Memento;
using Patterns_Design.Behavioral.Observer;
using Patterns_Design.Behavioral.State;
using Patterns_Design.Behavioral.Strategy;
using Patterns_Design.Behavioral.Template_Method;
using Patterns_Design.Behavioral.Visitor;
using Patterns_Design.Creation.AbstractFactory;
using Patterns_Design.Creation.Builder;
using Patterns_Design.Creation.FactoryMethod_VirtualConstructor;
using Patterns_Design.Structural.Facade;
using Patterns_Design.Structural.Flyweight;
using Patterns_Design.Structural.Proxy;
using Patterns_Design.Behavioral.UnitOfWork;
using Patterns_Design.Structural.Money;
using System.IO;
using System.Drawing;
using System.Net;

namespace Patterns_Design
{
    class Program
    {
        static void Main(string[] args)
        {
            string srcImagePath = @"http://dev.mygemplace.com/Content/_Traders/2/jwProducts/8_Ring2_1qK1b.jpg";
            string photoName = Path.GetFileNameWithoutExtension(srcImagePath);

            MemoryStream memory = new MemoryStream();
            HttpWebRequest lxRequest = (HttpWebRequest)WebRequest.Create(srcImagePath);
            using (HttpWebResponse lxResponse = (HttpWebResponse)lxRequest.GetResponse())
            {
                using (BinaryReader reader = new BinaryReader(lxResponse.GetResponseStream()))
                {
                    reader.BaseStream.CopyTo(memory);
                    //Byte[] lnByte = reader.ReadBytes(1 * 1024 * 1024 * 10);
                    //using (FileStream lxFS = new FileStream("34891.jpg", FileMode.Create))
                    //{
                    //    lxFS.Write(lnByte, 0, lnByte.Length);
                    //}
                }
            }

            Bitmap photo;
            try
            {
                photo = new Bitmap(memory);
            }
            catch (ArgumentException e)
            {
                throw new FileNotFoundException(string.Format(" GDIThumbnail generator file[{0}] not found.", srcImagePath), e);
            }

            // Factory Method
            Console.WriteLine();
            Console.WriteLine("[Abstract Factory] Pattern");
            IWidgetFactory abstractFactory = new PMWidgetFactory();
            IWidgetButton abstractButton = abstractFactory.CreateWidgetButton();
            IWidgetDialog abstractDialog = abstractFactory.CreateWidgetDialog();
            abstractButton.DrawButton();
            abstractDialog.DrawWidget();

            abstractButton.SetLocation();
            abstractDialog.SetTopMost();
            //-------------------

            // FactoryMethod/Virtual Constructor
            Console.WriteLine();
            Console.WriteLine("[FactoryMethod/Virtual Constructor] Pattern");
            Creator creator = new ConcreteCreator();
            IAMethodDocument amDocument = creator.CreateDocument();
            amDocument.Open();
            //----------------------------------

            // Builder
            Console.WriteLine("[Builder] Pattern");
            Console.WriteLine();
            Shop shop = new Shop();
            IVehicleBuilder builder = new CarBuilder();
            shop.Construct(builder);
            shop.ShowVehicle();
            builder = new VeloByke();
            shop.Construct(builder);
            shop.ShowVehicle();
            //----------------------

            // Facade
            // Provides more simple unified interface instead of few interfaces some subsystem.
            // Subsystem interfaces don't keep references to facade interface.
            Console.WriteLine();
            Console.WriteLine("[Facade] Pattern");
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            //-------

            // Flyweight
            // Build a document with text
            Console.WriteLine();
            Console.WriteLine("[Flyweight] Pattern");
            string document = "AAZZBBZB";
            char[] chars = document.ToCharArray();
            CharacterFactory factory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            //For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                Character character = factory.GetCharacter(c);
                character.Display(pointSize);
            }
            //-----------

            // Proxy
            Console.WriteLine();
            Console.WriteLine("[Proxy] pattern");
            IImage proxy = new ProxyImage();
            proxy.GetSize();
            proxy.Draw();
            //--------


            //Chain Responsibilities
            Console.WriteLine();
            Console.WriteLine("[Chain of Responsibilities] pattern");
            DialogChain dc1 = new DialogChain(null);
            ButtonChain bc1 = new ButtonChain(dc1);
            DialogChain dc2 = new DialogChain(bc1);
            ButtonChain buttonChain2 = new ButtonChain(dc2);
            IRequest request1 = new Request1();
            ((Request1) request1).Value = "QWE_RTYU";
            buttonChain2.HandleRequest(request1);

            Request2 rq2 = new Request2();
            rq2.Value = "123456";
            buttonChain2.HandleRequest(rq2);

            //----------------------

            // Command
            Console.WriteLine();
            Console.WriteLine("[Command] Pattern");
            List<SourceCommand> srcCmd = new List<SourceCommand>();

            SourceCommand scr1 = new SourceCommand();
            scr1.Command = new OpenCommand(new Receiver1("Star1"));

            SourceCommand scr2 = new SourceCommand();
            scr2.Command = new PasteCommand(new Receiver2("Paste Star 2"));

            srcCmd.Add(scr1);
            srcCmd.Add(scr2);

            TemplatedCommand<string> templatedCommand = new TemplatedCommand<string>(delegate(string s) { Console.WriteLine("---Delegate command is executed @@@@ {0}", s); });
            TemplatedSourceCommand<string> scr3 = new TemplatedSourceCommand<string>(templatedCommand);
            scr3.ActionInvoke("1111");

            foreach (var sourceCommand in srcCmd)
            {
                sourceCommand.InvokeCommand();
            }
            //---------
            
            // Interpreter
            string roman = "MCMXXVIII";
            Context context = new Context(roman);

            // Build the 'parse tree'
            List<Expression> tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());

            // Interpret
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }

            Console.WriteLine("{0} = {1}", roman, context.Output);

            // define booleand expression
            // (true and x) or (y and x)
            Console.WriteLine("----------------------------");
            BooleanExp expressing;
            BooleanContext boolContext = new BooleanContext();
            expressing = new OrExp(new AndExp(new BooleanConstant("true"), new VariableExp("x")),
                                   new AndExp(new VariableExp("y"), new NotExp("x")));

            boolContext.Assign("x",  false);
            boolContext.Assign("y", false);

            Console.WriteLine("Result of boolean interpreter is [{0}]", expressing.Evaluate(boolContext));
            //-------------

            // Iterator
            Console.WriteLine();
            Console.WriteLine("Pattern Iterator");
            ConcreteAggregate aggregate = new ConcreteAggregate();
            aggregate[0] = "Object 1";
            aggregate[1] = "Object 2";
            aggregate[2] = "Object 3";
            aggregate[3] = "Object 4";
            Iterator iter = aggregate.CreateIterator();

            for (object i = iter.First(); !iter.IsDone(); i = iter.Next())
            {
                Console.WriteLine("Current object [{0}]", i);
            }

            //--------------

            // Mediator
            Console.WriteLine();
            Console.WriteLine("Pattern Mediator");

            // parts could be informed about its mediator.
            ConcreteMediator cm = new ConcreteMediator(new Collegue1(), new Collegue2(), new Collegue3());
            cm.Process1AndInform23();
            cm.Process3AndInform1();
            //------------

            // Memento
            Console.WriteLine();
            Console.WriteLine("Pattern Memento");

            SalesProspect salesProspect = new SalesProspect();
            salesProspect.Budget = 45.56;
            salesProspect.Name = "Super Man";
            salesProspect.Phone = "45-78-96";

            ProspectMemory prospectMemory = new ProspectMemory();
            prospectMemory.Memento = salesProspect.SaveMemento();

            salesProspect.Budget = 11.11;
            salesProspect.Name = "Spider Man";
            salesProspect.Phone = "33-44-55";

            salesProspect.RestoreMemento(prospectMemory.Memento);
            //--------------

            // Observer (Dependents, Publish-Subscriber)
            Console.WriteLine();
            Console.WriteLine("Pattern Observer");

            Subject subject = new Subject();
            ConcreteObserver1 concreteObserver1 = new ConcreteObserver1();
            ConcreteObserver2 concreteObserver2 = new ConcreteObserver2();
            subject.Register(concreteObserver1);
            subject.Register(concreteObserver2);
            subject.Register(concreteObserver1);

            subject.NotifyObservers();

            subject.UnRegister(concreteObserver2);
            subject.UnRegister(concreteObserver2);

            subject.NotifyObservers();
            //------------------------------------------

            // State
            Console.WriteLine();
            Console.WriteLine("Pattern State");
            Account account = new Account("Jim Johnson");

            // Apply financial transactions
            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
            account.Deposit(50000);
            account.PayInterest();


            //------------------------------------------

            // Strategy
            // Client should knew all available strategies.
            Console.WriteLine();
            Console.WriteLine("Pattern Strategy");

            StrategyContext strategyContext = new StrategyContext(null);
            strategyContext.ContextOperationOne();
            strategyContext.ContextOperationTwo();

            strategyContext.Strategy = new ConcreteStrategy();
            strategyContext.ContextOperationOne();
            strategyContext.ContextOperationTwo();

            //------------------------------------------

            // Template Method
            Console.WriteLine();
            Console.WriteLine("Template Method");
            TemplateMethodClass tmc = new ConcreteTemplateMethodClass1();
            tmc.TemplateMethod();
            //------------------------------------------

            // Visitor
            Console.WriteLine();
            Console.WriteLine("Visitor");
            List<INode> elements = new List<INode>();
            elements.Add(new NodeType1(){Balance = 400, Name = "Qwerty"});
            elements.Add(new NodeType1() { Balance = 333, Name = "QasxzWe" });
            elements.Add(new NodeType2(){CarName = "Mersedes"});
            NodeVisitor visitor = new ConcreteNodeVisitor();

            foreach (var element in elements)
            {
                element.Accept(visitor);
            }

            //------------------------------------------

            ThreadTest threadTest = new ThreadTest();
            //threadTest.RunTask();
            threadTest.TestFactory();

            // Unit of Work patternt with Repository pattern
            Console.WriteLine();
            Console.WriteLine("UOW pattern");
            StudentController sc = new StudentController();
            sc.DoAction();

            MoneyPattern.Start();
            Console.Read();
        }
    }
}
