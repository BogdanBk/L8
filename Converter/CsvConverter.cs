using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

class CsvConverter
{
    private static readonly string CsvFilePath = "CLONED.csv";

    public void ChooseFormatCSV()
    {
        Console.WriteLine("Choose format to convert from CSV\n" +
                          "1. CSV -> JSON\n" +
                          "2. CSV -> XML");

        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        ConverterCSV(choice);
    }

    private void ConverterCSV(char choice)
    {
        try
        {
            switch (choice)
            {
                case '1':
                    ConvertCsvToJson();
                    Console.WriteLine("Converted successfully");
                    break;
                case '2':
                    ConvertCsvToXml();
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

    private void ConvertCsvToJson()
    {
        string jsonFilePath = "CONVERTED(CSV).json";

        using (var reader = new StreamReader(CsvFilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<dynamic>().ToList();
            string jsonString = JsonConvert.SerializeObject(records, Formatting.Indented);
            File.WriteAllText(jsonFilePath, jsonString);
        }
    }

    private void ConvertCsvToXml()
    {
        string xmlFilePath = "CONVERTED(CSV).xml";
        DataTable dataTable = new DataTable("Data");

        using (StreamReader reader = new StreamReader(CsvFilePath))
        {
            string[] headers = reader.ReadLine()?.Split(',') ?? Array.Empty<string>();
            foreach (string header in headers)
            {
                string columnName = header.Trim().Replace(" ", "_");
                dataTable.Columns.Add(columnName);
            }

            while (!reader.EndOfStream)
            {
                string[] rows = reader.ReadLine()?.Split(',') ?? Array.Empty<string>();
                DataRow dataRow = dataTable.NewRow();

                for (int i = 0; i < headers.Length; i++)
                {
                    dataRow[i] = rows.Length > i ? rows[i].Trim() : string.Empty;
                }

                dataTable.Rows.Add(dataRow);
            }
        }

        using (XmlWriter writer = XmlWriter.Create(xmlFilePath))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement(dataTable.TableName);

            foreach (DataRow row in dataTable.Rows)
            {
                writer.WriteStartElement("Row");

                foreach (DataColumn col in dataTable.Columns)
                {
                    string elementName = col.ColumnName.Replace(" ", "_");
                    writer.WriteStartElement(elementName);
                    writer.WriteValue(row[col]);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }
}

class Program
{
    static void Main()
    {
        CsvConverter csvConverter = new CsvConverter();
        csvConverter.ChooseFormatCSV();
    }
}
