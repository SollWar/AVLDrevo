using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLDrevo
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new AvlThree();
            var rnd = new System.Random();
            obj.Insert(5);
            obj.Insert(3);
            obj.Insert(7);
            obj.Insert(2);
            obj.Insert(4);


            obj.root = obj.RR(obj.root);
            obj.root = obj.LL(obj.root);

            obj.Print1();

            Console.ReadKey();
        }
    }
}
