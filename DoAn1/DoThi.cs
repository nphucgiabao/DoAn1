using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1
{
    public class DoThi
    {
        public int soDinh { get; set; }
        public int[,] data { get; set; }
        public bool[] visited { get; set; }
        public Stack<int> stack { get; set; }
        public async Task DocFileAsync(string duongDan)
        {
            if (File.Exists(duongDan))
            {
                using (var stream = new StreamReader(duongDan))
                {
                    var content = await stream.ReadToEndAsync();
                    var lines = content.Split("\n");
                    soDinh = int.Parse(lines[0]);
                    visited = new bool[soDinh];
                    stack = new Stack<int>();
                    data = new int[soDinh, soDinh];
                    for (var i = 0; i < soDinh; ++i)
                    {
                        for (var j = 0; j < soDinh; j++)
                        {
                            data[i, j] = 0;
                            var values = lines[i + 1].Split(" ");
                            if (values != null)
                            {
                                for (var x = 1; x < values.Length; x++)
                                {
                                    if (j == int.Parse(values[x]))
                                        data[i, j] = 1;
                                }
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("File not found!!!");
            }
        }

        public List<int> TimDinhKe(int dinh)
        {
            var result = new List<int>();
            for (var i = 0; i < soDinh; i++)
            {
                if (data[dinh, i] > 0)
                    result.Add(i);
            }
            return result;
        }

        public void DFS(int dinh)
        {
            visited[dinh] = true;
            var listDinhKe = this.TimDinhKe(dinh);
            listDinhKe.ForEach(x => {
                if (!visited[x])
                {
                    DFS(x);
                }
            });
            stack.Push(dinh);
        }

        public void DFS2(int dinh)
        {
            visited[dinh] = true;
            var listDinhKe = this.TimDinhKe(dinh);
            listDinhKe.ForEach(x => {
                if (!visited[x])
                    DFS2(x);
            });
            Console.Write("{0} ", dinh);
        }

        public DoThi RevertGraph()
        {
            var result = new DoThi();
            var revertdata = new int[soDinh, soDinh];
            for (var i = 0; i < soDinh; i++)
            {
                for (var j = 0; j < soDinh; j++)
                {
                    if (data[i, j] > 0)
                        revertdata[j, i] = 1;
                }
            }
            result.soDinh = this.soDinh;
            result.data = revertdata;
            result.visited = new bool[this.soDinh];
            return result;
        }
    }
}
