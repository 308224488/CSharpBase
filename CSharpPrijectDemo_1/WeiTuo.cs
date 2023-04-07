using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CShapPrijectDemo_1
{
    public delegate double Cacl(double x,double y);

    public  class WeiTuo
    {
        #region Action  Func委托
        //委托可以将方法作为参数进行传递
        //有返回值使用func,无返回值使用action
        public static void demo1() {
            Action action = new Action(WeiTuo_.console_);
            action();
            Console.ReadKey();
        }
        public static void demo2() {
            int x = 100;
            int y = 200;
            int z;
            Func<int, int, int> result1 = new Func<int, int, int>(WeiTuo_.Jia);
            Func<int, int, int> result2 = new Func<int, int, int>(WeiTuo_.Jian);
            z = result1(x,y);
            Console.WriteLine(z);
            z = result2(x, y);
            Console.WriteLine(z);
            Console.ReadKey();
        }
        #endregion

        #region 自定义委托
        //委托必须与封装的方法保持类型兼容
        public static void demo3() {
            Cacl cacl_1 = new Cacl(ZiDingYiWeiTuo.ADD);
            Cacl cacl_2 = new Cacl(ZiDingYiWeiTuo.Sub);
            Cacl cacl_3 = new Cacl(ZiDingYiWeiTuo.Mul);
            Cacl cacl_4 = new Cacl(ZiDingYiWeiTuo.Div);
            double x = 30.555;
            double y = 300;
            double result = 0;
            result = cacl_1(x,y);
            Console.WriteLine(result);
            result = cacl_2(x, y);
            Console.WriteLine(result);
            result = cacl_3(x, y);
            Console.WriteLine(result);
            result = cacl_4(x, y);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        #endregion

        #region 模板方法
        public static void demo4() {
            WrapProduct wrapProduct = new WrapProduct();
            ProductFactory productFactory=new ProductFactory();
            Func<Product> func_1 = new Func<Product>(productFactory.Pizza);
            Func<Product> func_2 = new Func<Product>(productFactory.ToyCar);
            Box box_1 = wrapProduct.WarpProduct(func_1);
            Box box_2 = wrapProduct.WarpProduct(func_2);
            Console.WriteLine(box_1.Product.Name);
            Console.WriteLine(box_2.Product.Name);
            Console.ReadKey();
        }
        #endregion

        #region 回调方法
        public static void demo5() {
            CllBack_WrapProduct wrapProduct = new CllBack_WrapProduct();
            CllBack_ProductFactory productFactory = new CllBack_ProductFactory();
            Func<CllBack_Product> func_1=new Func<CllBack_Product>(productFactory.Pizza);
            Func<CllBack_Product> func_2 = new Func<CllBack_Product>(productFactory.ToyCar);
            Logger logger = new Logger();
            Action<CllBack_Product> action = new Action<CllBack_Product>(logger.logger_);
            CllBack_Box box_1=wrapProduct.CllBack_WarpProduct(func_1,action);
            CllBack_Box box_2 = wrapProduct.CllBack_WarpProduct(func_2, action);
            Console.WriteLine(box_1.Product.Name);
            Console.WriteLine(box_2.Product.Name);
            Console.ReadKey();
        }
        #endregion

        #region 委托的高级用法
        /* 隐式多线程 v.s.显式多线程
         直接同步调用: 使用方法名间接同步调用: 
         使用单播/多播委托的Invoke方法隐式异步调用: 
         使用委托的Begininvoke显式异步调用:使用Thread或Task*/
        #region 单播/多播委托  间接同步调用
        public static void demo6()
        {
            Student stu_1 = new Student() { studentId = 1, colorPen = ConsoleColor.Green };
            Student stu_2 = new Student() { studentId = 2, colorPen = ConsoleColor.Cyan };
            Student stu_3 = new Student() { studentId = 3, colorPen = ConsoleColor.DarkYellow };
            Action action_1 = new Action(stu_1.homeWork);
            Action action_2 = new Action(stu_2.homeWork);
            Action action_3 = new Action(stu_3.homeWork);
            //action_1();
            //action_2();
            //action_3(); 单播委托
            action_1 = action_1 + action_2 + action_3;
            action_1();//多播委托
            Console.ReadKey();
        }
        #endregion

        #region 同步调用
        public static void demo7() {
            Student stu_1 = new Student() { studentId = 1, colorPen = ConsoleColor.Green };
            Student stu_2 = new Student() { studentId = 2, colorPen = ConsoleColor.Cyan };
            Student stu_3 = new Student() { studentId = 3, colorPen = ConsoleColor.DarkYellow };
            stu_1.homeWork();stu_2.homeWork();stu_3.homeWork();
            Console.ReadKey();
        }
        #endregion

        #region 使用委托隐式异步调用
        public static void demo8() {
            Student stu_1 = new Student() { studentId = 1, colorPen = ConsoleColor.Green };
            Student stu_2 = new Student() { studentId = 2, colorPen = ConsoleColor.Cyan };
            Student stu_3 = new Student() { studentId = 3, colorPen = ConsoleColor.DarkYellow };
            Action action_1 = new Action(stu_1.homeWork);
            Action action_2 = new Action(stu_2.homeWork);
            Action action_3= new Action(stu_3.homeWork);
            action_1.BeginInvoke(null,null);//隐式异步调用 并行执行
            action_2.BeginInvoke(null, null);
            action_3.BeginInvoke(null, null);
           
            Console.ReadKey();
        }
        #endregion

        #region 使用委托显式异步调用
        public static void demo9()
        {
            Student stu_1 = new Student() { studentId = 1, colorPen = ConsoleColor.Green };
            Student stu_2 = new Student() { studentId = 2, colorPen = ConsoleColor.Cyan };
            Student stu_3 = new Student() { studentId = 3, colorPen = ConsoleColor.DarkYellow };
            Action action_1 = new Action(stu_1.homeWork);
            Action action_2 = new Action(stu_2.homeWork);
            Action action_3 = new Action(stu_3.homeWork);
            Task task_1 = new Task(action_1);
            Task task_2 = new Task(action_2);
            Task task_3 = new Task(action_3);
            task_1.Start();
            task_2.Start();
            task_3.Start();

            Console.ReadKey();
        }
        #endregion
        #endregion
    }
    static class WeiTuo_{
        public static void console_()
        {
            Console.WriteLine("我有三个实例");
        }
        public static int Jia(int a, int b)
        {
            int result = a + b;
            return result;
        }
        public static int Jian(int a, int b)
        {
            int result = a - b;
            return result;
        }
    }
    static class ZiDingYiWeiTuo {
        public static double ADD(double a,double b) {
            return a + b;
        }
        public static double Sub(double a, double b)
        {
            return a - b;
        }
        public static double Mul(double a, double b)
        {
            return a * b;
        }
        public static double Div(double a, double b)
        {
            return a / b;
        }

    }
    #region 模板方法
    class Product
    {
        public string Name { get; set; } //产品名
    }
    class Box
    {
        public Product Product { get; set; }//产品包装箱
    }
    class WrapProduct
    {
        public Box WarpProduct(Func<Product> getProduct)
        {
            Box box = new Box();
            Product product = getProduct();//将方法名作为参数传递
            box.Product = product;
            return box;
        }
    }
    //披萨饼
    class ProductFactory
    {
        public Product Pizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }
        //玩具小汽车
        public Product ToyCar()
        {
            Product product = new Product();
            product.Name = "ToyCar";
            return product;
        }


    }
    #endregion

    #region 回调方法
    class Logger {
        
        public void logger_(CllBack_Product getProduct) {
            
            Console.WriteLine("产品名:{0}价格:{1}时间:{2}", getProduct.Name, getProduct.Price,DateTime.UtcNow);
        }
    }
    class CllBack_Product
    {
        public string Name { get; set; } //产品名
        public int Price { get; set; }//价格
    }
    class CllBack_Box
    {
        public CllBack_Product Product { get; set; }//产品包装箱
    }
    class CllBack_WrapProduct
    {
        public CllBack_Box CllBack_WarpProduct(Func<CllBack_Product> getProduct,Action<CllBack_Product> callBackLog)
        {
            CllBack_Box box = new CllBack_Box();
            CllBack_Product product = getProduct();//将方法名作为参数传递   
            box.Product = product;
            if (product.Price >= 30)
            {
                callBackLog(product);
            }
            return box;
        }
    }
    class CllBack_ProductFactory
    {   //披萨饼
        public CllBack_Product Pizza()
        {
            CllBack_Product product = new CllBack_Product();
            product.Name = "Pizza";
            product.Price = 20;
            return product;
        }
        //玩具小汽车
        public CllBack_Product ToyCar()
        {
            CllBack_Product product = new CllBack_Product();
            product.Name = "ToyCar";
            product.Price = 70;
            return product;
        }


    }
    #endregion

    class Student {
        public int studentId { get; set; }
        public ConsoleColor colorPen{ get; set; }//输出的颜色

        public  void homeWork() {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.colorPen;
                Console.WriteLine("{0}做了{1}小时的作业",studentId,i);
                Thread.Sleep(1000);//睡一秒
            }
        
        }
}

}
