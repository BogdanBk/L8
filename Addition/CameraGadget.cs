class CameraGadget : IGadgetFactory
{
    public IPhone CreatePhone()
    {
        return new CameraPhone();
    }
    public ITablet CreateTablet()
    {
        return new CameraTablet();
    }
    public ILaptop CreateLaptop()
    {
        return new CameraLaptop();
    }
}
