
using static System.Reflection.Metadata.BlobBuilder;

namespace linq_home;
internal class Program
{
    private static void Main(string[] args)
    {
        List<Product> store = new List<Product>
        {
            new Product{name = "banana", price = 30,producing_year = 2025, production_count = 3, Category = Product.CategoryType.food, country_producer = "Ukraine"},
            new Product{name = "Orange", price = 45,producing_year = 2025, production_count = 20, Category = Product.CategoryType.food, country_producer = "United states of America"},
            new Product{name = "chair", price = 100,producing_year = 2024, production_count = 25, Category = Product.CategoryType.furniture, country_producer = "France"},
            new Product{name = "coca-cola", price = 30,producing_year = 2025, production_count = 4, Category = Product.CategoryType.water, country_producer = "United states of America"},
            new Product{name = "koko-choko", price = 10,producing_year = 2025, production_count = 250, Category = Product.CategoryType.sweets, country_producer = "Ukraine"}
        };
        //1
        DateTime checker = DateTime.Now;
        var res = from b in store
                  where b.producing_year == checker.Year
                  orderby -b.price
                  select b;
        Print(res, "Print Products: ");
        //
        //2
        Console.WriteLine("Name country: ");
        string country = Console.ReadLine();
        var res_2 = from b in store
                    where b.country_producer == country
                    select b;
        count(res_2, "count: ");
        //
        //3
        Console.WriteLine("Name Category: ");
        string category = Console.ReadLine();
        //max
        var max = store.Where(b => b.Category.ToString() == category).Max(x => x.price);
        var res_3 = store.Where(b => b.Category.ToString() == category).Where(b => b.price == max);
        Print(res_3, "max product: ");
        //min
        var min = store.Where(b => b.Category.ToString() == category).Min(x => x.price);
        var res_4 = store.Where(b => b.Category.ToString() == category).Where(b => b.price == min);
        Print(res_4, "min product: ");
        //4
        var ukrainianCategories = store.Where(p => p.country_producer == "Ukraine").Select(p => p.Category).Distinct();

        var res_5 = store.Where(b => !ukrainianCategories.Contains(b.Category)).OrderBy(b => b.Category);
        Print(res_5, "Category of products which not producing in Ukraine: ");
        //
        //5
        var categoryCounts = store.GroupBy(p => p.Category).Select(g => new { Category = g.Key, Count = g.Count() });
        Print(categoryCounts, "Count of products in each category: ");
        //
        // 6
        var groupedProducts = store.GroupBy(p => p.Category).Select(g => new
    {
        Category = g.Key,
        Products = g.OrderBy(p => p.producing_year)
    });


        foreach (var group in groupedProducts)
        {
            Print(group.Products, $"Category: {group.Category}");
        }


    }
    static void Print<T>(IEnumerable<T> query, string text = "")
    {
        Console.WriteLine($"{(text?.Length == 0 ? "" : "\n\t")} {text}");
        foreach (var item in query)
        {
            Console.WriteLine($"{item,-7}");
        }
        Console.WriteLine();
    }
    static void count<T>(IEnumerable<T> query, string text = "")
    {
        int counter = 0;
        Print(query, text);
        foreach (var item in query)
        {
            counter++;
        }
        Console.WriteLine("Items from country: " + counter);
    }

}