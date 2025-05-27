using MVC.Models;
namespace MVC.Data;

public class SocksDataset

{
    static string[] brands = ["icebreaker", "adidas", "reebok", "nike", "dedoles", "fusakle"];
    static List<Socks> data = null;
    public static IEnumerable<Socks> GetSocks()
    {
        if (data == null)
        {
            Console.WriteLine("Creating new dataset");

            data = Enumerable.Range(1, 10).Select(index =>
                             new Socks()
                             {
                                 Id = index,
                                 Brand = brands[Random.Shared.Next(brands.Length)],
                                 Size = (SockSize)Random.Shared.Next(6),
                                 Price = Random.Shared.Next(50, 500),
                                 OnStock = Random.Shared.Next(0, 20)

                             }).ToList();
        }

        return data;
    }
}

