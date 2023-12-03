class Program
{
    static void Main()
    {
        FileManipulationHandler fileHandler = new FileManipulationHandler();

        char mainChoice;
        do
        {
            Console.WriteLine("Enter what you want to do\n" +
                              "1. Clone file\n" +
                              "2. Convert file\n" +
                              "3. Exit");
            mainChoice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (mainChoice)
            {
                case '1':
                    fileHandler.CloneFile();
                    break;
                case '2':
                    fileHandler.ConvertFile();
                    break;
                case '3':
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid main choice");
                    break;
            }
        } while (mainChoice != '3');
    }
}

class FileManipulationHandler
{
    private FileClone fileClone;
    private FileConverter fileConverter;

    public FileManipulationHandler()
    {
        fileClone = new FileClone();
        fileConverter = new FileConverter();
    }

    public void CloneFile()
    {
        fileClone.CloneFormat();
    }

    public void ConvertFile()
    {
        Console.WriteLine("Enter from what format you want to convert your file(for this you need at least one clone file)\n" +
                          "1. CSV\n" +
                          "2. JSON\n" +
                          "3. XML\n" +
                          "4. Exit");
        char convertChoice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (convertChoice)
        {
            case '1':
                fileConverter.ConvertCsv();
                break;
            case '2':
                fileConverter.ConvertJson();
                break;
            case '3':
                fileConverter.ConvertXml();
                break;
            case '4':
                break;
            default:
                Console.WriteLine("Invalid file format");
                break;
        }
    }
}

class FileConverter
{
    private Csv csv;
    private Json json;
    private Xml xml;

    public FileConverter()
    {
        csv = new Csv();
        json = new Json();
        xml = new Xml();
    }

    public void ConvertCsv()
    {
        csv.ChooseFormatCSV();
    }

    public void ConvertJson()
    {
        json.ChooseFormatJSON();
    }

    public void ConvertXml()
    {
        xml.ChooseFormatXML();
    }
}
