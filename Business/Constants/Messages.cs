using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    //Magic strings
    public static class Messages
    {
        public static string CarAdded = "Car added.";
        public static string CarDeleted = "Car deleted.";
        public static string CarUpdated = "Car updated.";
        public static string CarCouldNotBeAdded = "Car could not be added.";
        public static string CarCouldNotBeUpdated = "Car could not be updated.";
        public static string CarDescriptionInvalid = "Product name is invalid.";
        public static string CustomerAdded = "Customer added.";
        public static string CustomerDeleted = "Customer deleted.";
        public static string CustomerUpdated = "Customer updated.";
        public static string UserAdded = "User added.";
        public static string UserDeleted = "User deleted.";
        public static string UserUpdated = "User updated.";
        public static string RentalAdded = "Car hired.";
        public static string RentalDeleted = "Rental deleted.";
        public static string RentalUpdated = "Rental updated.";
        public static string ColorAdded = "Color Added.";
        public static string ColorDeleted = "Color Deleted.";
        public static string ColorUpdated = "Color Updated.";
        public static string CarsListed = "Cars listed.";
        public static string CarCouldNotBeHired = "Car could not be hired. Because this car hired from another customer.";
        public static string MaintenanceTime = "Maintenance Time";
        public static string UnknownError = "Unknown error.";
        public static string AccessTokenCreated = "Token created.";
        public static string UserAlreadyExists = "Kullanıcı zaten var.";
        public static string PasswordError = "Şifre hatalı.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserRegistered = "Kullanıcı kayıt edildi.";
        public static string AuthorizationDenied = "Kullanıcının yetkisi yok.";
        public static string CarAlreadyExists = "Car already exists.";
    }
}
