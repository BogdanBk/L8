class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose a type of gadget: 1. Gaming, 2. Everyday Usage, 3. Camera");
        int choiceType = int.Parse(Console.ReadLine());

        IGadgetFactory gadgetFactory;

        switch (choiceType)
        {
            case 1:
                gadgetFactory = new GamingGadget();
                break;
            case 2:
                gadgetFactory = new EverydayUsageGadget();
                break;
            case 3:
                gadgetFactory = new CameraGadget();
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
        }

        IPhone phone = gadgetFactory.CreatePhone();
        ITablet tablet = gadgetFactory.CreateTablet();
        ILaptop laptop = gadgetFactory.CreateLaptop();
        Console.WriteLine("Choose gadget: 1. Phone, 2. Tablet, 3. Laptop");
        int choiceGadget = int.Parse(Console.ReadLine());
        switch(choiceGadget)
        {
            case 1:
                phone.ShowScreen();
                phone.ShowCPU();
                phone.ShowSize();
                phone.ShowCamera();
                break;
            case 2:
                tablet.ShowCPU();
                tablet.ShowScreen();
                tablet.ShowCamera();
                break;
            case 3:
                laptop.ShowScreen();
                laptop.ShowCPU();
                laptop.ShowGPU();
                laptop.ShowCamera();
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
        }
    }
}
