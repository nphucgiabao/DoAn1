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
        public List<LinkedList<int>> data { get; set; }
        public async Task DocFileAsync(string duongDan)
        {
            if (File.Exists(duongDan))
            {
                using (var stream = new StreamReader(duongDan))
                {
                    var content = await stream.ReadToEndAsync();
                    var lines = content.Split("\n");
                    soDinh = int.Parse(lines[0]);
                  
                    data = new List<LinkedList<int>>();
                    for (var i = 0; i < soDinh; ++i)
                    {
                        var values = lines[i + 1].Split(" ");
                        if (values != null)
                        {
                            var list = new LinkedList<int>();
                            for (var j = 0; j < values.Length; ++j)
                            {
                                list.AddLast(int.Parse(values[j]));
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
    }
}
