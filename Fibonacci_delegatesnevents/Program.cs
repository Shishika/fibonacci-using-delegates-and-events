using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Recursivefibanocci
{
    delegate void Printpercentage(int n, int i);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fibanocci Series!!");
            var fibanocci = new Fibanocci(5);
            Fibanocci.Calculatefibanocci();
            Console.ReadKey();
        }
    }
    class Fibanocci
    {
        public int number = 0;
        Printpercentage printpercentage = new Printpercentage(Calculatepercentage);
        event Printpercentage printevent = Calculatepercentage;
        public Fibanocci(int n)
        {
            number = n;
        }
        public async Task Calculatefibanocci()
        {
            for (int i = 0; i <= number; i++)
            {
                Console.WriteLine(await Nthfibanocci(i));
                printevent.Invoke(number, i);
            }
        }
        public static void Calculatepercentage(int n, int i)
        {
            Console.WriteLine(i * 100 / n + "%");
        }
        public async Task<int> Nthfibanocci(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return await Nthfibanocci(n - 1) + await Nthfibanocci(n - 2);
        }
    }
}
