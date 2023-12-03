using System;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;

class XmlConverter
{
    private const string XmlFilePath = "CLONED.xml";

    public void ChooseFormatXML()
    {
        Console.WriteLine("Choose format to convert from XML\n" +
                          "1. XML -> CSV\n" +
                          "2. XML -> JSON");

        ConsoleKeyInfo key = Console.ReadKey();
        Console.WriteLine();

        switch (key.Key)
        {
            case ConsoleKey.D1:
                ConvertXmlToCsv();
                break;
            case ConsoleKey.D2:
                ConvertXmlToJson();
                break;
            default:
                Console.WriteLine("Wrong target format.");
                break;
        }
    }

    private void ConvertXmlToCsv()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(XmlFilePath);

        using (StreamWriter writer = new StreamWriter("CONVERTED(XML).csv"))
        {
            XmlNodeList headers = doc.SelectNodes("//item[1]/*");
            writer.WriteLine(string.Join(",", GetNodeValues(headers)));

            XmlNodeList items = doc.SelectNodes("//item");
            foreach (XmlNode item in items)
            {
                XmlNodeList values = item.SelectNodes("*");
                writer.WriteLine(string.Join(",", GetNodeValues(values)));
            }
        }

        Console.WriteLine("Converted successfully");
    }

    private void ConvertXmlToJson()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(XmlFilePath);

        string jsonContent = JsonConvert.SerializeXmlNode(doc);
        File.WriteAllText("CONVERTED(XML).json", jsonContent);

        Console.WriteLine("Converted successfully");
    }

    private static string[] GetNodeValues(XmlNodeList nodes)
    {
        return nodes.Cast<XmlNode>().Select(node => node.InnerText).ToArray();
    }
}

class Program
{
    static void Main()
    {
        XmlConverter xmlConverter = new XmlConverter();
        xmlConverter.ChooseFormatXML();
    }
}
