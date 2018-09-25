/*
 * It is used to create a set of related objects, or dependent objects. 
 * Internally, Abstract Factory use Factory design pattern for creating objects. 
 * It may also use Builder design pattern and prototype design pattern for creating objects. 
 * It completely depends upon your implementation for creating objects
 * 
 * When to use it?
 * - Create a set of related objects, or dependent objects which must be used together.
 * - System should be configured to work with multiple families of products.
 * - The creation of objects should be independent from the utilizing system.
 * - Concrete classes should be decoupled from clients.
 * 
 * https://www.dotnettricks.com/learn/designpatterns/abstract-factory-design-pattern-dotnet
 * 
*/

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ConcreteFactoryA factoryA = new ConcreteFactoryA();
            Client myProductA = new Client(factoryA);

            ConcreteFactoryB factoryB = new ConcreteFactoryB();
            Client myProductB = new Client(factoryB);

        }
    }

    // Example: Vehicule Factory
    public interface IAbstractFactory
    {   
        IAbstractProductA CreatProductA();
        IAbstractProductB CreatProductB();
    }

    // Example: HONDA Vehicule Factory
    public class ConcreteFactoryA : IAbstractFactory
    {
        public IAbstractProductA CreatProductA()
        {
            return new ProductA1();
        }

        public IAbstractProductB CreatProductB()
        {
            return new ProductB1();
        }
    }
    // Example: SUZUKI Vehicule Factory
    public class ConcreteFactoryB : IAbstractFactory
    {
        public IAbstractProductA CreatProductA()
        {
            return new ProductA2();
        }

        public IAbstractProductB CreatProductB()
        {
            return new ProductB2();
        }
    }

    // Example: Type Moto 
    public interface IAbstractProductA { }
    // Example: Type Scooter
    public interface IAbstractProductB { }

    // Example: Moto Sport
    public class ProductA1 : IAbstractProductA
    {

    }
    // Example: Scooter 50cc
    public class ProductB1 : IAbstractProductB
    {

    }
    // Example: Moto Roadster
    public class ProductA2 : IAbstractProductA
    {

    }
    // Example: Scooter > 125cc
    public class ProductB2 : IAbstractProductB
    {

    }

    public class Client
    {
        // Example: La Moto du Client
        private IAbstractProductA _productA;
        // Example: Le Scooter du Client
        private IAbstractProductB _productB;

        // Client choisi sa Factory:
        public Client(IAbstractFactory factory)
        {

            _productA = factory.CreatProductA();
            _productB = factory.CreatProductB();
        }


    }

}
