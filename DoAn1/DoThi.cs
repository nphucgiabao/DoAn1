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
        public List<List<int>> data { get; set; }
        public async Task DocFileAsync(string duongDan)
        {
            if (File.Exists(duongDan))
            {
                using (var stream = new StreamReader(duongDan))
                {
                    var content = await stream.ReadToEndAsync();
                    var lines = content.Split("\n");
                    soDinh = int.Parse(lines[0]);
                  
                    data = new List<List<int>>();
                    for (var i = 0; i < soDinh; ++i)
                    {
                        var values = lines[i + 1].Split(" ");
                        if (values != null)
                        {
                            var list = new List<int>();
                            for (var j = 0; j < values.Length; ++j)
                            {
                                list.Add(int.Parse(values[j]));
                            }
                            data.Add(list);
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
            var listDinhKe = this.data[dinh];
            for (var i = 1; i < this.data[dinh].Count; i++)
                result.Add(listDinhKe[i]);
            return result;
        }

        public void BFS(int dinh, out bool[] visited)
        {
            visited = new bool[this.soDinh];
            var queue = new Queue<int>();
            queue.Enqueue(dinh);
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                var listDinhKe = this.TimDinhKe(vertex);
                if (listDinhKe.Count > 0)
                {
                    foreach(var item in listDinhKe)
                    {
                        if (!visited[item])
                        {
                            visited[item] = true;
                            queue.Enqueue(item);
                        }
                    }
                }
            }
        }
    }
}
