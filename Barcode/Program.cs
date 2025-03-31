using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;

class BarcodeApp
{
    static string barcodePath = "barcode.png";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1 - Barkod Oluştur");
            Console.WriteLine("2 - Barkod Oku");
            Console.WriteLine("3 - Çıkış");
            Console.Write("Seçiminiz: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GenerateBarcode();
                    break;
                case "2":
                    ReadBarcode();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                    break;
            }
        }
    }

    static void GenerateBarcode()
    {
        Console.Write("Barkod için metin girin: ");
        string input = Console.ReadLine();

        var barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.CODE_128,
            Options = new ZXing.Common.EncodingOptions
            {
                Width = 300,
                Height = 100
            }
        };

        using (Bitmap bitmap = barcodeWriter.Write(input))
        {
            bitmap.Save(barcodePath, ImageFormat.Png);
        }

        Console.WriteLine($"Barkod oluşturuldu ve '{barcodePath}' olarak kaydedildi.");
    }

    static void ReadBarcode()
    {
        if (!File.Exists(barcodePath))
        {
            Console.WriteLine("Barkod dosyası bulunamadı!");
            return;
        }

        var barcodeReader = new BarcodeReader();
        using (Bitmap bitmap = new Bitmap(barcodePath))
        {
            var result = barcodeReader.Decode(bitmap);
            if (result != null)
            {
                Console.WriteLine($"Barkod İçeriği: {result.Text}");
            }
            else
            {
                Console.WriteLine("Barkod okunamadı!");
            }
        }
    }
}
