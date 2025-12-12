using System.Net.NetworkInformation;


    using System;

    namespace ParkingApp {
        public class ParkingSpot {
            public int Id { get; set; }
            public string SpotNumber { get; set; }        // Номер места (A-01, B-02 и т.д.)
            public string Zone { get; set; }              // Зона (A, B, VIP и т.д.)
            public decimal HourlyRate { get; set; }       // Тариф за час
            public bool IsOccupied { get; set; }          // Занято ли место
            public bool IsActive { get; set; }            // Активно ли место
            public string CarNumber { get; set; }         // Номер автомобиля (если занято) ← ДОБАВЬТЕ ЭТО
            public string CarModel { get; set; }          // Модель автомобиля (опционально)
            public decimal DailyIncome { get; set; }      // Доход за день
            public decimal MonthlyIncome { get; set; }    // Доход за месяц
            public DateTime? OccupiedSince { get; set; }  // Когда занято (если занято)
        public string Address { get; set; }           // Адрес парковки
        public string Description { get; set; }       // Описание места
        public string ParkingName { get; set; }       // Название паркинга
        public int TotalSpots { get; set; }           // Всего мест в паркинге
        public int AvailableSpots { get; set; }
        public double Distance { get; set; }          // Расстояние в км ← ЭТО СВОЙСТВО
        public double Rating { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public ParkingSpot() {
                IsActive = true;
                DailyIncome = 0;
                MonthlyIncome = 0;
            }
        }
    }



   
   
