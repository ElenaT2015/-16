using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace Задание_16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Admin/source/repos/Задание 16";
            Directory.SetCurrentDirectory(path);
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxProduct = new Product ();
            foreach (Product e in products)
            {
                if (e.Tsena > maxProduct.Tsena)
                {
                    maxProduct = e;
                }
            }
            Console.WriteLine($"{maxProduct.Cod}, {maxProduct.Nazvaniye},{maxProduct.Tsena}");
            Console.ReadKey();
        }
 
    }
}
