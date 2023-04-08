using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static HW_CashReceipt.PrototypeProduct;


namespace HW_CashReceipt
{
    public struct Supermarket
    {
        public enum Menu { PrintReceipt = 0, Exit = 11 };
        private string title;
        private CashReceipt cashReceipt;

        private static void SettingsConsole()
        {
            // настраиваем консоль под вывод меню
            Console.Clear();
            Console.SetWindowSize(92, 27);
            Console.SetBufferSize(92, 27);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        private static void FinalMessage()
        {
            Console.WriteLine("\n\nThank you!\nPlease, input click to continue...");
            Console.ReadKey();
        }


        public Supermarket(string title)
        {
            this.title = title;
            cashReceipt = new CashReceipt(null);
        }

        public void ShowMenu()
        {
            SettingsConsole();

            Console.WriteLine("\t------ Menu ------");
            Console.WriteLine($"{(int)Menu.PrintReceipt} - {Menu.PrintReceipt}; ");
            for (int i = 0; i < PrototypeProduct.AMOUNT_PROTOTYPES; i++)
            {
                if (i == PrototypeProduct.AMOUNT_PROTOTYPES / 2) Console.WriteLine();
                Console.Write($"{i + 1} - {Enum.GetNames(typeof(PrototypeProduct.TitleProducts))[i]}; ");
            }
            Console.WriteLine($"\n{(int)Menu.Exit} - {Menu.Exit};");
        }

        public void ChoiceProducts()
        {
            // ввод кол-ва товара
            int userChoice;
            Product choiceProduct;

            while (true)
            {
                // выбор продукта, вызываем ф-цию из класса Input
                userChoice = Input.InputUserData("Please, choice product:", 0, PrototypeProduct.AMOUNT_PROTOTYPES + 1);

                if (userChoice == (int)Menu.Exit)
                {
                    Console.WriteLine("You are stoping buy products!");
                    break;
                }

                else if (userChoice == (int)Menu.PrintReceipt)
                {
                    cashReceipt.Print(title);  // печатаем чек
                    FinalMessage();  // вывод сообщения
                    break;
                }

                else
                {
                    // получаем объект продукт, по типу TitleProducts
                    choiceProduct = PrototypeProduct.GetByTitle((TitleProducts)(userChoice));

                    // ввод кол-ва продукта (вызываем ф-цию из класса Input) и устанавливаем это значение в поле объекта продукта
                    choiceProduct.Amount = (uint)Input.InputUserData("Please, input amount:", 1, 50);

                    // добавляем продукт в список
                    cashReceipt.Products.Add(choiceProduct);
                    Console.WriteLine($"{choiceProduct.Title} - added!");
                }
            }

            cashReceipt.Reset();  // сброс чека и продуктов
            SettingsConsole();  // настраиваем консоль под вывод меню
        }
    }
}
