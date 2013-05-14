using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//All commented is the code that is needed to function
namespace ControlStructuresStatementsLoops
{
    class Excercise1Chef
    {
        private class Bowl
        {
            private List<Vegetable> vegetables = new List<Vegetable>();

            public void Add(Vegetable vegetable)
            {
                this.vegetables.Add(vegetable);
            }
        }

        private class Vegetable
        {
            /*
            public int Size { get; private set; }

            private bool isPeeled = false;

            
            public Vegetable(int size)
            {
                this.Size = size;
            }
            
            */
            public void Cut()
            {
                //this.Size--;
            }
            
            public void Peel()
            {
               //if (!this.isPeeled)
               // {
               //     this.isPeeled = true;
               // }
            }
             
        }

        private class Carrot : Vegetable
        {
            /*
            public Carrot(int size)
                : base(size)
            {

            }
            
             */
        }

        private class Potato : Vegetable
        {
            /*
            public Potato(int size)
                : base(size)
            {

            }
            */
        }

        public class Chef
        {
            private Bowl GetBowl()
            {
                return new Bowl();
            }

            private Carrot GetCarrot()
            {
                return new Carrot();
            }

            private Potato GetPotato()
            {
                return new Potato();
            }

            private void Cut(Vegetable vegetable)
            {
                vegetable.Cut();
            }

            private void Peel(Vegetable vegetable)
            {
                vegetable.Peel();
            }

            public void Cook()
            {
                Potato potato = GetPotato();
                Peel(potato);
                Cut(potato);

                Carrot carrot = GetCarrot();
                Peel(carrot);
                Cut(carrot);

                Bowl bowl = GetBowl();
                bowl.Add(carrot);
                bowl.Add(potato);
            }
        }
    }
}
