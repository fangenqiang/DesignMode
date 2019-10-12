using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode
{
    /// <summary>
    /// 中介者模式
    /// </summary>
    public class MediatorPattern
    {
        /// <summary>
        /// 抽象中介类
        /// </summary>
        public abstract class Mediator
        {
            public abstract void Common(string type);
        }
        /// <summary>
        /// 抽象房东类
        /// </summary>
        public abstract class Houser
        {
            public abstract void Handle();
        }
        /// <summary>
        /// 房东1
        /// </summary>
        public class SmallHouser : Houser
        {
            public override void Handle()
            {
                Console.WriteLine("单间——便宜整洁");
            }
        }
        /// <summary>
        /// 房东2
        /// </summary>
        public class TwoHouser : Houser
        {
            public override void Handle()
            {
                Console.WriteLine("两居室——合适，靠谱");
            }
        }
        /// <summary>
        /// 房东3
        /// </summary>
        public class ThreeHouser : Houser
        {
            public override void Handle()
            {
                Console.WriteLine("三居室——大气，宽松");
            }
        }
        /// <summary>
        /// 房屋中介
        /// </summary>
        public class HouseMediator : Mediator
        {
            private SmallHouser smallHouser;
            private TwoHouser twoHouser;
            private ThreeHouser threeHouser;

            public void SetSmallHouse(SmallHouser small)
            {
                smallHouser = small;
            }

            public void SetTwoHouse(TwoHouser two)
            {
                twoHouser = two;
            }
            public void SetThreeHouse(ThreeHouser three)
            {
                threeHouser = three;
            }
            public override void Common(string type)
            {

                switch (type)
                {
                    case "单间":
                        smallHouser.Handle();
                        Console.WriteLine("如果可以就可以租房了!");
                        break;
                    case "两居室":
                        twoHouser.Handle();
                        Console.WriteLine("如果可以就可以租房了!");
                        break;
                    case "三居室":
                        threeHouser.Handle();
                        Console.WriteLine("如果可以就可以租房了!");
                        break;
                    default:
                        Console.WriteLine($"{type}暂时没有房源!");
                        break;
                }
            }
        }
    }
}