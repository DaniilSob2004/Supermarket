using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_CashReceipt
{
    public struct CashReceipt
    {
        private List<Product> products;

        public CashReceipt(List<Product> products = null)
        {
            this.products = new List<Product>();
        }

        public List<Product> Products
        {
            get { return products; }
        }

        public void Print(string titleMarket)
        {
            SettingsConsole();

            float total = 0;
            float price = 0;

            Console.WriteLine("\t\tReceipt");
            Console.WriteLine($"\t\t{titleMarket}\n");  // вывод названия магазина
            Console.WriteLine($"\t\t{DateTime.Now}\n");  // вывод даты

            foreach (var p in products)
            {
                // узнаём общую сумму продукта (с учётом скидки и кол-ва)
                price = (p.Price * (1 - (p.Discount / 100))) * p.Amount;

                Console.WriteLine($"    {p.Amount}x{p.Title}  {p.Price}uah  {p.Discount}%  {price}");
                total += price;
            }

            Console.WriteLine("\t\t    ---------");
            Console.WriteLine($"\tTotal:  uah  {total}");
        }

        public void Reset()
        {
            // сброс продуктов, очищаем список
            products = new List<Product>();
        }

        public static void SettingsConsole()
        {
            // настраиваем консоль под печать чека
            Console.SetWindowSize(37, 20);
            Console.SetBufferSize(37, 20);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
}
