# CarParkControl
SSTEk Academy bünyesinde yapmış olduğum OTOPARK KONTROL APİ.

Bu projede Client tarafından gelen istekler neticesinde kullanıcı ;

Otoparka Arac Sınıfına göre ekleme yapabilir(1-2-3 . sınıflar olmak üzre )
Araç ekleme sırasında PlateNumber üzerinden aracın otopark içinde varlığı ve varsa aktifliği kontrol edilip , sonuca göre kayıt yapılıyor yada hata mesajı fırlatıyor.

Otoparktaki bütün aracları listelenebilir 
bu endpoint ile , otoparka daha önce giriş yapan bütün araçlar getirilir 

Otoparkta sadece aktif olan araçlar getirilebilir 
Logeedout propertisini flag olarak kullanarak cıkış yapmış araçları eleyerek getiriyor.

Girilen plakaya göre aracın beygir gücünü hesaplayabilir

Çıkış yapabilir ve çıkış yaparken giriş tarihi ve çıkış tarihi arasındaki saat farkından hesaplanarak ücret karşılığı çıkar 

Araç yıkama ve Lastik Değişimi hizmetlerinin kontrolü
bu endpoint ile, girilen plaka değerine göre aracın hangi hizmetten yararlanabileceği yönlendirilir . Utility propertisini flag olarak kullanarak arac daha önce bu özellikten yararlandıysa hata mesajı fırlatır.



