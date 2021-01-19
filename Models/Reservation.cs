using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fordonsbesiktning_EF_.Models
{
    class Reservation
    {
     [Required]
        public int Id { get; private set; }

       public string RegistrationNumber { get; private set; }

        public DateTime Date { get; private set; }


        public Reservation(string registrationNumber, DateTime date)
        {
            RegistrationNumber = registrationNumber;
            Date = date;
        }

        public Reservation(int id, string registrationNumber, DateTime date)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            Date = date;
        }


    }
}
