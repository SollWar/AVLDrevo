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

            var init = Enumerable.Range(0, 15).ToArray();

            for (int i = 0; i < 15; i++)
            {
                obj.Insert(i);
            }

            //obj.root = obj.RR(obj.root);
            //obj.root = obj.LL(obj.root);

            obj.Print1();


            Console.ReadKey();
        }
    }
}
