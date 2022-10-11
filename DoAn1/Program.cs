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

            Cau2(doThi);

            Console.ReadKey();
        }

        static void Cau2(DoThi doThi)
        {
            for (var i = 0; i < doThi.soDinh; i++)
            {
                if (!doThi.visited[i])
                    doThi.DFS(i);
            }
            var revert = doThi.RevertGraph();
            var step = 1;
            while (doThi.stack.Count > 0)
            {
                var v = doThi.stack.Pop();

                if (!revert.visited[v])
                {
                    Console.Write("Thanh phan lien thong manh {0}: ", step++);
                    revert.DFS2(v);
                    Console.WriteLine("");
                }
            }
        }
    }
}
