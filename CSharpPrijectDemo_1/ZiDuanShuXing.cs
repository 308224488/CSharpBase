using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShapPrijectDemo_1
{
    internal class ZiDuanShuXing
    {
        public static void demo1()
        {
            student stu = new student();
            stu.name = "礼遇1";
            stu.age = 1;
            //Console.WriteLine("{0},{1}", stu.name, stu.age);
            student stu2 = new student();
            stu2.name = "礼遇2";
            stu2.age = 2;
            student.returnAmount();
            Console.ReadKey();

        }
        class student
        {
            public string name;
            public int age;
            public static string staticAge;
            public static int staticScore;
            public static int staticAmount;
            public student()
            {
                student.staticAmount++;
            }
            public static void returnAmount()
            {
                Console.WriteLine(student.staticAmount);
            }
        }
        public static void demo2()
        {
            score stuScore = new score() { english = 20, math = 30 };
            Console.WriteLine("{0}{1}", stuScore.english, stuScore.math);
            Console.ReadKey();

        }
        public struct score
        {
            //public  int english;
            //public  int math;
            public int english { get; set; }
            public int math { get; set; }
        }
        public static void demo3()
        {
            //使用字典根据索引查数据
            scoreProgram stu = new scoreProgram();
            stu["math"] = 200;
            var indexstu = stu["math"];
            Console.WriteLine(indexstu);
            Console.ReadKey();
        }
        class scoreProgram
        {
            private Dictionary<string, int> scoreMap = new Dictionary<string, int>();
            public int? this[string subject]
            {
                get
                {
                    if (scoreMap.ContainsKey(subject))
                    {
                        return this.scoreMap[subject];
                    }
                    else
                    {
                        return null;
                    }
                }
                set
                {
                    if (value.HasValue == false)//检验传进来的是否真的有值
                    {
                        throw new Exception("传进来的是空值！");
                    }
                    if (scoreMap.ContainsKey(subject))
                    {
                        this.scoreMap[subject] = value.Value;
                    }
                    else
                    {
                        this.scoreMap.Add(subject, value.Value);
                    }
                }
            }
        }
        public static void demo4()
        {
            //定义一个常量
            const int a = 200;
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
