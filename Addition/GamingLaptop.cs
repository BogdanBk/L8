class GamingLaptop : ILaptop
{
    public void ShowScreen()
    {
        Console.WriteLine("This laptop has high quality and high resolution screen");
    }
    public void ShowCPU()
    {
        Console.WriteLine("This laptop has very powerful CPU");
    }
    public void ShowCamera()
    {
        Console.WriteLine("This laptop has low resolution camera");
    }
    public void ShowGPU()
    {
        Console.WriteLine("This laptop has very powerful GPU");
    }
}