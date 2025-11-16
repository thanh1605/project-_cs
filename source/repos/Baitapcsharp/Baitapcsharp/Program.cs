using System;
using System.Collections.Generic;
using System.Linq;

namespace Baitapcsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PHO> list = new List<PHO>();

            // Input data for 10 Pho bowls
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    PHO pho = new PHO();
                    Console.WriteLine($"Nhap du lieu cho bat pho thu {i + 1}:");
                    pho.Nhap();
                    list.Add(pho);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Loi chuyen doi kieu du lieu: {e.Message}");
                    i--; // Prompt user to re-enter data for the current pho bowl
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Loi khi tao doi tuong Pho: {e.Message}");
                }
            }

            // Display the Pho list in a tabular format
            DisplayPhoList(list);

            // Find the Pho bowl with the highest and lowest price
            try
            {
                var maxPricePho = list.OrderByDescending(p => p.TinhTien()).First();
                var minPricePho = list.OrderBy(p => p.TinhTien()).First();

                int maxIndex = list.IndexOf(maxPricePho) + 1;
                int minIndex = list.IndexOf(minPricePho) + 1;

                Console.WriteLine($"\nBat pho thu {minIndex} co gia thap nhat la {minPricePho.TinhTien()}");
                Console.WriteLine($"Bat pho thu {maxIndex} co gia cao nhat la {maxPricePho.TinhTien()}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Loi khi tim doi tuong Pho max/min: {e.Message}");
            }
        }

        static void DisplayPhoList(List<PHO> phoList)
        {
            Console.WriteLine($"{"STT",-5} {"Thit",-10} {"Banh pho",-10} {"Hanh",-10} {"Thanh tien",-10}");
            Console.WriteLine(new string('=', 45));
            for (int i = 0; i < phoList.Count; i++)
            {
                try
                {
                    var pho = phoList[i];
                    double price = pho.TinhTien();
                    Console.WriteLine($"{i + 1,-5} {pho.Thit,-10:F2} {pho.Banh,-10:F2} {pho.Hanh,-10:F2} {price,-10:F2}");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"Loi truy cap doi tuong Pho: {e.Message}");
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine($"Doi tuong Pho chua duoc cap phat: {e.Message}");
                }
            }
        }
    }

    public class PHO
    {
        public double Thit { get; set; }
        public double Banh { get; set; }
        public double Hanh { get; set; }

        public PHO()
        {
            Thit = 0.0;
            Banh = 0.0;
            Hanh = 0.0;
        }

        public PHO(double thit, double banh, double hanh)
        {
            Thit = thit;
            Banh = banh;
            Hanh = hanh;
        }

        public void Nhap()
        {
            Console.Write("Luong thit = ");
            Thit = double.Parse(Console.ReadLine());

            Console.Write("Luong banh pho = ");
            Banh = double.Parse(Console.ReadLine());

            Console.Write("Luong hanh = ");
            Hanh = double.Parse(Console.ReadLine());
        }

        public double TinhTien()
        {
            return (Thit * 15000) + (Banh * 10000) + (Hanh * 2000);
        }
    }
}
