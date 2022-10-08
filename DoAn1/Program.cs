using System;
using System.Threading.Tasks;

namespace DoAn1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var doThi = new DoThi();
            await doThi.DocFileAsync("../../../input.txt");
            Console.WriteLine(doThi.soDinh);
            foreach(var item in doThi.data)
            {
                foreach(var value in item)
                {
                    Console.Write("{0} ", value);
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
