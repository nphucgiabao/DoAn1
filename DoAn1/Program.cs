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
                var node = item.First;
                while(node != null)
                {
                    Console.Write("{0} ", node.Value);
                    node = node.Next;
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
