using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoAn1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var doThi = new DoThi();
            await doThi.DocFileAsync("../../../input.txt");
            
            for (var i = 0; i < doThi.soDinh; i++)
            {
                bool[] visited;
                doThi.BFS(i, out visited);
                foreach(var item in visited)
                {
                    if (!item)
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }

            }
            Console.WriteLine("true");

            Console.ReadKey();
        }

        
    }
}
