using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_CashReceipt
{
    public class Program
    {
        private enum Menu { Stop, Continue };

        private static void Start()
        {
            // инициализируем хранилище продуктов
            PrototypeProduct.InitPrototype();

            // создаём магазин и передаём в него пустой чек
            Supermarket supermarket = new Supermarket("Silpo");

            int userMenu;

            // запуск главного меню
            while (true)
            {
                // выбор меню, вызываем ф-цию из класса Input
                userMenu = Input.InputUserData("1 - Continue shopping; 0 - Stop:", (int)Menu.Stop, (int)Menu.Continue);

                // если начинаем покупки
                if (userMenu == (int)Menu.Continue)
                {
                    supermarket.ShowMenu();
                    supermarket.ChoiceProducts();  // выбираем продукты
                }

                // если выходи из программы
                else if (userMenu == (int)Menu.Stop)
                {
                    Console.WriteLine("Bye!!!");
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Supermarket";

            Start();
        }
    }
}
