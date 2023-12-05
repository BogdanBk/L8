class EverydayUsageLaptop : ILaptop
{
    public void ShowScreen()
    {
        Console.WriteLine("This laptop has good quality and good resolution screen");
    }
    public void ShowCPU()
    {
        Console.WriteLine("This laptop has average CPU");
    }
    public void ShowCamera()
    {
        Console.WriteLine("This laptop has medium resolution camera");
    }
    public void ShowGPU()
    {
        Console.WriteLine("This laptop has average GPU");
    }
}