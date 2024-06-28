using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace checkk
{
    
    internal class Program
    {
        class Book
        {
            public string Name { get; set; }
            public string Title { get; set; }
        }
        static void Main(string[] args)
        {
            var path = @"C:\Users\User\Desktop\try2.json";

            var data = "Dunya senin dunya menim, dunya heckimin";

            var j = JsonSerializer.Serialize(data);
            File.WriteAllText(path, j);

            var jsoon = File.ReadAllText(path);
            var ree = JsonSerializer.Deserialize<string>(jsoon);
            Console.WriteLine(ree);

            //var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            //var str = Encoding.UTF8.GetBytes(data);
            //stream.Write(str,0, str.Length);
            //stream.Dispose();

            //var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            //byte[] buffer = new byte[data.Length];
            //stream.Read(buffer,0,buffer.Length);
            //var result = Encoding.UTF8.GetString(buffer);
            //Console.WriteLine(result);
        }
    }
}
