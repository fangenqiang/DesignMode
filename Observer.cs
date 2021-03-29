//==================================================
// Copyright (C) 2021 Fanjia
// All rights reserved
// CLR 版本: 4.0.30319.42000
// 机器名称: PC-20180807FPRA
// 文 件 名: Observer
// 创建时间: 2021/3/29 11:45:49
// 创 建 人: 范根强
//==================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode
{

    /// <summary>
    /// 鱼竿-被观察者
    /// </summary>
    public class FishingRod
    {
        public delegate void FishingHandler(FishType type);//声明委托
        public event FishingHandler FishingEvent;//声明事件
        public void ThrowHook(FishingMan man)
        {
            Console.WriteLine("开始钓鱼");

            //用随机数模拟鱼咬钩，若随机数为偶数，则为鱼咬钩
            if (new Random().Next()%2==0)
            {
                var type = (FishType)new Random().Next(0, 5);
                Console.WriteLine("铃铛：叮叮叮，鱼儿咬钩了");
                if (FishingEvent != null)
                    FishingEvent(type);
            }
        }
    }
    /// <summary>
    /// 垂钓人-观察者
    /// </summary>
    public class FishingMan
    {
        public string Name { get; set; }
        public int FishCount { get; set; }
        public FishingRod FishingRod { get; set; }
        public FishingMan(string name)
        {
            this.Name = name;
        }

        public void Fishing()
        {
            this.FishingRod.ThrowHook(this);
        }

        public void Update(FishType type)
        {
            FishCount++;
            Console.WriteLine("{0}：钓到一条[{2}]，已经钓到{1}条鱼了！", Name, FishCount, type);
        }
    }

    /// <summary>
    /// 鱼的种类
    /// </summary>
    public enum FishType
    {
        鲫鱼,
        鲤鱼,
        黑鱼,
        青鱼,
        草鱼,
        鲈鱼
    }
}
