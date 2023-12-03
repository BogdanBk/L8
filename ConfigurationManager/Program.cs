class Program
{
    public static void Main()
    {
        ConfigurationManager instance1 = ConfigurationManager.Instance;
        ConfigurationManager instance2 = ConfigurationManager.Instance;

        instance1.ShowConfigurations();

        instance1.ConfigurationsChangeChoose();

        instance1.ShowConfigurations();

        instance2.ShowConfigurations();

        instance2.ConfigurationsChangeChoose();

        instance1.ShowConfigurations();

    }
}
