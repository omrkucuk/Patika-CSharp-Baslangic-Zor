using System;
using System.Collections.Generic;
using System.IO;

class ATM
{
    static string usersFile = "users.txt";
    static string logFile = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
    static Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();
    static List<string> transactions = new List<string>();
    static List<string> fraudAttempts = new List<string>();

    static void Main()
    {
        LoadAccounts(); // Kullanıcıları yükle
        Console.WriteLine("ATM Sistemine Hoş Geldiniz!");

        string username;
        while (true)
        {
            Console.Write("Kullanıcı adınızı girin: ");
            username = Console.ReadLine();

            if (accounts.ContainsKey(username))
            {
                Console.WriteLine("Giriş başarılı!");
                break;
            }
            else
            {
                Console.WriteLine("Hatalı giriş! Tekrar deneyin.");
                fraudAttempts.Add($"Hatalı giriş: {username} - {DateTime.Now}");
            }
        }

        while (true)
        {
            Console.WriteLine("\nYapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1 - Para Yatırma");
            Console.WriteLine("2 - Para Çekme");
            Console.WriteLine("3 - Ödeme Yapma");
            Console.WriteLine("4 - Gün Sonu Al");
            Console.WriteLine("5 - Çıkış");

            Console.Write("Seçiminiz: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Deposit(username);
                    break;
                case "2":
                    Withdraw(username);
                    break;
                case "3":
                    MakePayment(username);
                    break;
                case "4":
                    EndOfDayReport();
                    return;
                case "5":
                    Console.WriteLine("ATM'den çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                    break;
            }
        }
    }

    static void LoadAccounts()
    {
        if (File.Exists(usersFile))
        {
            string[] lines = File.ReadAllLines(usersFile);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && decimal.TryParse(parts[1], out decimal balance))
                {
                    accounts[parts[0]] = balance;
                }
            }
        }
        else
        {
            accounts["test_user"] = 1000m; // Örnek kullanıcı
            File.WriteAllText(usersFile, "test_user,1000");
        }
    }

    static void SaveAccounts()
    {
        List<string> lines = new List<string>();
        foreach (var account in accounts)
        {
            lines.Add($"{account.Key},{account.Value}");
        }
        File.WriteAllLines(usersFile, lines);
    }

    static void Deposit(string username)
    {
        Console.Write("Yatırmak istediğiniz tutarı girin: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
        {
            accounts[username] += amount;
            transactions.Add($"{username} {amount} TL yatırdı - {DateTime.Now}");
            Console.WriteLine($"Yeni bakiyeniz: {accounts[username]} TL");
            SaveAccounts();
        }
        else
        {
            Console.WriteLine("Geçersiz tutar!");
        }
    }

    static void Withdraw(string username)
    {
        Console.Write("Çekmek istediğiniz tutarı girin: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0 && amount <= accounts[username])
        {
            accounts[username] -= amount;
            transactions.Add($"{username} {amount} TL çekti - {DateTime.Now}");
            Console.WriteLine($"Yeni bakiyeniz: {accounts[username]} TL");
            SaveAccounts();
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye veya geçersiz tutar!");
        }
    }

    static void MakePayment(string username)
    {
        Console.Write("Ödeme yapmak istediğiniz tutarı girin: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0 && amount <= accounts[username])
        {
            accounts[username] -= amount;
            transactions.Add($"{username} {amount} TL ödeme yaptı - {DateTime.Now}");
            Console.WriteLine($"Yeni bakiyeniz: {accounts[username]} TL");
            SaveAccounts();
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye veya geçersiz tutar!");
        }
    }

    static void EndOfDayReport()
    {
        Console.WriteLine("\nGün Sonu Raporu:");
        Console.WriteLine("Yapılan İşlemler:");
        foreach (string transaction in transactions)
        {
            Console.WriteLine(transaction);
        }

        Console.WriteLine("\nHatalı Giriş Denemeleri:");
        foreach (string fraud in fraudAttempts)
        {
            Console.WriteLine(fraud);
        }

        File.WriteAllLines(logFile, transactions);
        File.AppendAllLines(logFile, fraudAttempts);
        Console.WriteLine($"\nGün sonu raporu '{logFile}' dosyasına kaydedildi.");
    }
}
