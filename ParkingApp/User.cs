using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp {
    public class User {
        // Основные свойства
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } // "driver", "host", "admin"
        public decimal Balance { get; set; }
        // Свойства водителя
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string LicenseNumber { get; set; }

        // Свойства владельца паркинга
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string TaxNumber { get; set; }

        // Системные свойства
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }

        // Конструктор по умолчанию
        public User() {
            RegistrationDate = DateTime.Now;
            IsActive = true;
        }

        // Конструктор для быстрого создания пользователя
        public User(int id,string name,string email,string role) : this() {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }

        
       

        // Конструктор для владельца паркинга
        public User(int id,string name,string companyName,string companyAddress,string email) : this() {
            Id = id;
            Name = name;
            FullName = name;
            CompanyName = companyName;
            CompanyAddress = companyAddress;
            Email = email;
            Role = "host";
        }
    }
}
