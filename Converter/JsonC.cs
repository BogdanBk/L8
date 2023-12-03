using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

class JsonConverter
{
    private string JsonContent { get; }

    public JsonConverter(string jsonFilePath)
    {
        JsonContent = File.ReadAllText(jsonFilePath);
    }

    public async Task ChooseFormatJSONAsync()
    {
        Console.WriteLine("Choose format to convert from JSON\n" +
                          "1. JSON -> CSV\n" +
                          "2. JSON -> XML");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        await ConverterJSONAsync(choice);
    }

    private async Task ConverterJSONAsync(char choice)
    {
        try
        {
            switch (choice)
            {
                case '1':
                    await ConvertJsonToCsvAsync();
                    Console.WriteLine("Converted successfully");
                    break;
                case '2':
                    ConvertJsonToXml();
                    Console.WriteLine("Converted successfully");
                    break;
                default:
                    Console.WriteLine("Wrong target format.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async Task ConvertJsonToCsvAsync()
    {
        string csvFilePath = "CONVERTED(JSON).csv";
        JArray jsonArray = JArray.Parse(JsonContent);

        List<string> headers = new List<string>();
        foreach (JObject jsonObject in jsonArray)
        {
            foreach (var property in jsonObject.Properties())
            {
                string header = property.Name;
                if (!headers.Contains(header))
                {
                    headers.Add(header);
                }
            }
        }

        using (StreamWriter writer = new StreamWriter(csvFilePath))
        {
            await writer.WriteLineAsync(string.Join(",", headers));

            foreach (JObject jsonObject in jsonArray)
            {
                List<string> rowData = new List<string>();

                foreach (string header in headers)
                {
                    JToken value;
                    if (jsonObject.TryGetValue(header, out value))
                    {
                        rowData.Add(value.ToString());
                    }
                    else
                    {
                        rowData.Add("");
                    }
                }

                await writer.WriteLineAsync(string.Join(",", rowData));
            }
        }
    }

    private void ConvertJsonToXml()
    {
        string xmlFilePath = "CONVERTED(JSON).xml";
        JsonContent = $"{{ \"root\": {JsonContent} }}";

        XmlDocument doc = JsonConvert.DeserializeXmlNode(JsonContent, "root");
        doc.Save(xmlFilePath);
    }
}

class Program
{
    static async Task Main()
    {
        JsonConverter jsonConverter = new JsonConverter("CLONED.json");
        await jsonConverter.ChooseFormatJSONAsync();
    }
}
