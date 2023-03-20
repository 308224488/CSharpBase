using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CShapPrijectDemo_1
{
    public class CanShu
    {

        #region 值类型
        public static void demo1()
        {
            //值类型   重新赋值的时候改变的是值的副本，值本身不会被修改。
            /*常见的数值类型：byte、sbyte、short、ushort、int、uint、
                              long、ulong、float、double、decimal
            布尔类型：bool
            字符类型：char
            枚举类型：enum
            结构体类型：struct
            */
            student stu = new student();
            int y = 500;
            stu.addMath(y);
            Console.WriteLine(y);
            Console.ReadKey();

        }
        class student
        {
            public void addMath(int x)
            {
                x = x + 1;
                Console.WriteLine(x);

            }

        }
        public static void demo2()
        {
            string name = "tom";
            consoleString(name);
            Console.WriteLine(name);
            Console.ReadKey();

        }
        #endregion

        #region 引用类型
        /*      Object：所有类的基类，所有类型均派生自此类型。
                String：一种字符串类型，表示为连续的 Unicode 字符。
                Array：一种集合类型，包含一些相同数据类型的元素。
                Class：一种引用类型，具体的类型定义，可以定义成员字段和方法。
                Interface：一种引用类型，可以定义可实现的成员，用于继承和多态。
                Delegate：一种引用类型，用于表示对一个或多个方法的引用。
                Dynamic：一种动态类型，变量的类型在运行时确定。
                Nullable：使值类型可空，一个包装器类型。
                Collection：一种泛型类型，表示数据集合，继承自 IEnumerable<T>。
                List：一种数组类型，动态增加和删除元素，继承自 ICollection<T>。
                Dictionary：一种键值对集合类型，提供一种基于哈希表的查找方式。
                Queue：一种先进先出的集合类型，用于存储元素，继承自 ICollection<T>。
                Stack：一种后进先出的集合类型，用于存储元素，继承自 ICollection<T>。
                HashSet：一种集合类型，不允许有重复元素，可以快速查找元素。
                LinkedList：一种链表类型，用于存储元素，每个元素包含对前一个和后一个元素的引用。
                ObservableCollection：一种集合类型，表示可以监听该集合对象的变化事件。
                SortedList：一种有序的集合类型，提供一种基于键值对的查找方式。
                Tuple：一种存储固定数量的元素的类型，每个元素可以是一个不同类型的值。*/

        public static void consoleString(string name)
        {

            stringTest stu = new stringTest();
            stu.name = "toy";
            Console.WriteLine("{0}{1}", stu.name.GetHashCode(), stu.name);
        }
        public class stringTest
        {
            public string name;
        }
        #endregion

        #region 值类型的引用参数
        public static void demo3() {
            int number_Test = 3;
            YinYongCanShu(ref number_Test);
            Console.WriteLine(number_Test);
            Console.ReadKey();
        }
        public static void YinYongCanShu(ref int number)
        {
            number = number + 1;
            Console.WriteLine(number);
        }
        #endregion

        #region 引用类型的引用参数

        public static void demo4() {
            stringTest stu = new stringTest();
            stu.name = "李遇";
            Console.WriteLine("{0}{1}", stu.name.GetHashCode(), stu.name);
            YinYongLeiXing(ref stu);

            Console.WriteLine("{0}{1}", stu.name.GetHashCode(), stu.name);
            Console.ReadKey();
        }
        public static void YinYongLeiXing(ref stringTest numeber) {
            numeber.name = "礼遇";
            Console.WriteLine("{0}{1}", numeber.name.GetHashCode(), numeber.name);

        }
        #endregion

        #region 输出参数
        public static void OutCanShu() {
            Console.WriteLine("请输入数字");
            string arg = Console.ReadLine();//获取输入的数字
            Double x = 0;
            bool b1 = double.TryParse(arg, out x);
            if (b1 == false)
            {
                Console.WriteLine("输入错误");
                return;
            }
            Console.WriteLine("请输入第二个数字");
            string arg1 = Console.ReadLine();//获取输入的数字
            Double y = 0;
            bool b2 = double.TryParse(arg, out y);
            if (b2 == false)
            {
                Console.WriteLine("输入错误");
                return;
            }
            Double Z = x + y;
            Console.WriteLine("输出的结果为:{0}+{1}={2}", x, y, Z);
            Console.ReadKey();
        }
        #endregion

        #region 数组参数
        public static void demo5()
        {
            //声明一个数组
            int[] arrayNumber = new int[] { 1, 2, 3, 4, 5 };
            //使用params关键字以后不需要再声明数组，直接输入数组元素即可
            int sum = arraySum(1, 2, 3, 4, 45, 3);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
        public static void demo6() {
            //字符串截取
            string nameInfo = "李瑞博,董玉蓉！礼遇~";
            string[] result = nameInfo.Split(',', '!', '~', '！');
            foreach (string itme in result) {
                Console.WriteLine(itme);
            }
            Console.ReadKey();
        }
        public static int arraySum(params int[] arrayNumber) {
            //返回数组之和  
            int number = 0;
            foreach (var item in arrayNumber)
            {
                number += item;
            }
            return number;

        }
        #endregion

        #region 具名参数
        public static void demo7() {
            //不具名参数
            JuMing("礼遇", 3);
            //具名参数
            //优点:1、提高代码可读性.2不受参数列表顺序影响
            JuMing(name: "礼遇", age: 4);
            Console.ReadKey();

        }
        public static void JuMing(string name, int age) {
            Console.WriteLine("您输入的名字为:{0},年龄:{1}", name, age);
        }
        #endregion

        #region 可选参数
        public static void demo8() {
            // KeXuanCanShu();//未声明的情况下使用默认值
            KeXuanCanShu(age: 2);
            Console.ReadKey();

        }
        public static void KeXuanCanShu(string name = "礼遇", int age = 5)
        {
            Console.WriteLine("您输入的名字为:{0},年龄:{1}", name, age);
        }
        #endregion

        #region 扩展方法（this参数）
        public static void demo9() {
            //方法必须是公有的，静态的 被public static所修饰
            //必须是形参列表中的第一个，由this修饰

            double x = 3.23454321;
            double result = x.KuoZhanFangFa(3);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        #endregion

        #region Linq
        //声明一个List集合 判断集合中的数字是否大于10
        public static void demo10() {
            List<int> number = new List<int>();
            int[] number_ ={1,2,3,4,5,6,7,8 };
            number.AddRange(number_);
            //bool result = listTrueOrFalse(number);
            //使用linq中的扩展方法
            bool result = number.All(x => x>=5);  
            Console.WriteLine(result);
            Console.ReadKey();

        }    
        public static bool listTrueOrFalse(List<int> list) {
            foreach (var item in list)
            {
                if (item>5)
                {
                    Console.WriteLine("{0}:{1}",item,false);
                   
                }
                
            }
            return true;
        }
        #endregion

    }
    #region 顶级静态类
    static class KuoZhan
    {
        public static double KuoZhanFangFa(this double zhi, int index)
        {
            double result = Math.Round(zhi, index);
            return result;
        }
    }
    #endregion


}
