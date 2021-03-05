using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi.";
        public static string CarCouldNotAdded ="Araç Eklenemedi.";
        public static string CarDeleted = "Araç silindi.";
        public static string CarCouldNotDeleted = "Araç silinemedi.";
        public static string CarUpdated = "Araç güncellendi.";
        public static string CarCouldNotDUpdated = "Araç güncellenemedi.";
        public static string CarDisplay = "Araç görüntülendi.";
        public static string CarCouldNotDisplay = "Araç görüntülenemedi.";
        public static string CarsCouldNotListed = "Araçlar Listelenemedi";
        public static string CarsDisplay = "Araçlar görüntülendi.";
        public static string CarsCouldNotDisplay = "Araçlar görüntülenemedi.";

        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorCouldNotAdded = "Renk Eklenemedi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorCouldNotDeleted = "Renk silinemedi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorCouldNotDUpdated = "Renk güncellenemedi.";
        public static string ColorDisplay = "Renk görüntülendi.";
        public static string ColorCouldNotDisplay = "Renk görüntülenemedi.";
        public static string ColorsCouldNotListed = "Renkler Listelenemedi";
        public static string ColorsDisplay = "Renkler görüntülendi.";
        public static string ColorsCouldNotDisplay = "Renkler görüntülenemedi.";

        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandCouldNotAdded = "Marka Eklenemedi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandCouldNotDeleted = "Marka silinemedi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandCouldNotDUpdated = "Marka güncellenemedi.";
        public static string BrandDisplay = "Marka görüntülendi.";
        public static string BrandCouldNotDisplay = "Marka görüntülenemedi.";
        public static string BrandsCouldNotListed = "Markalar Listelenemedi";
        public static string BrandsDisplay = "Markalar görüntülendi.";
        public static string BrandsCouldNotDisplay = "Markalar görüntülenemedi.";
        
        public static string CustomerAdded = "Müşteri Eklendi.";
        public static string CustomerCouldNotAdded = "Müşteri Eklenemedi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerCouldNotDeleted = "Müşteri silinemedi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerCouldNotDUpdated = "Müşteri güncellenemedi.";
        public static string CustomerDisplay = "Müşteri görüntülendi.";
        public static string CustomerCouldNotDisplay = "Müşteri görüntülenemedi.";
        public static string CustomersCouldNotListed = "Müşteriler Listelenemedi";
        public static string CustomersDisplay = "Müşteriler görüntülendi.";
        public static string CustomersCouldNotDisplay = "Müşteriler görüntülenemedi.";
   
        public static string RentalAdded = "Kiralık araç Eklendi.";
        public static string RentalCouldNotAdded = "Kiralık araç Eklenemedi.";
        public static string RentalDeleted = "Kiralık araç silindi.";
        public static string RentalCouldNotDeleted = "Kiralık araç silinemedi.";
        public static string RentalUpdated = "Kiralık araç güncellendi.";
        public static string RentalCouldNotDUpdated = "Kiralık araç güncellenemedi.";
        public static string RentalDisplay = "Kiralık araç görüntülendi.";
        public static string RentalCouldNotDisplay = "Kiralık araç görüntülenemedi.";
        public static string RentalsCouldNotListed = "Kiralık araçlar Listelenemedi";
        public static string RentalsDisplay = "Kiralık araçlar görüntülendi.";
        public static string RentalsCouldNotDisplay = "Kiralık araçlar görüntülenemedi.";
    
        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserCouldNotAdded = "Kullanıcı Eklenemedi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserCouldNotDeleted = "Kullanıcı silinemedi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserCouldNotDUpdated = "Kullanıcı güncellenemedi.";
        public static string UserDisplay = "Kullanıcı görüntülendi.";
        public static string UserCouldNotDisplay = "Kullanıcı görüntülenemedi.";
        public static string UserCouldNotListed = "Kullanıcılar Listelenemedi";
        public static string UsersDisplay = "Kullanıcılar görüntülendi.";
        public static string UsersCouldNotDisplay = "Kullanıcılar görüntülenemedi.";
        public static string CarNameExists = "Araç ismi zaten var";
       
        
        
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string UserRegistered = "Kullanıcı başarıyla oluşturuldu.";
        public static string AccesTokenCreated = "Token oluşturuldu.";
       
        
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni araç eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string CarCountOfCategoryError = "Bir kategoride en fazla 10 araç olabilir";
        public static string CarNameAlreadyExists = "Bu isimde zaten başka bir araç var";
      


    }
}
