using System;

namespace 观察者设计模式_猫捉老鼠
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("加菲猫", "黄色");
            Mouse mouse1 = new Mouse("米奇", "黑色",cat);
            //cat.catCome += mouse1.RunAway;
            Mouse mouse2 = new Mouse("唐老鸭", "红色",cat);
            //cat.catCome += mouse2.RunAway;
            //cat.CatComing(mouse1,mouse2);
            cat.CatComing();
            //cat.catCome();      //事件不能在类的外部触发，只能在类的内部触发
            Console.ReadKey();
        }
    }
}
