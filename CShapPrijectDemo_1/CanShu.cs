using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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
            number=number+1;
            Console.WriteLine(number);
        }
        #endregion

        #region 引用类型的引用参数

        public static void demo4() {
          stringTest stu = new stringTest();
            stu.name = "李遇";
            Console.WriteLine("{0}{1}",stu.name.GetHashCode(),stu.name);
            YinYongLeiXing(ref stu);
            
            Console.WriteLine("{0}{1}", stu.name.GetHashCode(), stu.name);
            Console.ReadKey();
        }
        public static void YinYongLeiXing(ref stringTest numeber) {
            numeber.name = "礼遇";
            Console.WriteLine("{0}{1}",numeber.name.GetHashCode(),numeber.name);
        
        }
        #endregion

        #region 输出参数
        public static void OutCanShu() {
            Console.WriteLine("请输入数字");
            string  arg=Console.ReadLine();//获取输入的数字
            Double x = 0;
            bool b1=double.TryParse(arg,out x);
            if (b1==false)
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
            Console.WriteLine("输出的结果为:{0}+{1}={2}",x,y,Z);
            Console.ReadKey();
        }
        #endregion

    }
}
