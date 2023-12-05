class GamingGadget : IGadgetFactory
{
    public IPhone CreatePhone()
    {
        return new GamingPhone();
    }
    public ITablet CreateTablet()
    {
        return new GamingTablet();
    }
    public ILaptop CreateLaptop()
    {
        return new GamingLaptop();
    }
}