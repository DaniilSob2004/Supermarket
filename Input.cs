using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_CashReceipt
{
    public struct Input
    {
        // для ввода данных (int), в параметрах текст что нужно вводить, минимальное и максимальное значение
        public static int InputUserData(string inputText, int from, int to)
        {
            string userValue;

            Console.WriteLine(inputText);
            while (true)
            {
                Console.Write("- ");
                userValue = Console.ReadLine();

                try
                {
                    if (int.Parse(userValue) >= from && int.Parse(userValue) <= to)
                    {
                        return int.Parse(userValue);
                    }
                    Console.WriteLine($"Error, need input from {from} to {to}");
                }
                catch (FormatException)  // исключение если был введён неверный формат
                {
                    Console.WriteLine($"Error, need input from {from} to {to}");
                }
            }
        }
    }
}
