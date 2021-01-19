using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using System.Text;

namespace Fordonsbesiktning_EF_.Models
{
    class Inspection
    {

        [Required]
        public int Id { get;  private set; }
        public string RegistrationNumber { get; private set; }
        public DateTime PerformedAt { get; private set; }
        public bool Passed { get; protected set; }

        public Inspection(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
            PerformedAt = DateTime.Now;
        }

        public Inspection(int id, string registrationNumber, DateTime performedAt, bool passed)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            PerformedAt = DateTime.Now;
            this.Passed = passed;
        }

        public void Pass()
        {
            Passed = true;


        }
        public void Fail()
        {
            Passed = false;
        }




    }
}
