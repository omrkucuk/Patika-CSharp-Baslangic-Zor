# ATM Uygulaması

## Açıklama
Bu proje, temel ATM işlemlerini gerçekleştiren bir C# console uygulamasıdır. Kullanıcılar giriş yaparak para çekme, para yatırma, ödeme yapma gibi işlemleri gerçekleştirebilir. Ayrıca, gün sonunda yapılan işlemler ve hatalı girişler bir log dosyasına kaydedilir.

## Özellikler
- Kullanıcı giriş kontrolü
- Para yatırma
- Para çekme
- Ödeme yapma
- Gün sonu raporu oluşturma
- Logların belirlenen bir lokasyona kaydedilmesi

## Kullanılan Teknikler
- Dosyaya Yazma
- Dosyadan Okuma
- Ön tanımlı işlem listesi

## Nasıl Kullanılır?
1. Projeyi çalıştırın.
2. Kullanıcı adınızı girin.
3. Açılan menüden yapmak istediğiniz işlemi seçin.
4. Gün sonu raporunu almak için "4" tuşuna basın.

---

# Voting Uygulaması

## Açıklama
Bu proje, belirlenen kategoriler arasında kullanıcıların oy verebileceği bir C# console uygulamasıdır. Sadece sisteme kayıtlı kullanıcılar oy verebilir. Yeni kullanıcılar kayıt olup oylamaya devam edebilir. Sonuçlar yüzdesel olarak gösterilir.

## Özellikler
- Kullanıcı kayıt ve giriş sistemi
- Belirlenen kategorilere oy verme
- Oylama sonuçlarını hem rakamsal hem de yüzdesel gösterme

## Kullanılan Teknikler
- Önceden tanımlı kategoriler
- Kullanıcı yönetimi
- Dosyaya yazma ve okuma

## Nasıl Kullanılır?
1. Projeyi çalıştırın.
2. Kullanıcı adı girin (yoksa kayıt olun).
3. Oylamak istediğiniz kategoriyi seçin.
4. Oylama tamamlandıktan sonra sonuçları görüntüleyin.

---

# Barcode Generator & Reader

## Açıklama
Bu proje, kullanıcı tarafından girilen metni barkod olarak oluşturan ve oluşturulan barkodu okuyabilen bir C# console uygulamasıdır. ZXing.Net kütüphanesi kullanılarak geliştirilmiştir.

## Özellikler
- Kullanıcı girdisine dayalı barkod oluşturma
- Oluşturulan barkodu belirli bir lokasyona kaydetme
- Kayıtlı barkodu okuma ve içeriğini ekrana yazdırma

## Kullanılan Teknikler
- Console Application
- ZXing.Net kütüphanesi
- Dosyaya Yazma
- Dosyadan Okuma

## Nasıl Kullanılır?
1. ZXing.Net paketini yükleyin:
   ```sh
   dotnet add package ZXing.Net
   ```
2. Projeyi çalıştırın.
3. Barkod oluşturmak için "1" seçeneğini seçin ve bir metin girin.
4. Barkod okumak için "2" seçeneğini seçin.
