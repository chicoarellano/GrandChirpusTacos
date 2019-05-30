using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject_1
{
    class Menu
    {
        public string ItemNumber { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public Menu(string itemNumber, string name, string category, string description, string price)
        {
            ItemNumber = itemNumber;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }

        public static void CreateMenu()
        {
            Console.WriteLine("Please select an item off the menu...");
            Console.WriteLine();

            string line;
            var menuList = new List<Menu>();

            System.IO.StreamReader file =
                new System.IO.StreamReader("productlist.txt");
            while ((line = file.ReadLine()) != null)
            {
                var words = line.Split(',');
                menuList.Add(new Menu(words[0], words[1], words[2], words[3], words[4]));
            }

            file.Close();

            Console.WriteLine("Tacos:");
            foreach (var item in menuList)
            {
                if (item.Category == "taco")
                    Console.WriteLine($"{item.ItemNumber}: {item.Name} ({item.Description}) - ${item.Price}");
            }
            Console.WriteLine();

            Console.WriteLine("Sides:");
            foreach (var item in menuList)
            {
                if (item.Category == "side")
                    Console.WriteLine($"{item.ItemNumber}: {item.Name} ({item.Description}) - ${item.Price}");
            }
            Console.WriteLine();

            Console.WriteLine("Drinks:");
            foreach (var item in menuList)
            {
                if (item.Category == "drink")
                    Console.WriteLine($"{item.ItemNumber}: {item.Name} ({item.Description}) - ${item.Price}");
            }
            Console.WriteLine();

            Console.WriteLine("Desserts:");
            foreach (var item in menuList)
            {
                if (item.Category == "dessert")
                    Console.WriteLine($"{item.ItemNumber}: {item.Name} ({item.Description}) - ${item.Price}");
            }
            Console.WriteLine();
        }
    }
}
