using System;


namespace DesignMode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton.Singleton1.GetSingleton();
            //Singleton.Singleton2.GetSingleton();
            //Singleton.Singleton3.GetSingleton();
            //Singleton.Singleton4.GetSingleton();
            //Singleton.Singleton5.GetSingleton();
            //Singleton.Singleton6.GetSingleton();

            ChannelService.SetChannel(ServiceType.AliPay).Pay();
           
            Console.WriteLine("Hello World!");
        }
    }
}
