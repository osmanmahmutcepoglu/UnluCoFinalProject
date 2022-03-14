# UnluCoFinalProject

Appsetting.Json dosyasından Veritabanı bağlatı stringlerini ayarlıyoruz. 

    + Package Manager Console, *UnluCoFinalProject.Persistence* Başlangıç projesi olarak seçiyoruz ve sırayla aşağıdaki komutları uyguluyoruz.
    + Run these commands:
      ```sh
      PM> add-migration Initial-commit-Application -Context ApplicationDbContext -o Migrations/Application
      PM> add-migration Identity-commit -Context IdentityContext -o Migrations/Identity

      PM> update-database -Context ApplicationDbContext 
      PM> update-database -Context IdentityContext 
      ```
Migration işlemleri tamamlandığında 

Parsistence projesinde Bulunan Seeds klasörü içerindeki classlar ile; 
Default Renkleri
Default IsSold türlerini
Default Rolleri
Default kullanıcıları
Default Markaları
olarak eklemiş oluyoruz.

Kategori işlemleri için end pointler oluşturuldu.
Ekle,Sil,Güncelle

Mail işlemleri işim MailKit kullanıldı.
Async Mail işlemi için Hangfire kullanıldı.
Mail' testi için end point oluşturuldu.

Yeni kayıt olma işleminde kullanıca mail gönderiliyor.
3 kere hatalı mail işleminde hesap banlanıyor ve kullanıcıya  mail gidiyor.

Identity ve Jwt kullanıldı

İdentity parola işlemi için custompassword kuralı eklendi.


