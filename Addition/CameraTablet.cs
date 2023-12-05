class CameraTablet : ITablet
{
    public void ShowScreen()
    {
        Console.WriteLine("This tablet has high resolution and big screen");
    }
    public void ShowCPU()
    {
        Console.WriteLine("This tablet has very weak CPU");
    }
    public void ShowCamera()
    {
        Console.WriteLine("This tablet has very high resolution camera");
    }
}