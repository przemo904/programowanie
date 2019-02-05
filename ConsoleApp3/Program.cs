using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {





        static void Main(string[] args)
        {
            Time time1 = new Time(12, 24, 45, 99);
            Time time2 = new Time(13, 24, 45, 99);
            Console.WriteLine(time1.Equals(time2));

            var milis = time1.CaltulateMiliseconds();
            var time3 = Time.CalculateTime(milis);
            Console.WriteLine(time3);
            if (time1 < time2) {
                Console.WriteLine("mniejsze");
            }else Console.WriteLine("wieksze");

        }
    }
}
