using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_CashReceipt
{
    public struct Product
    {
        private string title;
        private float price;
        private uint amount;
        private float discount;

        public Product(string title, float price, uint amount, float discount)
        {
            if (title.Length <= 2) throw new Exception("Product title length must be >= 2!");
            this.title = title;

            if (price <= 0 || price > 1000) throw new Exception("Product price must be from 1 to 1000!");
            this.price = price;

            if (amount < 0 || amount > 100) throw new Exception("Product amount must be from 0 to 100!");
            this.amount = amount;

            if (discount < 0 || discount > 50) throw new Exception("Product discount must be from 0 to 50");
            this.discount = discount;
        }

        public string Title { get { return title; } }
        public float Price { get { return price; } }
        public uint Amount
        {
            get { return amount; }
            set
            {
                if (amount < 0 || amount > 100) throw new Exception("");
                amount = value;
            }
        }
        public float Discount { get { return discount; } }
    }
}
