using System;

// Абстрактні класи компонентів

abstract class Screen
{
    public abstract void Display();
}

abstract class Processor
{
    public abstract void Process();
}

abstract class Camera
{
    public abstract void Capture();
}

// Конкретні реалізації компонентів

class IPSLcdScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("IPS LCD screen displays vibrant colors.");
    }
}

class SnapdragonProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Snapdragon processor provides smooth performance.");
    }
}

class DualCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Dual camera captures high-quality photos.");
    }
}

// Абстрактні фабрики

abstract class TechProductFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}

// Конкретні реалізації фабрик

class SmartphoneFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new IPSLcdScreen();
    }

    public override Processor CreateProcessor()
    {
        return new SnapdragonProcessor();
    }

    public override Camera CreateCamera()
    {
        return new DualCamera();
    }
}

class LaptopFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new IPSLcdScreen();
    }

    public override Processor CreateProcessor()
    {
        return new SnapdragonProcessor();
    }

    public override Camera CreateCamera()
    {
        return new DualCamera();
    }
}

class TabletFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new IPSLcdScreen();
    }

    public override Processor CreateProcessor()
    {
        return new SnapdragonProcessor();
    }

    public override Camera CreateCamera()
    {
        return new DualCamera();
    }
}

// Клас, що використовує фабрику для створення продукту

class TechProductAssembler
{
    private TechProductFactory factory;

    public TechProductAssembler(TechProductFactory factory)
    {
        this.factory = factory;
    }

    public void AssembleProduct()
    {
        Screen screen = factory.CreateScreen();
        Processor processor = factory.CreateProcessor();
        Camera camera = factory.CreateCamera();

        Console.WriteLine("Assembling a tech product:");
        screen.Display();
        processor.Process();
        camera.Capture();
        Console.WriteLine("Product assembled successfully.");
    }
}

// Клас програми

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose the type of tech product to assemble:");
        Console.WriteLine("1. Smartphone");
        Console.WriteLine("2. Laptop");
        Console.WriteLine("3. Tablet");

        char choice = Console.ReadKey().KeyChar;

        TechProductFactory factory = null;

        switch (choice)
        {
            case '1':
                factory = new SmartphoneFactory();
                break;
            case '2':
                factory = new LaptopFactory();
                break;
            case '3':
                factory = new TabletFactory();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        TechProductAssembler assembler = new TechProductAssembler(factory);
        assembler.AssembleProduct();
    }
}
