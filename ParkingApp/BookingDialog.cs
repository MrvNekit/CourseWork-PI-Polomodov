using System;
using System.Drawing;
using System.Windows.Forms;

namespace ParkingApp {
    public class Booking {
        public int Id { get; set; }
        public string ParkingSpotName { get; set; }
        public string UserName { get; set; } // Для владельца
        public string UserCar { get; set; }  // Для владельца
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}