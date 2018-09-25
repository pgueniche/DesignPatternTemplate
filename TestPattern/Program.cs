using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            var myTest = new TestPaperLow();
            myTest.Init();
            myTest.Start();
        }
    }

    public interface ITest
    {
        void Init();
        void Start();        
        string GetRepport();
    }

    public class TestPaperLow : ITest
    {
        private string _repport;
        private int _indexTest = 0;
        private List<ITestUnit> _sequence = new List<ITestUnit>();
                
        public void Init()
        {
            _sequence.Clear();
            _sequence.Add(new GetStatus());
            _sequence.Add(new GetStatus());            
            _repport = "";
            _indexTest = 0;
        }

        public void Start()
        {                
            foreach (ITestUnit item in _sequence)
            {                
                string resultExec = item.Execute();
                string resultTest = item.AnalysResult(resultExec);
                Console.WriteLine("[{0}]Test: {1}. Exec {2} Analys {3}.", _indexTest++, item.GetName(), resultExec, resultTest);
            }
            _repport = string.Format("Test done: {0}", _indexTest);
        }

        public string GetRepport()
        {
            return _repport;
        }

    }

    public interface ITestUnit
    {
        string GetName();
        string GetDescription();
        string Execute();
        string AnalysResult(string actionResult);
        void SetPassCondition(string condition);
    }

    public class GetStatus : ITestUnit
    {
        private string _passCondition = "";
        private string _name = "Get Status";
        private string _description = "Get the Status From the Printer";
        
        public string AnalysResult(string actionResult)
        {

            if (actionResult == _passCondition)
                return "OK";
            else
                return "FAILED";
        }

        public string Execute()
        {
            Console.WriteLine("Send Status Query.");
            Console.WriteLine("Read Status from Printer.");
            return "OK";
        }
        
        public string GetDescription()
        {
            return _description;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetPassCondition(string condition)
        {
            _passCondition = condition;            
        }
    }
    
}
