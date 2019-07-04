//==================================================
// Copyright (C) 2016-2019 Fanjia
// All rights reserved
// CLR 版本: 4.0.30319.42000
// 机器名称: PC-20180807FPRA
// 文 件 名: Strategy
// 创建时间: 2019/7/4 10:23:10
// 创 建 人: 范根强
//==================================================
using System;
using System.Collections.Concurrent;

namespace DesignMode
{
    /// <summary>
    /// 策略模式
    /// </summary>
    //public class Strategy
    //{
    public enum ServiceType
        {
            AliPay = 1,
            Tencent = 2,
            JD = 3
        }
        /// <summary>
        /// 提供服务接口
        /// </summary>
        public interface IChannelService
        {
            /// <summary>
            /// 支付
            /// </summary>
            void Pay();
        }
        /// <summary>
        /// 提供抽象类
        /// </summary>
        public abstract class ChannelService : IChannelService
        {
            /// <summary>
            /// 支付渠道集合
            /// </summary>
            protected static ConcurrentDictionary<ServiceType, IChannelService> Services = new ConcurrentDictionary<ServiceType, IChannelService>();
            /// <summary>
            /// 获取支付服务
            /// </summary>
            /// <param name="serviceType"></param>
            /// <returns></returns>
            public static IChannelService SetChannel(ServiceType serviceType)
            {
                return Services.GetOrAdd(serviceType, id =>
                {
                    var typeName = serviceType.ToString();
                    var serviceName = $"DesignMode.{typeName}Service";
                    var type = Type.GetType(serviceName);
                    if (type != null && Activator.CreateInstance(type) is IChannelService service)
                    {
                        return service;
                    }
                    return null;
                });
            }
            public abstract void Pay();
        }
        /// <summary>
        /// 支付宝服务
        /// </summary>
        public class AliPayService : ChannelService
        {
            public override void Pay()
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 腾讯服务
        /// </summary>
        public class TencentPayService : ChannelService
        {
            public override void Pay()
            {
                throw new NotImplementedException();
            }
        }


    //}
}
