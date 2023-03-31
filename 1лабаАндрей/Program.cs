using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1лабаАндрей
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Start:
            {
                try
                {
                    var tr = new Triangle(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                    Console.WriteLine(tr.ToString());
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto Start;
                }
            }
        }
    }
}
