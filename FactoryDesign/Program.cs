/*
 * The factory method design pattern abstract the process of object creation and allows the object to be created 
 * at run-time when it is required.
 * It is used to create objects. People usually use this pattern as the standard way to create objects
 * 
 * When to use it?
 * - Subclasses figure out what objects should be created.
 * - Parent class allows later instantiation to subclasses means the creation of object is done when it is required.
 * - The process of objects creation is required to centralize within the application.
 * - A class (creator) will not know what classes it will be required to create.
 * 
 */

using System;

namespace FactoryDesign
{
    class Program
    {
        static void Main(string[] args)
        {

            Creator myFactory = new ConcreateCreator();

            // Create the object when we need them.
            IProduct myProductA = myFactory.FactoryMethod("A");
            IProduct myProductB = myFactory.FactoryMethod("B");
        }
    }

    // Example: Vehicule
    public interface IProduct
    {

    }

    // Example: Moto
    public class ConcreteProductA : IProduct
    {

    }
    // Example: Scooter
    public class ConcreteProductB : IProduct
    {

    }

    // Example: Creator
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod(string type);
    }

    // Example: HONDA 
    public class ConcreateCreator : Creator
    {
        public override IProduct FactoryMethod(string type)
        {
            switch (type)
            {
                case "A": return new ConcreteProductA();                    
                case "B": return new ConcreteProductB();
                default:throw new ArgumentException("Invalid type", type);
            }
        }
    }

}
