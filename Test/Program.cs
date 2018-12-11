using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before call async");
            var t=CallTestAsync("LinTao");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine(i);
            }
            Console.WriteLine($"异步方法执行的结果是{t.Result}");

            //根据t的结果来决定下一步怎么做
            t.ContinueWith(tt=>Console.WriteLine($"Continue{tt.Result}"),CancellationToken.None);
            Console.ReadKey();
        }
    
        //拥有await的方法会被阻塞，但是调用该方法的会立即返回
        private static async Task<string> CallTestAsync(string Name)
        {
            Console.WriteLine("Before Call Sleep");
            var ret= await Task.Run(()=>Sleep(Name));
            Console.WriteLine("After Call Sleep");
            Console.WriteLine($"结果是{ret}");
            return ret;
        }


        //耗时的方法
        private static string Sleep(string Name)
        {
            Console.WriteLine($"Before {Name} Sleep");
            Thread.Sleep(7000);
            Console.WriteLine($"After {Name} Sleep");
            return $"{Name}'s Final name is {Name}+{Name}+{Name}";  
        }

    
    }
}
