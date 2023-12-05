class CameraLaptop : ILaptop
{
    public void ShowScreen()
    {
        Console.WriteLine("This laptop has high quality and high resolution screen");
    }
    public void ShowCPU()
    {
        Console.WriteLine("This laptop has weak CPU");
    }
    public void ShowCamera()
    {
        Console.WriteLine("This laptop has high resolution camera");
    }
    public void ShowGPU()
    {
        Console.WriteLine("This laptop has weak GPU");
    }
}