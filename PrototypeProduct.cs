using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_CashReceipt
{
    // Хранилище продуктов
    public struct PrototypeProduct
    {
        public enum TitleProducts { Bread = 1, Milk, Cheesse, Juices, Potato, Pasta, CocaCola, Noun, Cucumber, Apple };
        public const int AMOUNT_PROTOTYPES = 10;
        private static Product[] items = new Product[AMOUNT_PROTOTYPES];

        public static void InitPrototype()
        {
            // инициализируем продукты

            Random r = new Random();

            for (int i = 0; i < AMOUNT_PROTOTYPES; i++)
            {
                items[i] = new Product(Enum.GetNames(typeof(TitleProducts))[i], r.Next(10, 100), 1, r.Next(1, 10));
            }
        }

        public static Product GetByTitle(TitleProducts title)
        {
            // поиск продукта по названию, возвращается копия объекта
            foreach (var item in items)
            {
                if (item.Title == title.ToString())
                {
                    return item;
                }
            }
            throw new Exception("No such product of that name!");
        }
    }
}
