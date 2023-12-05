class EverydayUsageGadget : IGadgetFactory
{
    public IPhone CreatePhone()
    {
        return new EverydayUsagePhone();
    }
    public ITablet CreateTablet()
    {
        return new EverydayUsageTablet();
    }
    public ILaptop CreateLaptop()
    {
        return new EverydayUsageLaptop();
    }
}
