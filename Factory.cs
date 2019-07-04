//==================================================
// Copyright (C) 2016-2019 Fanjia
// All rights reserved
// CLR 版本: 4.0.30319.42000
// 机器名称: PC-20180807FPRA
// 文 件 名: Factory
// 创建时间: 2019/7/4 9:56:38
// 创 建 人: 范根强
//==================================================
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode
{
    /// <summary>
    /// 工厂模式
    /// </summary>
    public class Factory
    {
        #region 简单工厂
        public class  PizzaFactory
        {
            public static Pizza CreatePizza(string pizzaType)
            {
                switch (pizzaType)
                {
                    case "Cheese":
                        return new CheesePizza();
                    case "ApplePie":
                        return new ApplePiePizza();
                    default:
                        return new SomeOtherPizza();
                }
            }
        }

        public abstract class Pizza
        {
            public  string Name { get; set; }
            public  void Prepare( )
            {
                Console.WriteLine($"Preparing {Name}");
            }
            public void Cut()
            {
                Console.WriteLine($"Cutting the {Name}");
            }

            public void Bake()
            {
                Console.WriteLine($"Baking the {Name}");
            }

            public void Box()
            {
                Console.WriteLine($"Boxing the {Name}");
            }
        }
        public class ApplePiePizza : Pizza
        {
            public ApplePiePizza()
            {
                Name = "ApplePie";
            }
        }

        public class CheesePizza : Pizza
        {
            public CheesePizza()
            {
                Name = "Cheese";
            }
        }

        public class SomeOtherPizza : Pizza
        {
            public SomeOtherPizza()
            {
                Name = "Other";
            }
        }
        #endregion

        #region 工厂 符合开闭原则

        /// <summary>
        /// 工厂接口
        /// </summary>
        interface IFactory
        {
            Pizza CreatePizza();
        }
        /// <summary>
        /// CheesePizza工厂方法
        /// </summary>
        public class CheesePizzaFactory : IFactory
        {
            public Pizza CreatePizza()
            {
                return new CheesePizza();

            }
        }
        /// <summary>
        /// ApplePiePizza工厂方法
        /// </summary>
        public class ApplePiePizzaFactory : IFactory
        {
            public Pizza CreatePizza()
            {
                return new ApplePiePizza();
            }
        }
        #endregion

        #region 抽象工厂
        /// <summary>
        /// 面团
        /// </summary>
        public interface Dough
        {
            void Dough();
        }
        /// <summary>
        /// 纽约面团
        /// </summary>
        public class NYDough : Dough
        {
           public void Dough()
            {
                Console.WriteLine("NYDough");
            }
        }
        /// <summary>
        /// 芝加哥面团
        /// </summary>
        public class ChicagoDough : Dough
        {
            public void Dough()
            {
                Console.WriteLine("ChicagoDough");
            }
        }
        /// <summary>
        /// 果酱
        /// </summary>
        public interface Sauce
        {
            void Sauce();
        }
        /// <summary>
        /// 纽约果酱
        /// </summary>
        public class NYSauce : Sauce
        {
            public void Sauce()
            {
                Console.WriteLine("NYSauce");
            }
        }
        /// <summary>
        /// 芝加哥果酱
        /// </summary>
        public class ChicagoSauce : Sauce
        {
            public void Sauce()
            {
                Console.WriteLine("ChicagoSauce");
            }
        }
        /// <summary>
        /// 建造披萨原料工厂 接口
        /// </summary>
        public interface IPizzaIngredientFactory
        {
            Dough CreateDough();
            Sauce CreateSauce();
        }
        /// <summary>
        /// 纽约披萨工厂
        /// </summary>
        public class NYPizzaIngredientFactory : IPizzaIngredientFactory
        {
            public Dough CreateDough()
            {
                return new NYDough();
            }
            public Sauce CreateSauce()
            {
                return new NYSauce();
            }
        }
        /// <summary>
        /// 芝加哥披萨工厂
        /// </summary>
        public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
        {
            public Dough CreateDough()
            {
                return new ChicagoDough();
            }
            public Sauce CreateSauce()
            {
                return new ChicagoSauce();
            }
        }
        public abstract class Pizza3
        {
            public string Name { get; set; }
            /// <summary>
            /// 面团
            /// </summary>
            public Dough Dough { get; set; }
            /// <summary>
            /// 酱汁
            /// </summary>
            public Sauce Sauce { get; set; }

            public abstract void Prepare();


            public void Cut()
            {
                Console.WriteLine($"Cutting the {Name}");
            }

            public void Bake()
            {
                Console.WriteLine($"Baking the {Name}");
            }

            public void Box()
            {
                Console.WriteLine($"Boxing the {Name}");
            }
        }
        public class ApplePiePizza3 : Pizza3
        {
            IPizzaIngredientFactory _pizzaIngredientFactory;
            public ApplePiePizza3(IPizzaIngredientFactory pizzaIngredient)
            {
                this._pizzaIngredientFactory = pizzaIngredient;
                Name = "ApplePie";
            }

            public override void Prepare()
            {
                Console.WriteLine($"Preparing { Name}");
                Dough = _pizzaIngredientFactory.CreateDough();
                Dough.Dough();
                Sauce = _pizzaIngredientFactory.CreateSauce();
                Sauce.Sauce();
            }
        }
        public class CheesePizza3 : Pizza3
        {
            IPizzaIngredientFactory _pizzaIngredientFactory;
            public CheesePizza3(IPizzaIngredientFactory pizzaIngredient)
            {
                this._pizzaIngredientFactory = pizzaIngredient;
                Name = "Cheese";
            }

            public override void Prepare()
            {
                Console.WriteLine($"Preparing { Name}");
                Dough = _pizzaIngredientFactory.CreateDough();
                Dough.Dough();
                Sauce = _pizzaIngredientFactory.CreateSauce();
                Sauce.Sauce();
            }
        }
        public class SomeOtherPizza3 : Pizza3
        {
            public SomeOtherPizza3()
            {
                Name = "Other";
            }

            public override void Prepare()
            {
                throw new NotImplementedException();
            }
        }
        // <summary>
        /// 工厂接口
        /// </summary>
        interface IFactory3
        {
            Pizza3 CreatePizza(IPizzaIngredientFactory pizzaIngredientFactory);
        }
        /// <summary>
        /// CheesePizza工厂方法
        /// </summary>
        public class CheesePizzaFactory3 : IFactory3
        {
            public Pizza3 CreatePizza(IPizzaIngredientFactory pizzaIngredientFactory)
            {
                return new CheesePizza3(pizzaIngredientFactory);

            }
        }

        /// <summary>
        /// ApplePiePizza工厂方法
        /// </summary>
        public class ApplePiePizzaFactory3 : IFactory3
        {
            public Pizza3 CreatePizza(IPizzaIngredientFactory pizzaIngredientFactory)
            {
                return new ApplePiePizza3(pizzaIngredientFactory);
            }
        }
        //调用
        class Program
        {
            static void Main(string[] args)
            {
                IPizzaIngredientFactory pizzaIngredientFactory = new NYPizzaIngredientFactory();
                IFactory3 factory = new CheesePizzaFactory3();
                Pizza3 cheesePizza = factory.CreatePizza(pizzaIngredientFactory);
                cheesePizza.Prepare();
                cheesePizza.Cut();
                cheesePizza.Bake();
                cheesePizza.Box();
                //输出：
                //Preparing Cheese
                //NYDough
                //NYSauce
                //Cutting the Cheese
                //Baking the Cheese
                //Boxing the Cheese
            }
        }
        #endregion
    }
}
