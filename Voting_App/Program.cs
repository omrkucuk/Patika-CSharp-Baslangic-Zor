using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Kullanıcı sınıfı
    public class User
    {
        public string Username { get; set; }
    }

    // Oylama kategorileri
    public class Category
    {
        public string Name { get; set; }
        public int Votes { get; set; }
    }

    static void Main(string[] args)
    {
        // Kategoriler (pre-defined)
        List<Category> categories = new List<Category>
        {
            new Category { Name = "Film Kategorileri", Votes = 0 },
            new Category { Name = "Tech Stack Kategorileri", Votes = 0 },
            new Category { Name = "Spor Kategorileri", Votes = 0 }
        };

        // Kayıtlı kullanıcılar
        List<User> users = new List<User>();

        // Kullanıcı girişi yapma
        Console.Write("Kullanıcı adınızı girin: ");
        string username = Console.ReadLine();

        // Kullanıcı sistemde kayıtlı mı kontrol et
        User currentUser = users.FirstOrDefault(u => u.Username == username);
        if (currentUser == null)
        {
            // Kullanıcı kayıtlı değilse, kayıt al
            Console.WriteLine("Kullanıcı kaydınız bulunamadı. Kaydınızı oluşturuyoruz...");
            currentUser = new User { Username = username };
            users.Add(currentUser);
        }

        // Oylama işlemi
        Console.WriteLine("Oylama Başlıyor!");
        Console.WriteLine("Aşağıdaki kategorilerden birini seçin:");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].Name}");
        }

        Console.Write("Seçiminizi yapın (1-3 arası bir sayı): ");
        int voteChoice = int.Parse(Console.ReadLine());

        // Seçilen kategoriye oy ver
        if (voteChoice >= 1 && voteChoice <= categories.Count)
        {
            categories[voteChoice - 1].Votes++;
            Console.WriteLine($"Oyunuz {categories[voteChoice - 1].Name} kategorisine kaydedildi.");
        }
        else
        {
            Console.WriteLine("Geçersiz seçim.");
        }

        // Oylama sonuçlarını göster
        Console.WriteLine("\nOylama Sonuçları:");
        int totalVotes = categories.Sum(c => c.Votes);
        foreach (var category in categories)
        {
            double percentage = totalVotes > 0 ? (double)category.Votes / totalVotes * 100 : 0;
            Console.WriteLine($"{category.Name}: {category.Votes} oy ({percentage:F2}%)");
        }
    }
}
