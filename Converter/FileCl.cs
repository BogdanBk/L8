using System;
using System.IO;

public enum FileFormat
{
    CSV = 1,
    JSON,
    XML
}

public class Prototype
{
    private string FilePath { get; }
    private string[] Content { get; }

    public Prototype(string filePath, string[] content)
    {
        FilePath = filePath;
        Content = content;
    }

    public Prototype Clone()
    {
        return new Prototype(FilePath, Content);
    }

    public void Save(string newFileName)
    {
        File.WriteAllLines(newFileName, Content);
    }
}

public class FileClone
{
    public void CloneFormat()
    {
        Console.WriteLine("Enter source format: \n" +
                          "1. CSV\n" +
                          "2. JSON\n" +
                          "3. XML");

        if (Enum.TryParse(Console.ReadKey().KeyChar.ToString(), out FileFormat sourceFormat))
        {
            Console.WriteLine("\nEnter name of your file (it has to be in this folder: Converter\\bin\\Debug\\net6.0): ");
            string sourceName = Console.ReadLine();

            string extension = GetFileExtension(sourceFormat);
            string filePath = Path.Combine(Environment.CurrentDirectory, "Converter\\bin\\Debug\\net6.0", sourceName + extension);

            if (File.Exists(filePath))
            {
                string[] originalContent = File.ReadAllLines(filePath);

                Prototype originalFile = new Prototype(filePath, originalContent);

                Prototype clonedFile = originalFile.Clone();

                clonedFile.Save("CLONED" + extension);

                Console.WriteLine("Clone successful");
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid format.");
        }
    }

    private string GetFileExtension(FileFormat sourceFormat)
    {
        switch (sourceFormat)
        {
            case FileFormat.CSV: return ".csv";
            case FileFormat.JSON: return ".json";
            case FileFormat.XML: return ".xml";
            default: throw new ArgumentException("Invalid file format");
        }
    }
}
