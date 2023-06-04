using System;
using BLL;

namespace PL
{
    public static class FilePerformer
    {
        private static BillboardLogic blLgc = new BillboardLogic();

        public static void CreateAd()
        {
            Console.Write("Write your name: ");
            string name = Console.ReadLine();

            Console.Write("Write a category: ");
            string categ = Console.ReadLine();

            Console.Write("Write tags: ");
            string tags = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine(blLgc.CreateAd(name, categ, tags));
            Console.ReadLine();
        }

        public static void DeleteAd()
        {
            Console.Write("Write your name: ");
            string name = Console.ReadLine();

            Console.Write("Write ID of the product: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine(blLgc.DeleteAd(id, name));
            Console.ReadLine();
        }

        public static void DeactivateAd()
        {
            Console.Write("Write your name: ");
            string name = Console.ReadLine();

            Console.Write("Write ID of the product: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            try
            {
                Console.WriteLine(blLgc.Deactivate(id, name));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public static void ActivateAd()
        {
            Console.Write("Write your name: ");
            string name = Console.ReadLine();

            Console.Write("Write ID of the product: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            try
            {
                Console.WriteLine(blLgc.Activate(id, name));
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
            Console.ReadLine();
        }

        public static void ShowAllAds()
        {
            string[] arr = blLgc.AllAds();
            
            foreach (string s in arr) Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
