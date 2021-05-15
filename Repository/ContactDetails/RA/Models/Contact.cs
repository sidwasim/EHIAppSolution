using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ContactDetails.RA.Models
{
    public class Contact
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
    }
}
