using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Задание_16
{
    class Program
    {
        public static JavaScriptEncoder Encoder { get; private set; }
        public static bool WtiteIndented { get; private set; }

        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];

            for (int i = 0; i < n; i++)
            {
              Console.WriteLine("Введите код товара");
              int cod = Convert.ToInt32(Console.ReadLine());
              Console.WriteLine("Введите название товара");
              string nazvaniye = Console.ReadLine();
              Console.WriteLine("Введите цену товара");
              int tsena = Convert.ToInt32(Console.ReadLine());
            
              products[i] = new Product() { Cod = cod, Nazvaniye = nazvaniye, Tsena =  tsena };

            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw = new StreamWriter("../../../Products.json",false))
            {
                sw.WriteLine(jsonString);
            }
            Console.WriteLine(jsonString);
            Console.ReadKey();
        }
    }
}
