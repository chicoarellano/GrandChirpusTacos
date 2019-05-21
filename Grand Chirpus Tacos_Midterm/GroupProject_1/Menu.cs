using System;
using System.Collections.Generic;
using System.Text;

namespace GroupProject_1
{
    class Menu
    {

        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public string Price { get; set; }

        public Menu(string name, string category, string description, string price)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }

        public static void CreateMenu()
        {

            string line;
            var menuList = new List<Menu>();

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\jarellano\Desktop\productlist.txt");
            while ((line = file.ReadLine()) != null)
            {
                var words = line.Split(',');
                menuList.Add(new Menu(words[0], words[1], words[2], words[3]));
            }

            file.Close();

            foreach (var item in menuList)
            {
                Console.WriteLine($"{item.Name} {item.Category} {item.Description} {item.Price}");
            }

            Console.WriteLine($"{menuList[2].Description}");
            Console.ReadKey();

        }
    }
}
