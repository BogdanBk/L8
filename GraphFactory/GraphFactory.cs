using System;
using System.Collections.Generic;

// Інтерфейс або абстрактний клас для різних типів графіків
public interface IGraph
{
    void Draw();
}

// Конкретна реалізація лінійного графіка
public class LineGraph : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Line Graph");
        // Логіка для малювання лінійного графіка
    }
}

// Конкретна реалізація стовпчикового графіка
public class BarGraph : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Bar Graph");
        // Логіка для малювання стовпчикового графіка
    }
}

// Конкретна реалізація кругової діаграми
public class PieChart : IGraph
{
    public void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
        // Логіка для малювання кругової діаграми
    }
}

// Фабрика графіків з Factory Method
public abstract class GraphFactory
{
    public abstract IGraph CreateGraph();
}

// Фабрика для лінійного графіка
public class LineGraphFactory : GraphFactory
{
    public override IGraph CreateGraph()
    {
        return new LineGraph();
    }
}

// Фабрика для стовпчикового графіка
public class BarGraphFactory : GraphFactory
{
    public override IGraph CreateGraph()
    {
        return new BarGraph();
    }
}

// Фабрика для кругової діаграми
public class PieChartFactory : GraphFactory
{
    public override IGraph CreateGraph()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the type of graph (line/bar/pie):");
        string graphType = Console.ReadLine();

        GraphFactory factory = GetGraphFactory(graphType);

        if (factory != null)
        {
            IGraph graph = factory.CreateGraph();
            graph.Draw();
        }
        else
        {
            Console.WriteLine("Invalid graph type");
        }
    }

    static GraphFactory GetGraphFactory(string graphType)
    {
        switch (graphType.ToLower())
        {
            case "line":
                return new LineGraphFactory();
            case "bar":
                return new BarGraphFactory();
            case "pie":
                return new PieChartFactory();
            default:
                return null;
        }
    }
}
