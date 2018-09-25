/*
 * Builder pattern builds a complex object by using a step by step approach. 
 * Builder interface defines the steps to build the final object. 
 * This builder is independent from the objects creation process. 
 * A class that is known as Director, controls the object creation process.
 * 
 * When to use it?
 * - Need to create an object in several steps (a step by step approach).
 * - The creation of objects should be independent from the way the object's parts are assembled.
 * - Runtime control over the creation process is required.
 */


namespace BuilderDesign
{
    class Program
    {
        static void Main(string[] args)
        {            
            var myProduct = new Director(new ConcreteBuilder());

            // The COMPLEX object is create at once.
            myProduct.Construct();

        }
    }

    // Example: Moto Factory
    public interface IBuilder
    {
        void BuildPart1();
        void BuildPart2();
        void BuildPart3();
        Product GetProduct();
    }

    // Example: Moto : Frame + Engine + Accessories
    public class Product
    {
        public string Part1 { get; set; }
        public string Part2 { get; set; }
        public string Part3 { get; set; }
    }

    // Example: HONDA/SUZUKI Factory
    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public void  BuildPart1()
        {
            _product.Part1 = "Part 1";
        }

        public void BuildPart2()
        {
            _product.Part2 = "Part 2";
        }

        public void BuildPart3()
        {
            _product.Part3 = "Part 3";
        }

        public Product GetProduct()
        {
            return _product;
        }
    }

    // Example: Create a MOTO from a Factory:
    public class Director
    {
        private readonly IBuilder _builder;
        public Director(IBuilder builder) { _builder = builder; }

        public void Construct()
        {
            _builder.BuildPart1();
            _builder.BuildPart2();
            _builder.BuildPart3();
        }
    }
    
}
