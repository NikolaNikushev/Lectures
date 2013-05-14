namespace OtherTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Excercise1BooleanPrinter
    {
        class Engine
        {
            private const int MAX_COUNT = 6;

            class Grapcic
            {
                public void PrintBooleanValue(bool booleanValue)
                {
                    string valueToString = booleanValue.ToString();
                    Console.WriteLine(valueToString);
                }
            }

            public static void Main()
            {
                Engine.Grapcic grapcicalInstance = new Engine.Grapcic();
                grapcicalInstance.PrintBooleanValue(true);
            }
        }
    }

    class Excercise2HumanCreator
    {
        class World
        {
            enum Sex
            {
                Male,
                Female
            };

            class Human
            {
                public Sex Sex { get; set; }
                public string Name { get; set; }
                public int Age { get; set; }
            }

            public void MakeHuman(int age)
            {
                Human human = new Human();
                human.Age = age;
                if (age % 2 == 0)
                {
                    human.Name = "Just a Man";
                    human.Sex = Sex.Male;
                }
                else
                {
                    human.Name = "Just a Woman";
                    human.Sex = Sex.Female;
                }
            }
        }
    }
}