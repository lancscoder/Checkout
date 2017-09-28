using ClientLibrary;
using System;

namespace ClientLibraryTestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // To run this make sure the Api project is running 
            // If the port is different than what is listed below change the base address.
            HttpContext.SetProxyBaseAddress("http://localhost:7031/");

            var shoppingBasket = new ShoppingBasket();

            Console.WriteLine("------------------------");
            Console.WriteLine("Create Basket");
            var basket = shoppingBasket.Create().Result;

            WriteBasket(basket);

            Console.WriteLine("------------------------");
            Console.WriteLine("Add item to basket");
            basket = shoppingBasket.AddItem(basket, "Foobar", 10).Result;

            WriteBasket(basket);

            Console.WriteLine("------------------------");
            Console.WriteLine("Add item to basket - item 2");
            basket = shoppingBasket.AddItem(basket, "Barfoo", 5).Result;

            WriteBasket(basket);

            Console.WriteLine("------------------------");
            Console.WriteLine("Update item 1");
            basket = shoppingBasket.UpdateItem(basket,basket.Items[0].Id, 7).Result;

            WriteBasket(basket);

            Console.WriteLine("------------------------");
            Console.WriteLine("Clear list");
            basket = shoppingBasket.Clear(basket).Result;

            WriteBasket(basket);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void WriteBasket(Basket basket)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Basket id: {0}: ", basket.Id);

            foreach (var item in basket.Items)
            {
                Console.WriteLine("Item id: {0}, description: {1}, quantity: {2}", item.Id, item.Description, item.Quantity);
            }

            Console.WriteLine("------------------------");
        }
    }
}
