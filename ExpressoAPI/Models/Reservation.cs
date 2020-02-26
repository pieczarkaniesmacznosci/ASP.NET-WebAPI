using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpressoAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public int TotalPeople { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }
    }
}