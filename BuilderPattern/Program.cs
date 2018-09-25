using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandBuilder builder;

            // Create shop with vehicle builders
            Decoder decoder = new Decoder();

            // Construct and display vehicles
            builder = new RegionBuilder();
            decoder.Construct(builder);
            builder.Command.Show();

            builder = new TemplateBuilder();
            decoder.Construct(builder);
            builder.Command.Show();

            builder = new PrintBuilder();
            decoder.Construct(builder);
            builder.Command.Show();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Decoder
    {
        // Builder uses a complex series of steps
        public void Construct(CommandBuilder commandBuilder)
        {
            commandBuilder.BuildFrame();
            commandBuilder.BuildEngine();
            commandBuilder.BuildWheels();
            commandBuilder.BuildDoors();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class CommandBuilder
    {
        protected Command command;

        // Gets command instance
        public Command Command
        {
            get { return command; }
        }

        // Abstract build methods
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class PrintBuilder : CommandBuilder
    {
        public PrintBuilder()
        {
            command = new Command("Print");
        }

        public override void BuildFrame()
        {
            command["frame"] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            command["engine"] = "500 cc";
        }

        public override void BuildWheels()
        {
            command["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            command["doors"] = "0";
        }
    }


    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class TemplateBuilder : CommandBuilder
    {
        public TemplateBuilder()
        {
            command = new Command("Template");
        }

        public override void BuildFrame()
        {
            command["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            command["engine"] = "2500 cc";
        }

        public override void BuildWheels()
        {
            command["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            command["doors"] = "4";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>
    class RegionBuilder : CommandBuilder
    {
        public RegionBuilder()
        {
            command = new Command("Region");
        }

        public override void BuildFrame()
        {
            command["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            command["engine"] = "50 cc";
        }

        public override void BuildWheels()
        {
            command["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            command["doors"] = "0";
        }
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Command
    {
        private string _commandType;
        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();

        // Constructor
        public Command(string vehicleType)
        {
            this._commandType = vehicleType;
        }

        // Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Command Type: {0}", _commandType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }
}



