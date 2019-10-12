using System;
using static DesignMode.MediatorPattern;

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

            //ChannelService.SetChannel(ServiceType.AliPay).Pay();
            #region 中介者模式

            Console.WriteLine("一个租客看房：");
            ///初始化中介
            HouseMediator mediator = new HouseMediator();

            ///初始化房屋信息
            SmallHouser smallHouser = new SmallHouser();
            TwoHouser twoHouser = new TwoHouser();
            ThreeHouser threeHouse = new ThreeHouser();

            ///中介获取房屋信息
            mediator.SetSmallHouse(smallHouser);
            mediator.SetTwoHouse(twoHouser);
            mediator.SetThreeHouse(threeHouse);

            ///租户A需要两居室、提供看房
            mediator.Common("两居室");

            //租户B需要四居室、暂无房源
            mediator.Common("四居室");

            #endregion
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
    }
}
