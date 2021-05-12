using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace MMTConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("\n Welcome to MMTShop\n\n"); 
            Console.WriteLine("1. Featured Products");
            Console.WriteLine("2. Show Available Categories");
            Console.WriteLine("3. Show Products By Category");
            Console.WriteLine("4. Exit\n\n");
            Console.WriteLine("Enter Your choice from above: ");
            int n = Convert.ToInt32(Console.ReadLine());

            using (var MMTShop = new HttpClient())
            {
                MMTShop.BaseAddress = new Uri("http://localhost:44388/api/");
                switch (n)
                {
                    case 1:
                       var FProducts = MMTShop.GetAsync("featuredproducts");
                      //  FProducts.Wait();
                        var r = FProducts.Result;
                        if (r.IsSuccessStatusCode)
                        {
                            var RProducts = r.Content.ReadAsByteArrayAsync();
                            RProducts.Wait();
                            var PR = RProducts.Result;
                            foreach (var p in PR)
                                Console.WriteLine(p);
                         }
                        break;
                            
                    //case 2:
                    //   
                    //case 3:

                    //case 4:

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
             }
        }
    }
}
