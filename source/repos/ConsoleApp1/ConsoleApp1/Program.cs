using System.Text;
using System.Text.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\User\Desktop\try5.json";
            var data = "Let me teach you foreva";

            var rr = JsonSerializer.Serialize(data);
            File.WriteAllText(path, rr);



            var read = File.ReadAllText(path);
            var res = JsonSerializer.Deserialize<string>(read);
            Console.WriteLine(res);
            //var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            //var buffer = Encoding.UTF8.GetBytes(data);
            //stream.Write(buffer,0,data.Length);
            //stream.Dispose();

            //var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            //byte[] bytes = new byte[data.Length];
            //stream.Read(bytes,0,bytes.Length);
            //var str = Encoding.UTF8.GetString(bytes);
            //Console.WriteLine(str);
        }
    }
}
