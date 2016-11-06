using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    //Demo比较乱 大家看清楚哪一个输出对应哪一个知识点~祝好运
    //跟case2部分相关和一些相关的代码已经被注释 希望大家好好查下下再写
    #region 重写ToString()方法
    public enum _type
    {
        parrot,
        sparrow,
        eagle,
        _nullType
    }
    public class Bird
    {
        public Bird(string _name = "noNameYet", _type _Type = _type._nullType)
        {
            name = _name;
            type = _Type;
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private _type type;
        public _type Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public override string ToString()
        {
            return $"my name is {this.name},i'm a {this.type.ToString()}";
        }
    }

    #endregion

    #region 简易抽象类Demo
    public abstract class AbstractClass
    {
        public abstract void Fun();
        public string name = "wow i have a name";
    }
    public class NormalClassOne : AbstractClass
    {
        public override void Fun() { Console.WriteLine("???"); }
    }
    public class NormalClassTwo : AbstractClass
    {
        public override void Fun() { Console.WriteLine("!!!"); }
    }
    #endregion

    #region 简易接口Demo
    public interface IMyInterface
    {
        void Fun1();
        void Fun2();
    }

    public abstract class baseClass : IMyInterface
    {
        public virtual void Fun1() { }
        public abstract void Fun2();
    }//实现接口必须实现接口中的成员

    public class baseOnInterfaceClassOne : baseClass
    {
        public override void Fun2()
        {
            //....
        }
    }

    public abstract class Aves
    {
        private string type;
        private string age;
        public string Type { get { return type; } set { type = value; } }
        public string Age { get { return age; } set { age = value; } }

        public virtual void shout() { }
    }

    public class eagle : Aves, IFly { public void Fly() { } }

    public class qie : Aves { }

    public class plane : IFly { public void Fly() { } }

    interface IFly { void Fly(); }//飞机跟鸟类没有继承关系 但是飞机跟一些鸟类的子类共同拥有飞行的方法 故将飞行方法写成接口
    #endregion

    #region 集合使用类
    public class Human : IComparable
    {
        public int CompareTo(object obj)
        {
            if (obj is Human)
            {
                //注释掉了 大家查一查再写~ 祝好运
            }
            return 0;
        }
        private string name;
        private string age;
        public long propery { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public string Age { get { return age; } set { age = value; } }
      //public static long operator +(Human laoban1, Human laoban2)
    //  {
    //      //
     // }

    }

    public class Student : Human
    {
        public void Study()
        {
            Console.WriteLine("I'm a student,i can study");
        }
    }

    public class Teacher : Human
    {
        public void Teach()
        {
            Console.WriteLine("...teacher,...teach");
        }
    }

    public class proportySort : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            //..注释掉了 大家去查一查再写~
            return 0;
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Bird first = new Bird("paul", _type.parrot);
            Console.WriteLine(first.ToString());
            Bird second = new Bird();
            Console.WriteLine(second.ToString());
    

            NormalClassOne objectOne = new NormalClassOne();
            AbstractClass showName = objectOne;//派生类对象实例化抽象类 访问抽象类的中成员
            Console.WriteLine(showName.name);
            NormalClassTwo objectTwo = new NormalClassTwo();
            objectOne.Fun();
            objectTwo.Fun();

            ArrayList humanArray = new ArrayList();
            humanArray.Add(new Student() { Name = "a", propery = 130 });
            humanArray.Add(new Teacher() { Name = "b", propery = 120 });

            ((Student)humanArray[0]).Study();
            ((Teacher)humanArray[1]).Teach();

            List<Human> a = new List<Human>()
            {
                new Student() { Name ="pengjian "},
                new Student() { Name ="pengjian1 "},
            };


            //humanArray.Remove(humanArray[0]);

            foreach (var human in humanArray)
            {
                Console.WriteLine(((Human)human).Name);
            }

            //humanArray.Clear();
            //Console.WriteLine(humanArray.Count);

          //MyArray myHumanArray = new MyArray();
          //myHumanArray.Add(new Student() { Name = "yezhou2laoban", propery = 1000000000 });
         // myHumanArray.Add(new Teacher() { Name = "yangyuxinglaoban", propery = 999999999999 });

            //foreach (var human in myHumanArray)
            //    Console.WriteLine(((Human)human).Name);
            ////myHumanArray.Remove((Human)myHumanArray[0]);

            //foreach (var human in myHumanArray)
            //    Console.WriteLine(((Human)human).Name);

            //if (myHumanArray[0] is Teacher)
            //    Console.WriteLine("学生也是人");

            //Console.WriteLine($"叶舟2老板和杨宇星老板的资产和为{myHumanArray[0].propery + myHumanArray[1].propery}");


            //遍历初始arraylist内容
            //foreach (var human in humanArray)
            //    Console.WriteLine(((Human)human).Name);
            ////无参数/默认的Sort()方法 根据Human类内部的CompareTo方法的返回值来排序 
            //humanArray.Sort();
            //foreach (var human in humanArray)
            //    Console.WriteLine(((Human)human).Name);

            ////Sort方法根据IComparer对象返回值来排序
            //humanArray.Sort(new proportySort());
            //foreach (var human in humanArray)
            //    Console.WriteLine(((Human)human).Name);

            List<Human> humanList = new List<Human>()
            {
                new Student() { Name="penglaoban"},
                new Teacher() { Name ="xuejie"}
            };



            Console.ReadKey();
        }
    }
}
